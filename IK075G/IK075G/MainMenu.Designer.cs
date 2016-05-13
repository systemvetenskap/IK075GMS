namespace IK075G
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
            this.btnOperationMethod = new System.Windows.Forms.Button();
            this.btnTimeMonitoring = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnMonitoringMeasurements = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOperationMethod
            // 
            this.btnOperationMethod.Location = new System.Drawing.Point(471, 236);
            this.btnOperationMethod.Margin = new System.Windows.Forms.Padding(4);
            this.btnOperationMethod.Name = "btnOperationMethod";
            this.btnOperationMethod.Size = new System.Drawing.Size(236, 87);
            this.btnOperationMethod.TabIndex = 2;
            this.btnOperationMethod.Text = "Kontroll av drift i en metod";
            this.btnOperationMethod.UseVisualStyleBackColor = true;
            this.btnOperationMethod.Click += new System.EventHandler(this.btnOperationMethod_Click);
            // 
            // btnTimeMonitoring
            // 
            this.btnTimeMonitoring.Location = new System.Drawing.Point(406, 62);
            this.btnTimeMonitoring.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimeMonitoring.Name = "btnTimeMonitoring";
            this.btnTimeMonitoring.Size = new System.Drawing.Size(236, 87);
            this.btnTimeMonitoring.TabIndex = 1;
            this.btnTimeMonitoring.Text = "Se svarstider";
            this.btnTimeMonitoring.UseVisualStyleBackColor = true;
            this.btnTimeMonitoring.Click += new System.EventHandler(this.btnTimeMonitoring_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnMonitoringMeasurements
            // 
            this.btnMonitoringMeasurements.Location = new System.Drawing.Point(79, 62);
            this.btnMonitoringMeasurements.Margin = new System.Windows.Forms.Padding(4);
            this.btnMonitoringMeasurements.Name = "btnMonitoringMeasurements";
            this.btnMonitoringMeasurements.Size = new System.Drawing.Size(236, 87);
            this.btnMonitoringMeasurements.TabIndex = 0;
            this.btnMonitoringMeasurements.Text = "Uppföljning av mätvärden";
            this.btnMonitoringMeasurements.UseVisualStyleBackColor = true;
            this.btnMonitoringMeasurements.Click += new System.EventHandler(this.btnMonitoringMeasurements_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(273, 208);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(174, 41);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Avsluta programmet";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(720, 336);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMonitoringMeasurements);
            this.Controls.Add(this.btnTimeMonitoring);
            this.Controls.Add(this.btnOperationMethod);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IK075G - Huvudmeny";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOperationMethod;
        private System.Windows.Forms.Button btnTimeMonitoring;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnMonitoringMeasurements;
        private System.Windows.Forms.Button btnExit;
    }
}

