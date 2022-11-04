using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Converter
{
    public partial class Download_Form : Form
    {
        public static Download_Form D_Form;
        public Download_Form()
        {
            InitializeComponent();
            D_Form = this;

            Download.SetPage();
        }

        public string Category
        {
            get { return this.comboBox1.Text; }
        }

        public string Add_File
        {
            set { this.comboBox2.Items.Add(value); }
        }

        public string Set_File
        {
            get { return this.comboBox2.Text; }
            set { this.comboBox2.Text = value; }
        }

        /*public int Progress
        {
            get { return this.progressBar1.Value; }
            set { this.progressBar1.Value = value; }
        }*/

        public void Clear_Files()
        {
            this.comboBox2.Text = "";
            this.comboBox2.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Download.LoadFile())
            {
                this.saveFileDialog1.FileName = D_Form.Set_File;
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = this.saveFileDialog1.FileName;

                    File.Create(path).Dispose();
                    File.WriteAllBytes(path, Download.Download_File);

                    Log.Log_This("--------------------------------------------------------------------------------------", false);
                    Log.Log_This("File Saved at :", false);
                    Log.Log_This(path, false);
                }
            } else
            {
                Log.Log_This("Unable to download requested file", false);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Download.SetPage();
        }
    }
}
