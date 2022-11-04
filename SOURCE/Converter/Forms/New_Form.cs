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
    public partial class New_Form : Form
    {
        public New_Form()
        {
            InitializeComponent();
        }

        private void EctuneTuner_Label_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bouletmarc/eCtune_Tuner");
        }

        private void EctunePro_Label_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bouletmarc/eCtune_Pro_Ostrich");
        }

        private void NeptuneDealer_Label_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bouletmarc/NeptuneDealer");
        }

        private void NeptuneRTP_Label_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bouletmarc/Neptune_RTP");
        }

        private void CromeGOLD_Label_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bouletmarc/Crome_Tuning_Gold");
        }

        private void Freelog_Label_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bouletmarc/Freelog");
        }
    }
}
