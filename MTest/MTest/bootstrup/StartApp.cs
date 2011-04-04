using System.Linq;
using Common.Logging;
using System.Threading;
using MTest.core;
using MTest.view;
using System.Windows.Forms;
using Spring.Context;
using Spring.Context.Support;
using System;

namespace MTest.bootstrup
{
    class StartApp
    {

        #region Logging Definition

        private static readonly ILog LOG = LogManager.GetLogger(typeof(StartApp));

        #endregion

       
        unsafe static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "MainThread";
            LOG.Info("Strating...");
            IApplicationContext ctx = ContextRegistry.GetContext();

            using (ITestController mainTestController = new TestController(ctx))
            {
                if (args.Contains("-nogui"))
                {
                    LOG.Info("Console mode on");
                }
                else
                {
                    using (Form form = new DebugView(mainTestController))
                    {
                        mainTestController.ControllerView = form as IControllerView;
                        form.ShowDialog();
                    }
                }
            }
            LOG.Info("... end");
        }
    }
}
