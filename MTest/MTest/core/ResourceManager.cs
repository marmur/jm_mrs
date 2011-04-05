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
        }

        public void initTestCase(TestCase te)
        {
            LOG.Info("Initing Working group for C{"+te.WorkingGroup.Client.Name+"}");
        }

    }
}
