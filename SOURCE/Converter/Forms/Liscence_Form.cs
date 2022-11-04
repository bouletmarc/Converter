using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Converter
{
    public partial class Liscence_Form : Form
    {
        public Liscence_Form()
        {
            InitializeComponent();

            //this.HWID_Label.Text = Loader.CPU_HWID;
            this.textBox1.Text = Loader.CPU_HWID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=5LM2Q2U5EZ7VY");
        }
    }
}
