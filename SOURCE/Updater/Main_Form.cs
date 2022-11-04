using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Updater
{
    public partial class Main_Form : Form
    {

        public static Main_Form Main;

        public Main_Form()
        {
            InitializeComponent();
            Main = this;
            if (Load())
                Environment.Exit(0);
        }

        public string DescText
        {
            get { return Desc_Label.Text; }
            set { Desc_Label.Text = value; }
        }
    }
}
