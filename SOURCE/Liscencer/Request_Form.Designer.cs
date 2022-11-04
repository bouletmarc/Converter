using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Management;

namespace Liscencer
{
    partial class Request_Form
    {
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
            this.button1 = new System.Windows.Forms.Button();
            this.Email_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HWID_TextBox = new System.Windows.Forms.TextBox();
            this.Infos_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(52, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "SEND EMAIL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Email_TextBox
            // 
            this.Email_TextBox.Location = new System.Drawing.Point(102, 48);
            this.Email_TextBox.Name = "Email_TextBox";
            this.Email_TextBox.Size = new System.Drawing.Size(172, 20);
            this.Email_TextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Registered Email :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Hardware ID :";
            // 
            // HWID_TextBox
            // 
            this.HWID_TextBox.Enabled = false;
            this.HWID_TextBox.Location = new System.Drawing.Point(102, 71);
            this.HWID_TextBox.MaxLength = 19;
            this.HWID_TextBox.Name = "HWID_TextBox";
            this.HWID_TextBox.ReadOnly = true;
            this.HWID_TextBox.Size = new System.Drawing.Size(172, 20);
            this.HWID_TextBox.TabIndex = 3;
            // 
            // Infos_TextBox
            // 
            this.Infos_TextBox.AcceptsReturn = true;
            this.Infos_TextBox.AcceptsTab = true;
            this.Infos_TextBox.AllowDrop = true;
            this.Infos_TextBox.Location = new System.Drawing.Point(14, 120);
            this.Infos_TextBox.Multiline = true;
            this.Infos_TextBox.Name = "Infos_TextBox";
            this.Infos_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Infos_TextBox.Size = new System.Drawing.Size(260, 80);
            this.Infos_TextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightCyan;
            this.label3.Location = new System.Drawing.Point(38, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Add Personal Message :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightCyan;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "REQUEST NEW HARDWARD ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(12, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Unable to send email";
            // 
            // Request_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(284, 277);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Infos_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HWID_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Email_TextBox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Request_Form";
            this.Text = "Converter - Request New HWID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Load()
        {
            this.HWID_TextBox.Text = getUniqueID(Path.GetPathRoot(Environment.SystemDirectory).Substring(0, 1));
            this.label5.Text = "";
        }

        private void Send()
        {
            if (this.Email_TextBox.Text.Contains("@") & this.Email_TextBox.Text.Length > 6 & this.Email_TextBox.Text.Contains("."))
            {
                try
                {
                    string Subject = System.Environment.UserName + " Request a new HWID";
                    string MessageEmail = "";
                    MessageEmail += System.Environment.UserName + " Requesting this :";
                    MessageEmail += "\nHWID : " + getUniqueID(Path.GetPathRoot(Environment.SystemDirectory).Substring(0, 1));
                    MessageEmail += "\nEMAIL : " + this.Email_TextBox.Text;
                    MessageEmail += "\nMESSAGE :\n" + this.Infos_TextBox.Text;

                    //##########################
                    //###### YOU CAN TRY  ######
                    //##########################
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("bmectune@gmail.com");
                    mail.To.Add("bouletmarc@hotmail.com");
                    mail.Subject = Subject;
                    mail.Body = MessageEmail;

                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                    smtpServer.Port = 587;
                    smtpServer.EnableSsl = true;
                    smtpServer.UseDefaultCredentials = false;
                    smtpServer.Credentials = new System.Net.NetworkCredential("bmectune@gmail.com", "Converter") as ICredentialsByHost;
                    ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };

                    smtpServer.Timeout = 20000;
                    smtpServer.Send(mail);

                    this.label5.Text = "Email Sent with SUCCESS !";
                    this.label5.ForeColor = System.Drawing.Color.Lime;
                }
                catch
                {
                    this.label5.Text = "Unable to send Email !";
                }
            } else
                this.label5.Text = "Email address not valide !";
        }

        private string getUniqueID(string drive)
        {
            if (drive.EndsWith(":\\")) drive = drive.Substring(0, drive.Length - 2);
            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();
            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();
            return volumeSerial;
        }

        private string getCPUID()
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
        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Email_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HWID_TextBox;
        private System.Windows.Forms.TextBox Infos_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}