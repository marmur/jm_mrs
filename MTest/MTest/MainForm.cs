using System;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using RoBOSSCommunicator;
using System.Collections.Generic;


namespace MTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    /// 

    public partial class MainForm : Form
	{
        private Communicator communicator = null;

		
		
        private Thread driverThread;
        

        private BindingList<IRobotDriver> driversList;
        private IRobotDriver selectedDriver;
   
        public SimpleLog sLog;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

	
            addressTextBox.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            driversList = new BindingList<IRobotDriver>();
            BindingSource bindingDrivers = new BindingSource();
            bindingDrivers.DataSource = driversList;
            driversListBox.DataSource = bindingDrivers;

            sLog = new SimpleLog();
            
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void connectButton_Click(object sender, System.EventArgs e)
		{
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
			if (communicator.Connect(addressTextBox.Text,portTextBox.Text, "fira tester") <0)
			{
				connectionStatusLabel.Text = "Unable to contact Controller";
                sLog.log("Unable to contact Controller");
				Refresh();
				communicator = null;
				return;
			}

            driversButton.Enabled = true;
			connectButton.Text = "Disconnect";
			connectionStatusLabel.Text = "Connected to Controller";
            sLog.log("Connected to Controller");


           
            
		}

        unsafe private void  RefreshRobotInfo(Robot r)
        {
                robotNameLabel.Text = "robot name : ";
                robotPositionLabel.Text = "position : ";
                sensorLabel.Text = "sensor : ";
                sensorPositionLabel.Text = "sensors position : ";
                rotationLabel.Text = "rotation: ";
                angleLabel.Text = "angle: ";
                if (r != null)
                {
                    robotNameLabel.Text += r.name;
                    robotPositionLabel.Text += "[" + r.position[0] + " : " + r.position[1] + " : " + r.position[2] + "]";
                    Robot.SensorRangeFinder fs = r.GetSensorByName("front_distance") as Robot.SensorRangeFinder;
                    fs.UpdateValue();
                    sensorLabel.Text += fs.value;
                    sensorPositionLabel.Text += "[" + fs.position[0] + " : " + fs.position[1] + " : " + fs.position[2] + "]";
                    rotationLabel.Text += "[" + r.rotation[0] + 
                                Environment.NewLine + r.rotation[1] +
                                Environment.NewLine + r.rotation[2] + 
                                Environment.NewLine + r.rotation[3] + "]";
                    angleLabel.Text += "w-> " + 
                        (180*Math.Acos(r.rotation[0])*2.0)/Math.PI + Environment.NewLine+
                        " z-> "+ (180*Math.Asin(r.rotation[3])*2.0)/Math.PI; 
                }
        }

        unsafe private void RefreshDriverInfo(IRobotDriver driver)
        {
            robotNameLabel.Text = "robot name : ";
            robotPositionLabel.Text = "position : ";
            sensorLabel.Text = "sensor : ";
            sensorPositionLabel.Text = "sensors position : ";
            rotationLabel.Text = "rotation: ";
            angleLabel.Text = "angle: ";
            if (driver != null)
            {
                robotNameLabel.Text += driver.name;
                robotPositionLabel.Text += "[" + driver.position[0] + " : " + driver.position[1] + " : " + driver.position[2] + "]";
                /*
                Robot.SensorRangeFinder fs = r.GetSensorByName("front_distance") as Robot.SensorRangeFinder;
                fs.UpdateValue();
                sensorLabel.Text += fs.value;
                sensorPositionLabel.Text += "[" + fs.position[0] + " : " + fs.position[1] + " : " + fs.position[2] + "]";
                rotationLabel.Text += "[" + r.rotation[0] +
                            Environment.NewLine + r.rotation[1] +
                            Environment.NewLine + r.rotation[2] +
                            Environment.NewLine + r.rotation[3] + "]";
                angleLabel.Text += "w-> " +
                    (180 * Math.Acos(r.rotation[0]) * 2.0) / Math.PI + Environment.NewLine +
                    " z-> " + (180 * Math.Asin(r.rotation[3]) * 2.0) / Math.PI;
                 */
            }

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
            sLog.log("RefreshDriverThread running");
			try
			{
				while (true)
				{
					if (communicator.Receive(Communicator.RECEIVEBLOCKLEVEL_WaitForNewTimestamp) < 0)
					{
                        sLog.log("communicator.Receive fail");
						break;
					}
                    foreach(IRobotDriver driver in driversList){
                        driver.Refresh();
                    }
                    RefreshDriverInfo(selectedDriver);

					if (communicator.Send() < 0)
					{
                        sLog.log("communicator.Send fail");
						break;
					}
				}
                   
			}
			catch 
			{
                sLog.log("Exception catch in RefreshDriverThread");
			}
            sLog.log("RefreshDriverThread stopped");
            driverThread = null;
            driversButton.Text = "Start";
            connectButton_Click(this, null);
		}

        private void stopButton_Click(object sender, System.EventArgs e)
        {
            leftEngine.Value = 0;
            rightEngine.Value = 0;
            velocity.Value = 0;
        }

        private void controlsButton_Click(object sender, System.EventArgs e)
        {
            sLog.Show();
            sLog.BringToFront();
        }

        private void addDriverButton_Click(object sender, System.EventArgs e)
        {
            if(communicator == null )
            {
                sLog.log("Connect to communicator before adding drivers!!!");
                return;
            }

           String robotType = "FiraRobot";
           int id = communicator.RequestRobot(robotType);
           if (id < 0)
           {
               sLog.log("Unable to get robot " + robotType);
               Refresh();
               return;
           }
           Robot robot = communicator.robots[id];
            driversList.Add(new FiraDriver(robot));
            sLog.log("Fira driver added");
            driversListBox.DataSource = driversList;
            Refresh();
        }

        private void driversListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (driversListBox.SelectedIndex != -1)
            {
                selectedDriver = (IRobotDriver)driversListBox.SelectedItem;
                RefreshDriverInfo(selectedDriver);
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
	}
    
}
