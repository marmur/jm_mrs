using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;

namespace MTest.core
{
    public class TestWorker
    {
        #region Logging Definition
        private static readonly ILog LOG = LogManager.GetLogger(typeof(TestWorker));
        #endregion

        private bool _pauze;
        private bool _finish;

        public void Finish()
        {
            lock (this)
            {
                _finish = true;
                _pauze = false;
            }
        }

        public void Resume()
        {
            lock (this)
            {
                _pauze = false;
            }
        }

        public void Pause()
        {
            lock (this)
            {
                _pauze = true;
            }
        }

        public bool IsPaused()
        {
            lock (this)
            {
                return _pauze;
            }
        }

        private bool IsFinish()
        {
            lock (this)
            {
                return _finish;
            }
        }

        private TestController _testController;

        public TestWorker(TestController testController)
        {
            _testController = testController;
            _finish = false;
        }

        public void DoTestWork(){
            LOG.Info("Start working");
            try
            {
                while (!IsFinish())
                {
                    while (IsPaused())
                    {
                        Thread.Sleep(200);
                    }
                    _testController.ReciveSimulation();
                    _testController.CheckTestCases();
                    _testController.ProcessDrivers();
                }
            }catch (Exception e){
                LOG.Error("ERROR:",e);
            }
            LOG.Info("Finishing working");
            _finish = true;
            _pauze = false;
        }

    }
}
