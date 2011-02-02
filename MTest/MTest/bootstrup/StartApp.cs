using System.Linq;
using Common.Logging;
using System.Threading;
using MTest.core;
using MTest.view;
using System.Windows.Forms;

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

            using (ITestController mainTestController = new TestController())
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
