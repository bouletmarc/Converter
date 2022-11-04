using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public static class File_Converter
    {
        public static byte[] Bin_File;
        public static byte[] Cal_File;
        public static byte[] Original_NBin_File;

        public static int Current_Index = 0;
        public static int Max_Index = 0;
        public static string Mode = "";

        //##################################################################
        //CONVERT THE PRELODED ECTUNE BIN WITH THE CALIBRATION
        //public static void Convert_File(bool Save)
        public static void Convert_File()
        {
            Mode = Loader.Mode;

            //Set Load Time
            /*EndTime = Time.realtimeSinceStartup;
            float Load_Time = EndTime - StartTime;
            Load_Time = Mathf.Round(Load_Time * 100f) / 100f;*/
            //Set Log Loaded
            //this.GetComponent<Log>().Log_This("File loaded in " + Load_Time + " seconds", false);

            if (!Loader.C3)
            {
                if (Mode == "Bin") Convert64kb();
                
                string ErrorText = Check_Error();
                if (ErrorText != "")
                    Log.Log_This("NOT Compatible !", false);
                else
                {
                    Log.Log_This("Compatible !", false);
                    Log.Log_This("--------------------------------------------------------------------------------------", true);
                    Log.Log_This("Converting: " + Loader.Current_File, false);

                    //Start Convertion
                    //StartTime = Time.realtimeSinceStartup;
                    //Loop_Time_Start = Time.realtimeSinceStartup;
                    //AvgTimeLoop.Clear();

                    Max_Index = 8382;
                    if (Mode == "Neptune") Max_Index = 32768;
                    Current_Index = 0;

                    for (int i = 0; i < Max_Index; i++)
                    {
                        int ThisInteger = 0;
                        int Current_Index_End = 0;

                        //Set Values to the original file backup
                        //Max Index Cal = 8371, Bin = 8364, Others = 32768;

                        //CALIBRATION MODE
                        if (Mode == "Cal" & Current_Index < 8371) {
                            Current_Index_End = 24388 + Current_Index;
                            Bin_File.SetValue(Cal_File[Current_Index + 8], Current_Index_End);
                            ThisInteger = Bin_File[Current_Index_End];
                        }

                        //BIN MODE
                        if (Mode == "Bin" & Current_Index < 8364) {
                            Current_Index_End = 8 + Current_Index;
                            Cal_File.SetValue(Bin_File[24388 + Current_Index], Current_Index_End);
                            ThisInteger = Cal_File[Current_Index_End];
                        }

                        //NEPTUNE MODE
                        if (Mode == "Neptune") {
                            if (Current_Index < 21357) {
                                Bin_File.SetValue(Original_NBin_File[Current_Index], Current_Index);
                                ThisInteger = Bin_File[Current_Index];
                            } else if (Current_Index >= 21357 & Current_Index < 24575) {
                                ThisInteger = Bin_File[Current_Index];
                                /*if (Current_Index == 22995) {
                                    Bin_File.SetValue (Original_NBin_File [Current_Index], Current_Index);
                                    ThisInteger = Bin_File [Current_Index];
                                }*/
                            } else if (Current_Index >= 24575 & Current_Index < 27135) {
                                Bin_File.SetValue(Original_NBin_File[Current_Index], Current_Index);
                                ThisInteger = Bin_File[Current_Index];
                            } else if (Current_Index >= 27135 & Current_Index < 32543) {
                                ThisInteger = Bin_File[Current_Index];
                            } else if (Current_Index >= 32543) {
                                Bin_File.SetValue(Original_NBin_File[Current_Index], Current_Index);
                                ThisInteger = Bin_File[Current_Index];
                            }

                            Current_Index_End = Current_Index;
                        }

                        //Set Percent
                        int Percent = ((Current_Index * 100) / (Max_Index - 1));
                        Main_Form.Main.Progress = Percent;

                        Log.Log_This("Set hex: " + ThisInteger.ToString("X2") + " At address: " + Current_Index_End.ToString("X4"), true);
                        Current_Index++;
                    }

                    //Get Remaining Time
                    //float RemainTime = GetRemainingTime(Loop_Index);
                    //string StrTime = ConvertTimeToString(RemainTime);
                    //RemainingTime.GetComponent<Text>().text = "Remaining time : " + StrTime;
                    //Reset Loop Timer
                    //Loop_Time_Start = Time.realtimeSinceStartup;
                    
                    if (Loader.C & Mode != "Neptune") ResetChecksum();
                    Set_Convert_Done();
                }
            }
        }

        public static void Set_Convert_Done()
        {
            //Get Time && Set Convert Done Text
            /*EndTime = Time.realtimeSinceStartup;
            float Convert_Time = EndTime - StartTime;
            Convert_Time = Mathf.Round(Convert_Time * 100f) / 100f;
            //Log Time
            this.GetComponent<Log>().Log_This("--------------------------------------------------------------", true);
            this.GetComponent<Log>().Log_This("Conversion done in " + Convert_Time + " seconds", false);*/

            if (Mode != "Neptune") Main_Form.Main.SaveCalEnabled = true;
            Main_Form.Main.SaveBinEnabled = true;
            Main_Form.Main.EditEnabled = true;

            //#####################################################
            //Get Infos
            File_Infos.GetInfos();
            //#####################################################
        }

        private static void ResetChecksum()
        {
            //Get File Lenght, is not correct, add checksum location
            if (Cal_File.Length == 8381)
            {
                byte[] TempCal = Cal_File;
                Cal_File = new byte[8382];
                for (int i = 0; i < 8381; i++)
                {
                    Cal_File[i] = TempCal[i];
                }
            }

            //Set 0x06 at 20B8
            byte ThisNewByte = 6;
            Cal_File[8376] = ThisNewByte;

            byte Checksum = 0;
            for (int i = 0; i < 8382; i++)
            {
                if (i >= 8 && i != 8381)
                {
                    //Get 0x0008 to 0x20BC
                    Checksum += Cal_File[i];
                }
                else if (i == 8381)
                {
                    //Set Checksum at 0x20BD (8382 - 1)
                    Cal_File[i] = Checksum;
                }
            }

            Log.Log_This("Resetting Checksum: " + Checksum.ToString("X") + " at Hex: 20BD", false);
        }

        public static void RemoveComments(bool InBin)
        {
            string Output = "Calibration";
            if (InBin) Output = "Bin";

            Log.Log_This("Removing comments in the " + Output, false);

            if (InBin)
            {
                byte[] TempBin = new byte[32768];
                for (int i = 0; i < 32768; i++)
                {
                    TempBin[i] = Bin_File[i];
                }
                Bin_File = TempBin;
                Output = "Bin";
            }
            else
            {
                byte[] TempCal = new byte[8382];
                for (int i = 0; i < 8382; i++)
                {
                    TempCal[i] = Cal_File[i];
                }
                Cal_File = TempCal;
                Output = "Calibration";
            }
        }

        public static void Convert64kb()
        {
            Log.Log_This("Checking for 64kb", false);
            if (Bin_File.Length - 1 >= 65534)
            {
                Log.Log_This("This file is 64kb --> Converting to 32kb", false);
                byte[] Temp_Byte = new byte[32768];
                for (int i = 0; i < 32768; i++)
                {
                    Temp_Byte[i] = Bin_File[32768 + i];
                }
                Bin_File = Temp_Byte;
            }
            else
            {
                Log.Log_This("This file is not 64kb", false);
            }
        }

        public static string Check_Error()
        {
            Log.Log_This("Checking for compatibilities", false);
            string Error_Str = "";

            //CALIBRATION MODE
            if (Mode == "Cal") {
                //Check for compatible calibrations
                if (Cal_File[8371] != 101 & Cal_File[8372] != 67 & Cal_File[8372] != 116)
                    Error_Str = "The Calibration File aren't compatible for the convertion'";
                
                //Make sure original bin arent modified
                if (Bin_File.Length < 32768)
                    Error_Str = "The buffer bin file is too Short (Possibly Modified)\n Lenght '" + (Bin_File.Length) + "' < 32768";
                else if (Bin_File.Length > 32768)
                    Error_Str = "The buffer bin file is too Long (Possibly Modified)\n Lenght '" + (Bin_File.Length) + "' > 32768";
            }

            //BINARY OR NEPTUNE MODE
            if (Mode == "Bin" | Mode == "Neptune")
            {
                //Check for compatible binaries
                if (Bin_File.Length < 32768)
                    Error_Str = "The Binary File is too Short\n Lenght '" + (Bin_File.Length) + "' < 32768";
                else if (Bin_File.Length > 32768)
                {
                    Error_Str = "The Binary File is too Long\n Lenght '" + (Bin_File.Length) + "' > 32768";
                    
                    //Check if compatible and remove comments
                    if (Bin_File[528] == 196 | Bin_File[528] == 16)
                    {
                        Error_Str = "";
                        RemoveComments(true);
                    }
                }
                else if (Bin_File[528] != 196 & Bin_File[528] != 16)
                {
                    //0x0210 = 528	...	eCtune=196, P30=71, Gold=137, P72=228, Neptune=16, P28=212
                    //Get Other Softwares
                    if (Bin_File[528] == 71)
                        Error_Str = "This is a Crome P30 Binary file";
                    else if (Bin_File[528] == 228)
                        Error_Str = "This is a Crome P72 Binary file";
                    else if (Bin_File[528] == 212)
                        Error_Str = "This is a Crome P28 Binary file";
                    else if (Bin_File[528] == 137)
                        Error_Str = "This is a Crome Gold Binary file";
                    else if (Bin_File[528] == 19)
                        Error_Str = "This is a Hondata S200 Binary file";
                    else
                        Error_Str = "This Binary File is not reconized";
                }
            }

            //Make sure original cal arent modified
            if (Mode != "Neptune")
            {
                if (Cal_File.Length < 8381)
                    Error_Str = "The original cal file that\nneed convertion is too Short\n Lenght '" + (Cal_File.Length) + "' < 8382";
                else if (Cal_File.Length == 8381)
                    ResetChecksum();
                else if (Cal_File.Length > 8382) {
                    RemoveComments(false);
                    ResetChecksum();
                }
            }

            if (Error_Str != "") Log.Log_This(Error_Str, false);

            return Error_Str;
        }
    }
}
