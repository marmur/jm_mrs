using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.core;

namespace MTest.agents
{
    class ClientFira:IClientAgent
    {
        private ITestEnviroment _testEnvironment;
        private IRobotDriver _driver;
        private IAgentLeader _leader;
        private IAgentEnviroment _agentEnviroment;
        private string _name;

        public void SetTestEnviroment(ITestEnviroment enviroment)
        {
            _testEnvironment = enviroment;
        }

        public string GetDriverType()
        {
            return "ClientDirver";
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
            throw new NotImplementedException();
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public void SetAgentEnviroment(IAgentEnviroment agentEnviroment)
        {
            _agentEnviroment = agentEnviroment;
        }
    }
}
