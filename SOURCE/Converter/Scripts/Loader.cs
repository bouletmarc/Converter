using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Converter
{
    public static class Loader
    {
        public static string VersionT = "V7.1.0\n"; 


        public static string Current_File = "";
        //public static string Software = "";
        public static string Mode = "";
        private static string Ectune_Basemap_Filename = "eCt.base273.";

        //Set Computer Variables
        public static string CPU_Name = System.Environment.UserName;
        //public static string CPU_IP = "";
        public static string CPU_Windows = GetWindows();
        public static string CPU_Drive = Path.GetPathRoot(Environment.SystemDirectory);
        public static string CPU_HWID = getUniqueID(CPU_Drive.Substring(0, 1));

        public static string File_Path = Environment.CurrentDirectory + "\\Files\\";

        public static bool C = false;
        public static int C2 = 0;
        public static bool C3 = false;

        //####################################################################################
        //####################################################################################
        
        public static void Load() {
            Main_Form.Main.VersionText = VersionT;
            Main_Form.Main.Text = "Converter Interface - " + VersionT;

            RemoveOld();

            CT();

            Load_Settings_File("DO_NOT_EDIT.cal");
            Load_Settings_File("DO_NOT_EDIT.bin");

            //CheckIP();
            
            Settings.Load();
            //Chk();

            //Log.Log_This("--------------------------------------------------------------------------------------", false);
        }

        //####################################################################################
        //####################################################################################

        private static void RemoveOld()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\Updater.exe"))
                File.Delete(Environment.CurrentDirectory + "\\Updater.exe");
            if (File.Exists(File_Path + "\\Updater_Version.txt"))
                File.Delete(File_Path + "\\Updater_Version.txt");
        }

        private static string getUniqueID(string drive)
        {
            if (drive.EndsWith(":\\")) drive = drive.Substring(0, drive.Length - 2);
            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private static string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();
            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();
            return volumeSerial;
        }

        private static string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();
            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        private static string GetWindows()
        {
            string This = "";
            if (Environment.OSVersion.Version.Major <= 5)
                This = "XP";
            else if (Environment.OSVersion.Version.Major >= 6)
                This = "10";
            return This;
        }

        /*private static void Chk()
        {
            List<string> BL = new List<string>();
            BL.Add("190.203.193.54");
            BL.Add("72.27.212.58");
            BL.Add("186.94.222.62");
            BL.Add("201.242.75.130");
            //BL.Add("69.24.61.24");

            for (int i = 0; i < BL.Count; i++)
                if (CPU_IP == BL[i])
                    Main_Form.Main.Show_Ban();
        }*/

        /*private static void CheckIP()
        {
            try
            {
                string WholeText = (new WebClient()).DownloadString("http://get-ip.me/");
                CPU_IP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches(WholeText)[0].ToString();
            }
            catch { }
        }*/

        public static void Set_Original_Bin()
        {
            Ectune_Basemap_Filename = "eCt.base273." + Settings.Ectune_Baserom + ".bin";
            Mode = "";
            Load_Settings_File(Ectune_Basemap_Filename);
        }

        private static void Load_Settings_File(string filename)
        {
            byte[] This_File = File.ReadAllBytes(File_Path + filename);

            if (filename == Ectune_Basemap_Filename)
                File_Converter.Bin_File = This_File;
            else if (filename == "DO_NOT_EDIT.cal") //Cal_Original_Filename
                File_Converter.Cal_File = This_File;
            else if (filename == "DO_NOT_EDIT.bin") //NBin_Original_Filename
                File_Converter.Original_NBin_File = This_File;

            Log.Log_This("Loaded : " + filename, false);
        }


        public static void CT()
        {
            RegistryKey key;
            if (Registry.CurrentUser.OpenSubKey(G("7B978E9C9F899A8D84846B7E7C7A")) == null) key = Registry.CurrentUser.CreateSubKey(G("7B978E9C9F899A8D84846B7E7C7A"));
            
            string P = CPU_Drive + G("7D9B8D9A9B57") + CPU_Name + G("576B8998");
            if (CPU_Windows == "XP") P = CPU_Drive + G("6C978B9D958D969C9B4889968C487B8D9C9C91968F9B57") + CPU_Name + G("576B8998");
            P = P.Replace("/", "\\");
            if (File.Exists(P)) {
                string FS = File.ReadAllText(P);
                if (FS.Length == 19 && FS == CPU_HWID) C = true;
                if (FS.Length != 19) C2 = int.Parse(FS);
                Registry.SetValue(Loader.G("70736D81876B7D7A7A6D767C877D7B6D7A847B978E9C9F899A8D846B7E7C7A"), Loader.G("746B6C"), Loader.C.ToString(), RegistryValueKind.String);
                Registry.SetValue(Loader.G("70736D81876B7D7A7A6D767C877D7B6D7A847B978E9C9F899A8D846B7E7C7A"), Loader.G("74757C"), Loader.C2.ToString(), RegistryValueKind.String);
                File.Delete(P);
            }

            try { C2 = int.Parse(Registry.GetValue(Loader.G("70736D81876B7D7A7A6D767C877D7B6D7A847B978E9C9F899A8D846B7E7C7A"), Loader.G("74757C"), 0).ToString());
            } catch (Exception) { C2 = 0; }
            try { C = bool.Parse(Registry.GetValue(Loader.G("70736D81876B7D7A7A6D767C877D7B6D7A847B978E9C9F899A8D846B7E7C7A"), Loader.G("746B6C"), 0).ToString());
            } catch(Exception) { C = false; }

            if (C)
            {
                Main_Form.Main.RegisterText = Loader.G("7A6D6F717B7C6D7A6D6C");
                Main_Form.Main.RegisterColor = System.Drawing.Color.Lime;
                Main_Form.Main.ConvertDoneVisible = false;
                Main_Form.Main.LiscenceEnabled = false;
            }
            else
            {
                Main_Form.Main.ConnectEnabled = false;
                Main_Form.Main.EditEnabled = false;
                Main_Form.Main.DownloadEnabled = false;
                Main_Form.Main.ConvertDoneText = Loader.G("6B97969E8D9A9C486C97968D486248") + C2;
                if (int.Parse(C2.ToString()) >= (((((43 + 44) + 9) / 2) - 43) * 2)) C3 = true;
            }
        }

        public static string G(string T)
        {
            string L = T;
            string R = "";
            while (L != "")
            {
                int This = Int32.Parse(L.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier) - ((((40 * 4) / 2) * 4) / 8);
                if (This < 0) This = 256 + This;
                R += Convert.ToChar(This).ToString();
                L = L.Substring(2);
            }
            return R;
        }
    }
}
