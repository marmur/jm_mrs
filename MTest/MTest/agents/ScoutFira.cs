using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.core;
using System.Threading;
using MTest.core.maps;

namespace MTest.agents
{
    class ScoutFira:IScoutAgent
    {
        private ITestEnviroment _testEnvironment;
        private IRobotDriver _driver;
        private IAgentLeader _leader;
        private IAgentEnviroment _agentEnviroment;
        private string _name;
        private IMap _map;


        public void SetMap(IMap map)
        {
            _map = map;
        }

        public IMap GetMap()
        {
            return _map;
        }


        public string GetDriverType()
        {
            return "ScoutDirver";
        }

        public void SetDriver(IRobotDriver driver)
        {
            _driver = driver;
        }

        public IRobotDriver GetDriver()
        {
           return _driver;
        }

        public void SetLeader(IAgentLeader leader)
        {
            _leader = leader;
        }

        public void DoWork()
        {
            while(true){
                _agentEnviroment.AgentLOG(this, "Sleep");
                Thread.Sleep(2000);
            }
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
