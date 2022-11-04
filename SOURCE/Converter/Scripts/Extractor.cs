using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Converter
{
    public static class Extractor
    {
        // REQUIRED CONSTS
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int MEM_COMMIT = 0x00001000;
        const int PAGE_READWRITE = 0x04;
        const int PROCESS_WM_READ = 0x0010;

        // REQUIRED METHODS
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

        public static int Interval = 30000000;
        public static Int64 CurrentIndex = 4000000;
        public static IntPtr proc_min_address;
        public static IntPtr proc_max_address;
        public static long proc_min_address_l;
        public static long proc_max_address_l;
        public static Process process;
        public static int CurrentDump = 1;
        public static bool Done = false;
        public static string Patch = Loader.File_Path + "RTP\\";
        public static bool Patch_4kRPM_Hondata = true;
        public static bool Patch_Hondata_Chip_Lock = true;
        public static string Mode = "";
        public static bool IsRTP = false;
        public static byte[] ExtractedBytes = new byte[] { };

        // REQUIRED STRUCTS
        public struct MEMORY_BASIC_INFORMATION
        {
            public int BaseAddress;
            public int AllocationBase;
            public int AllocationProtect;
            public int RegionSize;
            public int State;
            public int Protect;
            public int lType;
        }

        public struct SYSTEM_INFO
        {
            public ushort processorArchitecture;
            ushort reserved;
            public uint pageSize;
            public IntPtr minimumApplicationAddress;
            public IntPtr maximumApplicationAddress;
            public IntPtr activeProcessorMask;
            public uint numberOfProcessors;
            public uint processorType;
            public uint allocationGranularity;
            public ushort processorLevel;
            public ushort processorRevision;
        }
        
        public static bool Extract(string Mode1, bool IsDoingRTP)
        {
            try
            {
                SYSTEM_INFO sys_info = new SYSTEM_INFO();
                GetSystemInfo(out sys_info);

                IsRTP = IsDoingRTP;

                if (!IsRTP) Main_Form.Main.ClearRTPLocation();

                if (IsRTP) Main_Form.Main.CurrentRTPBytes = new byte[] { };

                CurrentIndex = 4000000;
                Done = false;

                long MaxIndex = (CurrentIndex + Interval);
                if (IsRTP)
                {
                    CurrentIndex = Main_Form.Main.RTPLocation;
                    //MaxIndex = (CurrentIndex + (32768*2));
                }

                proc_min_address = (IntPtr)CurrentIndex;
                proc_max_address = (IntPtr)MaxIndex;
                proc_min_address_l = (long)proc_min_address;
                proc_max_address_l = (long)proc_max_address;

                Mode = Mode1;

                Log.Log_This("--------------------------------------------------------------------------------------", false);
                Log.Log_This("Extracting " + Mode, false);

                if (Mode == "Neptune RTP") Patch = Loader.File_Path + "RTP\\";
                if (Mode == "SManager") Patch = Loader.File_Path + "SManager\\";

                CurrentDump = 1;

                if (!Directory.Exists(Patch)) Directory.CreateDirectory(Patch);

                Process[] ProcList = Process.GetProcessesByName(Mode);
                if (ProcList.Length == 0)
                {
                    Log.Log_This(Mode + " IS NOT RUNNING", false);
                    return false;
                }
                else
                {
                    process = Process.GetProcessesByName(Mode)[0];
                    Log.Log_This(Mode + " Is Running", false);

                    RemovePastDump();
                    string ReloadDump = "";

                    while (!Done)
                    {
                        int Percent = 0;
                        if (!IsRTP) Percent = (int)(((CurrentIndex - 4000000) * 100) / (Int64.Parse(sys_info.maximumApplicationAddress.ToString()) - 1));
                        else Percent = 50;
                        //Console.Write("\nSEARCH #" + SearchID + " " + Percent + "%");
                        Main_Form.Main.Progress = (int)Percent;
                        Application.DoEvents();

                        if ((CurrentIndex + Interval) > Int64.Parse(sys_info.maximumApplicationAddress.ToString()))
                            Done = true;
                        else
                        {
                            MaxIndex = (CurrentIndex + Interval);
                            if (IsRTP)
                            {
                                CurrentIndex = Main_Form.Main.RTPLocation;
                                //MaxIndex = (CurrentIndex + (32768*2));
                            }

                            proc_min_address = (IntPtr)CurrentIndex;
                            proc_max_address = (IntPtr)MaxIndex;
                            proc_min_address_l = (long)proc_min_address;
                            proc_max_address_l = (long)proc_max_address;

                            //Console.WriteLine("here");

                            Search();
                            ReloadDump = ReloadDumpFile();

                            if (Mode == "Neptune RTP" && ReloadDump.Contains("292330231823")) GetIndex(ReloadDump, "292330231823");
                            if (Mode == "SManager")
                            {
                                //2000 to 2026
                                string SearchStr = "284329203230303020486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303120486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303220486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303320486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303420486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303520486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303620486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303720486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303820486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230303920486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);

                                SearchStr = "284329203230313020486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313120486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313220486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313320486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313420486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313520486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313620486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313720486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313820486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230313920486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);


                                SearchStr = "284329203230323020486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230323120486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230323220486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230323320486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230323420486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230323520486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                                SearchStr = "284329203230323620486F6E64617461";
                                if (ReloadDump.Contains(SearchStr)) GetIndex(ReloadDump, SearchStr);
                            }
                        }

                        if (!IsRTP)
                        {
                            CurrentIndex += Interval;
                        }
                        else
                        {
                            Done = true;
                        }
                    }

                    File.Delete(Patch + "Dump.txt");
                    File.Delete(Patch + "DumpHex");


                    Main_Form.Main.Progress = (int)0;

                    if (CurrentDump == 1)
                    {
                        Log.Log_This("NO BIN FOUND", false);
                        return false;
                    }
                    else
                    {
                        //Log.Log_This((CurrentDump - 1) + " BIN FOUND", false);
                        return true;
                    }
                }
            }
            catch (Exception message)
            {
                Main_Form.Main.Progress = (int)0;
                Log.Log_This("CANT EXTRACT ERROR:\n" + message, false);
                return false;

            }
        }

        static void RemovePastDump()
        {
            string[] FileList = Directory.GetFiles(Patch, "Dump*");
            if (FileList.Length > 0)
            {
                for (int i = 0; i < FileList.Length; i++)
                {
                    File.Delete(FileList[i]);
                }
            }
        }

        static string ReloadDumpFile()
        {
            string ReloadDump = File.ReadAllText(Patch + "Dump.txt");
            ReloadDump = ReloadDump.Replace("\n", "");
            ReloadDump = ReloadDump.Replace("\r", "");
            ReloadDump = ReloadDump.Replace(" ", "");
            File.WriteAllText(Patch + "Dump.txt", ReloadDump);

            ExtractedBytes = File.ReadAllBytes(Patch + "DumpHex");
            return ReloadDump;
        }

        static void Search()
        {
            int bytesRead = 0;
            IntPtr processHandle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, process.Id);
            MEMORY_BASIC_INFORMATION mem_basic_info = new MEMORY_BASIC_INFORMATION();
            StreamWriter sw = new StreamWriter(Patch + "Dump.txt");
            StreamWriter sw2 = new StreamWriter(Patch + "DumpHex");

            //Console.WriteLine(proc_min_address_l.ToString("X"));
            //Console.WriteLine(proc_max_address_l.ToString("X"));
            while (proc_min_address_l < proc_max_address_l)
            {
                VirtualQueryEx(processHandle, proc_min_address, out mem_basic_info, 28);

                //Console.WriteLine(proc_min_address_l.ToString("X"));
                //Console.WriteLine("here");
                if (mem_basic_info.Protect == PAGE_READWRITE && mem_basic_info.State == MEM_COMMIT)
                {
                    byte[] buffer = new byte[mem_basic_info.RegionSize];

                    ReadProcessMemory((int)processHandle,
                    mem_basic_info.BaseAddress, buffer, mem_basic_info.RegionSize, ref bytesRead);

                    for (int i = 0; i < mem_basic_info.RegionSize; i++)
                    {
                        sw.WriteLine(buffer[i].ToString("X2"));
                        sw2.Write((char) buffer[i]);
                    }
                }

                if (mem_basic_info.RegionSize > 0) proc_min_address_l += mem_basic_info.RegionSize;
                else proc_min_address_l++;
                proc_min_address = new IntPtr(proc_min_address_l);
            }

            sw.Close();
            sw2.Close();
        }

        static void GetIndex(string This, string SearchStr)
        {
            string LeftString = This;
            while (LeftString.Contains(SearchStr))
            {
                byte[] SearchBytes = new byte[SearchStr.Length / 2];
                for (int i = 0; i < SearchBytes.Length; i++) SearchBytes[i] = byte.Parse(SearchStr.Substring(i*2, 2), System.Globalization.NumberStyles.HexNumber);
                
                int Ind = LeftString.IndexOf(SearchStr);
                if (Mode == "Neptune RTP")
                {
                    string Similary2 = LeftString.Substring(Ind + ((32768 * 2) - 8), 8);
                    if (Similary2 == "FFFFFFFF") CreateBin(Ind, LeftString);

                    if (!IsRTP)
                    {
                        for (int i = 0; i < ExtractedBytes.Length; i++)
                        {
                            if (ExtractedBytes[i] == SearchBytes[0] && ExtractedBytes[i + 1] == SearchBytes[1] && ExtractedBytes[i + 2] == SearchBytes[2] && ExtractedBytes[i + 3] == SearchBytes[3] && ExtractedBytes[i + 4] == SearchBytes[4] && ExtractedBytes[i + 5] == SearchBytes[5])
                                Main_Form.Main.AddRTPLocation(CurrentIndex + i);
                        }
                    }
                }
                if (Mode == "SManager")
                {
                    if (CurrentDump == 1 && !IsRTP)
                    {
                        CurrentDump++;    //dont create the useless dump1
                    }
                    else
                    {
                        CreateBin(Ind - (0x7ff0 * 2), LeftString);

                        if (!IsRTP)
                        {
                            for (int i = 0; i < ExtractedBytes.Length; i++)
                            {
                                if (ExtractedBytes[i] == SearchBytes[0] && ExtractedBytes[i + 1] == SearchBytes[1] && ExtractedBytes[i + 2] == SearchBytes[2] && ExtractedBytes[i + 3] == SearchBytes[3] && ExtractedBytes[i + 4] == SearchBytes[4] && ExtractedBytes[i + 5] == SearchBytes[5])
                                    Main_Form.Main.AddRTPLocation(CurrentIndex + i - 0x7ff0);
                            }
                        }
                    }
                }
                LeftString = LeftString.Substring(Ind + 12);
                //CurrentIndex +=  (Ind/2) + 6;
            }
        }

        static void CreateBin(int StartInd, string LeftString)
        {
            string FoundStr = LeftString.Substring(StartInd, (32768 * 2));
            byte[] OutputFile = ConvertHexToByte(FoundStr);

            if (Mode == "SManager" && Patch_4kRPM_Hondata) OutputFile = Decrypt4KHondata(OutputFile);
            if (Mode == "SManager" && Patch_Hondata_Chip_Lock) OutputFile = DecryptHondata_V2(OutputFile);

            int CurrentDumpFound = CurrentDump;
            if (Mode == "SManager" && !IsRTP) CurrentDumpFound -= 1;

            File.Create(Patch + "Dump" + CurrentDumpFound + ".bin").Dispose();
            File.WriteAllBytes(Patch + "Dump" + CurrentDumpFound + ".bin", OutputFile);

            if (IsRTP) Main_Form.Main.CurrentRTPBytes = OutputFile;

            Log.Log_This("BIN #" + CurrentDumpFound + " FOUND!", false);
            //Log.Log_This("BIN #" + CurrentDumpFound + " FOUND! at 0x" + (CurrentIndex + StartInd).ToString("X2"), false);
            //Console.WriteLine("BIN #" + CurrentDumpFound + " | CurrentIndex:" + (CurrentIndex).ToString("X2") + " | StartInd:" + (StartInd / 2).ToString("X2"));
            //if (!IsRTP) Main_Form.Main.AddRTPLocation(CurrentIndex + StartInd);
            //Console.Write("\nSEARCH #" + SearchID + " ... BIN #" + CurrentDump + " FOUND !");
            CurrentDump++;
        }

        static byte[] Decrypt4KHondata(byte[] ThisBytes)
        {
            //Get Location
            //B5 06 A9 A2 7D
            int Location = -1;
            for (int i = 0; i < ThisBytes.Length; i++)
            {
                if (ThisBytes[i] == 0xB5 && ThisBytes[i + 1] == 0x06 && ThisBytes[i + 2] == 0xA9 && ThisBytes[i + 3] == 0xA2 && ThisBytes[i + 4] == 0x7D) Location = i + 5;
            }

            //Apply 4K rpm remover
            if (Location != -1)
            {
                ThisBytes[Location] = 0xCB;
                ThisBytes[Location + 1] = 0x08;
                for (int i = 0; i < 8; i++) ThisBytes[(Location + 2) + i] = 0xff;
                if (!IsRTP) Log.Log_This("4000rpm Limit Removed!", false);
            }

            return ThisBytes;
        }

        static byte[] DecryptHondata_V2(byte[] ThisBytes)
        {
            //Get Location
            //90 15 F0 38 04
            int Location = -1;
            for (int i = 0; i < ThisBytes.Length; i++)
            {
                if (ThisBytes[i] == 0x90 && ThisBytes[i + 1] == 0x15 && ThisBytes[i + 2] == 0xF0 && ThisBytes[i + 3] == 0x38 && ThisBytes[i + 4] == 0x04) Location = i;
            }

            //Apply 4K rpm remover
            if (Location != -1)
            {
                ThisBytes[Location + 21] = (byte) (ThisBytes[Location + 21] + 2);
                ThisBytes[Location + 23] = (byte)(ThisBytes[Location + 23] + 2);
                ThisBytes[Location + 49] = (byte)(ThisBytes[Location + 49] + 2);
                ThisBytes[Location + 53] = (byte)(ThisBytes[Location + 53] + 2);
                ThisBytes[Location + 65] = (byte)(ThisBytes[Location + 65] + 2);

                //71 = location, loop for 73bytes
                byte[] BufferBytes = new byte[73];
                for (int i = 0; i < BufferBytes.Length; i++) BufferBytes[i] = ThisBytes[Location + 71];

                ThisBytes[Location + 71] = 0xC2;
                ThisBytes[Location + 72] = 0x18;

                for (int i = 0; i < BufferBytes.Length; i++) ThisBytes[Location + 73] = BufferBytes[i];

                if (!IsRTP) Log.Log_This("Hondata Chip Security Removed!", false);
            }

            return ThisBytes;
        }

        static byte[] ConvertHexToByte(string Hex)
        {
            string Left = Hex;
            byte[] Returning = new byte[Hex.Length / 2];
            int Index = 0;
            while (Left != "")
            {
                Returning[Index] = Byte.Parse(Left.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                Left = Left.Substring(2);
                Index++;
            }

            return Returning;
        }
    }
}
