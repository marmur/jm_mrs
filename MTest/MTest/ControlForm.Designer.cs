namespace MTest
{
    partial class ControlForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.controlBox = new System.Windows.Forms.GroupBox();
            this.rightAmountLabel = new System.Windows.Forms.Label();
            this.leftAmountLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.leftEngine = new System.Windows.Forms.TrackBar();
            this.enginePower = new System.Windows.Forms.TrackBar();
            this.rightEngineLabel = new System.Windows.Forms.Label();
            this.leftEngineLabel = new System.Windows.Forms.Label();
            this.rightEngine = new System.Windows.Forms.TrackBar();
            this.powerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.directionLabel = new System.Windows.Forms.Label();
            this.comandBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.lookAtButton = new System.Windows.Forms.Button();
            this.goToButton = new System.Windows.Forms.Button();
            this.controlCheckBox = new System.Windows.Forms.CheckBox();
            this.controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftEngine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enginePower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightEngine)).BeginInit();
            this.comandBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "None";
            // 
            // controlBox
            // 
            this.controlBox.Controls.Add(this.rightAmountLabel);
            this.controlBox.Controls.Add(this.leftAmountLabel);
            this.controlBox.Controls.Add(this.label5);
            this.controlBox.Controls.Add(this.label4);
            this.controlBox.Controls.Add(this.label3);
            this.controlBox.Controls.Add(this.leftEngine);
            this.controlBox.Controls.Add(this.enginePower);
            this.controlBox.Controls.Add(this.rightEngineLabel);
            this.controlBox.Controls.Add(this.leftEngineLabel);
            this.controlBox.Controls.Add(this.rightEngine);
            this.controlBox.Controls.Add(this.powerLabel);
            this.controlBox.Enabled = false;
            this.controlBox.Location = new System.Drawing.Point(12, 193);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(285, 169);
            this.controlBox.TabIndex = 26;
            this.controlBox.TabStop = false;
            this.controlBox.Text = "control panel";
            // 
            // rightAmountLabel
            // 
            this.rightAmountLabel.AutoSize = true;
            this.rightAmountLabel.Location = new System.Drawing.Point(158, 72);
            this.rightAmountLabel.Name = "rightAmountLabel";
            this.rightAmountLabel.Size = new System.Drawing.Size(21, 13);
            this.rightAmountLabel.TabIndex = 31;
            this.rightAmountLabel.Text = "0%";
            // 
            // leftAmountLabel
            // 
            this.leftAmountLabel.AutoSize = true;
            this.leftAmountLabel.Location = new System.Drawing.Point(9, 72);
            this.leftAmountLabel.Name = "leftAmountLabel";
            this.leftAmountLabel.Size = new System.Drawing.Size(21, 13);
            this.leftAmountLabel.TabIndex = 30;
            this.leftAmountLabel.Text = "0%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "power:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "right engine:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "left engine:";
            // 
            // leftEngine
            // 
            this.leftEngine.Location = new System.Drawing.Point(12, 40);
            this.leftEngine.Maximum = 100;
            this.leftEngine.Minimum = -100;
            this.leftEngine.Name = "leftEngine";
            this.leftEngine.Size = new System.Drawing.Size(104, 45);
            this.leftEngine.TabIndex = 15;
            this.leftEngine.TickFrequency = 20;
            this.leftEngine.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.leftEngine.Scroll += new System.EventHandler(this.EngineTrackBar_Scroll);
            // 
            // enginePower
            // 
            this.enginePower.Location = new System.Drawing.Point(6, 127);
            this.enginePower.Minimum = -10;
            this.enginePower.Name = "enginePower";
            this.enginePower.Size = new System.Drawing.Size(259, 45);
            this.enginePower.TabIndex = 17;
            this.enginePower.Scroll += new System.EventHandler(this.EngineTrackBar_Scroll);
            // 
            // rightEngineLabel
            // 
            this.rightEngineLabel.AutoSize = true;
            this.rightEngineLabel.Location = new System.Drawing.Point(230, 24);
            this.rightEngineLabel.Name = "rightEngineLabel";
            this.rightEngineLabel.Size = new System.Drawing.Size(33, 13);
            this.rightEngineLabel.TabIndex = 20;
            this.rightEngineLabel.Text = "None";
            // 
            // leftEngineLabel
            // 
            this.leftEngineLabel.AutoSize = true;
            this.leftEngineLabel.Location = new System.Drawing.Point(71, 24);
            this.leftEngineLabel.Name = "leftEngineLabel";
            this.leftEngineLabel.Size = new System.Drawing.Size(33, 13);
            this.leftEngineLabel.TabIndex = 19;
            this.leftEngineLabel.Text = "None";
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
            this.rightEngine.Scroll += new System.EventHandler(this.EngineTrackBar_Scroll);
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(46, 111);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(13, 13);
            this.powerLabel.TabIndex = 21;
            this.powerLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Robot name :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Direction :";
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.Location = new System.Drawing.Point(87, 22);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(33, 13);
            this.directionLabel.TabIndex = 29;
            this.directionLabel.Text = "None";
            // 
            // comandBox
            // 
            this.comandBox.Controls.Add(this.goToButton);
            this.comandBox.Controls.Add(this.lookAtButton);
            this.comandBox.Controls.Add(this.yTextBox);
            this.comandBox.Controls.Add(this.label8);
            this.comandBox.Controls.Add(this.xTextBox);
            this.comandBox.Controls.Add(this.label7);
            this.comandBox.Location = new System.Drawing.Point(12, 38);
            this.comandBox.Name = "comandBox";
            this.comandBox.Size = new System.Drawing.Size(285, 108);
            this.comandBox.TabIndex = 31;
            this.comandBox.TabStop = false;
            this.comandBox.Text = "comand panel";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "X:";
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(112, 28);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(55, 20);
            this.xTextBox.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Y:";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(112, 51);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(55, 20);
            this.yTextBox.TabIndex = 34;
            // 
            // lookAtButton
            // 
            this.lookAtButton.Location = new System.Drawing.Point(49, 79);
            this.lookAtButton.Name = "lookAtButton";
            this.lookAtButton.Size = new System.Drawing.Size(75, 23);
            this.lookAtButton.TabIndex = 35;
            this.lookAtButton.Text = "look at";
            this.lookAtButton.UseVisualStyleBackColor = true;
            this.lookAtButton.Click += new System.EventHandler(this.lookAtButton_Click);
            // 
            // goToButton
            // 
            this.goToButton.Location = new System.Drawing.Point(130, 79);
            this.goToButton.Name = "goToButton";
            this.goToButton.Size = new System.Drawing.Size(75, 23);
            this.goToButton.TabIndex = 36;
            this.goToButton.Text = "go to";
            this.goToButton.UseVisualStyleBackColor = true;
            this.goToButton.Click += new System.EventHandler(this.goToButton_Click);
            // 
            // controlCheckBox
            // 
            this.controlCheckBox.AutoSize = true;
            this.controlCheckBox.Location = new System.Drawing.Point(12, 170);
            this.controlCheckBox.Name = "controlCheckBox";
            this.controlCheckBox.Size = new System.Drawing.Size(116, 17);
            this.controlCheckBox.TabIndex = 32;
            this.controlCheckBox.Text = "enable cotrol panel";
            this.controlCheckBox.UseVisualStyleBackColor = true;
            this.controlCheckBox.CheckedChanged += new System.EventHandler(this.controlCheckBox_CheckedChanged);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 374);
            this.Controls.Add(this.controlCheckBox);
            this.Controls.Add(this.comandBox);
            this.Controls.Add(this.directionLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.controlBox);
            this.Controls.Add(this.label1);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
            this.controlBox.ResumeLayout(false);
            this.controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftEngine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enginePower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightEngine)).EndInit();
            this.comandBox.ResumeLayout(false);
            this.comandBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label label1;
    

       

        private System.Windows.Forms.GroupBox controlBox;
        private System.Windows.Forms.TrackBar leftEngine;
        private System.Windows.Forms.TrackBar enginePower;
        private System.Windows.Forms.Label rightEngineLabel;
        private System.Windows.Forms.Label leftEngineLabel;
        private System.Windows.Forms.TrackBar rightEngine;
        private System.Windows.Forms.Label powerLabel;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label leftAmountLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label rightAmountLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label directionLabel;
        private System.Windows.Forms.GroupBox comandBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button goToButton;
        private System.Windows.Forms.Button lookAtButton;
        private System.Windows.Forms.CheckBox controlCheckBox;
    }
}