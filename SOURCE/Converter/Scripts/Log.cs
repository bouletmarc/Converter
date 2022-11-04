using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public static class Log
    {
        public static bool Save_Logs = false;
        public static bool Adv_Logs = false;

        public static string Logs_Path = Loader.File_Path + "Logs.txt";
        public static string ErrorLogs_Path = Loader.File_Path + "ERRORS_Logs.txt";

        public static void Log_This(string Message, bool Adv)
        {
            if ((!Adv || (Adv && Adv_Logs)) & Loader.C)
            {
                Main_Form.Main.LogsText = Message;
                if (Save_Logs) SaveLogs(Message);
            }
        }

        public static void Log_This_Error(string Message)
        {
            string Text = "\n" + Message;
            File.AppendAllText(ErrorLogs_Path, Text);
        }

        public static void SaveLogs(string Message)
        {
            string Text = "\n" + Message;
            File.AppendAllText(Logs_Path, Text);
        }

        public static void SaveFullLogs()
        {
            File.AppendAllText(Logs_Path, Main_Form.Main.LogsText);
            Log.Log_This("Logs Saved at :\n" + Logs_Path, false);
        }
    }
}
