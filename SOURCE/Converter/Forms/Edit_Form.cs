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
    public partial class Edit_Form : Form
    {
        public static Edit_Form Editf;

        public Edit_Form()
        {
            InitializeComponent();
            Editf = this;
            Edit.Load();
        }

        public bool ELD_Checked
        {
            get { return ELD_CheckBox.Checked; }
            set { ELD_CheckBox.Checked = value; }
        }

        public bool Knock_Checked
        {
            get { return Knock_CheckBox.Checked; }
            set { Knock_CheckBox.Checked = value; }
        }

        public bool Baro_Checked
        {
            get { return Baro_CheckBox.Checked; }
            set { Baro_CheckBox.Checked = value; }
        }

        public bool InjTest_Checked
        {
            get { return InjTest_CheckBox.Checked; }
            set { InjTest_CheckBox.Checked = value; }
        }

        public bool Heater_Checked
        {
            get { return Heater_CheckBox.Checked; }
            set { Heater_CheckBox.Checked = value; }
        }

        public bool Closeloop_Checked
        {
            get { return Closeloop_CheckBox.Checked; }
            set { Closeloop_CheckBox.Checked = value; }
        }

        public bool Vtec_Checked
        {
            get { return Vtec_CheckBox.Checked; }
            set { Vtec_CheckBox.Checked = value; }
        }

        public bool IAB_Checked
        {
            get { return IAB_CheckBox.Checked; }
            set { IAB_CheckBox.Checked = value; }
        }

        public bool Fan_Checked
        {
            get { return Fan_CheckBox.Checked; }
            set { Fan_CheckBox.Checked = value; }
        }

        public bool IACV_Checked
        {
            get { return IACV_CheckBox.Checked; }
            set { IACV_CheckBox.Checked = value; }
        }

        public bool FuelCut_Checked
        {
            get { return FuelCut_CheckBox.Checked; }
            set { FuelCut_CheckBox.Checked = value; }
        }

        public bool IgnCut_Checked
        {
            get { return IgnCut_CheckBox.Checked; }
            set { IgnCut_CheckBox.Checked = value; }
        }

        public bool ShiftLight_Checked
        {
            get { return ShiftLight_CheckBox.Checked; }
            set { ShiftLight_CheckBox.Checked = value; }
        }

        public bool SpeedCheck_Checked
        {
            get { return SpeedCheck_CheckBox.Checked; }
            set { SpeedCheck_CheckBox.Checked = value; }
        }

        public bool CoolantCheck_Checked
        {
            get { return CoolantCheck_CheckBox.Checked; }
            set { CoolantCheck_CheckBox.Checked = value; }
        }

        public bool VTP_Checked
        {
            get { return VTP_CheckBox.Checked; }
            set { VTP_CheckBox.Checked = value; }
        }

        public bool VtecError_Checked
        {
            get { return VtecError_CheckBox.Checked; }
            set { VtecError_CheckBox.Checked = value; }
        }

        //########################################################################

        public int ColdSet_RPM
        {
            get { return int.Parse(ColdSet_TextBox.Text); }
            set { ColdSet_TextBox.Text = value.ToString(); }
        }

        public int ColdReset_RPM
        {
            get { return int.Parse(ColdReset_TextBox.Text); }
            set { ColdReset_TextBox.Text = value.ToString(); }
        }

        public int WarmSet_RPM
        {
            get { return int.Parse(WarmSet_TextBox.Text); }
            set { WarmSet_TextBox.Text = value.ToString(); }
        }

        public int WarmReset_RPM
        {
            get { return int.Parse(WarmReset_TextBox.Text); }
            set { WarmReset_TextBox.Text = value.ToString(); }
        }

        public int ShiftLight_RPM
        {
            get { return int.Parse(ShiftLight_TextBox.Text); }
            set { ShiftLight_TextBox.Text = value.ToString(); }
        }

        public int VtecHigh_RPM
        {
            get { return int.Parse(VtecHigh_TextBox.Text); }
            set { VtecHigh_TextBox.Text = value.ToString(); }
        }

        public int VtecLow_RPM
        {
            get { return int.Parse(VtecLow_TextBox.Text); }
            set { VtecLow_TextBox.Text = value.ToString(); }
        }

        //#######################################################################################

        private void ELD_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_ELD();
        }

        private void Knock_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_Knock();
        }

        private void Baro_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_Baro();
        }

        private void InjTest_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_InjTest();
        }

        private void Heater_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_O2Heater();
        }

        private void Closeloop_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_CloseLoop();
        }

        private void Vtec_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_Using_Vtec();
        }

        private void IAB_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_IAB();
        }

        private void Fan_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_FanControl();
        }

        private void IACV_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_IACV();
        }

        private void FuelCut_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_FuelCut();
        }

        private void IgnCut_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_IgnitionCut();
        }

        private void ShiftLight_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_ShiftLight();
        }

        private void ColdSet_TextBox_TextChanged(object sender, EventArgs e)
        {
            Edit.Set_RPM_Cold_Set();
        }

        private void ColdReset_TextBox_TextChanged(object sender, EventArgs e)
        {
            Edit.Set_RPM_Cold_Reset();
        }

        private void WarmSet_TextBox_TextChanged(object sender, EventArgs e)
        {
            Edit.Set_RPM_Hot_Set();
        }

        private void WarmReset_TextBox_TextChanged(object sender, EventArgs e)
        {
            Edit.Set_RPM_Hot_Reset();
        }

        private void ShiftLight_TextBox_TextChanged(object sender, EventArgs e)
        {
            Edit.Set_RPM_Shiftlight();
        }

        private void SpeedCheck_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_Vtec_Speed();
        }

        private void CoolantCheck_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_Vtec_Coolant();
        }

        private void VTP_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_Vtec_Pressure();
        }

        private void VtecError_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Edit.Set_Vtec_Error();
        }

        private void VtecHigh_TextBox_TextChanged(object sender, EventArgs e)
        {
            Edit.Set_RPM_Vtec_Set();
        }

        private void VtecLow_TextBox_TextChanged(object sender, EventArgs e)
        {
            Edit.Set_RPM_Vtec_Reset();
        }

        private void Reconvert_Button_Click(object sender, EventArgs e)
        {
            Log.Log_This("--------------------------------------------------------------------------------------", false);
            File_Converter.Convert_File();
            Close();
        }
    }
}
