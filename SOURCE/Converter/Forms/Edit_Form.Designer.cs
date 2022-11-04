namespace Converter
{
    partial class Edit_Form
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
            this.ELD_CheckBox = new System.Windows.Forms.CheckBox();
            this.Knock_CheckBox = new System.Windows.Forms.CheckBox();
            this.Baro_CheckBox = new System.Windows.Forms.CheckBox();
            this.InjTest_CheckBox = new System.Windows.Forms.CheckBox();
            this.Heater_CheckBox = new System.Windows.Forms.CheckBox();
            this.Closeloop_CheckBox = new System.Windows.Forms.CheckBox();
            this.Vtec_CheckBox = new System.Windows.Forms.CheckBox();
            this.IAB_CheckBox = new System.Windows.Forms.CheckBox();
            this.Fan_CheckBox = new System.Windows.Forms.CheckBox();
            this.IACV_CheckBox = new System.Windows.Forms.CheckBox();
            this.FuelCut_CheckBox = new System.Windows.Forms.CheckBox();
            this.IgnCut_CheckBox = new System.Windows.Forms.CheckBox();
            this.ShiftLight_CheckBox = new System.Windows.Forms.CheckBox();
            this.ColdSet_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ColdReset_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WarmSet_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WarmReset_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ShiftLight_TextBox = new System.Windows.Forms.TextBox();
            this.SpeedCheck_CheckBox = new System.Windows.Forms.CheckBox();
            this.CoolantCheck_CheckBox = new System.Windows.Forms.CheckBox();
            this.VTP_CheckBox = new System.Windows.Forms.CheckBox();
            this.VtecError_CheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.VtecLow_TextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.VtecHigh_TextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Reconvert_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ELD_CheckBox
            // 
            this.ELD_CheckBox.AutoSize = true;
            this.ELD_CheckBox.Location = new System.Drawing.Point(12, 44);
            this.ELD_CheckBox.Name = "ELD_CheckBox";
            this.ELD_CheckBox.Size = new System.Drawing.Size(85, 17);
            this.ELD_CheckBox.TabIndex = 0;
            this.ELD_CheckBox.Text = "Disable ELD";
            this.ELD_CheckBox.UseVisualStyleBackColor = true;
            this.ELD_CheckBox.CheckedChanged += new System.EventHandler(this.ELD_CheckBox_CheckedChanged);
            // 
            // Knock_CheckBox
            // 
            this.Knock_CheckBox.AutoSize = true;
            this.Knock_CheckBox.Location = new System.Drawing.Point(12, 67);
            this.Knock_CheckBox.Name = "Knock_CheckBox";
            this.Knock_CheckBox.Size = new System.Drawing.Size(95, 17);
            this.Knock_CheckBox.TabIndex = 1;
            this.Knock_CheckBox.Text = "Disable Knock";
            this.Knock_CheckBox.UseVisualStyleBackColor = true;
            this.Knock_CheckBox.CheckedChanged += new System.EventHandler(this.Knock_CheckBox_CheckedChanged);
            // 
            // Baro_CheckBox
            // 
            this.Baro_CheckBox.AutoSize = true;
            this.Baro_CheckBox.Location = new System.Drawing.Point(12, 90);
            this.Baro_CheckBox.Name = "Baro_CheckBox";
            this.Baro_CheckBox.Size = new System.Drawing.Size(109, 17);
            this.Baro_CheckBox.TabIndex = 2;
            this.Baro_CheckBox.Text = "Disable PA (Baro)";
            this.Baro_CheckBox.UseVisualStyleBackColor = true;
            this.Baro_CheckBox.CheckedChanged += new System.EventHandler(this.Baro_CheckBox_CheckedChanged);
            // 
            // InjTest_CheckBox
            // 
            this.InjTest_CheckBox.AutoSize = true;
            this.InjTest_CheckBox.Location = new System.Drawing.Point(12, 113);
            this.InjTest_CheckBox.Name = "InjTest_CheckBox";
            this.InjTest_CheckBox.Size = new System.Drawing.Size(102, 17);
            this.InjTest_CheckBox.TabIndex = 3;
            this.InjTest_CheckBox.Text = "Disable Inj. Test";
            this.InjTest_CheckBox.UseVisualStyleBackColor = true;
            this.InjTest_CheckBox.CheckedChanged += new System.EventHandler(this.InjTest_CheckBox_CheckedChanged);
            // 
            // Heater_CheckBox
            // 
            this.Heater_CheckBox.AutoSize = true;
            this.Heater_CheckBox.Location = new System.Drawing.Point(12, 136);
            this.Heater_CheckBox.Name = "Heater_CheckBox";
            this.Heater_CheckBox.Size = new System.Drawing.Size(113, 17);
            this.Heater_CheckBox.TabIndex = 4;
            this.Heater_CheckBox.Text = "Disable O2 Heater";
            this.Heater_CheckBox.UseVisualStyleBackColor = true;
            this.Heater_CheckBox.CheckedChanged += new System.EventHandler(this.Heater_CheckBox_CheckedChanged);
            // 
            // Closeloop_CheckBox
            // 
            this.Closeloop_CheckBox.AutoSize = true;
            this.Closeloop_CheckBox.Location = new System.Drawing.Point(12, 159);
            this.Closeloop_CheckBox.Name = "Closeloop_CheckBox";
            this.Closeloop_CheckBox.Size = new System.Drawing.Size(110, 17);
            this.Closeloop_CheckBox.TabIndex = 5;
            this.Closeloop_CheckBox.Text = "Disable Closeloop";
            this.Closeloop_CheckBox.UseVisualStyleBackColor = true;
            this.Closeloop_CheckBox.CheckedChanged += new System.EventHandler(this.Closeloop_CheckBox_CheckedChanged);
            // 
            // Vtec_CheckBox
            // 
            this.Vtec_CheckBox.AutoSize = true;
            this.Vtec_CheckBox.Location = new System.Drawing.Point(12, 182);
            this.Vtec_CheckBox.Name = "Vtec_CheckBox";
            this.Vtec_CheckBox.Size = new System.Drawing.Size(86, 17);
            this.Vtec_CheckBox.TabIndex = 6;
            this.Vtec_CheckBox.Text = "Disable Vtec";
            this.Vtec_CheckBox.UseVisualStyleBackColor = true;
            this.Vtec_CheckBox.CheckedChanged += new System.EventHandler(this.Vtec_CheckBox_CheckedChanged);
            // 
            // IAB_CheckBox
            // 
            this.IAB_CheckBox.AutoSize = true;
            this.IAB_CheckBox.Location = new System.Drawing.Point(12, 205);
            this.IAB_CheckBox.Name = "IAB_CheckBox";
            this.IAB_CheckBox.Size = new System.Drawing.Size(81, 17);
            this.IAB_CheckBox.TabIndex = 7;
            this.IAB_CheckBox.Text = "Disable IAB";
            this.IAB_CheckBox.UseVisualStyleBackColor = true;
            this.IAB_CheckBox.CheckedChanged += new System.EventHandler(this.IAB_CheckBox_CheckedChanged);
            // 
            // Fan_CheckBox
            // 
            this.Fan_CheckBox.AutoSize = true;
            this.Fan_CheckBox.Location = new System.Drawing.Point(12, 228);
            this.Fan_CheckBox.Name = "Fan_CheckBox";
            this.Fan_CheckBox.Size = new System.Drawing.Size(118, 17);
            this.Fan_CheckBox.TabIndex = 8;
            this.Fan_CheckBox.Text = "Disable Fan Control";
            this.Fan_CheckBox.UseVisualStyleBackColor = true;
            this.Fan_CheckBox.CheckedChanged += new System.EventHandler(this.Fan_CheckBox_CheckedChanged);
            // 
            // IACV_CheckBox
            // 
            this.IACV_CheckBox.AutoSize = true;
            this.IACV_CheckBox.Location = new System.Drawing.Point(12, 251);
            this.IACV_CheckBox.Name = "IACV_CheckBox";
            this.IACV_CheckBox.Size = new System.Drawing.Size(113, 17);
            this.IACV_CheckBox.TabIndex = 9;
            this.IACV_CheckBox.Text = "Disable IACV Error";
            this.IACV_CheckBox.UseVisualStyleBackColor = true;
            this.IACV_CheckBox.CheckedChanged += new System.EventHandler(this.IACV_CheckBox_CheckedChanged);
            // 
            // FuelCut_CheckBox
            // 
            this.FuelCut_CheckBox.AutoSize = true;
            this.FuelCut_CheckBox.Location = new System.Drawing.Point(164, 44);
            this.FuelCut_CheckBox.Name = "FuelCut_CheckBox";
            this.FuelCut_CheckBox.Size = new System.Drawing.Size(101, 17);
            this.FuelCut_CheckBox.TabIndex = 13;
            this.FuelCut_CheckBox.Text = "Enable Fuel Cut";
            this.FuelCut_CheckBox.UseVisualStyleBackColor = true;
            this.FuelCut_CheckBox.CheckedChanged += new System.EventHandler(this.FuelCut_CheckBox_CheckedChanged);
            // 
            // IgnCut_CheckBox
            // 
            this.IgnCut_CheckBox.AutoSize = true;
            this.IgnCut_CheckBox.Location = new System.Drawing.Point(164, 67);
            this.IgnCut_CheckBox.Name = "IgnCut_CheckBox";
            this.IgnCut_CheckBox.Size = new System.Drawing.Size(96, 17);
            this.IgnCut_CheckBox.TabIndex = 14;
            this.IgnCut_CheckBox.Text = "Enable Ign Cut";
            this.IgnCut_CheckBox.UseVisualStyleBackColor = true;
            this.IgnCut_CheckBox.CheckedChanged += new System.EventHandler(this.IgnCut_CheckBox_CheckedChanged);
            // 
            // ShiftLight_CheckBox
            // 
            this.ShiftLight_CheckBox.AutoSize = true;
            this.ShiftLight_CheckBox.Location = new System.Drawing.Point(164, 90);
            this.ShiftLight_CheckBox.Name = "ShiftLight_CheckBox";
            this.ShiftLight_CheckBox.Size = new System.Drawing.Size(109, 17);
            this.ShiftLight_CheckBox.TabIndex = 15;
            this.ShiftLight_CheckBox.Text = "Enable Shift Light";
            this.ShiftLight_CheckBox.UseVisualStyleBackColor = true;
            this.ShiftLight_CheckBox.CheckedChanged += new System.EventHandler(this.ShiftLight_CheckBox_CheckedChanged);
            // 
            // ColdSet_TextBox
            // 
            this.ColdSet_TextBox.Location = new System.Drawing.Point(228, 111);
            this.ColdSet_TextBox.MaxLength = 5;
            this.ColdSet_TextBox.Name = "ColdSet_TextBox";
            this.ColdSet_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ColdSet_TextBox.Size = new System.Drawing.Size(45, 20);
            this.ColdSet_TextBox.TabIndex = 16;
            this.ColdSet_TextBox.Text = "9999";
            this.ColdSet_TextBox.TextChanged += new System.EventHandler(this.ColdSet_TextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cold Set";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cold Reset";
            // 
            // ColdReset_TextBox
            // 
            this.ColdReset_TextBox.Location = new System.Drawing.Point(228, 134);
            this.ColdReset_TextBox.MaxLength = 5;
            this.ColdReset_TextBox.Name = "ColdReset_TextBox";
            this.ColdReset_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ColdReset_TextBox.Size = new System.Drawing.Size(45, 20);
            this.ColdReset_TextBox.TabIndex = 18;
            this.ColdReset_TextBox.Text = "9999";
            this.ColdReset_TextBox.TextChanged += new System.EventHandler(this.ColdReset_TextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Warm Set";
            // 
            // WarmSet_TextBox
            // 
            this.WarmSet_TextBox.Location = new System.Drawing.Point(228, 157);
            this.WarmSet_TextBox.MaxLength = 5;
            this.WarmSet_TextBox.Name = "WarmSet_TextBox";
            this.WarmSet_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.WarmSet_TextBox.Size = new System.Drawing.Size(45, 20);
            this.WarmSet_TextBox.TabIndex = 20;
            this.WarmSet_TextBox.Text = "9999";
            this.WarmSet_TextBox.TextChanged += new System.EventHandler(this.WarmSet_TextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Warm Reset";
            // 
            // WarmReset_TextBox
            // 
            this.WarmReset_TextBox.Location = new System.Drawing.Point(228, 180);
            this.WarmReset_TextBox.MaxLength = 5;
            this.WarmReset_TextBox.Name = "WarmReset_TextBox";
            this.WarmReset_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.WarmReset_TextBox.Size = new System.Drawing.Size(45, 20);
            this.WarmReset_TextBox.TabIndex = 22;
            this.WarmReset_TextBox.Text = "9999";
            this.WarmReset_TextBox.TextChanged += new System.EventHandler(this.WarmReset_TextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Shift Light";
            // 
            // ShiftLight_TextBox
            // 
            this.ShiftLight_TextBox.Location = new System.Drawing.Point(228, 203);
            this.ShiftLight_TextBox.MaxLength = 5;
            this.ShiftLight_TextBox.Name = "ShiftLight_TextBox";
            this.ShiftLight_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ShiftLight_TextBox.Size = new System.Drawing.Size(45, 20);
            this.ShiftLight_TextBox.TabIndex = 24;
            this.ShiftLight_TextBox.Text = "9999";
            this.ShiftLight_TextBox.TextChanged += new System.EventHandler(this.ShiftLight_TextBox_TextChanged);
            // 
            // SpeedCheck_CheckBox
            // 
            this.SpeedCheck_CheckBox.AutoSize = true;
            this.SpeedCheck_CheckBox.Location = new System.Drawing.Point(310, 44);
            this.SpeedCheck_CheckBox.Name = "SpeedCheck_CheckBox";
            this.SpeedCheck_CheckBox.Size = new System.Drawing.Size(129, 17);
            this.SpeedCheck_CheckBox.TabIndex = 26;
            this.SpeedCheck_CheckBox.Text = "Disable Speed Check";
            this.SpeedCheck_CheckBox.UseVisualStyleBackColor = true;
            this.SpeedCheck_CheckBox.CheckedChanged += new System.EventHandler(this.SpeedCheck_CheckBox_CheckedChanged);
            // 
            // CoolantCheck_CheckBox
            // 
            this.CoolantCheck_CheckBox.AutoSize = true;
            this.CoolantCheck_CheckBox.Location = new System.Drawing.Point(310, 67);
            this.CoolantCheck_CheckBox.Name = "CoolantCheck_CheckBox";
            this.CoolantCheck_CheckBox.Size = new System.Drawing.Size(134, 17);
            this.CoolantCheck_CheckBox.TabIndex = 27;
            this.CoolantCheck_CheckBox.Text = "Disable Coolant Check";
            this.CoolantCheck_CheckBox.UseVisualStyleBackColor = true;
            this.CoolantCheck_CheckBox.CheckedChanged += new System.EventHandler(this.CoolantCheck_CheckBox_CheckedChanged);
            // 
            // VTP_CheckBox
            // 
            this.VTP_CheckBox.AutoSize = true;
            this.VTP_CheckBox.Location = new System.Drawing.Point(310, 90);
            this.VTP_CheckBox.Name = "VTP_CheckBox";
            this.VTP_CheckBox.Size = new System.Drawing.Size(119, 17);
            this.VTP_CheckBox.TabIndex = 28;
            this.VTP_CheckBox.Text = "Disable VTPressure";
            this.VTP_CheckBox.UseVisualStyleBackColor = true;
            this.VTP_CheckBox.CheckedChanged += new System.EventHandler(this.VTP_CheckBox_CheckedChanged);
            // 
            // VtecError_CheckBox
            // 
            this.VtecError_CheckBox.AutoSize = true;
            this.VtecError_CheckBox.Location = new System.Drawing.Point(310, 113);
            this.VtecError_CheckBox.Name = "VtecError_CheckBox";
            this.VtecError_CheckBox.Size = new System.Drawing.Size(111, 17);
            this.VtecError_CheckBox.TabIndex = 29;
            this.VtecError_CheckBox.Text = "Disable Vtec Error";
            this.VtecError_CheckBox.UseVisualStyleBackColor = true;
            this.VtecError_CheckBox.CheckedChanged += new System.EventHandler(this.VtecError_CheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Low Load";
            // 
            // VtecLow_TextBox
            // 
            this.VtecLow_TextBox.Location = new System.Drawing.Point(374, 157);
            this.VtecLow_TextBox.MaxLength = 5;
            this.VtecLow_TextBox.Name = "VtecLow_TextBox";
            this.VtecLow_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.VtecLow_TextBox.Size = new System.Drawing.Size(45, 20);
            this.VtecLow_TextBox.TabIndex = 33;
            this.VtecLow_TextBox.Text = "9999";
            this.VtecLow_TextBox.TextChanged += new System.EventHandler(this.VtecLow_TextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "High Load";
            // 
            // VtecHigh_TextBox
            // 
            this.VtecHigh_TextBox.Location = new System.Drawing.Point(374, 134);
            this.VtecHigh_TextBox.MaxLength = 5;
            this.VtecHigh_TextBox.Name = "VtecHigh_TextBox";
            this.VtecHigh_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.VtecHigh_TextBox.Size = new System.Drawing.Size(45, 20);
            this.VtecHigh_TextBox.TabIndex = 31;
            this.VtecHigh_TextBox.Text = "9999";
            this.VtecHigh_TextBox.TextChanged += new System.EventHandler(this.VtecHigh_TextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightCyan;
            this.label8.Location = new System.Drawing.Point(4, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 25);
            this.label8.TabIndex = 35;
            this.label8.Text = "SENSORS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.LightCyan;
            this.label9.Location = new System.Drawing.Point(164, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 25);
            this.label9.TabIndex = 36;
            this.label9.Text = "LIMITER";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.LightCyan;
            this.label10.Location = new System.Drawing.Point(334, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 25);
            this.label10.TabIndex = 37;
            this.label10.Text = "VTEC";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.LightCyan;
            this.label11.Location = new System.Drawing.Point(288, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 16);
            this.label11.TabIndex = 38;
            this.label11.Text = "Made By Bouletmarc";
            // 
            // Reconvert_Button
            // 
            this.Reconvert_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reconvert_Button.ForeColor = System.Drawing.Color.Red;
            this.Reconvert_Button.Location = new System.Drawing.Point(310, 186);
            this.Reconvert_Button.Name = "Reconvert_Button";
            this.Reconvert_Button.Size = new System.Drawing.Size(129, 52);
            this.Reconvert_Button.TabIndex = 39;
            this.Reconvert_Button.Text = "RECONVERT";
            this.Reconvert_Button.UseVisualStyleBackColor = true;
            this.Reconvert_Button.Click += new System.EventHandler(this.Reconvert_Button_Click);
            // 
            // Edit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(445, 270);
            this.Controls.Add(this.Reconvert_Button);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.VtecLow_TextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.VtecHigh_TextBox);
            this.Controls.Add(this.VtecError_CheckBox);
            this.Controls.Add(this.VTP_CheckBox);
            this.Controls.Add(this.CoolantCheck_CheckBox);
            this.Controls.Add(this.SpeedCheck_CheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ShiftLight_TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WarmReset_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WarmSet_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColdReset_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColdSet_TextBox);
            this.Controls.Add(this.ShiftLight_CheckBox);
            this.Controls.Add(this.IgnCut_CheckBox);
            this.Controls.Add(this.FuelCut_CheckBox);
            this.Controls.Add(this.IACV_CheckBox);
            this.Controls.Add(this.Fan_CheckBox);
            this.Controls.Add(this.IAB_CheckBox);
            this.Controls.Add(this.Vtec_CheckBox);
            this.Controls.Add(this.Closeloop_CheckBox);
            this.Controls.Add(this.Heater_CheckBox);
            this.Controls.Add(this.InjTest_CheckBox);
            this.Controls.Add(this.Baro_CheckBox);
            this.Controls.Add(this.Knock_CheckBox);
            this.Controls.Add(this.ELD_CheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Edit_Form";
            this.Text = "Converter - Edit Parameters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ELD_CheckBox;
        private System.Windows.Forms.CheckBox Knock_CheckBox;
        private System.Windows.Forms.CheckBox Baro_CheckBox;
        private System.Windows.Forms.CheckBox InjTest_CheckBox;
        private System.Windows.Forms.CheckBox Heater_CheckBox;
        private System.Windows.Forms.CheckBox Closeloop_CheckBox;
        private System.Windows.Forms.CheckBox Vtec_CheckBox;
        private System.Windows.Forms.CheckBox IAB_CheckBox;
        private System.Windows.Forms.CheckBox Fan_CheckBox;
        private System.Windows.Forms.CheckBox IACV_CheckBox;
        private System.Windows.Forms.CheckBox FuelCut_CheckBox;
        private System.Windows.Forms.CheckBox IgnCut_CheckBox;
        private System.Windows.Forms.CheckBox ShiftLight_CheckBox;
        private System.Windows.Forms.TextBox ColdSet_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ColdReset_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox WarmSet_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox WarmReset_TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ShiftLight_TextBox;
        private System.Windows.Forms.CheckBox SpeedCheck_CheckBox;
        private System.Windows.Forms.CheckBox CoolantCheck_CheckBox;
        private System.Windows.Forms.CheckBox VTP_CheckBox;
        private System.Windows.Forms.CheckBox VtecError_CheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox VtecLow_TextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox VtecHigh_TextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Reconvert_Button;
    }
}