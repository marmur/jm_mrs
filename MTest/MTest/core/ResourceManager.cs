using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;

namespace MTest.core
{
    public  class ResourceManager: IResourceManager
    {
        #region Logging Definition
        private static readonly ILog LOG = LogManager.GetLogger(typeof(ResourceManager));
        #endregion

        private TestController _testController;
        private Dictionary<string, TestCase> _testCasesMap;

        public ResourceManager()
        {
            _testCasesMap = new Dictionary<string, TestCase>();
        }

        public void SeignalTestEnd(IClientAgent from)
        {
            LOG.Info("Client {"+from.Name +"} - TEST END" );
        }

        public void SetTestController(TestController testControlle)
        {
            this._testController = testControlle;
        }

        public void Reset()
        {
            LOG.Info("Reseting");
            _testCasesMap.Clear();
        }

        public void initTestCase(TestCase te)
        {
            LOG.Info("Initing Working group for C{"+te.WorkingGroup.Client.Name+"}");
            _testCasesMap.Add(te.WorkingGroup.Client.Name, te);
            IAgentLeader leader = _testController.CreateLeader("AgentLeader");
            te.WorkingGroup.Leader = leader;
            te.WorkingGroup.Client.SetLeader(leader);
            leader.SetClient(te.WorkingGroup.Client);

            Vector clientPositon = te.Description.StartPosition;
            int allTest = _testController.TestCasesList.Count;
            int allRobots = _testController.RobotsRepository.GetRobotsCount("FiraRobot");
            int scoutsCount = allRobots / allTest;
            for (int i = 0; i < scoutsCount; i++ )
            {
                Vector position = calculatePosition(clientPositon,i,scoutsCount, 0.7);
                IScoutAgent scount = _testController.CreateScout("AgnetScout", position);
                scount.SetLeader(leader);
                leader.AssignScout(scount);
                te.WorkingGroup.Scouts.Add(scount);
            }

        }

        private Vector calculatePosition(Vector clientPositon, int i, int scoutsCount, double r)
        {
            Vector result = new Vector(clientPositon);
            double dr = (2.0 * Math.PI) / (double) scoutsCount;
            dr *= i;
            double dy = Math.Sin(dr) * r;
            double dx = Math.Cos(dr) *r;
            result.X += dx;
            result.Y -= dy;
            return result;
        }


    }
}
