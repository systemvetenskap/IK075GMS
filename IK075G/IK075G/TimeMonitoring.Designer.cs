namespace IK075G
{
    partial class TimeMonitoring
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.btnBack = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.comboBoxAnalysis = new System.Windows.Forms.ComboBox();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.comboBoxCustomerGrp = new System.Windows.Forms.ComboBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblAnalysis = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblCustomerGrp = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTimeInterval = new System.Windows.Forms.Label();
            this.comboBoxTimeInterval = new System.Windows.Forms.ComboBox();
            this.btnShowUpdateDiagram = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chartResponseTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResponseTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1267, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(241, 39);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Till huvudmenyn";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 29);
            this.label8.TabIndex = 21;
            this.label8.Text = "Svarstider";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(921, 101);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(218, 26);
            this.dateTimePickerTo.TabIndex = 35;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(681, 101);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(232, 26);
            this.dateTimePickerFrom.TabIndex = 34;
            // 
            // comboBoxAnalysis
            // 
            this.comboBoxAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAnalysis.FormattingEnabled = true;
            this.comboBoxAnalysis.Location = new System.Drawing.Point(298, 101);
            this.comboBoxAnalysis.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAnalysis.Name = "comboBoxAnalysis";
            this.comboBoxAnalysis.Size = new System.Drawing.Size(185, 28);
            this.comboBoxAnalysis.TabIndex = 31;
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Location = new System.Drawing.Point(504, 101);
            this.comboBoxPriority.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(155, 28);
            this.comboBoxPriority.TabIndex = 30;
            // 
            // comboBoxCustomerGrp
            // 
            this.comboBoxCustomerGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCustomerGrp.FormattingEnabled = true;
            this.comboBoxCustomerGrp.Location = new System.Drawing.Point(34, 101);
            this.comboBoxCustomerGrp.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCustomerGrp.Name = "comboBoxCustomerGrp";
            this.comboBoxCustomerGrp.Size = new System.Drawing.Size(234, 28);
            this.comboBoxCustomerGrp.TabIndex = 29;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(681, 78);
            this.lblDateFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(98, 20);
            this.lblDateFrom.TabIndex = 28;
            this.lblDateFrom.Text = "Datum från:";
            // 
            // lblAnalysis
            // 
            this.lblAnalysis.AutoSize = true;
            this.lblAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalysis.Location = new System.Drawing.Point(298, 78);
            this.lblAnalysis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnalysis.Name = "lblAnalysis";
            this.lblAnalysis.Size = new System.Drawing.Size(95, 20);
            this.lblAnalysis.TabIndex = 27;
            this.lblAnalysis.Text = "Välj analys:";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(504, 78);
            this.lblPriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(155, 20);
            this.lblPriority.TabIndex = 26;
            this.lblPriority.Text = "Välj prioritetsgrupp:";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(921, 78);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(86, 20);
            this.lblDateTo.TabIndex = 23;
            this.lblDateTo.Text = "Datum till:";
            // 
            // lblCustomerGrp
            // 
            this.lblCustomerGrp.AutoSize = true;
            this.lblCustomerGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerGrp.Location = new System.Drawing.Point(34, 78);
            this.lblCustomerGrp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerGrp.Name = "lblCustomerGrp";
            this.lblCustomerGrp.Size = new System.Drawing.Size(124, 20);
            this.lblCustomerGrp.TabIndex = 22;
            this.lblCustomerGrp.Text = "Välj kundgrupp:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(291, 32);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(138, 28);
            this.dataGridView1.TabIndex = 36;
            // 
            // labelTimeInterval
            // 
            this.labelTimeInterval.AutoSize = true;
            this.labelTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeInterval.Location = new System.Drawing.Point(34, 190);
            this.labelTimeInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeInterval.Name = "labelTimeInterval";
            this.labelTimeInterval.Size = new System.Drawing.Size(132, 20);
            this.labelTimeInterval.TabIndex = 38;
            this.labelTimeInterval.Text = "Välj tidsintervall:";
            // 
            // comboBoxTimeInterval
            // 
            this.comboBoxTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBoxTimeInterval.FormattingEnabled = true;
            this.comboBoxTimeInterval.Location = new System.Drawing.Point(34, 214);
            this.comboBoxTimeInterval.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTimeInterval.Name = "comboBoxTimeInterval";
            this.comboBoxTimeInterval.Size = new System.Drawing.Size(234, 28);
            this.comboBoxTimeInterval.TabIndex = 37;
            this.comboBoxTimeInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeInterval_SelectedIndexChanged_1);
            // 
            // btnShowUpdateDiagram
            // 
            this.btnShowUpdateDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUpdateDiagram.Location = new System.Drawing.Point(34, 261);
            this.btnShowUpdateDiagram.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowUpdateDiagram.Name = "btnShowUpdateDiagram";
            this.btnShowUpdateDiagram.Size = new System.Drawing.Size(161, 37);
            this.btnShowUpdateDiagram.TabIndex = 39;
            this.btnShowUpdateDiagram.Text = "Updatera/visa";
            this.btnShowUpdateDiagram.UseVisualStyleBackColor = true;
            this.btnShowUpdateDiagram.Click += new System.EventHandler(this.btnShowUpdateDiagram_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Välj personer:";
            // 
            // chartResponseTime
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResponseTime.ChartAreas.Add(chartArea1);
            this.chartResponseTime.Location = new System.Drawing.Point(295, 190);
            this.chartResponseTime.Name = "chartResponseTime";
            this.chartResponseTime.Size = new System.Drawing.Size(961, 434);
            this.chartResponseTime.TabIndex = 41;
            this.chartResponseTime.Text = "chart1";
            // 
            // TimeMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 690);
            this.Controls.Add(this.chartResponseTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowUpdateDiagram);
            this.Controls.Add(this.labelTimeInterval);
            this.Controls.Add(this.comboBoxTimeInterval);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.comboBoxAnalysis);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.comboBoxCustomerGrp);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.lblAnalysis);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblCustomerGrp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "TimeMonitoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Svarstider";
            this.Load += new System.EventHandler(this.TimeMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResponseTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.ComboBox comboBoxAnalysis;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.ComboBox comboBoxCustomerGrp;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblAnalysis;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblCustomerGrp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTimeInterval;
        private System.Windows.Forms.ComboBox comboBoxTimeInterval;
        private System.Windows.Forms.Button btnShowUpdateDiagram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResponseTime;
    }
}