using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Converter
{
    public static class Saver
    {

        public static string Path = "";
        public static byte[] SaveBytes;

        public static void Save()
        {
            if (!Loader.C)
            {
                Loader.C2++;
                Registry.SetValue(Loader.G("70736D81876B7D7A7A6D767C877D7B6D7A847B978E9C9F899A8D846B7E7C7A"), Loader.G("74757C"), Loader.C2.ToString(), RegistryValueKind.String);
                /*string D = Loader.CPU_Drive;
                string CP = Loader.CPU_Name;
                string P = D + Loader.G("7D9B8D9A9B57") + CP + Loader.G("576B89");
                if (Loader.CPU_Windows == "XP") P = D + Loader.G("6C978B9D958D969C9B4889968C487B8D9C9C91968F9B57") + CP + Loader.G("576B89");
                File.Create(P).Dispose();
                File.WriteAllText(P, Loader.C2.ToString());*/
            }

            if (Path != "" & ((!Loader.C & Loader.C2 <= 0x0A) | Loader.C))
            {
                File.Create(Path).Dispose();
                File.WriteAllBytes(Path, SaveBytes);

                Log.Log_This("--------------------------------------------------------------------------------------", false);
                Log.Log_This("File Saved at :", false);
                Log.Log_This(Path, false);

                //Sender.Send(Path);
            }
        }
    }
}
