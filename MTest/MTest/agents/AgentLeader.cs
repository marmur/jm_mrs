﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.agents
{
    class AgentLeader : IAgentLeader
    {
        private IClientAgent _client;
        private List<IScoutAgent> _scouts;
        private string _name;
        private IAgentEnviroment _agentEnviroment;

        public AgentLeader()
        {
            _scouts = new List<IScoutAgent>();
        }

        public void SetClient(IClientAgent client)
        {
            _client = client;
        }

        public void AssignScout(IScoutAgent scout)
        {
            _scouts.Add(scout);
        }

        public void SignalWorkDone(IScoutAgent scout)
        {
            
        }

        public void DoWork()
        {
 
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