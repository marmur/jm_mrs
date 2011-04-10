using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.core.maps;

namespace MTest.agents
{
    class AgentContainer
    {
        public AgentContainer(IAgent agent, IMapManagment map)
        {
            _agent = agent;
            _map = map;
        }

        private IAgent _agent;
        private IMapManagment _map;

        public IAgent Agent
        {
            get { return _agent; }
        }

        public void DoWork()
        {
            try
            {
                _map.StartWork();
                _agent.DoWork();
                _map.StartWork();
            }
            catch (Exception e)
            {
                _map.StopWork();
                throw e;
            }
        }

    }
}
