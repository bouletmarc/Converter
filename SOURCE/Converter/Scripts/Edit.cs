using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public static class Edit
    {
        public static bool Loading = true;

        public static void Load()
        {
            Loading = true;

            Edit_Form.Editf.ELD_Checked = File_Infos.ELD;
            Edit_Form.Editf.Knock_Checked = File_Infos.Knock;
            Edit_Form.Editf.Baro_Checked = File_Infos.Baro;
            Edit_Form.Editf.InjTest_Checked = File_Infos.InjTest;
            Edit_Form.Editf.Heater_Checked = File_Infos.O2Heater;
            Edit_Form.Editf.Closeloop_Checked = File_Infos.CloseLoop;
            Edit_Form.Editf.Vtec_Checked = !File_Infos.Using_Vtec;
            Edit_Form.Editf.IAB_Checked = File_Infos.IAB;
            Edit_Form.Editf.Fan_Checked = File_Infos.FanControl;
            Edit_Form.Editf.IACV_Checked = File_Infos.IACV;

            Edit_Form.Editf.FuelCut_Checked = File_Infos.FuelCut;
            Edit_Form.Editf.IgnCut_Checked = File_Infos.IgnitionCut;
            Edit_Form.Editf.ShiftLight_Checked = File_Infos.ShiftLight;
            Edit_Form.Editf.ColdSet_RPM = File_Infos.Rev_RPM_Cold_Set;
            Edit_Form.Editf.ColdReset_RPM = File_Infos.Rev_RPM_Cold_Reset;
            Edit_Form.Editf.WarmSet_RPM = File_Infos.Rev_RPM_Hot_Set;
            Edit_Form.Editf.WarmReset_RPM = File_Infos.Rev_RPM_Hot_Reset;
            Edit_Form.Editf.ShiftLight_RPM = File_Infos.ShiftLight_RPM;

            Edit_Form.Editf.SpeedCheck_Checked = File_Infos.Vtec_Speed;
            Edit_Form.Editf.CoolantCheck_Checked = File_Infos.Vtec_Coolant;
            Edit_Form.Editf.VTP_Checked = File_Infos.Vtec_Pressure;
            Edit_Form.Editf.VtecError_Checked = File_Infos.Vtec_Error;
            Edit_Form.Editf.VtecHigh_RPM = File_Infos.Vtec_Rpm_Set;
            Edit_Form.Editf.VtecLow_RPM = File_Infos.Vtec_Rpm_Reset;

            Loading = false;
        }

        //#########################################################################################################################

        public static void SetAt(int Index, byte ThisByte)
        {
            if (!Loading)
            {
                if (Loader.Mode != "Neptune")
                    File_Converter.Cal_File[Index] = ThisByte;
                else
                    File_Converter.Bin_File[Index] = ThisByte;
                Log.Log_This("Set hex: " + ThisByte.ToString("X2") + " At address: " + Index.ToString("X4"), false);
            }
        }

        public static void Set_ELD()
        {
            if (!Loading)
            {
                File_Infos.ELD = Edit_Form.Editf.ELD_Checked;
                byte ThisByte = 0;
                if (!File_Infos.ELD)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_ELD), ThisByte);
            }
        }

        public static void Set_Knock()
        {
            if (!Loading)
            {
                File_Infos.Knock = Edit_Form.Editf.Knock_Checked;
                byte ThisByte = 0;
                if (!File_Infos.Knock)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Knock), ThisByte);
            }
        }

        public static void Set_Baro()
        {
            if (!Loading)
            {
                File_Infos.Baro = Edit_Form.Editf.Baro_Checked;
                byte ThisByte = 0;
                if (!File_Infos.Baro)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Baro), ThisByte);
            }
        }

        public static void Set_InjTest()
        {
            if (!Loading)
            {
                File_Infos.InjTest = Edit_Form.Editf.InjTest_Checked;
                byte ThisByte = 0;
                if (File_Infos.InjTest)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_InjectorTest), ThisByte);
            }
        }

        public static void Set_O2Heater()
        {
            if (!Loading)
            {
                File_Infos.O2Heater = Edit_Form.Editf.Heater_Checked;
                byte ThisByte = 0;
                if (!File_Infos.O2Heater)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_O2Heater), ThisByte);
            }
        }

        public static void Set_CloseLoop()
        {
            if (!Loading)
            {
                File_Infos.CloseLoop = Edit_Form.Editf.Closeloop_Checked;
                byte ThisByte = 0;
                if (File_Infos.CloseLoop)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_O2CloseLoop), ThisByte);
            }
        }

        public static void Set_Using_Vtec()
        {
            if (!Loading)
            {
                File_Infos.Using_Vtec = !Edit_Form.Editf.Vtec_Checked;
                byte ThisByte = 0;
                if (File_Infos.Using_Vtec)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_Trigger), ThisByte);
            }
        }

        public static void Set_IAB()
        {
            if (!Loading)
            {
                File_Infos.IAB = Edit_Form.Editf.IAB_Checked;
                byte ThisByte = 0;
                if (File_Infos.IAB)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_IAB), ThisByte);
            }
        }

        public static void Set_FanControl()
        {
            if (!Loading)
            {
                File_Infos.FanControl = Edit_Form.Editf.Fan_Checked;
                byte ThisByte = 0;
                if (!File_Infos.FanControl)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_FanControl), ThisByte);
            }
        }

        public static void Set_IACV()
        {
            if (!Loading)
            {
                File_Infos.IACV = Edit_Form.Editf.IACV_Checked;
                byte ThisByte = 0;
                if (File_Infos.IACV)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_IAC_Error), ThisByte);
            }
        }

        public static void Set_FuelCut()
        {
            if (!Loading)
            {
                File_Infos.FuelCut = Edit_Form.Editf.FuelCut_Checked;
                byte ThisByte = 0;
                if (Loader.Mode != "Neptune")
                {
                    if (!File_Infos.FuelCut)
                        ThisByte = 255;
                }
                else
                {
                    if (File_Infos.FuelCut)
                        ThisByte = 255;
                }
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_FuelCut), ThisByte);
            }
        }

        public static void Set_IgnitionCut()
        {
            if (!Loading)
            {
                File_Infos.IgnitionCut = Edit_Form.Editf.IgnCut_Checked;
                byte ThisByte = 0;
                if (File_Infos.IgnitionCut)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_IgnitionCut), ThisByte);
            }
        }

        public static void Set_ShiftLight()
        {
            if (!Loading)
            {
                File_Infos.ShiftLight = Edit_Form.Editf.ShiftLight_Checked;
                byte ThisByte = 0;
                if (File_Infos.ShiftLight)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_ShiftLight), ThisByte);
            }
        }

        public static void Set_RPM_Cold_Set()
        {
            if (!Loading)
            {
                File_Infos.Rev_RPM_Cold_Set = Edit_Form.Editf.ColdSet_RPM;
                string HexRPM = File_Infos.GetHexRPM(File_Infos.Rev_RPM_Cold_Set);
                string Hex1 = HexRPM[0].ToString() + HexRPM[1].ToString();
                string Hex2 = HexRPM[2].ToString() + HexRPM[3].ToString();
                byte RPM1 = (byte)File_Infos.ConvertHexToInt(Hex1);
                byte RPM2 = (byte)File_Infos.ConvertHexToInt(Hex2);
                //Set
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Set_Cold), RPM1);
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Set_Cold) + 1, RPM2);
                //Reset
                Edit_Form.Editf.ColdSet_RPM = File_Infos.GetRPM(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Set_Cold));
            }
        }

        public static void Set_RPM_Cold_Reset()
        {
            if (!Loading)
            {
                File_Infos.Rev_RPM_Cold_Reset = Edit_Form.Editf.ColdReset_RPM;
                string HexRPM = File_Infos.GetHexRPM(File_Infos.Rev_RPM_Cold_Reset);
                string Hex1 = HexRPM[0].ToString() + HexRPM[1].ToString();
                string Hex2 = HexRPM[2].ToString() + HexRPM[3].ToString();
                byte RPM1 = (byte)File_Infos.ConvertHexToInt(Hex1);
                byte RPM2 = (byte)File_Infos.ConvertHexToInt(Hex2);
                //Set
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Reset_Cold), RPM1);
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Reset_Cold) + 1, RPM2);
                //Reset
                Edit_Form.Editf.ColdReset_RPM = File_Infos.GetRPM(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Reset_Cold));
            }
        }

        public static void Set_RPM_Hot_Set()
        {
            if (!Loading)
            {
                File_Infos.Rev_RPM_Hot_Set = Edit_Form.Editf.WarmSet_RPM;
                string HexRPM = File_Infos.GetHexRPM(File_Infos.Rev_RPM_Hot_Set);
                string Hex1 = HexRPM[0].ToString() + HexRPM[1].ToString();
                string Hex2 = HexRPM[2].ToString() + HexRPM[3].ToString();
                byte RPM1 = (byte)File_Infos.ConvertHexToInt(Hex1);
                byte RPM2 = (byte)File_Infos.ConvertHexToInt(Hex2);
                //Set
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Set_Hot), RPM1);
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Set_Hot) + 1, RPM2);
                //Reset
                Edit_Form.Editf.WarmSet_RPM = File_Infos.GetRPM(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Set_Hot));
            }
        }

        public static void Set_RPM_Hot_Reset()
        {
            if (!Loading)
            {
                File_Infos.Rev_RPM_Hot_Reset = Edit_Form.Editf.WarmReset_RPM;
                string HexRPM = File_Infos.GetHexRPM(File_Infos.Rev_RPM_Hot_Reset);
                string Hex1 = HexRPM[0].ToString() + HexRPM[1].ToString();
                string Hex2 = HexRPM[2].ToString() + HexRPM[3].ToString();
                byte RPM1 = (byte)File_Infos.ConvertHexToInt(Hex1);
                byte RPM2 = (byte)File_Infos.ConvertHexToInt(Hex2);
                //Set
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Reset_Hot), RPM1);
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Reset_Hot) + 1, RPM2);
                //Reset
                Edit_Form.Editf.WarmReset_RPM = File_Infos.GetRPM(File_Infos.ConvertHexToInt(File_Infos.HEX_Rev_Reset_Hot));
            }
        }

        public static void Set_RPM_Shiftlight()
        {
            if (!Loading)
            {
                File_Infos.ShiftLight_RPM = Edit_Form.Editf.ShiftLight_RPM;
                string HexRPM = File_Infos.GetHexRPM(File_Infos.ShiftLight_RPM);
                string Hex1 = HexRPM[0].ToString() + HexRPM[1].ToString();
                string Hex2 = HexRPM[2].ToString() + HexRPM[3].ToString();
                byte RPM1 = (byte)File_Infos.ConvertHexToInt(Hex1);
                byte RPM2 = (byte)File_Infos.ConvertHexToInt(Hex2);
                //Set
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_ShiftLight_Rpm), RPM1);
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_ShiftLight_Rpm) + 1, RPM2);
                //Reset
                Edit_Form.Editf.ShiftLight_RPM = File_Infos.GetRPM(File_Infos.ConvertHexToInt(File_Infos.HEX_ShiftLight_Rpm));
            }
        }

        public static void Set_Vtec_Speed()
        {
            if (!Loading)
            {
                File_Infos.Vtec_Speed = Edit_Form.Editf.SpeedCheck_Checked;
                byte ThisByte = 0;
                if (File_Infos.Vtec_Speed)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_SpeedCheck), ThisByte);
            }
        }

        public static void Set_Vtec_Coolant()
        {
            if (!Loading)
            {
                File_Infos.Vtec_Coolant = Edit_Form.Editf.CoolantCheck_Checked;
                byte ThisByte = 0;
                if (File_Infos.Vtec_Coolant)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_ECTCheck), ThisByte);
            }
        }

        public static void Set_Vtec_Pressure()
        {
            if (!Loading)
            {
                File_Infos.Vtec_Pressure = Edit_Form.Editf.VTP_Checked;
                byte ThisByte = 0;
                if (File_Infos.Vtec_Pressure)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_Pressure), ThisByte);
            }
        }

        public static void Set_Vtec_Error()
        {
            if (!Loading)
            {
                File_Infos.Vtec_Error = Edit_Form.Editf.VtecError_Checked;
                byte ThisByte = 0;
                if (File_Infos.Vtec_Error)
                    ThisByte = 255;
                SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_Error), ThisByte);
            }
        }

        public static void Set_RPM_Vtec_Set()
        {
            if (!Loading)
            {
                File_Infos.Vtec_Rpm_Set = Edit_Form.Editf.VtecHigh_RPM;
                if (Loader.Mode != "Neptune")
                {
                    byte RPMByte = (byte)File_Infos.ConvertVtecRPMToHex(File_Infos.Vtec_Rpm_Set);
                    //Set
                    SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_High_RPM), RPMByte);
                }
                else
                {
                    string HexRPM = File_Infos.GetHexRPM(File_Infos.Vtec_Rpm_Set);
                    string Hex1 = HexRPM[0].ToString() + HexRPM[1].ToString();
                    string Hex2 = HexRPM[2].ToString() + HexRPM[3].ToString();
                    byte RPM1 = (byte)File_Infos.ConvertHexToInt(Hex1);
                    byte RPM2 = (byte)File_Infos.ConvertHexToInt(Hex2);
                    //Set
                    SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_High_RPM), RPM1);
                    SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_High_RPM) + 1, RPM2);
                }
                //Reset
                Edit_Form.Editf.VtecHigh_RPM = File_Infos.ConvertHexToVtecRPM(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_High_RPM));
            }
        }

        public static void Set_RPM_Vtec_Reset()
        {
            if (!Loading)
            {
                File_Infos.Vtec_Rpm_Reset = Edit_Form.Editf.VtecLow_RPM;
                if (Loader.Mode != "Neptune")
                {
                    byte RPMByte = (byte)File_Infos.ConvertVtecRPMToHex(File_Infos.Vtec_Rpm_Reset);
                    //Set
                    SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_Low_RPM), RPMByte);
                }
                else
                {
                    string HexRPM = File_Infos.GetHexRPM(File_Infos.Vtec_Rpm_Reset);
                    string Hex1 = HexRPM[0].ToString() + HexRPM[1].ToString();
                    string Hex2 = HexRPM[2].ToString() + HexRPM[3].ToString();
                    byte RPM1 = (byte)File_Infos.ConvertHexToInt(Hex1);
                    byte RPM2 = (byte)File_Infos.ConvertHexToInt(Hex2);
                    //Set
                    SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_Low_RPM), RPM1);
                    SetAt(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_Low_RPM) + 1, RPM2);
                }
                //Reset
                Edit_Form.Editf.VtecLow_RPM = File_Infos.ConvertHexToVtecRPM(File_Infos.ConvertHexToInt(File_Infos.HEX_Vtec_Low_RPM));
            }
        }


    }
}
