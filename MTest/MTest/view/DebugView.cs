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
using MTest.core.maps;

namespace MTest.view
{

    public partial class DebugView : Form, IControllerView
    {
        private ITestController testController;
        private Boolean _overloadControl;
        private ListBox[] _listBoxAgnets;
        private bool _showMainMap = false;

        private Boolean CanUpdateView
        {
            get { lock (this) { return _overloadControl; } }
            set { lock (this) { _overloadControl = value; } }
        }

        public DebugView(ITestController mainController)
        {
            InitializeComponent();
            _listBoxAgnets = new ListBox[] { listBoxClient, listBoxLeader, listBoxScouts };

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
                initAgentsListBoxes(null);
            }
            else
            {
                List<TestCaseDescription> testCases = new List<TestCaseDescription>();
                testCases.Add(new TestCaseDescription()
                {
                    StartPosition = new Vector(-9.48, 0.13),
                    EndPosition = new Vector(3.84, -8, 15),
                    StartTime = 0,
                    DeadlineTime = -1,
                    ClientType = "AgentClient"
                });
                
                testCases.Add(new TestCaseDescription()
                {
                    StartPosition = new Vector(9.78, 8.49),
                    EndPosition = new Vector(-5.93, -0.92),
                    StartTime = 30,
                    DeadlineTime = -1,
                    ClientType = "AgentClient"
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
                if (CanUpdateView == true)
                {
                    CanUpdateView = false;
                    this.BeginInvoke(new System.EventHandler(_UpdateAll));
                }
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
            _UpdateDriverDetails();
            Refresh();
            CanUpdateView = true;
        }



        private void _UpdateControlPanel()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(testController.CommunicatorManager.TestTime / 1000);
            labelTestTime.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Minutes, ts.Seconds, ts.Milliseconds);
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

            if (!testController.CommunicatorManager.IsConnected)
            {
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
                labelTestCaseStatus.Text = testController.FocusedTestCase.Status.ToString();
                labelTestCaseStartTime.Text = testController.FocusedTestCase.Description.GetFormatedStartTime();
                labelTestCaseDeadline.Text = testController.FocusedTestCase.Description.GetFormatedDeadLineTime();
                labelStartPosition.Text = testController.FocusedTestCase.Description.StartPosition.ToString();
                labelFinishPosition.Text = testController.FocusedTestCase.Description.EndPosition.ToString();

            }
            else
            {
                labelClientType.Text = "";
                labelTestCaseStatus.Text = "";
                labelTestCaseStartTime.Text = "";
                labelTestCaseDeadline.Text = "";
                labelStartPosition.Text = "";
                labelFinishPosition.Text = "";
            }
        }

        private void _UpdateDriverDetails()
        {
            if (testController.FocusedAgent != null && (testController.FocusedAgent is IRobotAgent))
            {
                groupBoxDriverDetails.Enabled = true;
                IRobotDriver driver = ((IRobotAgent)testController.FocusedAgent).GetDriver();
                labelDriverType.Text = driver.Type;
                labelRobotType.Text = driver.GetRobotType();
                labelDriverName.Text = driver.Name;
                labelDriverStatus.Text = driver.Status.ToString();
                labelDriverPosition.Text = new Vector(driver.Position).ToString();
                labelDirection.Text = driver.Direction.ToString();
                labelSensors.Text = String.Format("{0:0.0000}", driver.SensorsValue[0]);
            }
            else
            {
                groupBoxDriverDetails.Enabled = false;
                labelDriverType.Text = "";
                labelRobotType.Text = "";
                labelDriverName.Text = "";
                labelDriverStatus.Text = "";
                labelDriverPosition.Text = "";
                labelDirection.Text = "";
                labelSensors.Text = "";
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
                else
                {
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
                TestCase tc = (TestCase)listBoxTestCases.SelectedItem;
                testController.SetFocusOnTestCase(tc);
                initAgentsListBoxes(tc.WorkingGroup);
            }
        }

        private void listBoxAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
            {
                foreach (ListBox lb in _listBoxAgnets)
                {
                    if (lb == sender)
                    {
                        IAgent agent = (IAgent)lb.SelectedItem;
                        testController.SetFocusOnAgent(agent);
                    }
                    else
                    {
                        lb.ClearSelected();
                    }
                }
            }
        }

        private void initAgentsListBoxes(WorkingGroup wg)
        {
            testController.SetFocusOnAgent(null);
            listBoxClient.DataSource = null;
            listBoxLeader.DataSource = null;
            listBoxScouts.DataSource = null;
            if (wg != null)
            {
                listBoxClient.DataSource = new IClientAgent[] { wg.Client };
                listBoxLeader.DataSource = new IAgentLeader[] { wg.Leader };
                listBoxScouts.DataSource = wg.Scouts;
            }
        }


        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
           if(_showMainMap){
               DrawMap(testController.MainMap, e);
           }else{
               if (testController.FocusedAgent != null && (testController.FocusedAgent is MapAware))
               {
                   IMap map = ((MapAware)testController.FocusedAgent).GetMap();
                   DrawMap(map, e);
               }
               else
               {
                   DrawMap(null, e);
               }
           }
        }

        private void DrawMap(IMap iMap, PaintEventArgs e)
        {
            const int cell_px_size = 1;
            if (iMap == null || iMap.getCurentMapView() == null)
            {
                pictureBoxMap.Size = panelMap.ClientSize;
                Brush brush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(brush, 0, 0, pictureBoxMap.Width, pictureBoxMap.Height);
                brush.Dispose();
            }
            else
            {
                MapHolder mapHolder = iMap.getCurentMapView();
                pictureBoxMap.Width = mapHolder.SizeX * cell_px_size;
                pictureBoxMap.Height = mapHolder.SizeY * cell_px_size;
                SolidBrush brush = new SolidBrush(DrawMapHelper.getUnknownColor());
                e.Graphics.FillRectangle(brush, 0, 0, pictureBoxMap.Width, pictureBoxMap.Height);
                for (int x = 0; x < mapHolder.SizeX; x++ )
                {
                    for (int y = 0; y < mapHolder.SizeY; y++ )
                    {
                        brush.Color = DrawMapHelper.getColor(mapHolder.Map[x,y]);
                        e.Graphics.FillRectangle(brush,x* cell_px_size, y *cell_px_size, cell_px_size,cell_px_size);
                    }
                }
                brush.Dispose();
            }
        }

        private void buttonShowMainMap_Click(object sender, EventArgs e)
        {
            if (_showMainMap)
            {
                _showMainMap = false;
                buttonShowMainMap.BackColor = connectButton.BackColor;
            }
            else
            {
                buttonShowMainMap.BackColor = Color.GreenYellow;
                _showMainMap = true;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            for (int x = 0; x < pictureBox1.Width;x++ )
            {
                for (int y = 0; y < pictureBox1.Height;y++ )
                {
                    int c =(int) Math.Ceiling(((double)x /(double)pictureBox1.Width) * (double)int.MaxValue);
                    if (c > 10000)
                    {
                    }
                    brush.Color = DrawMapHelper.getColor(c);
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }
            brush.Dispose();
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
