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
            this.labelClientType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxScouts = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.listBoxLeader = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxClient = new System.Windows.Forms.ListBox();
            this.labelFinishPosition = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelStartPosition = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTestCaseDeadline = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTestCaseStartTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTestCaseStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
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
            this.groupBox1.Size = new System.Drawing.Size(244, 106);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tests";
            // 
            // listBoxTestCases
            // 
            this.listBoxTestCases.FormattingEnabled = true;
            this.listBoxTestCases.Location = new System.Drawing.Point(6, 32);
            this.listBoxTestCases.Name = "listBoxTestCases";
            this.listBoxTestCases.Size = new System.Drawing.Size(232, 69);
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
            this.groupBox2.Controls.Add(this.labelClientType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.listBoxScouts);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.listBoxLeader);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.listBoxClient);
            this.groupBox2.Controls.Add(this.labelFinishPosition);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelStartPosition);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.labelTestCaseDeadline);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.labelTestCaseStartTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelTestCaseStatus);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(8, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 215);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test case details";
            // 
            // labelClientType
            // 
            this.labelClientType.AutoSize = true;
            this.labelClientType.Location = new System.Drawing.Point(72, 29);
            this.labelClientType.Name = "labelClientType";
            this.labelClientType.Size = new System.Drawing.Size(35, 13);
            this.labelClientType.TabIndex = 19;
            this.labelClientType.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "ClientType:";
            // 
            // listBoxScouts
            // 
            this.listBoxScouts.FormattingEnabled = true;
            this.listBoxScouts.Location = new System.Drawing.Point(47, 149);
            this.listBoxScouts.Name = "listBoxScouts";
            this.listBoxScouts.Size = new System.Drawing.Size(191, 56);
            this.listBoxScouts.TabIndex = 35;
            this.listBoxScouts.SelectedIndexChanged += new System.EventHandler(this.listBoxAgent_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Scouts:";
            // 
            // listBoxLeader
            // 
            this.listBoxLeader.FormattingEnabled = true;
            this.listBoxLeader.Location = new System.Drawing.Point(47, 129);
            this.listBoxLeader.Name = "listBoxLeader";
            this.listBoxLeader.Size = new System.Drawing.Size(191, 17);
            this.listBoxLeader.TabIndex = 33;
            this.listBoxLeader.SelectedIndexChanged += new System.EventHandler(this.listBoxAgent_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Leader:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Client:";
            // 
            // listBoxClient
            // 
            this.listBoxClient.FormattingEnabled = true;
            this.listBoxClient.Location = new System.Drawing.Point(47, 109);
            this.listBoxClient.Name = "listBoxClient";
            this.listBoxClient.Size = new System.Drawing.Size(191, 17);
            this.listBoxClient.TabIndex = 30;
            this.listBoxClient.SelectedIndexChanged += new System.EventHandler(this.listBoxAgent_SelectedIndexChanged);
            // 
            // labelFinishPosition
            // 
            this.labelFinishPosition.AutoSize = true;
            this.labelFinishPosition.Location = new System.Drawing.Point(72, 81);
            this.labelFinishPosition.Name = "labelFinishPosition";
            this.labelFinishPosition.Size = new System.Drawing.Size(35, 13);
            this.labelFinishPosition.TabIndex = 29;
            this.labelFinishPosition.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Finish at";
            // 
            // labelStartPosition
            // 
            this.labelStartPosition.AutoSize = true;
            this.labelStartPosition.Location = new System.Drawing.Point(72, 68);
            this.labelStartPosition.Name = "labelStartPosition";
            this.labelStartPosition.Size = new System.Drawing.Size(35, 13);
            this.labelStartPosition.TabIndex = 27;
            this.labelStartPosition.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Start at:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Deadline:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Start time:";
            // 
            // labelTestCaseStatus
            // 
            this.labelTestCaseStatus.AutoSize = true;
            this.labelTestCaseStatus.Location = new System.Drawing.Point(72, 16);
            this.labelTestCaseStatus.Name = "labelTestCaseStatus";
            this.labelTestCaseStatus.Size = new System.Drawing.Size(35, 13);
            this.labelTestCaseStatus.TabIndex = 21;
            this.labelTestCaseStatus.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Status:";
            // 
            // DebugView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 595);
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
        private System.Windows.Forms.Label labelFinishPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelStartPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxClient;
        private System.Windows.Forms.ListBox listBoxScouts;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listBoxLeader;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;

    }
}