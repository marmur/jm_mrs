using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MTest
{
    public partial class SimpleLog : Form
    {
        public SimpleLog()
        {
            InitializeComponent();
            
        }

        public void log(String msg)
        {
            logTextBox.Text += String.Format("{0:hh:mm:ss} : {1}", DateTime.Now, msg);
            logTextBox.Text += Environment.NewLine;
            logTextBox.SelectionStart = logTextBox.TextLength;
            logTextBox.ScrollToCaret();
            Refresh();
        }

        private void SimpleLog_FormClosing(Object sender, FormClosingEventArgs e)
        {
           this.Hide();
           e.Cancel = true; 
        }

        private void SimpleLog_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            logTextBox.Width = control.Size.Width - 12;
            logTextBox.Height = control.Size.Height - 50;
        }
    }
}
