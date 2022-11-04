using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Converter
{
    public partial class Settings_Form : Form
    {
        public Settings_Form()
        {
            InitializeComponent();
            LoadValue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveLogs_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save_Logs = SaveLogs_Checkbox.Checked;
            Reload();
        }

        private void AdvLogs_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Adv_Logs = AdvLogs_Checkbox.Checked;
            Reload();
        }

        private void EctuneBaserom_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Ectune_Baserom = EctuneBaserom_ComboBox.Text;
            Reload();
        }

        private void Reload()
        {
            Settings.SaveSettings();
            Settings.LoadSettings();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Patch_4kRPM_Hondata = checkBox_4k_Hondata.Checked;
            Reload();
        }

        private void LoadValue()
        {
            Settings.Patch_Hondata_Chip_Lock = false;

            this.SaveLogs_Checkbox.Checked = Settings.Save_Logs;
            this.AdvLogs_Checkbox.Checked = Settings.Adv_Logs;
            this.EctuneBaserom_ComboBox.Text = Settings.Ectune_Baserom;
            this.checkBox_4k_Hondata.Checked = Settings.Patch_4kRPM_Hondata;
            this.checkBox_Hondata_Chip_Lock.Checked = Settings.Patch_Hondata_Chip_Lock;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            Settings.Patch_Hondata_Chip_Lock = checkBox_Hondata_Chip_Lock.Checked;
            Reload();
        }
    }
}
