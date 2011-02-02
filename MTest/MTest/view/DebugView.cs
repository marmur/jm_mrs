using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTest.core;
using System.Net;

namespace MTest.view
{

    public partial class DebugView : Form, IControllerView
    {
        private ITestController testController;

        public DebugView(ITestController mainController)
        {
            InitializeComponent();

            testController = mainController;

            listBoxTestCases.DataSource = testController.TestCasesList;
  
            UpdateAll();

            addressTextBox.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            portTextBox.Text = "4468";
        }


        #region Event handlers

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (testController.CommunicatorManager.IsConnected && !testController.IsRunnign())
            {
                testController.Disconnect();
            }
            else
            {
                testController.Connect(addressTextBox.Text, portTextBox.Text);
            }
        }

        private void buttonLoadTest_Click(object sender, EventArgs e)
        {
            if (testController.IsInitialized())
            {
                testController.Reset();
            }
            else
            {
                List<TestCaseDescription> testCases = new List<TestCaseDescription>();
                testCases.Add(new TestCaseDescription()
                {
                    StartPosition = new Vector(0.0, -2.0),
                    EndPosition = new Vector(-2.0, -2.0),
                    StartTime = 10,
                    DeadlineTime = -1,
                    ClientType = "CFiraRobot"
                });
                testCases.Add(new TestCaseDescription()
                {
                    StartPosition = new Vector(1.0, -2.0),
                    EndPosition = new Vector(-2.0, -2.0),
                    StartTime = 120,
                    DeadlineTime = -1,
                    ClientType = "CFiraRobot"
                });
                testController.SetTestCases(testCases);
            }
        }



        #endregion

        #region IControllerView implementation

        public void UpdateAll()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new System.EventHandler(_UpdateAll));
            }
            else
            {
                _UpdateAll(this, System.EventArgs.Empty);
            }
        }

        public void UpdateTestCasesList()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new System.EventHandler(_UpdateTestCasesList));
            }
            else
            {
                _UpdateTestCasesList(this, System.EventArgs.Empty);
            }
        }




        public void showError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public void UpdateProgress(string message, int percent)
        {
            UpdateEventArgs eArg = new UpdateEventArgs(message, percent);
            object argList = new object[] { null, eArg };
            if (InvokeRequired)
            {
                this.BeginInvoke(new System.EventHandler<UpdateEventArgs>(_UpdateProgress), argList);
            }
            else
            {
                _UpdateProgress(this, eArg);
            }
        }

        #endregion


        #region private function
        private void _UpdateAll(object o, System.EventArgs e)
        {
            _UpdateConnectorPanel();
            _UpdateConnectorStatus();
            _UpdateControlPanel();
            _UpdateTestCasesList(o, e);
            _UpdateTestCaseDetails();
            Refresh();
        }

        private void _UpdateControlPanel()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(testController.CommunicatorManager.TestTime/1000);
            labelTestTime.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",ts.Minutes, ts.Seconds,ts.Milliseconds);
            labelTestTime.Refresh();

            if (testController.IsInitialized())
            {
                buttonLoadTest.Text = "Reset";
                buttonTestSartStop.Enabled = true;
                labelTestStatus.Text = "INIT";
            }
            else
            {
                buttonLoadTest.Text = "LoadTest";
                buttonTestSartStop.Enabled = false;
                labelTestStatus.Text = "NOT INIT";
            }

            if(!testController.CommunicatorManager.IsConnected){
                buttonTestSartStop.Enabled = false;
            }

            if (!testController.IsRunnign())
            {
                buttonTestSartStop.Text = "Start";
            }
            else if (testController.IsPaused())
            {
                buttonTestSartStop.Text = "Go";
                labelTestStatus.Text = "PAUSED";                
            }
            else
            {
                buttonTestSartStop.Text = "Pause";
                labelTestStatus.Text = "RUNNING";
            }
        }

        private void _UpdateTestCasesList(object o, System.EventArgs e)
        {

        }


        private void _UpdateProgress(object sender, UpdateEventArgs args)
        {
            int _percent = args.percent;
            if (_percent < 0)
            {
                _percent = 0;
            }
            if (_percent > 100)
            {
                _percent = 100;
            }
            toolStripProgressBar.Value = _percent;
            toolStripStatusLabelInfo.Text = args.message;
            statusStrip1.Refresh();
        }

        private void _UpdateConnectorPanel()
        {
            if (testController.IsRunnign())
            {
                connectButton.Enabled = false;
            }
            else
            {
                connectButton.Enabled = true;
            }
            if (testController.CommunicatorManager.IsConnected)
            {
                connectButton.Text = "Disconnect";
            }
            else
            {
                connectButton.Text = "Connect";
            }
        }

        private void _UpdateConnectorStatus()
        {
            if (testController.CommunicatorManager.IsConnected)
            {
                toolStripStatusLabelConnector.Text = "CONNECTED";
                toolStripStatusLabelConnector.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                toolStripStatusLabelConnector.Text = "DISCONNECTED";
                toolStripStatusLabelConnector.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void _UpdateTestCaseDetails()
        {
            if (testController.FocusedTestCase != null)
            {
                labelClientType.Text = testController.FocusedTestCase.Description.ClientType;
            }
            else
            {
                labelClientType.Text = "";
            }
        }


        #endregion

        private void buttonTestSartStop_Click(object sender, EventArgs e)
        {
            if (testController.IsRunnign())
            {
                if (testController.IsPaused())
                {
                    testController.ResumeTest();
                }
                else { 
                    testController.PauseTest(); 
                }
            }
            else
            {
                testController.RunTest();
            }
        }

        private void listBoxTestCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTestCases.SelectedIndex != -1)
            {
                TestCase tc =(TestCase) listBoxTestCases.SelectedItem;
                testController.SetFocusOnTestCase(tc);
            }
        }




    }


    public class UpdateEventArgs : EventArgs
    {
        public UpdateEventArgs(string message, int percent)
        {
            this.message = message;
            this.percent = percent;
        }
        public string message;
        public int percent;

    }
}
