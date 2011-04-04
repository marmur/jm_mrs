using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;
using MTest.agents;

namespace MTest.core
{
    class AgentThreadPool : IDisposable
    {

        private interface IAgentWrapper
        {
            void DoWork();
            string Name
            {
                get;
            }
        }

        private class AgentWrapper : IAgentWrapper
        {
            IAgent _agent;

            public AgentWrapper(IAgent agent)
            {
                _agent = agent;
            }

            public string Name
            {
                get { return _agent.Name; }
            }

            public void DoWork()
            {
                try
                {
                    _agent.DoWork();
                }
                catch (Exception e)
                {
                    LOG.Warn("Exception occurs during agent[" + _agent.Name + "] work", e);
                }
            }
        }

        private class AgentContainerWrapper : IAgentWrapper
        {
            AgentContainer _container;

            public string Name
            {
                get { return _container.Agent.Name; }
            }

            public AgentContainerWrapper(AgentContainer container)
            {
                _container = container;
            }

            public void DoWork()
            {
                try
                {
                    _container.DoWork();
                }
                catch (Exception e)
                {
                    LOG.Warn("Exception occurs during agent[" + _container.Agent.Name + "] work", e);
                }
            }
        }


        #region Logging Definition
        private static readonly ILog LOG = LogManager.GetLogger(typeof(AgentThreadPool));
        #endregion

        private List<Thread> _threadList;

        public AgentThreadPool()
        {
            _threadList = new List<Thread>();
        }


        public void RunAgentThread(AgentContainer agentContener)
        {
            lock (_threadList)
            {
                IAgentWrapper wrapper = new AgentContainerWrapper(agentContener);
                Thread th = new Thread(new ThreadStart(wrapper.DoWork));
                th.Name = "AT:" + wrapper.Name;
                _threadList.Add(th);
                th.Start();
            }

        }


        public void RunAgentThread(IAgent agent)
        {
            lock (_threadList)
            {
                IAgentWrapper wrapper = new AgentWrapper(agent);
                Thread th = new Thread(new ThreadStart(wrapper.DoWork));
                th.Name = "AT:" + wrapper.Name;
                _threadList.Add(th);
                th.Start();
            }

        }

        public void Dispose()
        {
            lock (_threadList)
            {
                foreach (var th in _threadList)
                {
                    th.Abort();
                    th.Join();
                }
            }
        }
    }
}
