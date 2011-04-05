namespace MTest.view
{
    partial class DebugView
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelConnector = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.controllerConnectionGroupBox = new System.Windows.Forms.GroupBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxTestCases = new System.Windows.Forms.ListBox();
            this.labelTestStatus = new System.Windows.Forms.Label();
            this.labelTestTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoadTest = new System.Windows.Forms.Button();
            this.buttonTestSartStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelTestCaseStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelClientType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTestCaseStartTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTestCaseDeadline = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.controllerConnectionGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelConnector,
            this.toolStripProgressBar,
            this.toolStripStatusLabelInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(579, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "Controller:";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelConnector
            // 
            this.toolStripStatusLabelConnector.AutoSize = false;
            this.toolStripStatusLabelConnector.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelConnector.Name = "toolStripStatusLabelConnector";
            this.toolStripStatusLabelConnector.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelConnector.Text = "DISCONNECTED";
            this.toolStripStatusLabelConnector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabelInfo.Text = "   ";
            // 
            // controllerConnectionGroupBox
            // 
            this.controllerConnectionGroupBox.Controls.Add(this.addressTextBox);
            this.controllerConnectionGroupBox.Controls.Add(this.portTextBox);
            this.controllerConnectionGroupBox.Controls.Add(this.connectButton);
            this.controllerConnectionGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.controllerConnectionGroupBox.Location = new System.Drawing.Point(8, 0);
            this.controllerConnectionGroupBox.Name = "controllerConnectionGroupBox";
            this.controllerConnectionGroupBox.Size = new System.Drawing.Size(244, 45);
            this.controllerConnectionGroupBox.TabIndex = 14;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxTestCases);
            this.groupBox1.Controls.Add(this.labelTestStatus);
            this.groupBox1.Controls.Add(this.labelTestTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 185);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tests";
            // 
            // listBoxTestCases
            // 
            this.listBoxTestCases.FormattingEnabled = true;
            this.listBoxTestCases.Location = new System.Drawing.Point(6, 32);
            this.listBoxTestCases.Name = "listBoxTestCases";
            this.listBoxTestCases.Size = new System.Drawing.Size(232, 147);
            this.listBoxTestCases.TabIndex = 18;
            this.listBoxTestCases.SelectedIndexChanged += new System.EventHandler(this.listBoxTestCases_SelectedIndexChanged);
            // 
            // labelTestStatus
            // 
            this.labelTestStatus.AutoSize = true;
            this.labelTestStatus.Location = new System.Drawing.Point(6, 16);
            this.labelTestStatus.Name = "labelTestStatus";
            this.labelTestStatus.Size = new System.Drawing.Size(27, 13);
            this.labelTestStatus.TabIndex = 18;
            this.labelTestStatus.Text = "OFF";
            // 
            // labelTestTime
            // 
            this.labelTestTime.AutoSize = true;
            this.labelTestTime.Location = new System.Drawing.Point(141, 16);
            this.labelTestTime.Name = "labelTestTime";
            this.labelTestTime.Size = new System.Drawing.Size(13, 13);
            this.labelTestTime.TabIndex = 16;
            this.labelTestTime.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Test Time:";
            // 
            // buttonLoadTest
            // 
            this.buttonLoadTest.Location = new System.Drawing.Point(8, 51);
            this.buttonLoadTest.Name = "buttonLoadTest";
            this.buttonLoadTest.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadTest.TabIndex = 16;
            this.buttonLoadTest.Text = "LoadTest";
            this.buttonLoadTest.UseVisualStyleBackColor = true;
            this.buttonLoadTest.Click += new System.EventHandler(this.buttonLoadTest_Click);
            // 
            // buttonTestSartStop
            // 
            this.buttonTestSartStop.Location = new System.Drawing.Point(89, 51);
            this.buttonTestSartStop.Name = "buttonTestSartStop";
            this.buttonTestSartStop.Size = new System.Drawing.Size(163, 23);
            this.buttonTestSartStop.TabIndex = 17;
            this.buttonTestSartStop.Text = "Start";
            this.buttonTestSartStop.UseVisualStyleBackColor = true;
            this.buttonTestSartStop.Click += new System.EventHandler(this.buttonTestSartStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTestCaseDeadline);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.labelTestCaseStartTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelTestCaseStatus);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelClientType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 291);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test case details";
            // 
            // labelTestCaseStatus
            // 
            this.labelTestCaseStatus.AutoSize = true;
            this.labelTestCaseStatus.Location = new System.Drawing.Point(72, 29);
            this.labelTestCaseStatus.Name = "labelTestCaseStatus";
            this.labelTestCaseStatus.Size = new System.Drawing.Size(35, 13);
            this.labelTestCaseStatus.TabIndex = 21;
            this.labelTestCaseStatus.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Status:";
            // 
            // labelClientType
            // 
            this.labelClientType.AutoSize = true;
            this.labelClientType.Location = new System.Drawing.Point(72, 16);
            this.labelClientType.Name = "labelClientType";
            this.labelClientType.Size = new System.Drawing.Size(35, 13);
            this.labelClientType.TabIndex = 19;
            this.labelClientType.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "ClientType:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Start time:";
            // 
            // labelTestCaseStartTime
            // 
            this.labelTestCaseStartTime.AutoSize = true;
            this.labelTestCaseStartTime.Location = new System.Drawing.Point(72, 42);
            this.labelTestCaseStartTime.Name = "labelTestCaseStartTime";
            this.labelTestCaseStartTime.Size = new System.Drawing.Size(35, 13);
            this.labelTestCaseStartTime.TabIndex = 23;
            this.labelTestCaseStartTime.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Deadline:";
            // 
            // labelTestCaseDeadline
            // 
            this.labelTestCaseDeadline.AutoSize = true;
            this.labelTestCaseDeadline.Location = new System.Drawing.Point(72, 55);
            this.labelTestCaseDeadline.Name = "labelTestCaseDeadline";
            this.labelTestCaseDeadline.Size = new System.Drawing.Size(35, 13);
            this.labelTestCaseDeadline.TabIndex = 25;
            this.labelTestCaseDeadline.Text = "label6";
            // 
            // DebugView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 595);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonTestSartStop);
            this.Controls.Add(this.buttonLoadTest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.controllerConnectionGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DebugView";
            this.Text = "DebugView";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.controllerConnectionGroupBox.ResumeLayout(false);
            this.controllerConnectionGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConnector;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox controllerConnectionGroupBox;
        public System.Windows.Forms.TextBox addressTextBox;
        public System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTestTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadTest;
        private System.Windows.Forms.Button buttonTestSartStop;
        private System.Windows.Forms.Label labelTestStatus;
        private System.Windows.Forms.ListBox listBoxTestCases;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelClientType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTestCaseStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTestCaseDeadline;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTestCaseStartTime;
        private System.Windows.Forms.Label label4;

    }
}