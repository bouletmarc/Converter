using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public static class Settings
    {
        public static bool Patch_4kRPM_Hondata = true;
        public static bool Save_Logs = false;
        public static bool Adv_Logs = false;
        public static string Ectune_Baserom = "0065.3.pri";
        public static bool Patch_Hondata_Chip_Lock = false;

        public static string Settings_Path = Loader.File_Path + "Settings.txt";

        //############################################################################

        public static void Load()
        {
            if (!File.Exists(Settings_Path)) SetInitialValues();
            LoadSettings();
            Log.Log_This("Loaded Settings", false);
        }

        //###########################################################################

        private static void SetInitialValues()
        {
            //if (!DONT_RELOAD_IF_TOGGLE_CHANGED)
            //{
                Loader.Set_Original_Bin();
                Log.Save_Logs = Save_Logs;
                Log.Adv_Logs = Adv_Logs;
                Extractor.Patch_4kRPM_Hondata = Patch_4kRPM_Hondata;
                Extractor.Patch_Hondata_Chip_Lock = Patch_Hondata_Chip_Lock;

                SaveSettings();
            //}
        }
        
        public static void LoadSettings()
        {
            string Whole_File = File.ReadAllText(Settings_Path);
            string[] Splited_File = Whole_File.Split('\n');
            
            for (int i = 0; i < Splited_File.Length; i++)
            {
                try
                {
                    if (Splited_File[i] != "")
                    {
                        if (Splited_File[i].Contains("="))
                        {
                            //Split 'Setting Name' and 'Settings Values'
                            string[] Whole_Splited_File = Splited_File[i].Split("="[0]);

                            //Set Settings
                            if (i == 0)
                            {
                                Save_Logs = bool.Parse(Whole_Splited_File[1]);
                                //SaveLog_Toggle.isOn = Save_Logs;
                                Log.Save_Logs = Save_Logs;
                            }
                            else if (i == 1)
                            {
                                Adv_Logs = bool.Parse(Whole_Splited_File[1]);
                                //AdvMode_Toggle.isOn = AdvMode;
                                Log.Adv_Logs = Adv_Logs;
                            }
                            else if (i == 2)
                            {
                                Ectune_Baserom = Whole_Splited_File[1];
                                //BaseromVersion_Text.text = BaseromVersion;
                                Loader.Set_Original_Bin();
                            }
                            else if (i == 3)
                            {
                                Patch_4kRPM_Hondata = bool.Parse(Whole_Splited_File[1]);
                                Extractor.Patch_4kRPM_Hondata = Patch_4kRPM_Hondata;
                            }
                            else if (i == 4)
                            {
                                //Patch_Hondata_Chip_Lock = bool.Parse(Whole_Splited_File[1]);
                                Patch_Hondata_Chip_Lock = false;
                                Extractor.Patch_Hondata_Chip_Lock = Patch_Hondata_Chip_Lock;
                            }
                            /*else if (i == 2)
                            {
                                AutoSave = bool.Parse(Whole_Splited_File[1]);
                                //AutoSave_Toggle.isOn = AutoSave;
                                File_Converter.AutoSave = AutoSave;
                            }
                            else if (i == 3)*/
                        }
                    }
                }
                catch (Exception message)
                {
                    Log.Log_This("Error while loading Settings:\n" + message, false);
                }
            }
        }

        public static void SaveSettings()
        {
            string Settings_Txt = "";
            Settings_Txt = Settings_Txt + "Save_Logs=" + Save_Logs.ToString() + "\n";
            Settings_Txt = Settings_Txt + "Advanced_Logs=" + Adv_Logs.ToString() + "\n";
            Settings_Txt = Settings_Txt + "Ectune_Baserom=" + Ectune_Baserom + "\n";
            Settings_Txt = Settings_Txt + "Patch_4kRPM_Hondata=" + Patch_4kRPM_Hondata.ToString() + "\n";
            Settings_Txt = Settings_Txt + "Patch_Hondata_Chip_Lock=" + Patch_Hondata_Chip_Lock.ToString() + "\n";
            //Settings_Txt = Settings_Txt + "AutoSave=" + AutoSave.ToString() + "\n";

            File.Create(Settings_Path).Dispose();
            File.WriteAllText(Settings_Path, Settings_Txt);
        }
    }
}
