using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public static class File_Infos
    {
        public static string HEX_O2CloseLoop;
        public static string HEX_IAC_Error;
        public static string HEX_IAB_Reset;
        public static string HEX_IAB_Set;
        public static string HEX_Vtec_Error;
        public static string HEX_Vtec_ECTCheck;
        public static string HEX_Vtec_Pressure;
        public static string HEX_Vtec_SolenoidErr;
        public static string HEX_IgnitionCut;
        public static string HEX_FuelCut;
        public static string HEX_ShiftLight;
        public static string HEX_ShiftLight_Rpm;
        public static string HEX_Knock;
        public static string HEX_Vtec_Trigger;
        public static string HEX_O2Heater;
        public static string HEX_Baro;
        public static string HEX_InjectorTest;
        public static string HEX_Boost_Column;
        public static string HEX_IAB_USDM;
        public static string HEX_Vtec_SpeedCheck;
        public static string HEX_AutoTranny;
        public static string HEX_ELD;
        public static string HEX_IAB;
        public static string HEX_Launch_Mode;
        public static string HEX_Launch_Type;
        public static string HEX_Launch_RPM = "5419"; //NEPTUNE LAUNCH RPM
        public static string HEX_Launch_RPM_MEM;
        public static string HEX_Antilag_Fuel;
        public static string HEX_Antilag;
        public static string HEX_Launch_RPM_TPS;
        public static string HEX_Purge;
        public static string HEX_FanControl;
        public static string HEX_AC;
        public static string HEX_Rev_Reset_Cold;
        public static string HEX_Rev_Set_Cold;
        public static string HEX_Rev_Reset_Hot;
        public static string HEX_Rev_Set_Hot;
        public static string HEX_Vtec_Low_RPM;
        public static string HEX_Vtec_High_RPM;

        public static bool ELD = true;
        public static bool Knock = true;
        public static bool Baro = true;
        public static bool InjTest = true;
        public static bool O2Heater = false;
        public static bool CloseLoop = false;
        public static bool AutoTranny = true;
        public static bool IAB = true;
        public static bool Purge = false;
        public static bool FanControl = false;
        public static bool IACV = false;
        public static bool AC = false;

        public static bool Using_Vtec = false;
        public static int Vtec_Rpm_Set = 0;
        public static int Vtec_Rpm_Reset = 0;
        public static bool Vtec_Speed = false;
        public static bool Vtec_Coolant = false;
        public static bool Vtec_Pressure = true;
        public static bool Vtec_Solenoid = false;
        public static bool Vtec_Error = false;

        public static int Rev_RPM_Cold_Set = 0;
        public static int Rev_RPM_Cold_Reset = 0;
        public static int Rev_RPM_Hot_Set = 0;
        public static int Rev_RPM_Hot_Reset = 0;
        public static bool FuelCut = true;
        public static bool IgnitionCut = false;
        public static bool ShiftLight = false;
        public static int ShiftLight_RPM = 0;

        public static bool Using_Launch = false;
        public static bool Using_Launch_TPS = false;
        public static int Launch_Input = 0;
        public static int Launch_RPM_Mem = 0;
        public static int Launch_RPM_TPS = 0;
        public static int Launch_RPM = 0;      //Neptune

        public static bool Using_Antilag = false;
        public static int Antilag_Fuel = 0;

        public static bool Boosted = false;

        public static bool IAB_Disabled = true;
        public static bool IAB_USDM = true;
        public static int IAB_RPM_Set = 0;
        public static int IAB_RPM_Reset = 0;

        public static byte[] Current_File;
        public static string Mode = "";

        //###############################################################################
        public static void LoadHexRegion()
        {
            if (Mode != "Neptune")
            {
                HEX_O2CloseLoop = "01D5";   //FF = Disabled
                HEX_IAC_Error = "01DA"; //FF = Disabled
                HEX_IAB_Reset = "01DD"; //FF = 8000rpm
                HEX_IAB_Set = "01DE";   //FF = 8000rpm
                HEX_Vtec_Error = "01E2";    //FF = Disabled
                HEX_Vtec_ECTCheck = "01E3"; //FF = Disabled
                HEX_Vtec_Pressure = "01E7"; //FF = Disabled
                HEX_Vtec_SolenoidErr = "01E8";  //FF = Disabled
                HEX_IgnitionCut = "01E9";   //FF = Enabled
                HEX_FuelCut = "01EA";   //FF = Disabled
                HEX_ShiftLight = "0206";    //FF = Enabled
                HEX_ShiftLight_Rpm = "0208";    //"0209";
                HEX_Knock = "02B7"; //FF = Disabled
                HEX_Vtec_Trigger = "02B6";  //FF = Disabled
                HEX_O2Heater = "02B8";  //FF = Disabled
                HEX_Baro = "02B9";  //FF = Disabled
                HEX_InjectorTest = "02BD";  //FF = Disabled
                HEX_Boost_Column = "02BF";
                HEX_IAB_USDM = "02C5";  //FF = USDM ECU
                HEX_Vtec_SpeedCheck = "02CD";   //FF = Disabled
                HEX_AutoTranny = "02CF";    //FF = Disabled
                HEX_ELD = "02D2";   //FF = Disabled
                HEX_IAB = "02D9";   //FF = Disabled
                HEX_Launch_Mode = "0216";   //always on = 0x80, disabled = 0x00, B5 = 0x10, B7 = 0x40, B8 = 0x01-FF, B9 = 0x04-FF, D2 = 0x20, D4 = 0x02, D6 = 0x08;
                HEX_Launch_Type = "0219";   //tps = 0xFF, memory = 0x00
                HEX_Launch_RPM_MEM = "021A";    //"021B";
                HEX_Antilag_Fuel = "0225";  //Value * 4 ### "0226" When over 255
                HEX_Antilag = "0228";
                HEX_Launch_RPM_TPS = "0229";    //"022A";
                HEX_Purge = "022F"; //FF = Disabled
                HEX_FanControl = "0231";    //FF = Enabled
                HEX_AC = "025E";    //FF = Disabled
                HEX_Rev_Reset_Cold = "0655";    //"0656";
                HEX_Rev_Set_Cold = "065B";  //"065C";
                HEX_Rev_Reset_Hot = "0661"; //"0662";
                HEX_Rev_Set_Hot = "0667";   //"0668";
                HEX_Vtec_Low_RPM = "071E";
                HEX_Vtec_High_RPM = "071C";
            }
            else
            {
                HEX_O2CloseLoop = "5464";   //FF = Disabled
                HEX_IAC_Error = "5452"; //FF = Disabled
                HEX_IAB_Reset = "5434"; //FF = 8000rpm
                HEX_IAB_Set = "5433";   //FF = 8000rpm
                HEX_Vtec_Error = "545C";    //FF = Disabled
                HEX_Vtec_ECTCheck = "545D"; //FF = Disabled
                HEX_Vtec_Pressure = "545B"; //FF = Disabled
                HEX_IgnitionCut = "53BF";   //FF = Enabled
                HEX_FuelCut = "53B6";   //FF = Disabled
                HEX_ShiftLight = "5458";    //FF = Enabled
                HEX_ShiftLight_Rpm = "5442";
                HEX_Knock = "5467"; //FF = Disabled
                HEX_Vtec_Trigger = "5466";  //FF = Disabled
                HEX_O2Heater = "5468";  //FF = Disabled
                HEX_Baro = "5469";  //FF = Enabled
                HEX_InjectorTest = "546D";  //FF = Disabled
                HEX_Boost_Column = "7E88";  //0E = NOT BOOSTED
                HEX_IAB_USDM = "5475";  //FF = USDM ECU
                HEX_Vtec_SpeedCheck = "547D";   //FF = Disabled
                HEX_ELD = "5482";   //FF = Disabled
                HEX_IAB = "5489";   //FF = Disabled
                HEX_Launch_Mode = "545E";   //always on = 0xFF, disabled = 0x00;
                                            //HEX_Launch_Type 		= "5455";	//tps = 0x02, MPH = 0x00, clutch = 0x01
                                            //HEX_Antilag_Fuel 		= "541E";	//Value * 4 ### "0226" When over 255
                                            //HEX_Antilag 			= "0228";
                HEX_FanControl = "5453";    //FF = Enabled
                HEX_Rev_Reset_Cold = "580D";    //"0656";
                HEX_Rev_Set_Cold = "5813";  //"065C";
                HEX_Rev_Reset_Hot = "5819"; //"0662";
                HEX_Rev_Set_Hot = "581F";   //"0668";
                HEX_Vtec_Low_RPM = "58D3";
                HEX_Vtec_High_RPM = "58D5";
            }
        }

        //####################################################################################################

        public static void GetInfos()
        {
            Current_File = File_Converter.Cal_File;

            Mode = Loader.Mode;

            //Get Byes from Bin file instead of Cal file for Neptune
            if (Mode == "Neptune")
                Current_File = File_Converter.Bin_File;
            /*else if (Mode == "Serial")
            {
                Current_File = this.GetComponent<Serial>().BufferArray;
                if (this.GetComponent<Serial>().BufferArray[528] == 196)
                {
                    Current_File = new byte[8382];
                    for (int i = 0; i < 8364; i++)
                    {
                        Current_File.SetValue(this.GetComponent<Serial>().BufferArray[24388 + i], 8 + i);
                    }
                }
                else
                {
                    Mode = "Neptune";
                    Current_File = this.GetComponent<Serial>().BufferArray;
                }
            }*/

            LoadHexRegion();

            //Get Values
            ELD = GetBool(ConvertHexToInt(HEX_ELD), true);
            Knock = GetBool(ConvertHexToInt(HEX_Knock), true);
            Baro = GetBool(ConvertHexToInt(HEX_Baro), true);
            InjTest = GetBool(ConvertHexToInt(HEX_InjectorTest), false);
            O2Heater = GetBool(ConvertHexToInt(HEX_O2Heater), true);
            CloseLoop = GetBool(ConvertHexToInt(HEX_O2CloseLoop), false);
            FanControl = GetBool(ConvertHexToInt(HEX_FanControl), true);
            IACV = GetBool(ConvertHexToInt(HEX_IAC_Error), false);
            if (Mode != "Neptune")
            {
                AutoTranny = GetBool(ConvertHexToInt(HEX_AutoTranny), true);
                Purge = GetBool(ConvertHexToInt(HEX_Purge), false);
                AC = GetBool(ConvertHexToInt(HEX_AC), false);
            }

            //Get Vtec Values
            Using_Vtec = GetBool(ConvertHexToInt(HEX_Vtec_Trigger), false);
            if (Mode != "Neptune")
            {
                Vtec_Rpm_Reset = ConvertHexToVtecRPM(ConvertHexToInt(HEX_Vtec_Low_RPM));
                Vtec_Rpm_Set = ConvertHexToVtecRPM(ConvertHexToInt(HEX_Vtec_High_RPM));
            }
            else
            {
                Vtec_Rpm_Reset = GetRPM(ConvertHexToInt(HEX_Vtec_Low_RPM));
                Vtec_Rpm_Set = GetRPM(ConvertHexToInt(HEX_Vtec_High_RPM));
            }
            Vtec_Speed = GetBool(ConvertHexToInt(HEX_Vtec_SpeedCheck), false);
            Vtec_Coolant = GetBool(ConvertHexToInt(HEX_Vtec_ECTCheck), false);
            Vtec_Pressure = GetBool(ConvertHexToInt(HEX_Vtec_Pressure), false);
            if (Mode != "Neptune")
            {
                Vtec_Solenoid = GetBool(ConvertHexToInt(HEX_Vtec_SolenoidErr), false);
            }
            Vtec_Error = GetBool(ConvertHexToInt(HEX_Vtec_Error), false);

            //Get Rev rpm's
            Rev_RPM_Cold_Set = GetRPM(ConvertHexToInt(HEX_Rev_Set_Cold));
            Rev_RPM_Cold_Reset = GetRPM(ConvertHexToInt(HEX_Rev_Reset_Cold));
            Rev_RPM_Hot_Set = GetRPM(ConvertHexToInt(HEX_Rev_Set_Hot));
            Rev_RPM_Hot_Reset = GetRPM(ConvertHexToInt(HEX_Rev_Reset_Hot));
            if (Mode != "Neptune")
            {
                FuelCut = GetBool(ConvertHexToInt(HEX_FuelCut), true);
            }
            else
            {
                FuelCut = GetBool(ConvertHexToInt(HEX_FuelCut), false);
            }
            IgnitionCut = GetBool(ConvertHexToInt(HEX_IgnitionCut), false);
            ShiftLight = GetBool(ConvertHexToInt(HEX_ShiftLight), false);
            ShiftLight_RPM = GetRPM(ConvertHexToInt(HEX_ShiftLight_Rpm));

            //Get Launch Values
            Launch_Input = (int)Current_File[ConvertHexToInt(HEX_Launch_Mode)];
            Using_Launch = false;
            //Set Using Launch
            if (Current_File[ConvertHexToInt(HEX_Launch_Mode)] > 0)
            {
                Using_Launch = true;
            }
            //Get Launch Type
            if (Mode != "Neptune")
            {
                if (Current_File[ConvertHexToInt(HEX_Launch_Type)] > 0)
                {
                    Using_Launch_TPS = true;
                }
                else
                {
                    Using_Launch_TPS = false;
                }

                Launch_RPM_TPS = GetRPM(ConvertHexToInt(HEX_Launch_RPM_TPS));
                Launch_RPM_Mem = GetRPM(ConvertHexToInt(HEX_Launch_RPM_MEM));
            }
            else
            {
                Launch_RPM = GetRPM(ConvertHexToInt(HEX_Launch_RPM));
            }

            //Get Antilag
            if (Mode != "Neptune")
            {
                Using_Antilag = GetBool(ConvertHexToInt(HEX_Antilag), false);
                int FuelIndex = ConvertHexToInt(HEX_Antilag_Fuel);
                Antilag_Fuel = ((int)Current_File[FuelIndex] + ((int)Current_File[FuelIndex + 1] * 256)) / 4;
            }

            //Get Boosted
            if (Mode != "Neptune")
            {
                if (Current_File[ConvertHexToInt(HEX_Boost_Column)] > 10)
                {
                    Boosted = true;
                }
                else
                {
                    Boosted = false;
                }
            }
            else
            {
                if (Current_File[ConvertHexToInt(HEX_Boost_Column)] != 14)
                {
                    Boosted = true;
                }
                else
                {
                    Boosted = false;
                }
            }

            //Get IAB Values
            IAB_Disabled = GetBool(ConvertHexToInt(HEX_IAB), false);
            IAB_USDM = GetBool(ConvertHexToInt(HEX_IAB_USDM), false);
            if (Mode != "Neptune")
            {
                IAB_RPM_Set = ConvertHexToVtecRPM(ConvertHexToInt(HEX_IAB_Set));
                IAB_RPM_Reset = ConvertHexToVtecRPM(ConvertHexToInt(HEX_IAB_Reset));
            }
            else
            {
                IAB_RPM_Set = GetRPM(ConvertHexToInt(HEX_IAB_Set));
                IAB_RPM_Reset = GetRPM(ConvertHexToInt(HEX_IAB_Reset));
            }

            //Set Infos Texts
            SetInfos();
            //SetEditInfos();
        }

        //#################################################################################################

        public static bool GetBool(int Index, bool Inverted)
        {
            bool This = Inverted;

            if (Current_File[Index] == 255)
            {
                This = true;

                if (Inverted)
                {
                    This = false;
                }
            }

            return This;
        }

        public static int GetRPM(int Index)
        {
            //RPM = 1875000 / ((1st byte * 256) + 2nd byte)
            int RPM1 = (int)Current_File[Index];
            int RPM2 = (int)Current_File[Index + 1];
            int RPM = 1875000 / ((RPM2 * 256) + RPM1);
            return RPM;
        }

        public static string GetHexRPM(int RPM)
        {
            //Reset Max RPM
            if (RPM >= 12000)
            {
                RPM = 12000;
            }
            //Set
            int RPM_Full = 1875000 / RPM;
            int RPM2 = RPM_Full / 256;
            int RPM1 = RPM_Full - (RPM2 * 256);

            string HexRPM = RPM1.ToString("X2") + RPM2.ToString("X2");
            return HexRPM;
        }

        public static int ConvertHexToInt(string Hex)
        {
            return System.Int32.Parse(Hex, System.Globalization.NumberStyles.AllowHexSpecifier);
        }

        public static int ConvertHexToVtecRPM(int Index)
        {
            string Vtec_Hex = Current_File[Index].ToString("X2");

            string Index1 = Vtec_Hex[0].ToString();
            string Index2 = Vtec_Hex[1].ToString();

            //Incread with First index
            int RPM = 0;
            if (Index1 == "9")
                RPM = 1000;
            else if (Index1 == "A")
                RPM = 2000;
            else if (Index1 == "B")
                RPM = 3000;
            else if (Index1 == "C")
                RPM = 4000;
            else if (Index1 == "D")
                RPM = 5000;
            else if (Index1 == "E")
                RPM = 6000;
            else if (Index1 == "F")
                RPM = 7000;

            //Incread with Second index
            if (Index2 == "1")
                RPM = RPM + 50;
            else if (Index2 == "2")
                RPM = RPM + 125;
            else if (Index2 == "3")
                RPM = RPM + 200;
            else if (Index2 == "4")
                RPM = RPM + 250;
            else if (Index2 == "5")
                RPM = RPM + 300;
            else if (Index2 == "6")
                RPM = RPM + 375;
            else if (Index2 == "7")
                RPM = RPM + 450;
            else if (Index2 == "8")
                RPM = RPM + 500;
            else if (Index2 == "9")
                RPM = RPM + 550;
            else if (Index2 == "A")
                RPM = RPM + 625;
            else if (Index2 == "B")
                RPM = RPM + 700;
            else if (Index2 == "C")
                RPM = RPM + 750;
            else if (Index2 == "D")
                RPM = RPM + 800;
            else if (Index2 == "E")
                RPM = RPM + 875;
            else if (Index2 == "F")
                RPM = RPM + 950;

            return RPM;
        }

        public static int ConvertVtecRPMToHex(int RPM)
        {
            string Hex1 = "8";
            string Hex2 = "0";

            //Incread with First index
            int Remover = 0;
            if (RPM >= 1000)
            {
                Hex1 = "9";
                Remover = 1000;
                if (RPM >= 2000)
                {
                    Hex1 = "A";
                    Remover = 2000;
                    if (RPM >= 3000)
                    {
                        Hex1 = "B";
                        Remover = 3000;
                        if (RPM >= 4000)
                        {
                            Hex1 = "C";
                            Remover = 4000;
                            if (RPM >= 5000)
                            {
                                Hex1 = "D";
                                Remover = 5000;
                                if (RPM >= 6000)
                                {
                                    Hex1 = "E";
                                    Remover = 6000;
                                    if (RPM >= 7000)
                                    {
                                        Hex1 = "F";
                                        Remover = 7000;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Incread with Second index
            int RPM2 = RPM - Remover;
            Hex2 = "F";
            if (RPM2 <= 875)
            {
                Hex2 = "E";
                if (RPM2 <= 800)
                {
                    Hex2 = "D";
                    if (RPM2 <= 750)
                    {
                        Hex2 = "C";
                        if (RPM2 <= 700)
                        {
                            Hex2 = "B";
                            if (RPM2 <= 625)
                            {
                                Hex2 = "A";
                                if (RPM2 <= 550)
                                {
                                    Hex2 = "9";
                                    if (RPM2 <= 500)
                                    {
                                        Hex2 = "8";
                                        if (RPM2 <= 450)
                                        {
                                            Hex2 = "7";
                                            if (RPM2 <= 375)
                                            {
                                                Hex2 = "6";
                                                if (RPM2 <= 300)
                                                {
                                                    Hex2 = "5";
                                                    if (RPM2 <= 250)
                                                    {
                                                        Hex2 = "4";
                                                        if (RPM2 <= 200)
                                                        {
                                                            Hex2 = "3";
                                                            if (RPM2 <= 125)
                                                            {
                                                                Hex2 = "2";
                                                                if (RPM2 <= 50)
                                                                {
                                                                    Hex2 = "1";
                                                                    if (RPM2 <= 25)
                                                                    {
                                                                        Hex2 = "0";
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ConvertHexToInt(Hex1 + Hex2);
        }
        //#################################################
        //Set Description input field infos
        public static void SetInfos()
        {
            string Desc = "Boosted: " + Boosted;
            Desc = Desc + Environment.NewLine + "Rev Limiter: " + Rev_RPM_Hot_Set + "rpm";

            //Vtec
            if (Using_Vtec)
                Desc = Desc + Environment.NewLine + "Vtec: True, Vtec RPM: " + Vtec_Rpm_Set + "rpm";
            else
                Desc = Desc + Environment.NewLine + "Vtec: False";

            //Launch
            if (Using_Launch)
            {
                if (Mode != "Neptune")
                {
                    if (Using_Launch_TPS)
                        Desc = Desc + Environment.NewLine + "Launch: True, TPS : " + Using_Launch_TPS + ", RPM: " + Launch_RPM_TPS + "rpm";
                    else
                        Desc = Desc + Environment.NewLine + "Launch: True, TPS : " + Using_Launch_TPS + ", RPM: " + Launch_RPM_Mem + "rpm";
                }
                else
                    Desc = Desc + Environment.NewLine + "Launch: True, RPM: " + Launch_RPM + "rpm";
            }
            else
                Desc = Desc + Environment.NewLine + "Launch: False";

            //Antilag
            if (Mode != "Neptune")
                Desc = Desc + Environment.NewLine + "Antilag: " + Using_Antilag;

            //Output to descriptions menu
            Main_Form.Main.InfosText = Desc;
        }
    }
}
