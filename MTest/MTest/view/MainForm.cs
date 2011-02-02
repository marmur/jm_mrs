using System;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using RoBOSSCommunicator;
using System.Collections.Generic;


namespace MTest
{



    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class MainForm : Form
    {
        private String robotType = "FiraRobot";
        private Communicator communicator = null;
        private Thread driverThread;
        private BindingList<IRobotDriver> driversList;
        private IRobotDriver selectedDriver;
        private ControlForm controls;


        //for testing agent
        private SimpleAgent agent;
        private Thread agentThread;

        public SimpleLog sLog;


        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //to avoid flickering FIXME :<
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            addressTextBox.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            driversList = new BindingList<IRobotDriver>();
            BindingSource bindingDrivers = new BindingSource();
           // bindingDrivers.DataSource = driversList;
          //  driversListBox.DataSource = bindingDrivers;
            driversListBox.DisplayMember = "Name";

            sLog = new SimpleLog();
            controls = new ControlForm(this);

        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("START");
            //Application.Run(new MainForm());
            Console.WriteLine("END");
            
            using (MainForm form = new MainForm())
            {
                form.ShowDialog();
            }
            Console.WriteLine("stop");
             
        }

        private void connectButton_Click(object sender, System.EventArgs e)
        {
            /*
            if (communicator != null)
            {
                StopDriverThread();
                communicator.Dispose();
                communicator = null;
                driversButton.Enabled = false;
                connectButton.Text = "Connect";
                connectionStatusLabel.Text = "Disconnected";
                sLog.log("Disconnected");
                return;
            }

            communicator = new Communicator();
            connectionStatusLabel.Text = "Connecting to Controller...";
            sLog.log("Connecting to Controller...");
            Refresh();
            if (communicator.Connect(addressTextBox.Text, portTextBox.Text, "fira tester") < 0)
            {
                connectionStatusLabel.Text = "Unable to contact Controller";
                sLog.log("Unable to contact Controller");
                Refresh();
                communicator = null;
                return;
            }
            //TODO: add recovery after crash 
            if (driversList.Count > 0)
            {
                driversList.Clear();
            }

            driversButton.Enabled = true;
            connectButton.Text = "Disconnect";
            connectionStatusLabel.Text = "Connected to Controller";
            sLog.log("Connected to Controller");



            */
        }

        private void RefreshDriverInfo(IRobotDriver driver)
        {
            /*
            robotNameLabel.Text = "robot name : ";
            robotPositionLabel.Text = "position : ";
            sensorLabel.Text = "sensor : ";
            statusLabel.Text = "status : ";
            if (driver != null && communicator != null)
            {
                robotNameLabel.Text += driver.Name;
                robotPositionLabel.Text += String.Format("[{0:0.000}:{1:0.000}:{2:0.000}]", driver.Position[0], driver.Position[1], driver.Position[2]);
                statusLabel.Text += driver.Status;
                sensorLabel.Text += String.Format("{0:0.000}", driver.SensorsValue[0]);
            }
            */
        }

        private void UIRefresh(){
            RefreshDriverInfo(selectedDriver);
            controls.Refresh();
        }

        private void StartDriverThread()
        {
            StopDriverThread();
            sLog.log("Starting RefreshDriverThread");
            driverThread = new Thread(new ThreadStart(RefreshDriverThread));
            driverThread.Priority = ThreadPriority.Normal;
            driverThread.Start();
            driversButton.Text = "Stop";
        }

        private void StopDriverThread()
        {
            if (driverThread != null)
            {
                sLog.log("RefreshDriverThread aborted");
                driverThread.Abort();
                driverThread.Join();
                driverThread = null;
            }
            driversButton.Text = "Start";
        }

        private void RefreshDriverThread()
        {
            /*
            sLog.log("RefreshDriverThread running");
            try
            {
                while (true)
                {
                    if (communicator.Receive(Communicator.RECEIVEBLOCKLEVEL_WaitForTimestamp) < 0)
                    {
                        sLog.log("communicator.Receive fail");
                        break;
                    }
                    lock (driversList)
                    {
                        foreach (IRobotDriver driver in driversList)
                        {
                            driver.Process();
                        }
                    }
                    UIRefresh();

                    if (communicator.Send() < 0)
                    {
                        sLog.log("communicator.Send fail");
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                if (e is ThreadAbortException)
                    sLog.log("RefreshDriverThread stopped");
                else
                {
                    sLog.log("Exception catched in RefreshDriverThread " + e);
                    driverThread = null;
                    driversButton.Text = "Start";
                    connectButton_Click(this, null);
                }
            }

            */
        }



        private void logButton_Click(object sender, System.EventArgs e)
        {
            sLog.Show();
            sLog.BringToFront();
        }

        private void controlButton_Click(object sender, System.EventArgs e)
        {
            controls.Show();
            controls.BringToFront();
                
        }

        private void addDriverButton_Click(object sender, System.EventArgs e)
        {
            /*
            if (communicator == null)
            {
                sLog.log("Connect to communicator before adding drivers!!!");
                return;
            }

           
            int id = communicator.RequestRobot(robotType);
            if (id < 0)
            {
                sLog.log("Unable to get robot " + robotType);
                Refresh();
                return;
            }
            Robot robot = communicator.robots[id];
            lock (driversList)
            {
                driversList.Add(new FiraDriver(robot));
            }
            sLog.log("Fira driver added");
            //driversListBox.DataSource = driversList;
            Refresh();
             * */
        }

        private void driversListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (driversListBox.SelectedIndex != -1)
            {
                selectedDriver = (IRobotDriver)driversListBox.SelectedItem;
                UIRefresh();
                sLog.log("selection changed");
            }
        }

        private void driversButton_Click(object sender, System.EventArgs e)
        {
            if (driverThread != null)
            {
                StopDriverThread();
            }
            else
            {
                StartDriverThread();
            }
        }


        #region Property
        public IRobotDriver SelectedDriver
        {
            get { return selectedDriver; }
        }
        #endregion

        //For testing agent
        private void buttonTestAgent_Click(object sender, EventArgs e)
        {
            if(agentThread != null){
                sLog.log("Reseting agent thread");
                agentThread.Abort();
                agentThread.Join();
                agentThread = null;
            }
            sLog.log("Preparing agent");
            agent = new SimpleAgent();
            if(driversList.Count != 1){
                addDriverButton_Click(this, null);
            }
            agent.setMainForm(this);
            agent.setDriver(driversList[0]);
            agent.setGoalPosition(-2.0, -2.0);
            sLog.log("Starting agent thread");
            StartDriverThread();
            agentThread = new Thread(new ThreadStart(RefreshAgentThread));
            agentThread.Priority = ThreadPriority.Normal;
            agentThread.Start();
        }

        private void RefreshAgentThread()
        {
            sLog.log("RefreshAgentThread running");
            try
            {
                while (!agent.isWorkCompleat())
                {
                    agent.doWork();
                }
                sLog.log("Agent has finished his job");
            }
            catch (Exception e)
            {
                if (e is ThreadAbortException)
                    sLog.log("RefreshAgentThread stopped");
                else
                {
                    sLog.log("Exception catched in RefreshAgentThread " + e);
                    agentThread = null;
                    connectButton_Click(this, null);
                }
            }
            agentThread = null;
        }

    }
}
