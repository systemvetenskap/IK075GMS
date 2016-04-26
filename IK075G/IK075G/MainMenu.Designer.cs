﻿namespace IK075G
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnChoice1 = new System.Windows.Forms.Button();
            this.btnChoice2 = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnChoice3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoice1
            // 
            this.btnChoice1.Location = new System.Drawing.Point(47, 95);
            this.btnChoice1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChoice1.Name = "btnChoice1";
            this.btnChoice1.Size = new System.Drawing.Size(260, 107);
            this.btnChoice1.TabIndex = 0;
            this.btnChoice1.Text = "Kontroll av drift i en metod";
            this.btnChoice1.UseVisualStyleBackColor = true;
            this.btnChoice1.Click += new System.EventHandler(this.btnChoice1_Click);
            // 
            // btnChoice2
            // 
            this.btnChoice2.Location = new System.Drawing.Point(363, 95);
            this.btnChoice2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChoice2.Name = "btnChoice2";
            this.btnChoice2.Size = new System.Drawing.Size(260, 107);
            this.btnChoice2.TabIndex = 1;
            this.btnChoice2.Text = "Se svarstider";
            this.btnChoice2.UseVisualStyleBackColor = true;
            this.btnChoice2.Click += new System.EventHandler(this.btnChoice2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Huvudmeny";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnChoice3
            // 
            this.btnChoice3.Location = new System.Drawing.Point(47, 235);
            this.btnChoice3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChoice3.Name = "btnChoice3";
            this.btnChoice3.Size = new System.Drawing.Size(260, 107);
            this.btnChoice3.TabIndex = 3;
            this.btnChoice3.Text = "Uppföljning av mätvärden";
            this.btnChoice3.UseVisualStyleBackColor = true;
            this.btnChoice3.Click += new System.EventHandler(this.btnChoice3_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(720, 394);
            this.Controls.Add(this.btnChoice3);
            this.Controls.Add(this.btnChoice2);
            this.Controls.Add(this.btnChoice1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IK075G";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChoice1;
        private System.Windows.Forms.Button btnChoice2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnChoice3;
    }
}

