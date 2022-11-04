using System;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Threading;
using System.Timers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Converter
{
    public static class Serial
    {
        //SERIAL INFOS
        public static SerialPort serial;
        public static List<string> AvailablePorts = new List<string>();
        public static bool Connected = false;

        //READ/WRITE INFOS
        public static byte[] Commands;
        public static byte[] ReadArray;
        public static List<byte[]> BufferArrayList = new List<byte[]>();
        public static byte Encrypted_Checksum = 0;
        public static int WaitForBytes = 0;
        public static int MMSB = 0;
        public static int MSB = 0;
        public static int LSB = 0;
        public static int Current_Index = 0;
        public static string Mode = "Read";
        public static bool ReadOnly = false;
        public static string Chips = "SST27SF512";
        //public static string Software = "ECTUNE";
        public static bool IsEmulator = false;
        public static bool IsDemon = false;
        public static string Device = "";
        private static System.Timers.Timer timer_1 = new System.Timers.Timer(100.0);

        public static byte Vendor_ID = 0;
        public static byte[] Serial_ID = new byte[8];

        public static void SetChips(string This)
        {
            ReadOnly = false;
            Chips = This;   //SST27SF512, AT27C256, AT27C512

            Log.Log_This("Chips set to : " + Chips, false);

            //Set Read Only
            if (Chips == "AT27C256 (Read Only)")
                ReadOnly = true;

            //Reset Mode to Read
            if (ReadOnly & Mode != "Read")
                Mode = "Read";
        }

        public static void GetPortName()
        {
            AvailablePorts.Clear();

            Log.Log_This("Getting available ports list", false);
            foreach (string s in SerialPort.GetPortNames())
            {
                AvailablePorts.Add(s);
                Log.Log_This("    " + s + " available", false);
            }

            if (AvailablePorts.Count == 0)
                Log.Log_This("NO COM Ports found", false);
        }

        //###########################################################################################################

        public static void Press_Commands()
        {
            Current_Index = 0;
            string Success = "Successfully";

            Main_Form.Main.SaveCalEnabled = false;
            Main_Form.Main.SaveBinEnabled = false;
            Main_Form.Main.EditEnabled = false;
            Main_Form.Main.Progress = 0;

            MSB = 128;
            if (!IsEmulator || Chips == "AT29C256" || Chips == "AT27C256")
                MSB = 0;

            //if (IsEmulator) MSB = 0;

            //Erase SST Chips before writing
            if (Mode == "Write" & !IsEmulator & Chips == "SST27SF512")
                EraseChips();

            Log.Log_This("--------------------------------------------------------------------------------------", false);
            Log.Log_This(Mode + " device started", false);
            
            //Loop 32kb
            while (Current_Index < 32768)
            {
                //Set Percent
                int Percent = ((Current_Index * 100) / (32768 - 1));
                Main_Form.Main.Progress = Percent;

                //Get Commands (Read/Write/Verify)
                Commands = GetCommands(Current_Index);

                //Send
                Write(Commands);

                //Set waiting bytes
                WaitForBytes = 256;
                if (IsEmulator)
                    WaitForBytes = 4096;
                if (Mode == "Write")
                    WaitForBytes = 1;
                
                //Receive
                Success = ReceiveBack(Success);
                DiscardBuffer();

                //Increase Index/MSB for the next Loop
                if (!IsEmulator)
                {
                    Current_Index += 256;
                    MSB += 1;
                }
                else if (IsEmulator)
                {
                    Current_Index += 4096;
                    MSB += 16;
                }
            }

            //Set Percent (Done)
            Main_Form.Main.Progress = 100;

            //Check for Errors
            if (Success != " WITH ERRORS")
            {
                if (Mode == "Read")
                {
                    File_Converter.Bin_File = BufferArrayList.SelectMany(a => a).ToArray();
                    File_Converter.Set_Convert_Done();
                }

                //Verify
                if (Mode == "Verify")
                {
                    Log.Log_This("Verifying ... ", false);

                    //Set Temporary Array with the Read Array
                    byte[] TempArray = new byte[32768];
                    TempArray = BufferArrayList.SelectMany(a => a).ToArray();

                    //Compare all 0x7FFF adresse of the buffer with the Read Buffer
                    for (int i = 0; i < 32768; i++)
                    {
                        if (File_Converter.Bin_File[i] != TempArray[i])
                        {
                            //DONT BOTHER FOR THE 7FF6 ECTUNE DIFFERENNCE
                            if (i.ToString("X4") != "7FF6")
                            {
                                Log.Log_This("Error : 0x" + File_Converter.Bin_File[i].ToString("X2") + " != 0x" + TempArray[i].ToString("X2"), false);
                                Success = " but we found a difference at : 0x" + i.ToString("X4");
                                i = 32768;
                            }
                        }

                        int Percent = ((i * 100) / (32768 - 1));
                        Main_Form.Main.Progress = Percent;
                    }
                    
                    Main_Form.Main.Progress = 100;

                    File_Converter.Bin_File = TempArray;
                    File_Converter.Set_Convert_Done();
                }
            }
            
            Log.Log_This(Mode + " Done " + Success, false);
        }

        private static string ReceiveBack(string Success)
        {
            if (Mode == "Read" | Mode == "Verify")
            {
                ReadArray = new byte[WaitForBytes];
                ReadArray = ReadBytes(WaitForBytes);
                
                byte Checksum1 = GetChecksum(ReadArray, true);
                byte Checksum2 = ReadByte();
                
                if (Checksum1 == Checksum2)
                {
                    if (IsEmulator)
                        ReadArray = Decrypt(Encrypted_Checksum, ReadArray, 0, 4096);

                    BufferArrayList.Add(ReadArray);
                    //Set Sucess
                    Log.Log_This("Read successful " + GetAddresString() + " to : " + GetToAddresString(), false);
                }
                else
                {
                    //Checksum Error at block
                    Current_Index = 32768;
                    Success = " WITH ERRORS";
                    Log.Log_This("Read UNSUCCESFUL" + GetAddresString() + " to  : " + GetToAddresString() + ", Checksum : " + Checksum1.ToString() + " != " + Checksum2.ToString(), false);

                    //Set Array To 0xFF
                    BufferArrayList.Clear();
                    BufferArrayList.Add(ReadArray);
                }
            }
            else if (Mode == "Write")
            {
                byte Readed_Byte = ReadByte();

                if (Convert.ToChar(Readed_Byte).ToString() == "O")
                    Log.Log_This("Write successful " + GetAddresString() + " to : " + GetToAddresString(), false);
                else
                {
                    Current_Index = 32768;
                    Success = " WITH ERRORS";
                    Log.Log_This("Write UNSUCCESFUL " + GetAddresString() + " to : " + GetToAddresString(), false);
                }
            }

            return Success;
        }

        //#########################################################################################################

        private static byte GetChecksum(byte[] ThisArray, bool Full)
        {
            byte sum = 0;
            if (Full)
            {
                for (int i = 0; i < ThisArray.Length; ++i)
                    sum += ThisArray[i];
            }
            else
            {
                for (int i = 0; i < ThisArray.Length - 1; i++)
                    sum += ThisArray[i];
            }
            return sum;
        }

        private static string GetAddresString()
        {
            string Address = "";

            if (!IsEmulator)
                Address = "0x" + MSB.ToString("X2") + LSB.ToString("X2");
            else if (IsEmulator)
                Address = "0x" + MMSB.ToString("X2") + MSB.ToString("X2") + LSB.ToString("X2");

            return Address;
        }

        private static string GetToAddresString()
        {
            string Address = "";

            if (!IsEmulator)
                Address = "0x" + MSB.ToString("X2") + "FF";
            else if (IsEmulator)
                Address = "0x" + MMSB.ToString("X2") + MSB.ToString("X2") + "FF";
                //Address = "0x" + MMSB.ToString("X2") + (MSB + 15).ToString("X2") + "FF";

            return Address;
        }

        private static byte GetChipsByte()
        {
            byte Temp = 0;
            if (Chips == "SST27SF512")
                Temp = Convert.ToByte('5');
            else if (Chips == "AT29C256")
                Temp = Convert.ToByte('2');
            else if (Chips == "AT27C256")
                Temp = Convert.ToByte('2');
            else if (Chips == "AT27C512")
                Temp = Convert.ToByte('5');

            return Temp;
        }

        private static byte GetModeByte()
        {
            byte Temp = 0;
            if (Mode == "Read" | Mode == "Verify")
                Temp = Convert.ToByte('R');
            else if (Mode == "Write")
                Temp = Convert.ToByte('W');

            return Temp;
        }

        //#################################################################### SERIAL COMMANDS ##########################################################################

        private static void EraseChips()
        {
            Commands = new byte[3];
            Commands[0] = Convert.ToByte('5');
            Commands[1] = Convert.ToByte('E');
            Commands[2] = GetChecksum(Commands, false);

            Log.Log_This("Erasing chips ...", false);

            //Send
            Write(Commands);
            
            //Read
            byte Readed_Byte = ReadByte();
            DiscardBuffer();

            if (Convert.ToChar(Readed_Byte).ToString() == "O")
                Log.Log_This("Chips erased successful", false);
            else
                Log.Log_This("Chips erased UNSUCCESSFUL", false);
        }

        private static void GetVersion()
        {
            //Set Commands
            Commands = new byte[2];
            Commands[0] = Convert.ToByte('V');
            Commands[1] = Convert.ToByte('V');

            //Send
            Write(Commands);

            //Receive & Check Bytes
            byte[] VersionBytes = new byte[3];
            VersionBytes = ReadBytes(3);
            DiscardBuffer();

            //Check for Available Moates Devices
            if (VersionBytes[0] != 0)
            {
                //Set Device
                Device = "";
                IsEmulator = false;
                IsDemon = false;

                if (VersionBytes[0] == 5)
                {
                    Device = "BURN1/BURN2";
                    Main_Form.Main.Set_ChipsEnabled = true;
                }
                else if (VersionBytes[0] == 33)
                {
                    Device = "ARDUINO MEGA 2650";
                    Main_Form.Main.Set_ChipsEnabled = true;
                }
                else if (VersionBytes[0] == 10)
                {
                    Device = "OSTRICH 1.0";
                    IsEmulator = true;
                }
                else if (VersionBytes[0] == 20)
                {
                    Device = "OSTRICH 2.0";
                    IsEmulator = true;
                    method_32(true);
                }
                else if (VersionBytes[0] == 1 | VersionBytes[0] == 2)
                {
                    Device = "DEMON";
                    IsEmulator = true;
                    IsDemon = true;
                    method_32(false);
                }

                //Check Reconized Device
                if (Device != "")
                {
                    Log.Log_This(Device + " Found !", false);

                    //Set Version String
                    string VersionString = "V" + VersionBytes[0] + "." + VersionBytes[1] + "." + Convert.ToChar(VersionBytes[2]).ToString();
                    Log.Log_This("Version : " + VersionString, false);

                    //Get Device Serial and Vendor
                    //if (IsEmulator) GetSerial();

                    if (!Main_Form.Main.LiscenceEnabled && (Device == "OSTRICH 1.0" || Device == "OSTRICH 2.0" || Device == "DEMON"))
                    {
                        Main_Form.Main.ShowRTPMenu(true);
                    }

                    Connected = true;
                }
                else
                {
                    serial.Close();
                    Log.Log_This("The device you are trying to connect aren't reconized", false);
                }
            }
            else
            {
                serial.Close();
                Log.Log_This("The device you are trying to connect aren't reconized", false);
            }
        }

        private static byte[] GetCommands(int Index)
        {
            //FIRST PASS, SET BYTES 1-5
            if (!IsEmulator)
            {
                //SET '5+R+n+MSB+LSB+CS'
                Commands = new byte[6];
                if (Mode == "Write")
                    Commands = new byte[262];

                Commands[0] = GetChipsByte();
                Commands[1] = GetModeByte();
                Commands[2] = 0;
                Commands[3] = (byte)MSB;
                Commands[4] = (byte)LSB;
            }
            else if (IsEmulator)
            {
                if (IsDemon)
                {
                    //SET 'Z+R+n+RB1+RB2+MMSB+MSB+CS'
                    Commands = new byte[8];
                    if (Mode == "Write") Commands = new byte[4104]; //Should be 4104/263 ??

                    Commands[0] = Convert.ToByte('Z');
                    Commands[1] = GetModeByte();
                    Commands[2] = 16;
                    Commands[3] = (byte)0;
                    Commands[4] = (byte)0;
                }
                else
                {
                    //SET 'Z+R+n+MMSB+MSB+CS'
                    Commands = new byte[6];
                    if (Mode == "Write") Commands = new byte[4102]; //Should be 4104/263 ??

                    Commands[0] = Convert.ToByte('Z');
                    Commands[1] = GetModeByte();
                    Commands[2] = 16;
                }
            }

            //SET 2ND PASS, BYTES 5++
            if (Mode == "Read" | Mode == "Verify")
            {
                //Set Read Commands
                if (!IsEmulator)
                    Commands[5] = GetChecksum(Commands, false);
                else if (IsEmulator)
                {
                    if (IsDemon)
                    {
                        Commands[5] = (byte)MMSB;
                        Commands[6] = (byte)MSB;

                        //Encrypt Commands
                        Encrypted_Checksum = Encrypt(Commands, 3, 7);              //encrypt RB1, RB2, MMSB, MSB  (from RB1 to end)
                        Commands[7] = GetChecksum(Commands, false);
                    }
                    else
                    {
                        Commands[3] = (byte)MMSB;
                        Commands[4] = (byte)MSB;
                        Commands[5] = GetChecksum(Commands, false);
                    }
                }
            }
            else if (Mode == "Write")
            {
                //Set Write Commands
                if (!IsEmulator)
                {
                    //Set Bytes To Write
                    for (int i = 0; i < 256; ++i)
                        Commands[5 + i] = File_Converter.Bin_File[Index + (long)i];
                    Commands[261] = GetChecksum(Commands, false);
                }
                else if (IsEmulator)
                {
                    if (IsDemon)
                    {
                        Commands[5] = (byte)MMSB;
                        Commands[6] = (byte)MSB;

                        //Set Bytes To Write
                        for (int i = 0; i < 4096; ++i) Commands[7 + i] = File_Converter.Bin_File[Index + (long)i];

                        //Encrypt Commands
                        Encrypted_Checksum = Encrypt(Commands, 3, 4103);        //encrypt from RB1 to end
                        Commands[4103] = GetChecksum(Commands, false);
                    }
                    else
                    {
                        Commands[3] = (byte)MMSB;
                        Commands[4] = (byte)MSB;

                        //Set Bytes To Write
                        for (int i = 0; i < 4096; ++i) Commands[5 + i] = File_Converter.Bin_File[Index + (long)i];

                        Commands[4101] = GetChecksum(Commands, false);
                    }
                }
            }

            return Commands;
        }


        public static bool method_32(bool Ostrich)
        {
            int num = 0;
            GetSerial();

            //Reset only if vendor ID doesnt match
            if ((Ostrich && Vendor_ID != 0) || (!Ostrich && Vendor_ID != 1))
            {

                Commands = new byte[11];
                Commands[0] = 0x4e;
                if (Ostrich) Commands[1] = 0;
                else Commands[1] = 1;

                for (int i = 0; i < 8; i++) Commands[2 + i] = Serial_ID[i];
                Commands[10] = GetChecksum(Commands, false);

                Label_0071:
                if (num == 3)
                {
                    MessageBox.Show("Error resetting VendorID after 3 tries", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Log.Log_This("Error resetting VendorID after 3 tries", false);
                    return false;
                }
                try
                {
                    Write(Commands);
                    serial.ReadTimeout = 0x1388;
                    byte ReceivedByte = ReadByte();
                    DiscardBuffer();
                    if (ReceivedByte == 0x4f) return true;
                    num++;
                }
                catch
                {
                    num++;
                    goto Label_0071;
                }
            }
            return false;
        }

        private static void GetSerial()
        {
            int num = 0;
            Commands = new byte[3];
            Commands[0] = 0x4e;
            Commands[1] = 0x53;
            Commands[2] = 0xa1;

            Label_0041:
            if (num == 3)
            {
                MessageBox.Show("Error getting SerialID after 3 tries", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Log.Log_This("Error getting SerialID after 3 tries", false);
            }
            try
            {
                Write(Commands);

                Vendor_ID = ReadByte();
                for (int i = 0; i < 8; i++) Serial_ID[i] = ReadByte();

                byte CheckS = ReadByte();
                DiscardBuffer();
            }
            catch
            {
                Vendor_ID = 0;
                num++;
                goto Label_0041;
            }
        }

        public static void Send1Byte(long Location, byte ThisByte)
        {
            if (Main_Form.Main.IsRTP) Location -= 0x8000;
            Commands = new byte[6];
            Commands[0] = 0x57;
            Commands[1] = 1;
            Commands[2] = (byte)((Location & 0xff00L) / 0x100L);
            Commands[3] = (byte)(Location & 0xffL);
            Commands[4] = ThisByte;
            Commands[5] = GetChecksum(Commands, false);

            //Extra logging here Console
            Log.Log_This("Uploading byte: 0x" + ThisByte.ToString("X2") + " At: 0x" + (0x8000 + Location).ToString("X4"), false);

            try
            {
                Write(Commands);

                byte Readed_Byte = ReadByte();
                DiscardBuffer();
                if (Convert.ToChar(Readed_Byte).ToString() != "O")
                {
                    Log.Log_This("Byte not updated at location:@" + string.Format("{0:X2}", Location), false);
                    string BufString = "Checksum error @" + string.Format("{0:X2}", Location) + "\nReply is: " + string.Format("{0:X2}", Readed_Byte) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")";
                    Log.Log_This(BufString, false);
                }
            }
            catch (Exception exception2)
            {
                DiscardBuffer();
                Log.Log_This("Realtime update error:\n" + exception2.Message, false);
            }
        }

        private static void DiscardBuffer()
        {
            try
            {
                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();
            }
            catch { }
        }

        //#################################################################### SERIAL CONNECT ##########################################################################

        public static void SerialConnect()
        {
            Connected = false;

            if (timer_1 != null)
            {
                try
                {
                    timer_1.Stop();
                }
                catch { }
            }
            timer_1.Elapsed += new ElapsedEventHandler(timer_1_Elapsed);
            Main_Form.Main.DisconnectEnabled = false;
            Main_Form.Main.ReadEnabled = false;
            Main_Form.Main.WriteEnabled = false;
            Main_Form.Main.VerifyEnabled = false;
            Main_Form.Main.Set_ChipsEnabled = false;

            Log.Log_This("--------------------------------------------------------------", false);

            serial = new SerialPort();

            GetPortName();

            int Index = 0;
            if (AvailablePorts.Count > 0)
            {
                //Loop through all COM Ports until we find the proper one
                while (!Connected & Index < AvailablePorts.Count)
                {
                    //Close before Setting Values
                    try
                    {
                        if (serial.IsOpen)
                        {
                            serial.Close();
                            serial.Dispose();
                        }
                    }
                    catch { }

                    //Set Settings
                    serial.PortName = AvailablePorts[Index];
                    serial.BaudRate = 921600; //First Try for arduino
                    serial.ReadTimeout = 800;
                    serial.WriteTimeout = 400;

                    //Connect and Get Version
                    try
                    {
                        serial.Open();
                        DiscardBuffer();
                        Log.Log_This("Connected on " + serial.PortName + ":" + serial.BaudRate, false);
                        GetVersion();
                        DiscardBuffer();

                        //If still not connected, then replace baudrate for 115200 (Moates)
                        if (!Connected)
                        {
                            serial.BaudRate = 115200;
                            serial.Open();
                            Log.Log_This("--------------------------------------------------------------", false);
                            Log.Log_This("Connected on " + serial.PortName + ":" + serial.BaudRate, false);
                            GetVersion();
                        }

                        //If still not connected, then increase Index
                        if (!Connected)
                            Index++;
                    }
                    catch
                    {
                        Index++;
                    }
                }
            }

            //Set Connected
            if (Connected)
            {
                Main_Form.Main.ConnectEnabled = false;
                Main_Form.Main.DisconnectEnabled = true;
                Main_Form.Main.ReadEnabled = true;
                Main_Form.Main.WriteEnabled = true;
                Main_Form.Main.VerifyEnabled = true;
                timer_1.Start();
            }
        }

        public static void SerialDisconnect()
        {
            Connected = false;

            try
            {
                if (serial.IsOpen)
                {
                    DiscardBuffer();
                    serial.Close();
                    serial.Dispose();
                    Log.Log_This("Serial port " + serial.PortName + " disconnected successfully", false);
                }
                else
                {
                    Log.Log_This("Serial port wasn't connected", false);
                }
            }
            catch
            {
                Log.Log_This("Serial port wasn't connected", false);
            }
            serial = null;

            Main_Form.Main.ConnectEnabled = true;
            Main_Form.Main.DisconnectEnabled = false;
            Main_Form.Main.ReadEnabled = false;
            Main_Form.Main.WriteEnabled = false;
            Main_Form.Main.VerifyEnabled = false;
        }

        private static void timer_1_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer_1.Stop();

            string[] portNames = SerialPort.GetPortNames();
            bool flag = false;
            for (int i = 0; i < portNames.Length; i++)
            {
                if ((serial != null) && (serial.PortName == portNames[i]))
                {
                    timer_1.Start();
                    return;
                }
            }
            if (!flag)
            {
                SerialDisconnect();
                Log.Log_This("USB might be disconnected!", false);
            }
        }

        //#################################################################### SERIAL READ/WRITE ##########################################################################


        private static void Write(byte[] Bytes)
        {
            try
            {
                //Try again, not for timeout
                try
                {
                    serial.Write(Bytes, 0, Bytes.Length);
                }
                catch
                {
                    Log.Log_This("Can't WriteBytes, Error : Possibly Disconnected", false);
                }
            }
            catch (TimeoutException)
            {
                Log.Log_This("Can't WriteBytes, Error : Timeout", false);

                try
                {
                    serial.DiscardInBuffer();
                    serial.DiscardOutBuffer();
                }
                catch
                {
                    Log.Log_This("Serial.Discard failed", false);
                }
            }
        }

        private static byte ReadByte()
        {
            int Timeout = 0;

            try
            {
                //Try again, not for timeout
                try
                {
                    //Timeout Loop if bytes is not availables
                    while (serial.BytesToRead < 1 & Timeout < 800)
                    {
                        Thread.Sleep(1);
                        Timeout++;
                    }

                    //Check Timeout is out of time
                    if (Timeout >= 800)
                    {
                        Log.Log_This("Read Timeout Exception", false);
                        return 255;
                    }
                    else
                    {
                        return (byte)serial.ReadByte();
                    }
                }
                catch
                {
                    Log.Log_This("Can't ReadByte, Error : Possibly Disconnected", false);
                    return 255;
                }
            }
            catch (TimeoutException)
            {
                Log.Log_This("Read Timeout Exception", false);
                return 255;
            }
        }

        private static byte[] ReadBytes(int size)
        {
            byte[] Temp = new byte[size];

            int Timeout = 0;

            try
            {
                //Try again, not for timeout
                try
                {
                    //Timeout Loop if bytes is not availables
                    while (serial.BytesToRead < size & Timeout < 800)
                    {
                        Thread.Sleep(1);
                        Timeout++;
                    }

                    //Check Timeout is out of time
                    if (Timeout >= 800)
                    {
                        for (int i = 0; i < Temp.Length; i++)
                            Temp[i] = 255;

                        Log.Log_This("Read Timeout Exception", false);
                    }
                    else
                    {
                        serial.Read(Temp, 0, size);
                    }
                }
                catch
                {
                    for (int i = 0; i < Temp.Length; i++)
                        Temp[i] = 255;

                    Log.Log_This("Can't ReadBytes, Error : Possibly Disconnected", false);
                }
            }
            catch (TimeoutException)
            {
                for (int i = 0; i < Temp.Length; i++)
                    Temp[i] = 255;

                Log.Log_This("Read Timeout Exception", false);
            }

            return Temp;
        }

        //#################################################################### COMMANDS ENCRYPTION ##########################################################################
        private static byte Encrypt(byte[] This_Array, int Start_Index, int Max_Index)
        {
            byte num = GetEncryptedChecksum();
            for (int index1 = Start_Index; index1 < Max_Index; ++index1)
            {
                This_Array[index1] ^= num;
                for (int index2 = 0; index2 <= 7; ++index2)
                {
                    if (index2 != 0 && index2 != 2 && (index2 != 4 && index2 != 6))
                        This_Array[index1] ^= GetEmulatorCommands()[index2];
                    else
                        This_Array[index1] += GetEmulatorCommands()[index2];
                }
                num = This_Array[index1];
            }
            return num;
        }
        
        private static byte GetEncryptedChecksum()
        {
            byte num = 90;
            for (int index = 0; index < GetEmulatorCommands().Length; ++index)
                num += GetEmulatorCommands()[index];
            return num;
        }
        
        public static byte[] GetEmulatorCommands()
        {
            byte[] Array = new byte[8] { (byte)15, (byte)252, (byte)206, (byte)44, (byte)163, (byte)159, (byte)101, (byte)153 };
            return Array;
        }
        
        private static byte[] Decrypt(byte Checksum_Byte, byte[] This_Array, int Start_Index, int Max_Index)
        {
            byte num1 = Checksum_Byte;
            
            for (int index1 = Start_Index; index1 < Max_Index; ++index1)
            {
                byte num2 = This_Array[index1];
                
                for (int index2 = 7; index2 >= 0; --index2)
                {
                    if (index2 != 0 && index2 != 2 && (index2 != 4 && index2 != 6))
                        This_Array[index1] ^= GetEmulatorCommands()[index2];
                    else
                        This_Array[index1] -= GetEmulatorCommands()[index2];
                }
                
                This_Array[index1] ^= num1;
                
                num1 = num2;
            }
            return This_Array;
        }



    }
}
