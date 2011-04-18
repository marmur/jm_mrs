using MTest.view;
using System;
using Common.Logging;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using RoBOSSCommunicator;
using System.ComponentModel;
using Spring.Context;
using MTest.core.maps;
using MTest.agents;

namespace MTest.core
{
    public class TestController : ITestController, IAgentEnviroment
    {
        #region Logging Definition
        private static readonly ILog LOG = LogManager.GetLogger(typeof(TestController));
        #endregion

        #region Constans Definition

        public const string robossClientName = "MTest";

        #endregion

        #region Properties Definition

        public IControllerView ControllerView { get; set; }

        private CommunicatorManager _communicationManager;

        private RobotsRepository _robotRepo;

        private AgentThreadPool _clientThreadPool;

        private TestCase _focusedTestCase;

        private IAgent _focusedAgent;

        private BindingList<TestCase> _testCases;

        private Object _refreshFocusViewLock;

        private Thread _mainTestThread;

        private TestWorker _mainWorker;

        private List<IRobotDriver> _driverList;

        private IApplicationContext _ctx;

        private IResourceManager _resourceManager;

        private MapManager _mapManager;

        public ICommunicatorManageer CommunicatorManager
        {
            get
            {
                { return _communicationManager; }
            }
        }

        public BindingList<TestCase> TestCasesList
        {
            get { return _testCases; }
        }

        public TestCase FocusedTestCase
        {
            get { lock (_refreshFocusViewLock) { return _focusedTestCase; } }
        }

        public IAgent FocusedAgent
        {
            get { lock (_refreshFocusViewLock) { return _focusedAgent; } }
        }

        public RobotsRepository RobotsRepository
        {
            get { return _robotRepo; }
        }

        #endregion

        #region Constructors Definition

        public TestController(IApplicationContext ctx)
        {
            _ctx = ctx;
            _resourceManager = (IResourceManager)ctx.GetObject("ResourceManager");
            _resourceManager.SetTestController(this);
            _testCases = new BindingList<TestCase>();
            _communicationManager = new CommunicatorManager();
            _robotRepo = new RobotsRepository();
            _clientThreadPool = new AgentThreadPool();
            _focusedAgent = null;
            _focusedTestCase = null;
            _refreshFocusViewLock = new Object();
            _driverList = new List<IRobotDriver>();
            _mapManager = new MapManager();
        }

        #endregion

        #region Core Functions

        public void Reset()
        {
            try
            {
                LOG.Info("Resetting");
                UpdateProgress("Resetting...", 10);
                StopTestThread();
                UpdateProgress("Resetting...", 20);
                _resourceManager.Reset();
                _driverList.Clear();
                _testCases.Clear();
                UpdateProgress("Resetting...", 50);
                _communicationManager.Reset();
                UpdateProgress("Resetting...", 70);
                _robotRepo.Reset();
                _clientThreadPool.Dispose();
                _clientThreadPool = new AgentThreadPool();
                UpdateProgress("Resetting...", 90);
                lock (_refreshFocusViewLock)
                {
                    _focusedAgent = null;
                    _focusedTestCase = null;
                }
                UpdateProgress("", 0);
                _mapManager.Reset();
            }
            catch (CommunicatorException ce)
            {
                LogError("Error during reseting: " + ce.Message);
                UpdateProgress("", 0);
            }
            UpdateUI();
        }

        private void StopTestThread()
        {
            if (IsRunnign())
            {
                LOG.Info("Stoping TestThread");
                _mainWorker.Finish();
                _mainTestThread.Join();
                _mainTestThread = null;
            }
            else
            {
                LOG.Warn("TestThread is already stopped");
            }
        }

        private void RunTestThread()
        {
            if (!IsRunnign())
            {
                LOG.Info("Starting TestThread");
                _mainWorker = new TestWorker(this);
                _mainTestThread = new Thread(_mainWorker.DoTestWork);
                _mainTestThread.Name = "TestThread";
                _mainTestThread.Start();
                while (!_mainTestThread.IsAlive) ;
            }
            else
            {
                LOG.Warn("TestThread is already running");
            }
        }

        private void PauseTestThread()
        {
            if (IsRunnign())
            {
                if (!IsPaused())
                {
                    LOG.Info("Pausing testThread");
                    _mainWorker.Pause();
                    while (!_mainWorker.IsPaused()) ;
                }
                else
                {
                    LOG.Warn("Cannot pause TestThread, it is already paused");
                }
            }
            else
            {
                LOG.Warn("Cannot pause TestThread, it is not running");
            }
        }

        private void ResumeTestThread()
        {
            if (IsRunnign())
            {
                if (IsPaused())
                {
                    LOG.Info("Resuming testThread");
                    _mainWorker.Resume();
                    while (_mainWorker.IsPaused()) ;
                }
                else
                {
                    LOG.Warn("Cannot resume TestThread, it is already running");
                }
            }
            else
            {
                LOG.Warn("Cannot resume TestThread, it is not running");
            }
        }

        public void Connect(string ipAddr, string port)
        {
            try
            {
                UpdateProgress("connecting...", 10);
                _communicationManager.connect(ipAddr, port);
                UpdateProgress("Requesting robots", 50);
                _communicationManager.preStart();
                Robot[] robots = _communicationManager.getAllRobots();
                _robotRepo.FillRepo(robots);
                UpdateProgress("Requesting robots", 80);
                Geom[] geoms = _communicationManager.GetAllWorldGeoms();
                _mapManager.Initialize(geoms, robots);
                UpdateProgress("", 0);
            }
            catch (CommunicatorException ce)
            {
                LogError("Error during inicjalization: " + ce.Message);
                UpdateProgress("", 0);
            }
            UpdateUI();
        }

        public IMap MainMap { get { return _mapManager.GetMainMap(); } }


        public void SetTestCases(List<TestCaseDescription> testCasesDescription)
        {
            LOG.Info("Setting TestCases");
            foreach (TestCaseDescription testDescription in testCasesDescription)
            {
                TestCase testCase = new TestCase(testDescription);
                TestCasesList.Add(testCase);
                LOG.Info("Add test case: " + testCase.ToString());
            }
            UpdateUI();
        }

        public void RunTest()
        {
            LOG.Info("Run test");
            if (!IsInitialized())
            {
                LogError("Test is not initialized");
            }
            else if (!_communicationManager.IsConnected)
            {
                LogError("TestController is noot connected to RoboSSController");
            }
            else
            {
                try
                {
                    _communicationManager.Start();
                    RunTestThread();
                }
                catch (CommunicatorException ce)
                {
                    LogError("Error during starting test: " + ce.Message);
                    StopTestThread();
                }
            }
            UpdateUI();
        }

        public void Disconnect()
        {
            PauseTestThread();
            _communicationManager.disconnect();
            UpdateUI();
        }


        public void Dispose()
        {
            StopTestThread();
            _communicationManager.disconnect();
            _clientThreadPool.Dispose();
            _mapManager.Dispose();
        }

        public void PauseTest()
        {
            LOG.Info("Pause Test");
            PauseTestThread();
            try
            {
                _communicationManager.Pause();
            }
            catch (CommunicatorException ce)
            {
                LogError("Error during pausing test: " + ce.Message);
                StopTestThread();
            }
            UpdateUI();
        }

        public void ResumeTest()
        {
            LOG.Info("Resume Test");
            try
            {
                _communicationManager.Resume();
                ResumeTestThread();
            }
            catch (CommunicatorException ce)
            {
                LogError("Error during resuming test: " + ce.Message);
                StopTestThread();
            }
            UpdateUI();
        }

        long overloadController = 0;
        internal void ReciveSimulation()
        {
            lock (this)
            {
                _communicationManager.Recive();
                if(overloadController % 200 == 0){
                    UpdateUI();
                    overloadController = 0;
                }
                overloadController++;
            }
        }

        internal void CheckTestCases()
        {
            lock (this)
            {
                foreach (TestCase te in _testCases)
                {
                    if (te.shouldRun(_communicationManager.TestTime))
                    {
                        FireTestCase(te);
                    }
                }
            }
        }

        private void FireTestCase(TestCase te)
        {
            try
            {
                LOG.Info("Strating test case : " + te.ToString());
                te.Status = TestState.Processing;
                IClientAgent client = CreateClient(te.Description.ClientType, te.Description.StartPosition);
                te.WorkingGroup = new WorkingGroup();
                te.WorkingGroup.Client = client;
                _resourceManager.initTestCase(te);

                _driverList.Add(client.GetDriver());
                foreach (IRobotAgent scaut in te.WorkingGroup.Scouts)
                {
                    _driverList.Add(scaut.GetDriver());
                }

                _clientThreadPool.RunAgentThread(client);

                IMapManagment leaderMap = _mapManager.GetMainMap().CreateChildMap();

                foreach (IScoutAgent scout in te.WorkingGroup.Scouts)
                {
                    IMapManagment scoutMap = leaderMap.CreateChildMap();
                    AgentContainer container = new AgentContainer(scout, scoutMap);
                    scout.SetMap(scoutMap);
                    scout.GetDriver().SetMap(scoutMap);
                    _clientThreadPool.RunAgentThread(container);
                }

                te.WorkingGroup.Leader.SetMap(leaderMap);
                AgentContainer leaderContainer = new AgentContainer(te.WorkingGroup.Leader, leaderMap);
                _clientThreadPool.RunAgentThread(leaderContainer);
                LOG.Info("Strating test case : " + te.ToString() + " DONE");
            }
            catch (Exception ex)
            {
                te.Status = TestState.Fail;
                LOG.Error("Cannot run test " + te.ToString(), ex);
            }
        }

        static int leaderCount = 0;
        internal IAgentLeader CreateLeader(string liderType)
        {
            IAgentLeader leader = (IAgentLeader)_ctx.GetObject(liderType);
            leader.Name = liderType + ":" + leaderCount;
            leaderCount++;
            leader.SetAgentEnviroment(this);
            return leader;
        }

        internal IScoutAgent CreateScout(string scoutType, Vector position)
        {
            IScoutAgent scout = (IScoutAgent)_ctx.GetObject(scoutType);
            IRobotDriver drivare = GetRobotDriver(scout.GetDriverType(), position);
            scout.Name = scoutType + ":" + drivare.Name;
            scout.SetDriver(drivare);
            scout.SetAgentEnviroment(this);
            return scout;
        }

        private IClientAgent CreateClient(string clientType, Vector startPosition)
        {
            IClientAgent client = (IClientAgent)_ctx.GetObject(clientType);
            IRobotDriver drivare = GetRobotDriver(client.GetDriverType(), startPosition);
            if (drivare == null)
            {
                throw new TestCaseException("No driver for client " + client.Name);
            }
            client.Name = clientType + ":" + drivare.Name;
            client.SetDriver(drivare);
            client.SetAgentEnviroment(this);
            client.SetTestEnviroment(_resourceManager);
            return client;
        }

        private IRobotDriver GetRobotDriver(string driverType, Vector startPosition)
        {
            IRobotDriver drivare = (IRobotDriver)_ctx.GetObject(driverType);
            Robot robot = _robotRepo.GetFreeRobotByType(drivare.GetRobotType());
            if (robot != null)
            {
                Vector initialPosition = _robotRepo.GetRobotInitialPosition(robot);
                robot.SetPosition(startPosition.X, startPosition.Y, initialPosition.Z + 0.005);
                drivare.SetRobot(robot);
                return drivare;
            }
            else
            {
                return null;
            }
        }



        internal void ProcessDrivers()
        {
            lock (this)
            {
                foreach (IRobotDriver driver in _driverList)
                {
                    driver.Process();
                }
            }
        }

        public bool IsFinished()
        {
            return false;
        }

        public bool IsInitialized()
        {
            return _testCases != null && _testCases.Count > 0;
        }

        public bool IsRunnign()
        {
            return _mainTestThread != null;
        }

        public bool IsPaused()
        {
            return _mainTestThread != null && _mainWorker.IsPaused();
        }

        #endregion


        #region Gui functions

        private void UpdateUI()
        {

            if (ControllerView != null)
            {
                ControllerView.UpdateAll();
            }
        }

        private void UpdateTestCaseList()
        {
            if (ControllerView != null)
            {
                ControllerView.UpdateTestCasesList();
            }
        }

        private void UpdateProgress(string message, int percent)
        {
            if (ControllerView != null)
            {
                ControllerView.UpdateProgress(message, percent);
            }
        }

        private void LogError(string message)
        {
            LOG.Error(message);
            if (ControllerView != null)
            {
                ControllerView.showError(message);
            }
        }

        public void SetFocusOnAgent(IAgent agent)
        {
            lock (_refreshFocusViewLock)
            {
                LOG.Debug("Set focus on agent :" + agent);
                _focusedAgent = agent;
            }
        }

        public void SetFocusOnTestCase(TestCase testCase)
        {
            lock (_refreshFocusViewLock)
            {
                _focusedTestCase = testCase;
                UpdateUI();
            }
        }

        public void AgentLOG(IAgent from, string message)
        {
            lock (_refreshFocusViewLock)
            {
                if (_focusedAgent != null && _focusedAgent == from)
                {
                    LOG.Info("From Agnet{" + from.Name + "}:" + message);
                }
            }
        }

        public void UpdateAgentView(IAgent from)
        {
            lock (_refreshFocusViewLock)
            {
                if (ControllerView != null && _focusedAgent != null && _focusedAgent == from)
                {
                    ControllerView.UpdateAll();
                }
            }
        }

        #endregion




    }

    class TestCaseException : System.Exception
    {
        public TestCaseException(string message) : base(message) { }
    }
}
