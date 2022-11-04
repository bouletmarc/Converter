using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using Microsoft.Win32;

namespace Liscencer
{
    public partial class Main_Form : Form
    {
        public string H43534F;

        public Main_Form()
        {
            InitializeComponent();
            H43534F += T2("9577");
            Load();
        }

        public void Load()
        {
            H43534F += T2("1320");
            this.Bad_Label.Visible = false;
            G3();
            H43534F += T2("0607");
            string GW432FH3A = GSEEET(Path.GetPathRoot(Environment.SystemDirectory).Substring(0, 1));
            GW432FH3A = GW432FH3A.Substring(0, 16);
            if (GW432FH3A == H43534F)
            {
                RegistryKey key;
                bool EMHRE = true;
                if (Registry.CurrentUser.OpenSubKey(G233RF("7B978E9C9F899A8D84846B7E7C7A")) == null) key = Registry.CurrentUser.CreateSubKey(G233RF("7B978E9C9F899A8D84846B7E7C7A"));
                Registry.SetValue(G233RF("70736D81876B7D7A7A6D767C877D7B6D7A847B978E9C9F899A8D846B7E7C7A"), G233RF("746B6C"), EMHRE.ToString(), RegistryValueKind.String);
            }
            else
            {
                this.Bad_Label.Visible = true;
                this.Good_Label.Visible = false;
            }
        }

        private void G3()
        {
            H43534F += T2("0DE3");
        }

        private string GSEEET(string F323F)
        {
            if (F323F.EndsWith(":\\")) F323F = F323F.Substring(0, F323F.Length - 2);
            string SBSEEB = G233G3(F323F);
            string G23G = HH2333S();
            return G23G.Substring(13) + G23G.Substring(1, 4) + SBSEEB + G23G.Substring(4, 4);
        }

        private string G233G3(string DSEGESEG)
        {
            ManagementObject SDFV = new ManagementObject(@"win32_logicaldisk.deviceid=""" + DSEGESEG + @":""");
            SDFV.Get();
            string VSVESV = SDFV["VolumeSerialNumber"].ToString();
            SDFV.Dispose();
            return VSVESV;
        }

        private string HH2333S()
        {
            string VESEVE = "";
            ManagementClass BANR = new ManagementClass("win32_processor");
            ManagementObjectCollection NRDDR = BANR.GetInstances();
            foreach (ManagementObject RDMRRD in NRDDR)
            {
                if (VESEVE == "")
                {
                    VESEVE = RDMRRD.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return VESEVE;
        }

        private string T2(string H234h2)
        {
            string T43B34 = H234h2;
            string GG43 = "";
            while (T43B34 != "")
            {
                int NT454H = Int32.Parse(T43B34.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier) - ((((44 * 4) / 2) * 4) / 8);
                if (NT454H < 0) NT454H = 256 + NT454H;
                GG43 += NT454H.ToString("X2");
                T43B34 = T43B34.Substring(2);
            }

            return GG43;
        }

        public static string G233RF(string T32F2)
        {
            string L32F2 = T32F2;
            string R23232F = "";
            while (L32F2 != "")
            {
                int T2G23G = Int32.Parse(L32F2.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier) - ((((40 * 4) / 2) * 4) / 8);
                if (T2G23G < 0) T2G23G = 256 + T2G23G;
                R23232F += Convert.ToChar(T2G23G).ToString();
                L32F2 = L32F2.Substring(2);
            }
            return R23232F;
        }
    }
}
