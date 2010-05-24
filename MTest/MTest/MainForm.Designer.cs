using System.Windows.Forms;
namespace MTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (communicator != null)
            {
                connectButton_Click(this, null);
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.controllerConnectionGroupBox = new System.Windows.Forms.GroupBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.angleLabel = new System.Windows.Forms.Label();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.sensorPositionLabel = new System.Windows.Forms.Label();
            this.sensorLabel = new System.Windows.Forms.Label();
            this.robotPositionLabel = new System.Windows.Forms.Label();
            this.robotNameLabel = new System.Windows.Forms.Label();
            this.leftEngine = new System.Windows.Forms.TrackBar();
            this.velocity = new System.Windows.Forms.TrackBar();
            this.rightEngine = new System.Windows.Forms.TrackBar();
            this.leftEngineLabel = new System.Windows.Forms.Label();
            this.rightEngineLabel = new System.Windows.Forms.Label();
            this.engineLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.controlsButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.driversListBox = new System.Windows.Forms.ListBox();
            this.addDriverButton = new System.Windows.Forms.Button();
            this.driversButton = new System.Windows.Forms.Button();
            this.controllerConnectionGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftEngine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightEngine)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // controllerConnectionGroupBox
            // 
            this.controllerConnectionGroupBox.Controls.Add(this.addressTextBox);
            this.controllerConnectionGroupBox.Controls.Add(this.portTextBox);
            this.controllerConnectionGroupBox.Controls.Add(this.connectButton);
            this.controllerConnectionGroupBox.Controls.Add(this.connectionStatusLabel);
            this.controllerConnectionGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.controllerConnectionGroupBox.Location = new System.Drawing.Point(0, 0);
            this.controllerConnectionGroupBox.Name = "controllerConnectionGroupBox";
            this.controllerConnectionGroupBox.Size = new System.Drawing.Size(244, 69);
            this.controllerConnectionGroupBox.TabIndex = 13;
            this.controllerConnectionGroupBox.TabStop = false;
            this.controllerConnectionGroupBox.Text = "Controller Connection";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(8, 16);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(104, 20);
            this.addressTextBox.TabIndex = 5;
            this.addressTextBox.Text = "128.0.0.2";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(112, 16);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(48, 20);
            this.portTextBox.TabIndex = 7;
            this.portTextBox.Text = "4468";
            // 
            // connectButton
            // 
            this.connectButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connectButton.Location = new System.Drawing.Point(166, 15);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(72, 20);
            this.connectButton.TabIndex = 8;
            this.connectButton.Text = "connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connectionStatusLabel.Location = new System.Drawing.Point(6, 44);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(224, 16);
            this.connectionStatusLabel.TabIndex = 6;
            this.connectionStatusLabel.Text = "Simulation Controller not connected";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.angleLabel);
            this.groupBox1.Controls.Add(this.rotationLabel);
            this.groupBox1.Controls.Add(this.sensorPositionLabel);
            this.groupBox1.Controls.Add(this.sensorLabel);
            this.groupBox1.Controls.Add(this.robotPositionLabel);
            this.groupBox1.Controls.Add(this.robotNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(272, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 292);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // angleLabel
            // 
            this.angleLabel.AutoSize = true;
            this.angleLabel.Location = new System.Drawing.Point(1, 197);
            this.angleLabel.Name = "angleLabel";
            this.angleLabel.Size = new System.Drawing.Size(35, 13);
            this.angleLabel.TabIndex = 5;
            this.angleLabel.Text = "label1";
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(6, 107);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(35, 13);
            this.rotationLabel.TabIndex = 4;
            this.rotationLabel.Text = "label1";
            // 
            // sensorPositionLabel
            // 
            this.sensorPositionLabel.AutoSize = true;
            this.sensorPositionLabel.Location = new System.Drawing.Point(6, 81);
            this.sensorPositionLabel.Name = "sensorPositionLabel";
            this.sensorPositionLabel.Size = new System.Drawing.Size(80, 13);
            this.sensorPositionLabel.TabIndex = 3;
            this.sensorPositionLabel.Text = "sensor position:";
            // 
            // sensorLabel
            // 
            this.sensorLabel.AutoSize = true;
            this.sensorLabel.Location = new System.Drawing.Point(6, 59);
            this.sensorLabel.Name = "sensorLabel";
            this.sensorLabel.Size = new System.Drawing.Size(41, 13);
            this.sensorLabel.TabIndex = 2;
            this.sensorLabel.Text = "sensor:";
            // 
            // robotPositionLabel
            // 
            this.robotPositionLabel.AutoSize = true;
            this.robotPositionLabel.Location = new System.Drawing.Point(6, 38);
            this.robotPositionLabel.Name = "robotPositionLabel";
            this.robotPositionLabel.Size = new System.Drawing.Size(49, 13);
            this.robotPositionLabel.TabIndex = 1;
            this.robotPositionLabel.Text = "position :";
            // 
            // robotNameLabel
            // 
            this.robotNameLabel.AutoSize = true;
            this.robotNameLabel.Location = new System.Drawing.Point(6, 16);
            this.robotNameLabel.Name = "robotNameLabel";
            this.robotNameLabel.Size = new System.Drawing.Size(63, 13);
            this.robotNameLabel.TabIndex = 0;
            this.robotNameLabel.Text = "robot name:";
            // 
            // leftEngine
            // 
            this.leftEngine.Location = new System.Drawing.Point(6, 40);
            this.leftEngine.Maximum = 100;
            this.leftEngine.Minimum = -100;
            this.leftEngine.Name = "leftEngine";
            this.leftEngine.Size = new System.Drawing.Size(104, 45);
            this.leftEngine.TabIndex = 15;
            this.leftEngine.TickFrequency = 20;
            this.leftEngine.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // velocity
            // 
            this.velocity.Location = new System.Drawing.Point(6, 127);
            this.velocity.Minimum = -10;
            this.velocity.Name = "velocity";
            this.velocity.Size = new System.Drawing.Size(259, 45);
            this.velocity.TabIndex = 17;
            // 
            // rightEngine
            // 
            this.rightEngine.Location = new System.Drawing.Point(161, 40);
            this.rightEngine.Maximum = 100;
            this.rightEngine.Minimum = -100;
            this.rightEngine.Name = "rightEngine";
            this.rightEngine.Size = new System.Drawing.Size(104, 45);
            this.rightEngine.TabIndex = 18;
            this.rightEngine.TickFrequency = 20;
            this.rightEngine.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // leftEngineLabel
            // 
            this.leftEngineLabel.AutoSize = true;
            this.leftEngineLabel.Location = new System.Drawing.Point(17, 24);
            this.leftEngineLabel.Name = "leftEngineLabel";
            this.leftEngineLabel.Size = new System.Drawing.Size(35, 13);
            this.leftEngineLabel.TabIndex = 19;
            this.leftEngineLabel.Text = "label1";
            // 
            // rightEngineLabel
            // 
            this.rightEngineLabel.AutoSize = true;
            this.rightEngineLabel.Location = new System.Drawing.Point(180, 24);
            this.rightEngineLabel.Name = "rightEngineLabel";
            this.rightEngineLabel.Size = new System.Drawing.Size(35, 13);
            this.rightEngineLabel.TabIndex = 20;
            this.rightEngineLabel.Text = "label2";
            // 
            // engineLabel
            // 
            this.engineLabel.AutoSize = true;
            this.engineLabel.Location = new System.Drawing.Point(3, 111);
            this.engineLabel.Name = "engineLabel";
            this.engineLabel.Size = new System.Drawing.Size(35, 13);
            this.engineLabel.TabIndex = 21;
            this.engineLabel.Text = "label3";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(6, 190);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 22;
            this.stopButton.Text = "stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // logButton
            // 
            this.logButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.logButton.Location = new System.Drawing.Point(9, 509);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(62, 23);
            this.logButton.TabIndex = 15;
            this.logButton.Text = "show logs";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.controlsButton_Click);
            // 
            // controlsButton
            // 
            this.controlsButton.Location = new System.Drawing.Point(77, 509);
            this.controlsButton.Name = "controlsButton";
            this.controlsButton.Size = new System.Drawing.Size(83, 23);
            this.controlsButton.TabIndex = 15;
            this.controlsButton.Text = "control panel";
            this.controlsButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.leftEngine);
            this.groupBox2.Controls.Add(this.velocity);
            this.groupBox2.Controls.Add(this.rightEngineLabel);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.leftEngineLabel);
            this.groupBox2.Controls.Add(this.rightEngine);
            this.groupBox2.Controls.Add(this.engineLabel);
            this.groupBox2.Location = new System.Drawing.Point(322, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 231);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "control panel";
            // 
            // driversListBox
            // 
            this.driversListBox.FormattingEnabled = true;
            this.driversListBox.HorizontalScrollbar = true;
            this.driversListBox.Location = new System.Drawing.Point(12, 75);
            this.driversListBox.Name = "driversListBox";
            this.driversListBox.Size = new System.Drawing.Size(109, 186);
            this.driversListBox.TabIndex = 26;
            this.driversListBox.SelectedIndexChanged += new System.EventHandler(this.driversListBox_SelectedValueChanged);
            // 
            // addDriverButton
            // 
            this.addDriverButton.Location = new System.Drawing.Point(127, 104);
            this.addDriverButton.Name = "addDriverButton";
            this.addDriverButton.Size = new System.Drawing.Size(75, 23);
            this.addDriverButton.TabIndex = 27;
            this.addDriverButton.Text = "add driver";
            this.addDriverButton.UseVisualStyleBackColor = true;
            this.addDriverButton.Click += new System.EventHandler(this.addDriverButton_Click);
            // 
            // driversButton
            // 
            this.driversButton.Enabled = false;
            this.driversButton.Location = new System.Drawing.Point(127, 75);
            this.driversButton.Name = "driversButton";
            this.driversButton.Size = new System.Drawing.Size(75, 23);
            this.driversButton.TabIndex = 28;
            this.driversButton.Text = "Start";
            this.driversButton.UseVisualStyleBackColor = true;
            this.driversButton.Click += new System.EventHandler(this.driversButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(807, 544);
            this.Controls.Add(this.driversButton);
            this.Controls.Add(this.addDriverButton);
            this.Controls.Add(this.driversListBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.controlsButton);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.controllerConnectionGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "City Driver";
            this.controllerConnectionGroupBox.ResumeLayout(false);
            this.controllerConnectionGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftEngine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightEngine)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


        private GroupBox controllerConnectionGroupBox;
        public TextBox addressTextBox;
        public TextBox portTextBox;
        private Button connectButton;
        private Label connectionStatusLabel;

        private GroupBox groupBox1;
        private Label sensorLabel;
        private Label robotPositionLabel;
        private Label robotNameLabel;
        private Label sensorPositionLabel;
        private TrackBar leftEngine;
        private TrackBar velocity;
        private TrackBar rightEngine;
        private Label leftEngineLabel;
        private Label rightEngineLabel;
        private Label engineLabel;

        
        private Button stopButton;
        private Label rotationLabel;
        private Label angleLabel;
        private Button logButton;
        private Button controlsButton;
        private GroupBox groupBox2;
        private ListBox driversListBox;
        private Button addDriverButton;
        private Button driversButton;

    }
}