using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;

namespace MTest.core
{
    class AgentThreadPool : IDisposable
    {
        private class AgentWrapper{
            IAgent2 _agent;

            public AgentWrapper(IAgent2 agent)
            {
                _agent = agent;
            }

            public void DoWork()
            {
                try
                {
                    _agent.DoWork();
                }
                catch (Exception e)
                {
                    LOG.Warn("Exception occurs during agent["+_agent.Name+"] work",e);
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

        public void RunAgentThread(IAgent2 agent)
        {
            lock (_threadList)
            {
                AgentWrapper wrapper = new AgentWrapper(agent);
                Thread th = new Thread(new ThreadStart(wrapper.DoWork));
                th.Name = "AT:" + agent.Name;
                _threadList.Add(th);
                th.Start();
            }

        }

        public void Dispose()
        {
            lock(_threadList){
                foreach (var th in _threadList)
                {
                    th.Abort();
                    th.Join();
                }
            }
        }
    }
}
