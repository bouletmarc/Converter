using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Collections.Generic;

namespace Updater
{
    partial class Main_Form
    {
        public string Github_Get_Url = "https://raw.githubusercontent.com/bouletmarc/Converter/master/";
        public string Github_Download_Url = "https://github.com/bouletmarc/Converter/raw/master/";
        public List<string> Filelist = new List<string>();

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Desc_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCyan;
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Updating Converter";
            // 
            // Desc_Label
            // 
            this.Desc_Label.AutoSize = true;
            this.Desc_Label.Location = new System.Drawing.Point(33, 61);
            this.Desc_Label.Name = "Desc_Label";
            this.Desc_Label.Size = new System.Drawing.Size(119, 13);
            this.Desc_Label.TabIndex = 1;
            this.Desc_Label.Text = "Connecting to Github ...";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.Controls.Add(this.Desc_Label);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main_Form";
            this.Text = "Converter - Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool Load()
        {
            bool CanClose = false;
            string Save_Path = Environment.CurrentDirectory + "\\";
            string Converter_Version = File.ReadAllText(Environment.CurrentDirectory + "/Files/Version.txt");
            string Updater_Version = File.ReadAllText(Environment.CurrentDirectory + "/Files/Updater_Version.txt");
            Filelist.Clear();

            try
            {
                string Online_Converter_Version = (new WebClient()).DownloadString(Github_Get_Url + "Files/Version.txt");
                string Online_Updater_Version = (new WebClient()).DownloadString(Github_Get_Url + "Files/Updater_Version.txt");
                string File_List_Full = (new WebClient()).DownloadString(Github_Get_Url + "Files/FileList.txt");

                if (Online_Updater_Version == Updater_Version)
                {
                    if (Online_Converter_Version != Converter_Version)
                    {
                        Main_Form.Main.DescText = "Updating to version : " + Online_Converter_Version;

                        //Add File List
                        if (File_List_Full.Contains("\n"))
                        {
                            string[] Splited_File = File_List_Full.Split('\n');
                            for (int i = 0; i < Splited_File.Length; i++)
                                Filelist.Add(Splited_File[i]);
                        }
                        else
                            Filelist.Add(File_List_Full);

                        //Download
                        int Index = 0;
                        while (Index < Filelist.Count)
                        {
                            GetGithubFile(Filelist[Index]);
                            Main_Form.Main.DescText = "Updating file (" + (Index + 1) + "/" + Filelist.Count + ") : " + Filelist[Index];
                            Console.WriteLine("Updating file (" + (Index + 1) + "/" + Filelist.Count + ") : " + Filelist[Index]);
                            Index++;
                        }

                        //File.Create(Environment.CurrentDirectory + "\\Files\\Version.txt").Dispose();
                        //File.WriteAllText(Environment.CurrentDirectory + "\\Files\\Version.txt", Online_Converter_Version);

                        Main_Form.Main.DescText = "UPDATED TO " + Online_Converter_Version;
                        Process p = new Process();
                        p.StartInfo.FileName = Environment.CurrentDirectory + "\\Converter.exe";
                        p.Start();
                        CanClose = true;
                    }
                    else
                    {
                        Main_Form.Main.DescText = "ALREADY UPDATED TO " + Online_Converter_Version;
                        Process p = new Process();
                        p.StartInfo.FileName = Environment.CurrentDirectory + "\\Converter.exe";
                        p.Start();
                        CanClose = true;
                    }
                }
                else
                {
                    Main_Form.Main.DescText = "Updater.exe need to update";
                }
            }
            catch
            {
                Main_Form.Main.DescText = "Connection Unavailable to Github";
            }

            return CanClose;
        }

        private void GetGithubFile(string ThisFile)
        {
            try
            {
                byte[] ThisBytes = (new WebClient()).DownloadData(Github_Download_Url + ThisFile);
                string path = Environment.CurrentDirectory + "\\" + ThisFile;
                string FolderPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(FolderPath);

                File.Create(path).Dispose();
                File.WriteAllBytes(path, ThisBytes);
            }
            catch { Console.WriteLine("UNABLE TO DOWNLOAD FILE"); }
        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Desc_Label;
    }
}

