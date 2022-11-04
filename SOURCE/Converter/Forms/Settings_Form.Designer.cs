namespace Converter
{
    partial class Settings_Form
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
            this.SaveLogs_Checkbox = new System.Windows.Forms.CheckBox();
            this.AdvLogs_Checkbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EctuneBaserom_ComboBox = new System.Windows.Forms.ComboBox();
            this.Close_Button = new System.Windows.Forms.Button();
            this.checkBox_4k_Hondata = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_Hondata_Chip_Lock = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveLogs_Checkbox
            // 
            this.SaveLogs_Checkbox.AutoSize = true;
            this.SaveLogs_Checkbox.Location = new System.Drawing.Point(16, 15);
            this.SaveLogs_Checkbox.Name = "SaveLogs_Checkbox";
            this.SaveLogs_Checkbox.Size = new System.Drawing.Size(143, 17);
            this.SaveLogs_Checkbox.TabIndex = 0;
            this.SaveLogs_Checkbox.Text = "Auto Save Logs (Slower)";
            this.SaveLogs_Checkbox.UseVisualStyleBackColor = true;
            this.SaveLogs_Checkbox.CheckedChanged += new System.EventHandler(this.SaveLogs_Checkbox_CheckedChanged);
            // 
            // AdvLogs_Checkbox
            // 
            this.AdvLogs_Checkbox.AutoSize = true;
            this.AdvLogs_Checkbox.Location = new System.Drawing.Point(16, 39);
            this.AdvLogs_Checkbox.Name = "AdvLogs_Checkbox";
            this.AdvLogs_Checkbox.Size = new System.Drawing.Size(142, 17);
            this.AdvLogs_Checkbox.TabIndex = 1;
            this.AdvLogs_Checkbox.Text = "Advanced Logs (Slower)";
            this.AdvLogs_Checkbox.UseVisualStyleBackColor = true;
            this.AdvLogs_Checkbox.CheckedChanged += new System.EventHandler(this.AdvLogs_Checkbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Baserom Version";
            // 
            // EctuneBaserom_ComboBox
            // 
            this.EctuneBaserom_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EctuneBaserom_ComboBox.FormattingEnabled = true;
            this.EctuneBaserom_ComboBox.Items.AddRange(new object[] {
            "0065.3.pri",
            "Custom",
            "0063",
            "0062",
            "0061",
            "0060",
            "0059",
            "0058",
            "0057",
            "0056",
            "0055",
            "0054"});
            this.EctuneBaserom_ComboBox.Location = new System.Drawing.Point(135, 14);
            this.EctuneBaserom_ComboBox.Name = "EctuneBaserom_ComboBox";
            this.EctuneBaserom_ComboBox.Size = new System.Drawing.Size(142, 21);
            this.EctuneBaserom_ComboBox.TabIndex = 5;
            this.EctuneBaserom_ComboBox.SelectedIndexChanged += new System.EventHandler(this.EctuneBaserom_ComboBox_SelectedIndexChanged);
            // 
            // Close_Button
            // 
            this.Close_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_Button.ForeColor = System.Drawing.Color.Blue;
            this.Close_Button.Location = new System.Drawing.Point(94, 181);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(124, 47);
            this.Close_Button.TabIndex = 7;
            this.Close_Button.Text = "CLOSE";
            this.Close_Button.UseVisualStyleBackColor = true;
            this.Close_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_4k_Hondata
            // 
            this.checkBox_4k_Hondata.AutoSize = true;
            this.checkBox_4k_Hondata.Location = new System.Drawing.Point(9, 19);
            this.checkBox_4k_Hondata.Name = "checkBox_4k_Hondata";
            this.checkBox_4k_Hondata.Size = new System.Drawing.Size(197, 17);
            this.checkBox_4k_Hondata.TabIndex = 8;
            this.checkBox_4k_Hondata.Text = "Remove 4000rpm Limit on S300 .bin";
            this.checkBox_4k_Hondata.UseVisualStyleBackColor = true;
            this.checkBox_4k_Hondata.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EctuneBaserom_ComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 43);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "eCtune Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_Hondata_Chip_Lock);
            this.groupBox2.Controls.Add(this.checkBox_4k_Hondata);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 40);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hondata Settings";
            // 
            // checkBox_Hondata_Chip_Lock
            // 
            this.checkBox_Hondata_Chip_Lock.AutoSize = true;
            this.checkBox_Hondata_Chip_Lock.Location = new System.Drawing.Point(147, 9);
            this.checkBox_Hondata_Chip_Lock.Name = "checkBox_Hondata_Chip_Lock";
            this.checkBox_Hondata_Chip_Lock.Size = new System.Drawing.Size(164, 17);
            this.checkBox_Hondata_Chip_Lock.TabIndex = 9;
            this.checkBox_Hondata_Chip_Lock.Text = "Remove Chip Lock Limitation";
            this.checkBox_Hondata_Chip_Lock.UseVisualStyleBackColor = true;
            this.checkBox_Hondata_Chip_Lock.Visible = false;
            this.checkBox_Hondata_Chip_Lock.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(342, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 142);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RTP Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "RTP Device:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Ostrich",
            "Demon"});
            this.comboBox2.Location = new System.Drawing.Point(135, 61);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(142, 21);
            this.comboBox2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "RTP With:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hondata SManager",
            "Neptune RTP",
            "eCtune"});
            this.comboBox1.Location = new System.Drawing.Point(135, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(167, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Enable Realtime Programming";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(303, 236);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.AdvLogs_Checkbox);
            this.Controls.Add(this.SaveLogs_Checkbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings_Form";
            this.Text = "Converter Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.CheckBox SaveLogs_Checkbox;
        private System.Windows.Forms.CheckBox AdvLogs_Checkbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EctuneBaserom_ComboBox;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.CheckBox checkBox_4k_Hondata;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox_Hondata_Chip_Lock;
    }
}