﻿namespace IK075G
{
    partial class MonitoringMeasurements
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCustomerGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxAnalysis = new System.Windows.Forms.ComboBox();
            this.comboBoxPriorityGroup = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDayFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDayTo = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTimeInterval = new System.Windows.Forms.ComboBox();
            this.comboBoxYearFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxWeekFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxWeekTo = new System.Windows.Forms.ComboBox();
            this.comboBoxYearTo = new System.Windows.Forms.ComboBox();
            this.dateTimePickerMonthFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMonthTo = new System.Windows.Forms.DateTimePicker();
            this.btnShowUpdateDiagram = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(246, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "Uppföljning av mätvärden";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(991, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(181, 32);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Till huvudmenyn";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kundgrupp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Från:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(477, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Till:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tidsintervall:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Analys:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(152, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Prioritetsgrupp:";
            // 
            // comboBoxCustomerGroup
            // 
            this.comboBoxCustomerGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCustomerGroup.FormattingEnabled = true;
            this.comboBoxCustomerGroup.Location = new System.Drawing.Point(25, 66);
            this.comboBoxCustomerGroup.Name = "comboBoxCustomerGroup";
            this.comboBoxCustomerGroup.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCustomerGroup.TabIndex = 34;
            this.comboBoxCustomerGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomerGroup_SelectedIndexChanged);
            // 
            // comboBoxAnalysis
            // 
            this.comboBoxAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAnalysis.FormattingEnabled = true;
            this.comboBoxAnalysis.Location = new System.Drawing.Point(25, 115);
            this.comboBoxAnalysis.Name = "comboBoxAnalysis";
            this.comboBoxAnalysis.Size = new System.Drawing.Size(121, 24);
            this.comboBoxAnalysis.TabIndex = 35;
            // 
            // comboBoxPriorityGroup
            // 
            this.comboBoxPriorityGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPriorityGroup.FormattingEnabled = true;
            this.comboBoxPriorityGroup.Location = new System.Drawing.Point(152, 66);
            this.comboBoxPriorityGroup.Name = "comboBoxPriorityGroup";
            this.comboBoxPriorityGroup.Size = new System.Drawing.Size(121, 24);
            this.comboBoxPriorityGroup.TabIndex = 36;
            // 
            // dateTimePickerDayFrom
            // 
            this.dateTimePickerDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDayFrom.Location = new System.Drawing.Point(286, 68);
            this.dateTimePickerDayFrom.Name = "dateTimePickerDayFrom";
            this.dateTimePickerDayFrom.Size = new System.Drawing.Size(164, 22);
            this.dateTimePickerDayFrom.TabIndex = 42;
            // 
            // dateTimePickerDayTo
            // 
            this.dateTimePickerDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDayTo.Location = new System.Drawing.Point(477, 68);
            this.dateTimePickerDayTo.Name = "dateTimePickerDayTo";
            this.dateTimePickerDayTo.Size = new System.Drawing.Size(164, 22);
            this.dateTimePickerDayTo.TabIndex = 43;
            // 
            // comboBoxTimeInterval
            // 
            this.comboBoxTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTimeInterval.FormattingEnabled = true;
            this.comboBoxTimeInterval.Location = new System.Drawing.Point(152, 115);
            this.comboBoxTimeInterval.Name = "comboBoxTimeInterval";
            this.comboBoxTimeInterval.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTimeInterval.TabIndex = 44;
            this.comboBoxTimeInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeInterval_SelectedIndexChanged);
            // 
            // comboBoxYearFrom
            // 
            this.comboBoxYearFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearFrom.FormattingEnabled = true;
            this.comboBoxYearFrom.Location = new System.Drawing.Point(286, 68);
            this.comboBoxYearFrom.Name = "comboBoxYearFrom";
            this.comboBoxYearFrom.Size = new System.Drawing.Size(70, 24);
            this.comboBoxYearFrom.TabIndex = 46;
            this.comboBoxYearFrom.Text = "Startår";
            // 
            // comboBoxWeekFrom
            // 
            this.comboBoxWeekFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekFrom.FormattingEnabled = true;
            this.comboBoxWeekFrom.Location = new System.Drawing.Point(355, 68);
            this.comboBoxWeekFrom.Name = "comboBoxWeekFrom";
            this.comboBoxWeekFrom.Size = new System.Drawing.Size(95, 24);
            this.comboBoxWeekFrom.TabIndex = 47;
            this.comboBoxWeekFrom.Text = "Startvecka";
            // 
            // comboBoxWeekTo
            // 
            this.comboBoxWeekTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekTo.FormattingEnabled = true;
            this.comboBoxWeekTo.Location = new System.Drawing.Point(546, 68);
            this.comboBoxWeekTo.Name = "comboBoxWeekTo";
            this.comboBoxWeekTo.Size = new System.Drawing.Size(95, 24);
            this.comboBoxWeekTo.TabIndex = 48;
            this.comboBoxWeekTo.Text = "Slutvecka";
            // 
            // comboBoxYearTo
            // 
            this.comboBoxYearTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearTo.FormattingEnabled = true;
            this.comboBoxYearTo.Location = new System.Drawing.Point(477, 68);
            this.comboBoxYearTo.Name = "comboBoxYearTo";
            this.comboBoxYearTo.Size = new System.Drawing.Size(70, 24);
            this.comboBoxYearTo.TabIndex = 49;
            this.comboBoxYearTo.Text = "Slutår";
            // 
            // dateTimePickerMonthFrom
            // 
            this.dateTimePickerMonthFrom.CustomFormat = "MMMM yyyy";
            this.dateTimePickerMonthFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonthFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthFrom.Location = new System.Drawing.Point(286, 68);
            this.dateTimePickerMonthFrom.Name = "dateTimePickerMonthFrom";
            this.dateTimePickerMonthFrom.Size = new System.Drawing.Size(164, 22);
            this.dateTimePickerMonthFrom.TabIndex = 58;
            this.dateTimePickerMonthFrom.Value = new System.DateTime(2016, 4, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerMonthTo
            // 
            this.dateTimePickerMonthTo.CustomFormat = "MMMM yyyy";
            this.dateTimePickerMonthTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthTo.Location = new System.Drawing.Point(477, 68);
            this.dateTimePickerMonthTo.Name = "dateTimePickerMonthTo";
            this.dateTimePickerMonthTo.Size = new System.Drawing.Size(164, 22);
            this.dateTimePickerMonthTo.TabIndex = 59;
            this.dateTimePickerMonthTo.Value = new System.DateTime(2016, 4, 1, 0, 0, 0, 0);
            // 
            // btnShowUpdateDiagram
            // 
            this.btnShowUpdateDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUpdateDiagram.Location = new System.Drawing.Point(689, 66);
            this.btnShowUpdateDiagram.Name = "btnShowUpdateDiagram";
            this.btnShowUpdateDiagram.Size = new System.Drawing.Size(180, 30);
            this.btnShowUpdateDiagram.TabIndex = 60;
            this.btnShowUpdateDiagram.Text = "Updatera/visa";
            this.btnShowUpdateDiagram.UseVisualStyleBackColor = true;
            this.btnShowUpdateDiagram.Click += new System.EventHandler(this.btnShowUpdateDiagram_Click);
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(12, 150);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1160, 386);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            // 
            // MonitoringMeasurements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnShowUpdateDiagram);
            this.Controls.Add(this.dateTimePickerMonthTo);
            this.Controls.Add(this.dateTimePickerMonthFrom);
            this.Controls.Add(this.comboBoxYearTo);
            this.Controls.Add(this.comboBoxWeekTo);
            this.Controls.Add(this.comboBoxWeekFrom);
            this.Controls.Add(this.comboBoxYearFrom);
            this.Controls.Add(this.comboBoxTimeInterval);
            this.Controls.Add(this.dateTimePickerDayTo);
            this.Controls.Add(this.dateTimePickerDayFrom);
            this.Controls.Add(this.comboBoxPriorityGroup);
            this.Controls.Add(this.comboBoxAnalysis);
            this.Controls.Add(this.comboBoxCustomerGroup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MonitoringMeasurements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uppföljning av mätvärden";
            this.Load += new System.EventHandler(this.MonitoringMeasurements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCustomerGroup;
        private System.Windows.Forms.ComboBox comboBoxAnalysis;
        private System.Windows.Forms.ComboBox comboBoxPriorityGroup;
        private System.Windows.Forms.DateTimePicker dateTimePickerDayFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerDayTo;
        private System.Windows.Forms.ComboBox comboBoxTimeInterval;
        private System.Windows.Forms.ComboBox comboBoxYearFrom;
        private System.Windows.Forms.ComboBox comboBoxWeekFrom;
        private System.Windows.Forms.ComboBox comboBoxWeekTo;
        private System.Windows.Forms.ComboBox comboBoxYearTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerMonthFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerMonthTo;
        private System.Windows.Forms.Button btnShowUpdateDiagram;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}