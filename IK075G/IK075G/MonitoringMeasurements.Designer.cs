namespace IK075G
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitoringMeasurements));
            this.label1 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTodaysDateAndTime = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kundgrupp:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(235, 65);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 16);
            this.lblFrom.TabIndex = 25;
            this.lblFrom.Text = "Från:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(431, 65);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 16);
            this.lblTo.TabIndex = 26;
            this.lblTo.Text = "Till:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tidsintervall:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Analys:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(431, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Prioritetsgrupp:";
            // 
            // comboBoxCustomerGroup
            // 
            this.comboBoxCustomerGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCustomerGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCustomerGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCustomerGroup.FormattingEnabled = true;
            this.comboBoxCustomerGroup.Location = new System.Drawing.Point(42, 35);
            this.comboBoxCustomerGroup.Name = "comboBoxCustomerGroup";
            this.comboBoxCustomerGroup.Size = new System.Drawing.Size(180, 24);
            this.comboBoxCustomerGroup.TabIndex = 0;
            this.comboBoxCustomerGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomerGroup_SelectedIndexChanged);
            this.comboBoxCustomerGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxCustomerGroup_KeyPress);
            // 
            // comboBoxAnalysis
            // 
            this.comboBoxAnalysis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxAnalysis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAnalysis.FormattingEnabled = true;
            this.comboBoxAnalysis.Location = new System.Drawing.Point(235, 35);
            this.comboBoxAnalysis.Name = "comboBoxAnalysis";
            this.comboBoxAnalysis.Size = new System.Drawing.Size(180, 24);
            this.comboBoxAnalysis.TabIndex = 1;
            this.comboBoxAnalysis.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnalysis_SelectedIndexChanged);
            this.comboBoxAnalysis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxAnalysis_KeyPress);
            // 
            // comboBoxPriorityGroup
            // 
            this.comboBoxPriorityGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxPriorityGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPriorityGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPriorityGroup.FormattingEnabled = true;
            this.comboBoxPriorityGroup.Location = new System.Drawing.Point(431, 35);
            this.comboBoxPriorityGroup.Name = "comboBoxPriorityGroup";
            this.comboBoxPriorityGroup.Size = new System.Drawing.Size(180, 24);
            this.comboBoxPriorityGroup.TabIndex = 2;
            this.comboBoxPriorityGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriorityGroup_SelectedIndexChanged);
            this.comboBoxPriorityGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxPriorityGroup_KeyPress);
            // 
            // dateTimePickerDayFrom
            // 
            this.dateTimePickerDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDayFrom.Location = new System.Drawing.Point(235, 83);
            this.dateTimePickerDayFrom.Name = "dateTimePickerDayFrom";
            this.dateTimePickerDayFrom.ShowUpDown = true;
            this.dateTimePickerDayFrom.Size = new System.Drawing.Size(177, 22);
            this.dateTimePickerDayFrom.TabIndex = 9;
            this.dateTimePickerDayFrom.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerDayFrom.ValueChanged += new System.EventHandler(this.dateTimePickerDayFrom_ValueChanged);
            // 
            // dateTimePickerDayTo
            // 
            this.dateTimePickerDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDayTo.Location = new System.Drawing.Point(431, 83);
            this.dateTimePickerDayTo.Name = "dateTimePickerDayTo";
            this.dateTimePickerDayTo.ShowUpDown = true;
            this.dateTimePickerDayTo.Size = new System.Drawing.Size(177, 22);
            this.dateTimePickerDayTo.TabIndex = 10;
            this.dateTimePickerDayTo.ValueChanged += new System.EventHandler(this.dateTimePickerDayTo_ValueChanged);
            // 
            // comboBoxTimeInterval
            // 
            this.comboBoxTimeInterval.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxTimeInterval.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTimeInterval.FormattingEnabled = true;
            this.comboBoxTimeInterval.Location = new System.Drawing.Point(42, 83);
            this.comboBoxTimeInterval.Name = "comboBoxTimeInterval";
            this.comboBoxTimeInterval.Size = new System.Drawing.Size(180, 24);
            this.comboBoxTimeInterval.TabIndex = 3;
            this.comboBoxTimeInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeInterval_SelectedIndexChanged);
            this.comboBoxTimeInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxTimeInterval_KeyPress);
            // 
            // comboBoxYearFrom
            // 
            this.comboBoxYearFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxYearFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearFrom.FormattingEnabled = true;
            this.comboBoxYearFrom.Location = new System.Drawing.Point(235, 106);
            this.comboBoxYearFrom.Name = "comboBoxYearFrom";
            this.comboBoxYearFrom.Size = new System.Drawing.Size(81, 24);
            this.comboBoxYearFrom.TabIndex = 5;
            this.comboBoxYearFrom.Text = "Startår";
            this.comboBoxYearFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearFrom_SelectedIndexChanged);
            // 
            // comboBoxWeekFrom
            // 
            this.comboBoxWeekFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekFrom.FormattingEnabled = true;
            this.comboBoxWeekFrom.Location = new System.Drawing.Point(322, 106);
            this.comboBoxWeekFrom.Name = "comboBoxWeekFrom";
            this.comboBoxWeekFrom.Size = new System.Drawing.Size(90, 24);
            this.comboBoxWeekFrom.TabIndex = 6;
            this.comboBoxWeekFrom.Text = "Startvecka";
            this.comboBoxWeekFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeekFrom_SelectedIndexChanged);
            // 
            // comboBoxWeekTo
            // 
            this.comboBoxWeekTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekTo.FormattingEnabled = true;
            this.comboBoxWeekTo.Location = new System.Drawing.Point(518, 106);
            this.comboBoxWeekTo.Name = "comboBoxWeekTo";
            this.comboBoxWeekTo.Size = new System.Drawing.Size(90, 24);
            this.comboBoxWeekTo.TabIndex = 8;
            this.comboBoxWeekTo.Text = "Slutvecka";
            this.comboBoxWeekTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeekTo_SelectedIndexChanged);
            // 
            // comboBoxYearTo
            // 
            this.comboBoxYearTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxYearTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearTo.FormattingEnabled = true;
            this.comboBoxYearTo.Location = new System.Drawing.Point(431, 106);
            this.comboBoxYearTo.Name = "comboBoxYearTo";
            this.comboBoxYearTo.Size = new System.Drawing.Size(81, 24);
            this.comboBoxYearTo.TabIndex = 7;
            this.comboBoxYearTo.Text = "Slutår";
            this.comboBoxYearTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearTo_SelectedIndexChanged);
            // 
            // dateTimePickerMonthFrom
            // 
            this.dateTimePickerMonthFrom.CustomFormat = "MMMM yyyy";
            this.dateTimePickerMonthFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonthFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthFrom.Location = new System.Drawing.Point(235, 132);
            this.dateTimePickerMonthFrom.Name = "dateTimePickerMonthFrom";
            this.dateTimePickerMonthFrom.ShowUpDown = true;
            this.dateTimePickerMonthFrom.Size = new System.Drawing.Size(177, 22);
            this.dateTimePickerMonthFrom.TabIndex = 11;
            this.dateTimePickerMonthFrom.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerMonthFrom.ValueChanged += new System.EventHandler(this.dateTimePickerMonthFrom_ValueChanged);
            // 
            // dateTimePickerMonthTo
            // 
            this.dateTimePickerMonthTo.CustomFormat = "MMMM yyyy";
            this.dateTimePickerMonthTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthTo.Location = new System.Drawing.Point(431, 132);
            this.dateTimePickerMonthTo.Name = "dateTimePickerMonthTo";
            this.dateTimePickerMonthTo.ShowUpDown = true;
            this.dateTimePickerMonthTo.Size = new System.Drawing.Size(177, 22);
            this.dateTimePickerMonthTo.TabIndex = 12;
            this.dateTimePickerMonthTo.Value = new System.DateTime(2016, 4, 1, 0, 0, 0, 0);
            this.dateTimePickerMonthTo.ValueChanged += new System.EventHandler(this.dateTimePickerMonthTo_ValueChanged);
            // 
            // btnShowUpdateDiagram
            // 
            this.btnShowUpdateDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUpdateDiagram.Location = new System.Drawing.Point(614, 82);
            this.btnShowUpdateDiagram.Name = "btnShowUpdateDiagram";
            this.btnShowUpdateDiagram.Size = new System.Drawing.Size(180, 24);
            this.btnShowUpdateDiagram.TabIndex = 8;
            this.btnShowUpdateDiagram.Text = "Updatera/visa";
            this.btnShowUpdateDiagram.UseVisualStyleBackColor = true;
            this.btnShowUpdateDiagram.Click += new System.EventHandler(this.btnShowUpdateDiagram_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(-7, 160);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1197, 407);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTodaysDateAndTime
            // 
            this.lblTodaysDateAndTime.AutoSize = true;
            this.lblTodaysDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaysDateAndTime.Location = new System.Drawing.Point(988, 63);
            this.lblTodaysDateAndTime.Name = "lblTodaysDateAndTime";
            this.lblTodaysDateAndTime.Size = new System.Drawing.Size(151, 16);
            this.lblTodaysDateAndTime.TabIndex = 63;
            this.lblTodaysDateAndTime.Text = "DatumVeckodagKlocka";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(991, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(181, 32);
            this.btnBack.TabIndex = 64;
            this.btnBack.Text = "Till huvudmenyn";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // MonitoringMeasurements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTodaysDateAndTime);
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
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MonitoringMeasurements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IK075G - Uppföljning av mätvärden";
            this.Load += new System.EventHandler(this.MonitoringMeasurements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTodaysDateAndTime;
        private System.Windows.Forms.Button btnBack;
    }
}