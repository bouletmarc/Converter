using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Liscencer
{
    public partial class Request_Form : Form
    {
        public Request_Form()
        {
            InitializeComponent();
            Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send();
        }
    }
}
