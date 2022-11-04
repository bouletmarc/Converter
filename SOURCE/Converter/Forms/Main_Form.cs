using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Converter
{
    public partial class Main_Form : Form
    {

        public static Main_Form Main;
        private System.Windows.Forms.Timer LoadTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer RTPTimer = new System.Windows.Forms.Timer();
        public bool Loading = true;

        public bool IsRTP = false;
        public long RTPLocation = 0;
        public byte[] CurrentRTPBytes = new byte[] { };
        public byte[] LastUploadedBytes = new byte[] { };

        public Main_Form()
        {
            Main = this;

            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            ShowRTPMenu(false);
            textBox1.Text = "No location selected!";
            groupBox2.Enabled = false;

            LoadTimer.Interval = 1;
            LoadTimer.Tick += LoadingThread;
            LoadTimer.Start();

            RTPTimer.Interval = 15000;
            RTPTimer.Tick += RTPThread;
            RTPTimer.Start();
        }

        void LoadingThread(object sender, EventArgs e)
        {
            LoadTimer.Stop();
            Loader.Load();
            ServerManager.CheckConnectionToGithub();
        }

        void RTPThread(object sender, EventArgs e)
        {
            if (!LiscenceEnabled) {
                if (IsRTP && RTPLocation != 0)
                {
                    if (comboBox1.SelectedIndex == 0) Extractor.Extract("SManager", true);
                    if (comboBox1.SelectedIndex == 1) Extractor.Extract("Neptune RTP", true);

                    if (CurrentRTPBytes.Length == 32768)
                    {
                        if (!Serial.Connected)
                        {
                            Log.Log_This("Not connected to any RTP Device, trying to connect", false);
                            Serial.SerialConnect();
                        }

                        if (Serial.Connected)
                        {
                            bool WasSame = true;

                            if (LastUploadedBytes.Length == 0 || LastUploadedBytes.Length < 32768)
                            {
                                WasSame = false;
                                File_Converter.Bin_File = CurrentRTPBytes;
                                Serial.Mode = "Write";
                                Serial.Press_Commands();
                                LastUploadedBytes = CurrentRTPBytes;
                            }

                            for (int i = 0; i < CurrentRTPBytes.Length; i++)
                            {
                                try
                                {
                                    if (LastUploadedBytes[i] != CurrentRTPBytes[i])
                                    {
                                        WasSame = false;
                                        Serial.Send1Byte(i, CurrentRTPBytes[i]);
                                        LastUploadedBytes[i] = CurrentRTPBytes[i];
                                    }
                                }
                                catch { }
                            }
                            if (WasSame)
                            {
                                Log.Log_This("Bytes didn't get updated during this check", false);
                            }
                        }
                    }
                }
            }
        }

        public void CloseApp()
        {
            Environment.Exit(0);
        }

        public void AddRTPLocation(long Location)
        {
            bool IsIncluded = false;
            if (listBox1.Items.Count > 0) for(int i = 0; i < listBox1.Items.Count; i++) if (listBox1.Items[i].ToString() == "0x" + Location.ToString("X2")) IsIncluded = true;
            if (!IsIncluded) listBox1.Items.Add("0x" + Location.ToString("X2"));
        }

        public void ClearRTPLocation()
        {
            listBox1.Items.Clear();
        }

        private void Main_Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serial.SerialDisconnect();
            Application.Exit();
        }

        private void Load_Button_Click(object sender, EventArgs e)
        {
            this.Open_File_Form.Filter = "Tuning Files (*.cal, *bin)|*.cal; *bin";
            DialogResult result = Open_File_Form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Log.Log_This("--------------------------------------------------------------------------------------", false);

                Loader.Current_File = Path.GetFileName(Open_File_Form.FileName);
                string Ext = Loader.Current_File.Substring(Loader.Current_File.Length - 3);
                byte[] This_File = File.ReadAllBytes(Open_File_Form.FileName);

                //Reset Buttons
                SaveCalEnabled = false;
                SaveBinEnabled = false;
                EditEnabled = false;
                Progress = 0;

                //Check Ext and Apply bytes
                if (Ext == "cal")
                {
                    Loader.Mode = "Cal";
                    File_Converter.Cal_File = This_File;
                }
                else if (Ext == "bin")
                {
                    Loader.Mode = "Bin";
                    if (This_File[528] == 16) Loader.Mode = "Neptune";
                    File_Converter.Bin_File = This_File;
                }

                Main.InfosText = "LOADING FILE INFOS";
                Log.Log_This("Loaded : " + Loader.Current_File, false);
                
                File_Converter.Convert_File();
            }
        }

        private void Extract_Button_Click(object sender, EventArgs e)
        {
            if (Extractor.Extract("Neptune RTP", false))
            {
                if (!LiscenceEnabled)
                {
                    ShowRTPMenu(true);
                }

                this.Open_File_Form.Filter = "Neptune RTP Files|*bin";
                this.Open_File_Form.InitialDirectory = Loader.File_Path + "RTP\\";
                DialogResult result = Open_File_Form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Log.Log_This("--------------------------------------------------------------------------------------", false);

                    Loader.Current_File = Path.GetFileName(Open_File_Form.FileName);
                    string Ext = Loader.Current_File.Substring(Loader.Current_File.Length - 3);
                    byte[] This_File = File.ReadAllBytes(Open_File_Form.FileName);

                    //Reset Buttons
                    SaveCalEnabled = false;
                    SaveBinEnabled = false;
                    EditEnabled = false;
                    Progress = 0;

                    //Check Ext and Apply bytes
                    if (Ext == "cal")
                    {
                        Loader.Mode = "Cal";
                        File_Converter.Cal_File = This_File;
                    }
                    else if (Ext == "bin")
                    {
                        Loader.Mode = "Bin";
                        if (This_File[528] == 16) Loader.Mode = "Neptune";
                        File_Converter.Bin_File = This_File;
                    }

                    Main.InfosText = "LOADING FILE INFOS";
                    Log.Log_This("Loaded : " + Loader.Current_File, false);

                    File_Converter.Convert_File();
                }
            }
        }

        public void ShowRTPMenu(bool Show)
        {
            //376 470
            //604 470
            if (Show)
            {
                this.Size = new Size(604, 470);
            }
            else
            {
                this.Size = new Size(376, 470);
            }
        }


        private void extractSManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Extractor.Extract("SManager", false))
            {
                if (!LiscenceEnabled)
                {
                    ShowRTPMenu(true);
                }
                try
                {
                    Process.Start(Loader.File_Path + "SManager\\");
                }
                catch { }
            }
        }

        private void SaveCal_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = Save_File_Cal_Form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Saver.Path = Save_File_Cal_Form.FileName;
                Saver.SaveBytes = File_Converter.Cal_File;
                Saver.Save();
            }
        }

        private void SaveBin_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = Save_File_Bin_Form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Saver.Path = Save_File_Bin_Form.FileName;
                Saver.SaveBytes = File_Converter.Bin_File;
                Saver.Save();
            }
        }

        private void Download_Button_Click(object sender, EventArgs e)
        {
            Download_Form This_Form = new Download_Form();
            This_Form.ShowDialog();
        }

        private void Settings_Button_Click(object sender, EventArgs e)
        {
            Settings_Form This_Form = new Settings_Form();
            This_Form.ShowDialog();
        }

        private void Connect_Button_Click(object sender, EventArgs e)
        {
            Serial.SerialConnect();
        }

        private void Disconnect_Button_Click(object sender, EventArgs e)
        {
            Serial.SerialDisconnect();
        }

        private void Read_Button_Click(object sender, EventArgs e)
        {
            Serial.Mode = "Read";
            Serial.Press_Commands();
        }

        private void Write_Button_Click(object sender, EventArgs e)
        {
            Serial.Mode = "Write";
            Serial.Press_Commands();
            LastUploadedBytes = File_Converter.Bin_File;
        }

        private void Verify_Button_Click(object sender, EventArgs e)
        {
            Serial.Mode = "Verify";
            Serial.Press_Commands();
        }

        private void Liscence_Button_Click(object sender, EventArgs e)
        {
            Liscence_Form This_Form = new Liscence_Form();
            This_Form.ShowDialog();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            Edit_Form This_Form = new Edit_Form();
            This_Form.ShowDialog();
        }

        private void Liscence_Button_Click_1(object sender, EventArgs e)
        {
            Liscence_Form This_Form = new Liscence_Form();
            This_Form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log.SaveFullLogs();
        }

        private void Chips_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Serial.SetChips(Chips_ComboBox.Text);
        }

        private void New_Button_Click(object sender, EventArgs e)
        {
            New_Form This_Form = new New_Form();
            This_Form.ShowDialog();
        }

        public void Show_Ban()
        {
            Ban_Form This_Form = new Ban_Form();
            This_Form.ShowDialog();
            Serial.SerialDisconnect();
            Application.Exit();
            this.Close();
        }
        //####################################################################################################
        //Inside Menu
        public string VersionText
        {
            get { return Version_Label.Text; }
            set { Version_Label.Text = value; }
        }

        public string RegisterText
        {
            get { return Register_Label.Text; }
            set { Register_Label.Text = value; }
        }

        public Color RegisterColor
        {
            get { return Register_Label.ForeColor; }
            set { Register_Label.ForeColor = value; }
        }

        public string ConvertDoneText
        {
            get { return ConvertDone_Label.Text; }
            set { ConvertDone_Label.Text = value; }
        }

        public bool ConvertDoneVisible
        {
            get { return ConvertDone_Label.Visible; }
            set { ConvertDone_Label.Visible = value; }
        }

        public string InfosText
        {
            get { return Infos_TextBox.Text; }
            set { Infos_TextBox.Text = value; }
        }

        public string LogsText
        {
            get { return Logs_TextBox.Text; }
            set { Logs_TextBox.AppendText(value); Logs_TextBox.AppendText(Environment.NewLine); }
        }

        public int Progress
        {
            get { return Progress_Bar.Value; }
            set { Progress_Bar.Value = value; }
        }

        //####################################################################################################
        //File Menu
        public bool EditEnabled
        {
            get { return Edit_Button.Enabled; }
            set { Edit_Button.Enabled = value; }
        }

        public bool SaveCalEnabled
        {
            get { return SaveCal_Button.Enabled; }
            set { SaveCal_Button.Enabled = value; }
        }

        public bool SaveBinEnabled
        {
            get { return SaveBin_Button.Enabled; }
            set { SaveBin_Button.Enabled = value; }
        }

        public bool DownloadEnabled
        {
            get { return Download_Button.Enabled; }
            set { Download_Button.Enabled = value; }
        }

        public string DownloadText
        {
            get { return Download_Button.Text; }
            set { Download_Button.Text = value; }
        }

        //####################################################################################################
        //Moates Menu
        public bool ConnectEnabled
        {
            get { return Connect_Button.Enabled; }
            set { Connect_Button.Enabled = value; }
        }

        public bool DisconnectEnabled
        {
            get { return Disconnect_Button.Enabled; }
            set { Disconnect_Button.Enabled = value; }
        }

        public bool ReadEnabled
        {
            get { return Read_Button.Enabled; }
            set { Read_Button.Enabled = value; }
        }

        public bool WriteEnabled
        {
            get { return Write_Button.Enabled; }
            set { Write_Button.Enabled = value; }
        }

        public bool VerifyEnabled
        {
            get { return Verify_Button.Enabled; }
            set { Verify_Button.Enabled = value; }
        }

        public bool Set_ChipsEnabled
        {
            get { return Set_Chips_Button.Enabled; }
            set { Set_Chips_Button.Enabled = value; }
        }

        //####################################################################################################
        //Liscence
        public bool LiscenceEnabled
        {
            get { return Liscence_Button.Enabled; }
            set { Liscence_Button.Enabled = value; }
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serial.SerialDisconnect();
        }

        private void openFlashBurnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\BM Devs Flash&Burn.exe");
            }
            catch
            {
                Log.Log_This("CAN'T Start 'FlashNBurn' ... File possibly deleted", false);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IsRTP = checkBox1.Checked;
            groupBox2.Enabled = IsRTP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) Extractor.Extract("SManager", false);
            if (comboBox1.SelectedIndex == 1) Extractor.Extract("Neptune RTP", false);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text;
            try
            {
                RTPLocation = long.Parse(textBox1.Text.Substring(2), System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                Log.Log_This("CAN'T set RTP Loction correctly!", false);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "0") textBox2.Text = "1";
            try
            {
                RTPTimer.Interval = int.Parse(textBox2.Text) * 1000;
            }
            catch
            {
                RTPTimer.Interval = 5000;
            }
        }
    }
}
