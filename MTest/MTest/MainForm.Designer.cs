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
            this.controllerConnectionGroupBox = new System.Windows.Forms.GroupBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.robotNameLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.robotPositionLabel = new System.Windows.Forms.Label();
            this.sensorLabel = new System.Windows.Forms.Label();
            this.logButton = new System.Windows.Forms.Button();
            this.controlsButton = new System.Windows.Forms.Button();
            this.driversListBox = new System.Windows.Forms.ListBox();
            this.addDriverButton = new System.Windows.Forms.Button();
            this.driversButton = new System.Windows.Forms.Button();
            this.controllerConnectionGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(250, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 292);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.robotNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.robotPositionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sensorLabel, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // robotNameLabel
            // 
            this.robotNameLabel.AutoSize = true;
            this.robotNameLabel.Location = new System.Drawing.Point(3, 0);
            this.robotNameLabel.Name = "robotNameLabel";
            this.robotNameLabel.Size = new System.Drawing.Size(63, 13);
            this.robotNameLabel.TabIndex = 0;
            this.robotNameLabel.Text = "robot name:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 60);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(38, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "status:";
            // 
            // robotPositionLabel
            // 
            this.robotPositionLabel.AutoSize = true;
            this.robotPositionLabel.Location = new System.Drawing.Point(3, 20);
            this.robotPositionLabel.Name = "robotPositionLabel";
            this.robotPositionLabel.Size = new System.Drawing.Size(49, 13);
            this.robotPositionLabel.TabIndex = 1;
            this.robotPositionLabel.Text = "position :";
            // 
            // sensorLabel
            // 
            this.sensorLabel.AutoSize = true;
            this.sensorLabel.Location = new System.Drawing.Point(3, 40);
            this.sensorLabel.Name = "sensorLabel";
            this.sensorLabel.Size = new System.Drawing.Size(41, 13);
            this.sensorLabel.TabIndex = 2;
            this.sensorLabel.Text = "sensor:";
            // 
            // logButton
            // 
            this.logButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.logButton.Location = new System.Drawing.Point(9, 269);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(62, 23);
            this.logButton.TabIndex = 15;
            this.logButton.Text = "show logs";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // controlsButton
            // 
            this.controlsButton.Location = new System.Drawing.Point(77, 269);
            this.controlsButton.Name = "controlsButton";
            this.controlsButton.Size = new System.Drawing.Size(83, 23);
            this.controlsButton.TabIndex = 15;
            this.controlsButton.Text = "control panel";
            this.controlsButton.UseVisualStyleBackColor = true;
            this.controlsButton.Click += new System.EventHandler(this.controlButton_Click);
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
            this.ClientSize = new System.Drawing.Size(487, 321);
            this.Controls.Add(this.driversButton);
            this.Controls.Add(this.addDriverButton);
            this.Controls.Add(this.driversListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.controlsButton);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.controllerConnectionGroupBox);
            this.Name = "MainForm";
            this.Text = "City Driver";
            this.controllerConnectionGroupBox.ResumeLayout(false);
            this.controllerConnectionGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private Button logButton;
        private Button controlsButton;
        private ListBox driversListBox;
        private Button addDriverButton;
        private Button driversButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Label statusLabel;

    }
}