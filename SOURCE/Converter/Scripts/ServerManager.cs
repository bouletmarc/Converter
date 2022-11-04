using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public static class ServerManager
    {
        public static string Github_Text = "";
        public static string Github_Get_Url = "https://raw.githubusercontent.com/bouletmarc/Converter/master/";
        public static string Github_Download_Url = "https://github.com/bouletmarc/Converter/raw/master/";
        public static List<string> Filelist = new List<string>();
        public static bool Github_Connected = false;

        public static void CheckConnectionToGithub()
        {
            Github_Connected = false;
            try
            {
                string OnlineVersion = (new WebClient()).DownloadString(Github_Get_Url + "Files/Version.txt");
                if (OnlineVersion != Loader.VersionT)
                    GitUpdate();

                //if passing thru there, this mean is updated
                Log.Log_This("Converter is UPDATED !", false);

                if (!Github_Connected)
                    Github_Connected = true;

                if (Loader.C)
                    Main_Form.Main.DownloadEnabled = true;

                Download.GetGithubFiles();
            }
            catch { Log.Log_This("CAN'T check for Updates !", false); }
        }

        private static void GitUpdate()
        {
            Log.Log_This("Updating...", false);
            Filelist.Clear();

            try
            {
                string FilelistOnlineFULL = (new WebClient()).DownloadString(Github_Get_Url + "Files/FileList.txt");

                if (FilelistOnlineFULL.Contains("\n"))
                {
                    string[] Splited_File = FilelistOnlineFULL.Split('\n');
                    for (int i = 0; i < Splited_File.Length; i++)
                        Filelist.Add(Splited_File[i]);
                }
                else
                    Filelist.Add(FilelistOnlineFULL);

                for (int i=0; i < Filelist.Count; i++)
                {
                    if (Filelist[i] != "Converter.exe")
                    {
                        Log.Log_This("Updating file (" + (i + 1) + "/" + Filelist.Count + ") : " + Filelist[i], false);
                        GetGithubFile(Filelist[i]);
                    }
                }
                
                UpdateSelf();
            }
            catch
            { Log.Log_This("UNABLE TO DOWNLOAD FILE", false); }
        }

        private static void GetGithubFile(string ThisFile)
        {
            try
            {
                Log.Log_This("Trying to download file:\n" + Github_Get_Url + ThisFile, false);
                byte[] ThisBytes = (new WebClient()).DownloadData(Github_Get_Url + ThisFile);
                string path = Environment.CurrentDirectory + "\\" + ThisFile;
                string FolderPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(FolderPath);
                
                File.Create(path).Dispose();
                File.WriteAllBytes(path, ThisBytes);
            }
            catch
            { Log.Log_This("UNABLE TO DOWNLOAD FILE", false); }
        }

        private static void UpdateSelf()
        {
            string self = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string selfFileName = Path.GetFileName(self);
            string selfWithoutExt = Path.Combine(Path.GetDirectoryName(self), Path.GetFileNameWithoutExtension(self));
            byte[] ThisBytes = (new WebClient()).DownloadData(Github_Get_Url + "Converter.exe");

            File.Create(selfWithoutExt + "Update.exe").Dispose();
            File.WriteAllBytes(selfWithoutExt + "Update.exe", ThisBytes);

            string BatStr = "@ECHO OFF" + Environment.NewLine;
            BatStr += "TIMEOUT /t 1 /nobreak > NUL" + Environment.NewLine;
            BatStr += "TASKKILL /IM \"" + selfFileName + "\" > NUL" + Environment.NewLine;
            BatStr += "MOVE \"" + selfWithoutExt + "Update.exe\" \"" + self + "\"" + Environment.NewLine;
            BatStr += "DEL \"%~f0\" & START \"\" /B \"" + self + "\"" + Environment.NewLine;
            File.Create(selfWithoutExt + "Update.bat").Dispose();
            File.WriteAllText(selfWithoutExt + "Update.bat", BatStr);

            ProcessStartInfo startInfo = new ProcessStartInfo(selfWithoutExt + "Update.bat");
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = Path.GetDirectoryName(self);
            Process.Start(startInfo);

            Environment.Exit(0);
        }

    }
}
