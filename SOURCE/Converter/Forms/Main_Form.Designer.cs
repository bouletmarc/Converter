namespace Converter
{
    partial class Main_Form
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
            System.Windows.Forms.ToolStripDropDownButton Moates_Drop;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.Connect_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Disconnect_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Read_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Write_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Verify_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Set_Chips_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Chips_ComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.openFlashBurnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Files_Drop = new System.Windows.Forms.ToolStripDropDownButton();
            this.Load_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Extract_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.extractSManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCal_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveBin_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Download_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Settings_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Liscence_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.New_Button = new System.Windows.Forms.ToolStripButton();
            this.Open_File_Form = new System.Windows.Forms.OpenFileDialog();
            this.Save_File_Cal_Form = new System.Windows.Forms.SaveFileDialog();
            this.Save_File_Bin_Form = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Infos_TextBox = new System.Windows.Forms.TextBox();
            this.Logs_TextBox = new System.Windows.Forms.TextBox();
            this.Progress_Bar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ConvertDone_Label = new System.Windows.Forms.Label();
            this.Register_Label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Version_Label = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            Moates_Drop = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Moates_Drop
            // 
            Moates_Drop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Connect_Button,
            this.Disconnect_Button,
            this.toolStripSeparator3,
            this.Read_Button,
            this.Write_Button,
            this.Verify_Button,
            this.toolStripSeparator5,
            this.Set_Chips_Button,
            this.toolStripSeparator7,
            this.openFlashBurnToolStripMenuItem});
            Moates_Drop.Image = global::Converter.Properties.Resources.parametersToolStripButton_Image;
            Moates_Drop.Name = "Moates_Drop";
            Moates_Drop.Size = new System.Drawing.Size(75, 22);
            Moates_Drop.Text = "Moates";
            // 
            // Connect_Button
            // 
            this.Connect_Button.Image = global::Converter.Properties.Resources.emuConnect;
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(167, 22);
            this.Connect_Button.Text = "Connect";
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // Disconnect_Button
            // 
            this.Disconnect_Button.Enabled = false;
            this.Disconnect_Button.Image = global::Converter.Properties.Resources.emuDisc;
            this.Disconnect_Button.Name = "Disconnect_Button";
            this.Disconnect_Button.Size = new System.Drawing.Size(167, 22);
            this.Disconnect_Button.Text = "Disconnect";
            this.Disconnect_Button.Click += new System.EventHandler(this.Disconnect_Button_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // Read_Button
            // 
            this.Read_Button.Enabled = false;
            this.Read_Button.Image = global::Converter.Properties.Resources.eeprom_upload_v2;
            this.Read_Button.Name = "Read_Button";
            this.Read_Button.Size = new System.Drawing.Size(167, 22);
            this.Read_Button.Text = "Read";
            this.Read_Button.Click += new System.EventHandler(this.Read_Button_Click);
            // 
            // Write_Button
            // 
            this.Write_Button.Enabled = false;
            this.Write_Button.Image = global::Converter.Properties.Resources.eeprom_download_v2;
            this.Write_Button.Name = "Write_Button";
            this.Write_Button.Size = new System.Drawing.Size(167, 22);
            this.Write_Button.Text = "Write";
            this.Write_Button.Click += new System.EventHandler(this.Write_Button_Click);
            // 
            // Verify_Button
            // 
            this.Verify_Button.Enabled = false;
            this.Verify_Button.Image = global::Converter.Properties.Resources.eeprom_verify_v2;
            this.Verify_Button.Name = "Verify_Button";
            this.Verify_Button.Size = new System.Drawing.Size(167, 22);
            this.Verify_Button.Text = "Verify";
            this.Verify_Button.Click += new System.EventHandler(this.Verify_Button_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(164, 6);
            // 
            // Set_Chips_Button
            // 
            this.Set_Chips_Button.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Chips_ComboBox});
            this.Set_Chips_Button.Enabled = false;
            this.Set_Chips_Button.Image = global::Converter.Properties.Resources.TunerPro_109_0;
            this.Set_Chips_Button.Name = "Set_Chips_Button";
            this.Set_Chips_Button.Size = new System.Drawing.Size(167, 22);
            this.Set_Chips_Button.Text = "Set Chips";
            // 
            // Chips_ComboBox
            // 
            this.Chips_ComboBox.Items.AddRange(new object[] {
            "SST27SF512",
            "AT27C256 (Read Only)",
            "AT29C256"});
            this.Chips_ComboBox.Name = "Chips_ComboBox";
            this.Chips_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.Chips_ComboBox.Text = "SST27SF512";
            this.Chips_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Chips_ComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(164, 6);
            // 
            // openFlashBurnToolStripMenuItem
            // 
            this.openFlashBurnToolStripMenuItem.Image = global::Converter.Properties.Resources.display;
            this.openFlashBurnToolStripMenuItem.Name = "openFlashBurnToolStripMenuItem";
            this.openFlashBurnToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openFlashBurnToolStripMenuItem.Text = "Open FlashNBurn";
            this.openFlashBurnToolStripMenuItem.Click += new System.EventHandler(this.openFlashBurnToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Files_Drop,
            this.toolStripSeparator1,
            Moates_Drop,
            this.toolStripSeparator4,
            this.Settings_Button,
            this.toolStripSeparator2,
            this.Liscence_Button,
            this.toolStripSeparator6,
            this.New_Button});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(589, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Files_Drop
            // 
            this.Files_Drop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Load_Button,
            this.Extract_Button,
            this.extractSManagerToolStripMenuItem,
            this.Edit_Button,
            this.SaveCal_Button,
            this.SaveBin_Button,
            this.Download_Button});
            this.Files_Drop.Image = global::Converter.Properties.Resources.copyToolStripButton_Image;
            this.Files_Drop.Name = "Files_Drop";
            this.Files_Drop.Size = new System.Drawing.Size(59, 22);
            this.Files_Drop.Text = "Files";
            // 
            // Load_Button
            // 
            this.Load_Button.Image = global::Converter.Properties.Resources.toolDtOpen_Image;
            this.Load_Button.Name = "Load_Button";
            this.Load_Button.Size = new System.Drawing.Size(181, 22);
            this.Load_Button.Text = "Load";
            this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
            // 
            // Extract_Button
            // 
            this.Extract_Button.Image = global::Converter.Properties.Resources.export_table;
            this.Extract_Button.Name = "Extract_Button";
            this.Extract_Button.Size = new System.Drawing.Size(181, 22);
            this.Extract_Button.Text = "Extract Neptune RTP";
            this.Extract_Button.Click += new System.EventHandler(this.Extract_Button_Click);
            // 
            // extractSManagerToolStripMenuItem
            // 
            this.extractSManagerToolStripMenuItem.Image = global::Converter.Properties.Resources.export_table;
            this.extractSManagerToolStripMenuItem.Name = "extractSManagerToolStripMenuItem";
            this.extractSManagerToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.extractSManagerToolStripMenuItem.Text = "Extract SManager";
            this.extractSManagerToolStripMenuItem.Click += new System.EventHandler(this.extractSManagerToolStripMenuItem_Click);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Enabled = false;
            this.Edit_Button.Image = global::Converter.Properties.Resources.adjust_selection2;
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(181, 22);
            this.Edit_Button.Text = "Edit";
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // SaveCal_Button
            // 
            this.SaveCal_Button.Enabled = false;
            this.SaveCal_Button.Image = global::Converter.Properties.Resources.saveAsToolStripButton_Image;
            this.SaveCal_Button.Name = "SaveCal_Button";
            this.SaveCal_Button.Size = new System.Drawing.Size(181, 22);
            this.SaveCal_Button.Text = "Save as .cal";
            this.SaveCal_Button.Click += new System.EventHandler(this.SaveCal_Button_Click);
            // 
            // SaveBin_Button
            // 
            this.SaveBin_Button.Enabled = false;
            this.SaveBin_Button.Image = global::Converter.Properties.Resources.Binary;
            this.SaveBin_Button.Name = "SaveBin_Button";
            this.SaveBin_Button.Size = new System.Drawing.Size(181, 22);
            this.SaveBin_Button.Text = "Save as .bin";
            this.SaveBin_Button.Click += new System.EventHandler(this.SaveBin_Button_Click);
            // 
            // Download_Button
            // 
            this.Download_Button.Enabled = false;
            this.Download_Button.Image = global::Converter.Properties.Resources.import_table;
            this.Download_Button.Name = "Download_Button";
            this.Download_Button.Size = new System.Drawing.Size(181, 22);
            this.Download_Button.Text = "Download .cal";
            this.Download_Button.Visible = false;
            this.Download_Button.Click += new System.EventHandler(this.Download_Button_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Settings_Button
            // 
            this.Settings_Button.Image = global::Converter.Properties.Resources.settingsSensor;
            this.Settings_Button.Name = "Settings_Button";
            this.Settings_Button.Size = new System.Drawing.Size(69, 22);
            this.Settings_Button.Text = "Settings";
            this.Settings_Button.Click += new System.EventHandler(this.Settings_Button_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Liscence_Button
            // 
            this.Liscence_Button.Image = global::Converter.Properties.Resources.registration;
            this.Liscence_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Liscence_Button.Name = "Liscence_Button";
            this.Liscence_Button.Size = new System.Drawing.Size(72, 22);
            this.Liscence_Button.Text = "Liscence";
            this.Liscence_Button.Click += new System.EventHandler(this.Liscence_Button_Click_1);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator6.Visible = false;
            // 
            // New_Button
            // 
            this.New_Button.Image = global::Converter.Properties.Resources.help;
            this.New_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.New_Button.Name = "New_Button";
            this.New_Button.Size = new System.Drawing.Size(53, 22);
            this.New_Button.Text = "NEW";
            this.New_Button.Visible = false;
            this.New_Button.Click += new System.EventHandler(this.New_Button_Click);
            // 
            // Open_File_Form
            // 
            this.Open_File_Form.Filter = "Tuning Files (*.cal, *bin)|*.cal; *bin";
            this.Open_File_Form.Title = "Open File";
            // 
            // Save_File_Cal_Form
            // 
            this.Save_File_Cal_Form.Filter = "Calibrations Files|*.cal";
            this.Save_File_Cal_Form.Title = "Save Calibration File";
            // 
            // Save_File_Bin_Form
            // 
            this.Save_File_Bin_Form.Filter = "Binaries Files|*.bin";
            this.Save_File_Bin_Form.Title = "Save Binary File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCyan;
            this.label1.Location = new System.Drawing.Point(120, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Files Infos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightCyan;
            this.label2.Location = new System.Drawing.Point(120, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Logs Infos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Infos_TextBox
            // 
            this.Infos_TextBox.Enabled = false;
            this.Infos_TextBox.Location = new System.Drawing.Point(12, 38);
            this.Infos_TextBox.Multiline = true;
            this.Infos_TextBox.Name = "Infos_TextBox";
            this.Infos_TextBox.ReadOnly = true;
            this.Infos_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Infos_TextBox.ShortcutsEnabled = false;
            this.Infos_TextBox.Size = new System.Drawing.Size(332, 84);
            this.Infos_TextBox.TabIndex = 2;
            // 
            // Logs_TextBox
            // 
            this.Logs_TextBox.Location = new System.Drawing.Point(12, 153);
            this.Logs_TextBox.Multiline = true;
            this.Logs_TextBox.Name = "Logs_TextBox";
            this.Logs_TextBox.ReadOnly = true;
            this.Logs_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logs_TextBox.ShortcutsEnabled = false;
            this.Logs_TextBox.Size = new System.Drawing.Size(332, 196);
            this.Logs_TextBox.TabIndex = 3;
            // 
            // Progress_Bar
            // 
            this.Progress_Bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progress_Bar.Location = new System.Drawing.Point(0, 396);
            this.Progress_Bar.Name = "Progress_Bar";
            this.Progress_Bar.Size = new System.Drawing.Size(589, 11);
            this.Progress_Bar.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.ConvertDone_Label);
            this.panel1.Controls.Add(this.Register_Label);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Version_Label);
            this.panel1.Controls.Add(this.Progress_Bar);
            this.panel1.Controls.Add(this.Logs_TextBox);
            this.panel1.Controls.Add(this.Infos_TextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 407);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(23, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Founds Locations for RTP:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(10, 197);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 13;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(10, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(159, 95);
            this.listBox1.TabIndex = 10;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(200)))));
            this.label5.Location = new System.Drawing.Point(37, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "RTP at Location:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ConvertDone_Label
            // 
            this.ConvertDone_Label.AutoSize = true;
            this.ConvertDone_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertDone_Label.ForeColor = System.Drawing.Color.Red;
            this.ConvertDone_Label.Location = new System.Drawing.Point(3, 381);
            this.ConvertDone_Label.Name = "ConvertDone_Label";
            this.ConvertDone_Label.Size = new System.Drawing.Size(114, 12);
            this.ConvertDone_Label.TabIndex = 9;
            this.ConvertDone_Label.Text = "CONVERT DONE : 10";
            // 
            // Register_Label
            // 
            this.Register_Label.AutoSize = true;
            this.Register_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_Label.ForeColor = System.Drawing.Color.Red;
            this.Register_Label.Location = new System.Drawing.Point(264, 381);
            this.Register_Label.Name = "Register_Label";
            this.Register_Label.Size = new System.Drawing.Size(91, 12);
            this.Register_Label.TabIndex = 8;
            this.Register_Label.Text = "UNREGISTERED";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(125, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save Logs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(277, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "By Bouletmarc";
            // 
            // Version_Label
            // 
            this.Version_Label.AutoSize = true;
            this.Version_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Version_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(200)))));
            this.Version_Label.Location = new System.Drawing.Point(3, 3);
            this.Version_Label.Name = "Version_Label";
            this.Version_Label.Size = new System.Drawing.Size(38, 12);
            this.Version_Label.TabIndex = 5;
            this.Version_Label.Text = "v7.0.0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(398, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Enable RTP with Emulator";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(15, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Check for new locations";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(383, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 344);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Realtime Programming Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(42, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "RTP with software:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hondata SManager",
            "Neptune RTP"});
            this.comboBox1.Location = new System.Drawing.Point(18, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 226);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RTP Extract Location";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(18, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Extract Interval:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(105, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(34, 20);
            this.textBox2.TabIndex = 21;
            this.textBox2.Text = "15";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(145, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "sec";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(589, 431);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main_Form";
            this.Text = "Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton Files_Drop;
        private System.Windows.Forms.ToolStripMenuItem Load_Button;
        private System.Windows.Forms.ToolStripMenuItem Edit_Button;
        private System.Windows.Forms.ToolStripMenuItem SaveCal_Button;
        private System.Windows.Forms.ToolStripMenuItem SaveBin_Button;
        private System.Windows.Forms.ToolStripMenuItem Download_Button;
        private System.Windows.Forms.ToolStripMenuItem Connect_Button;
        private System.Windows.Forms.ToolStripMenuItem Read_Button;
        private System.Windows.Forms.ToolStripMenuItem Write_Button;
        private System.Windows.Forms.ToolStripMenuItem Verify_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Settings_Button;
        private System.Windows.Forms.ToolStripMenuItem Disconnect_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.OpenFileDialog Open_File_Form;
        private System.Windows.Forms.SaveFileDialog Save_File_Cal_Form;
        private System.Windows.Forms.SaveFileDialog Save_File_Bin_Form;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Infos_TextBox;
        private System.Windows.Forms.ProgressBar Progress_Bar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Version_Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton Liscence_Button;
        private System.Windows.Forms.Label ConvertDone_Label;
        private System.Windows.Forms.Label Register_Label;
        private System.Windows.Forms.TextBox Logs_TextBox;
        private System.Windows.Forms.ToolStripMenuItem Extract_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem Set_Chips_Button;
        private System.Windows.Forms.ToolStripComboBox Chips_ComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton New_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem openFlashBurnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractSManagerToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
    }
}

