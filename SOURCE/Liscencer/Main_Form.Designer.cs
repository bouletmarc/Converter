using System;

namespace Liscencer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.Good_Label = new System.Windows.Forms.Label();
            this.Bad_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCyan;
            this.label1.Location = new System.Drawing.Point(63, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liscencer";
            // 
            // Good_Label
            // 
            this.Good_Label.AutoSize = true;
            this.Good_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Good_Label.ForeColor = System.Drawing.Color.Lime;
            this.Good_Label.Location = new System.Drawing.Point(82, 45);
            this.Good_Label.Name = "Good_Label";
            this.Good_Label.Size = new System.Drawing.Size(110, 20);
            this.Good_Label.TabIndex = 1;
            this.Good_Label.Text = "LISCENCED";
            // 
            // Bad_Label
            // 
            this.Bad_Label.AutoSize = true;
            this.Bad_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bad_Label.ForeColor = System.Drawing.Color.Red;
            this.Bad_Label.Location = new System.Drawing.Point(47, 45);
            this.Bad_Label.Name = "Bad_Label";
            this.Bad_Label.Size = new System.Drawing.Size(179, 20);
            this.Bad_Label.TabIndex = 2;
            this.Bad_Label.Text = "BAD HARDWARE ID";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(284, 75);
            this.Controls.Add(this.Bad_Label);
            this.Controls.Add(this.Good_Label);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main_Form";
            this.Text = "Converter - Liscencer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Good_Label;
        private System.Windows.Forms.Label Bad_Label;
    }
}

