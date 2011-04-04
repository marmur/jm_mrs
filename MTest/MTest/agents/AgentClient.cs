using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.core;
using System.Threading;

namespace MTest.agents
{
    class ClientAgent: IClientAgent
    {
        private ITestEnvironment _testEnvironment;
        private bool _completed;
        private IRobotDriver _driver;
        private IAgentLeader _leader;
        private IAgentEnvironment _agentEnvironment;
        private string _name;

        public void FinishSuccessful()
        {
            _completed = true;
        }

        public void SetTestEnvironment(ITestEnvironment environment)
        {
            _testEnvironment = environment;
        }

        public bool IsCompleted()
        {
            return _completed ;
        }

        public string GetDriverType()
        {
            return "CFiraRobot";
        }

        public void SetDriver(IRobotDriver driver)
        {
            _driver = driver;
        }

        public void SetLeader(IAgentLeader leader)
        {
            _leader = leader;
        }

        public void DoWork()
        {
           while(!_completed){
               Thread.Sleep(200);
           }
        }

        public string Name
        {
            get { return _name;}
            set { _name = value;}
        }

        public void SetAgentEnvironment(IAgentEnvironment agentEnviroment)
        {
            _agentEnvironment = agentEnviroment;
        }
    }
}
