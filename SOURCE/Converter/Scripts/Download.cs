using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Converter
{
    public static class Download
    {
        public static string Github_File_List = "https://raw.githubusercontent.com/bouletmarc/eCtune_Files/master/Files_List.txt";
        public static string Github_File_Location = "https://raw.githubusercontent.com/bouletmarc/eCtune_Files/master/Files/";
        public static List<string> Github_fileNames = new List<string>();
        public static List<string> Github_fileNames_BSerie = new List<string>();
        public static List<string> Github_fileNames_DSerie = new List<string>();
        public static List<string> Github_fileNames_FSerie = new List<string>();
        public static List<string> Github_fileNames_HSerie = new List<string>();
        public static List<string> Github_fileNames_Unknown = new List<string>();

        public static byte[] Download_File;

        public static void GetGithubFiles()
        {
            try
            {
                string Github_Text_Down = (new WebClient()).DownloadString(Github_File_List);

                Github_fileNames.Clear();
                Github_fileNames_BSerie.Clear();
                Github_fileNames_DSerie.Clear();
                Github_fileNames_FSerie.Clear();
                Github_fileNames_HSerie.Clear();
                Github_fileNames_Unknown.Clear();

                while (Github_Text_Down.Contains("|"))
                {
                    int Index = Github_Text_Down.IndexOf("|");
                    string ThisStrName = Github_Text_Down.Substring(0, Index);
                    
                    Github_fileNames.Add(ThisStrName);

                    //Get Categories
                    Github_Text_Down = Github_Text_Down.Substring(Index + 1);
                    Index = Github_Text_Down.IndexOf("|");
                    string ThisStrEngine = Github_Text_Down.Substring(0, Index);

                    //Set Categories
                    if (ThisStrEngine == "B-Serie")
                        Github_fileNames_BSerie.Add(ThisStrName);
                    else if (ThisStrEngine == "D-Serie")
                        Github_fileNames_DSerie.Add(ThisStrName);
                    else if (ThisStrEngine == "F-Serie")
                        Github_fileNames_FSerie.Add(ThisStrName);
                    else if (ThisStrEngine == "H-Serie")
                        Github_fileNames_HSerie.Add(ThisStrName);
                    else if (ThisStrEngine == "Unknown")
                        Github_fileNames_Unknown.Add(ThisStrName);
                    
                    Github_Text_Down = Github_Text_Down.Substring(Index + 3);
                }
                
                Main_Form.Main.DownloadText = "Download .cal (" + Github_fileNames.Count + ")";
            }
            catch { }
        }

        public static void SetPage()
        {
            Download_Form.D_Form.Clear_Files();

            if (Download_Form.D_Form.Category == "All")
            {
                for (int i = 0; i < Github_fileNames.Count; i++)
                    Download_Form.D_Form.Add_File = Github_fileNames[i];

                Download_Form.D_Form.Set_File = Github_fileNames[0];
            }
            else if (Download_Form.D_Form.Category == "B-Serie")
            {
                for (int i = 0; i < Github_fileNames_BSerie.Count; i++)
                    Download_Form.D_Form.Add_File = Github_fileNames_BSerie[i];

                Download_Form.D_Form.Set_File = Github_fileNames_BSerie[0];
            }
            else if (Download_Form.D_Form.Category == "D-Serie")
            {
                for (int i = 0; i < Github_fileNames_DSerie.Count; i++)
                    Download_Form.D_Form.Add_File = Github_fileNames_DSerie[i];

                Download_Form.D_Form.Set_File = Github_fileNames_DSerie[0];
            }
            else if (Download_Form.D_Form.Category == "F-Serie")
            {
                for (int i = 0; i < Github_fileNames_FSerie.Count; i++)
                    Download_Form.D_Form.Add_File = Github_fileNames_FSerie[i];

                Download_Form.D_Form.Set_File = Github_fileNames_FSerie[0];
            }
            else if (Download_Form.D_Form.Category == "H-Serie")
            {
                for (int i = 0; i < Github_fileNames_HSerie.Count; i++)
                    Download_Form.D_Form.Add_File = Github_fileNames_HSerie[i];

                Download_Form.D_Form.Set_File = Github_fileNames_HSerie[0];
            }
            else if (Download_Form.D_Form.Category == "Unknown")
            {
                for (int i = 0; i < Github_fileNames_Unknown.Count; i++)
                    Download_Form.D_Form.Add_File = Github_fileNames_Unknown[i];

                Download_Form.D_Form.Set_File = Github_fileNames_Unknown[0];
            }
        }

        public static bool LoadFile()
        {
            bool Received = false;
            try
            {
                Download_File = (new WebClient()).DownloadData(Github_File_Location + Download_Form.D_Form.Set_File);
                Log.Log_This("Downloaded : " + Download_Form.D_Form.Set_File, false);
                Received = true;
            }
            catch { }

            return Received;
        }

    }
}
