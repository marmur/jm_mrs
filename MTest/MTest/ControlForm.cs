using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RoBOSSCommunicator;

namespace MTest
{
    public partial class ControlForm : Form
    {
        private MainForm mainForm;
        private SimpleLog sLog;

        private ControlForm()
        {
            InitializeComponent();
        }

        public ControlForm(MainForm mf)
            : this()
        {
            mainForm = mf;
            sLog = mainForm.sLog;
        }

        private void ControlForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        public override void Refresh()
        {
            base.Refresh();
            if (mainForm.SelectedDriver == null)
            {
                rightEngineLabel.Text = leftEngineLabel.Text = label1.Text = "None";
                directionLabel.Text = "None";
            }
            else
            {
                label1.Text = mainForm.SelectedDriver.Name;
                Robot.Joint leftMotor = mainForm.SelectedDriver.Joints[0];
                Robot.Joint rightMotor = mainForm.SelectedDriver.Joints[1];
                leftEngineLabel.Text = leftMotor.motorDesiredVelocity.ToString();
                rightEngineLabel.Text = rightMotor.motorDesiredVelocity.ToString();
                directionLabel.Text = mainForm.SelectedDriver.Direction.ToString();
            }

        }

        private void EngineTrackBar_Scroll(object sender, System.EventArgs e)
        {
            if (sender.Equals(leftEngine))
            {
                leftAmountLabel.Text = leftEngine.Value.ToString() + "%";
            }
            else if (sender.Equals(rightEngine))
            {
                rightAmountLabel.Text = rightEngine.Value.ToString() + "%";
            }
            else //engine 
            {
                powerLabel.Text = enginePower.Value.ToString();
            }

            if (mainForm.SelectedDriver != null)
            {
                double leftV = enginePower.Value * (leftEngine.Value / 100.0);
                double rightV = enginePower.Value * (rightEngine.Value / 100.0);
                mainForm.SelectedDriver.CommandTest(leftV, rightV);
                sLog.log("Direct Command : " + leftV.ToString() + " " + rightV.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void controlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(mainForm.SelectedDriver != null)
                mainForm.SelectedDriver.CommandEmergencyStop();

            if (controlCheckBox.Checked)
            {
                comandBox.Enabled = false;
                controlBox.Enabled = true;
            }
            else
            {
                comandBox.Enabled = true;
                controlBox.Enabled = false;
            }
        }

        private void lookAtButton_Click(object sender, EventArgs e)
        {
            if (mainForm.SelectedDriver != null)
            {
                double x = Double.Parse(xTextBox.Text);
                double y = Double.Parse(yTextBox.Text);
                mainForm.SelectedDriver.CommandLookAt(x, y);
                sLog.log("lookAt" + new Vector(x,y).ToString() + " submited");
            }
        }

        private void goToButton_Click(object sender, EventArgs e)
        {
            if (mainForm.SelectedDriver != null)
            {
                double x = Double.Parse(xTextBox.Text);
                double y = Double.Parse(yTextBox.Text);
                mainForm.SelectedDriver.CommandGoTo(x, y);
                sLog.log("GoTo" + new Vector(x, y).ToString() + " submited");
            }

        }

    }
}
