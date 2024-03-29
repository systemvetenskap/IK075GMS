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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblTodaysDateAndTime = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.lblFromWeek = new System.Windows.Forms.Label();
            this.lblToWeek = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridTimeMonitoring = new System.Windows.Forms.DataGridView();
            this.comboBoxShow = new System.Windows.Forms.ComboBox();
            this.lblShowAs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimeMonitoring)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kund:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(235, 71);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 16);
            this.lblFrom.TabIndex = 25;
            this.lblFrom.Text = "Från:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(431, 71);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 16);
            this.lblTo.TabIndex = 26;
            this.lblTo.Text = "Till:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 71);
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
            this.comboBoxPriorityGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.dateTimePickerDayFrom.Location = new System.Drawing.Point(235, 89);
            this.dateTimePickerDayFrom.Name = "dateTimePickerDayFrom";
            this.dateTimePickerDayFrom.ShowUpDown = true;
            this.dateTimePickerDayFrom.Size = new System.Drawing.Size(177, 22);
            this.dateTimePickerDayFrom.TabIndex = 9;
            this.dateTimePickerDayFrom.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerDayTo
            // 
            this.dateTimePickerDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDayTo.Location = new System.Drawing.Point(431, 89);
            this.dateTimePickerDayTo.Name = "dateTimePickerDayTo";
            this.dateTimePickerDayTo.ShowUpDown = true;
            this.dateTimePickerDayTo.Size = new System.Drawing.Size(177, 22);
            this.dateTimePickerDayTo.TabIndex = 10;
            // 
            // comboBoxTimeInterval
            // 
            this.comboBoxTimeInterval.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxTimeInterval.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTimeInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTimeInterval.FormattingEnabled = true;
            this.comboBoxTimeInterval.Location = new System.Drawing.Point(42, 89);
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
            this.comboBoxYearFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearFrom.FormattingEnabled = true;
            this.comboBoxYearFrom.Location = new System.Drawing.Point(235, 111);
            this.comboBoxYearFrom.Name = "comboBoxYearFrom";
            this.comboBoxYearFrom.Size = new System.Drawing.Size(81, 24);
            this.comboBoxYearFrom.TabIndex = 5;
            // 
            // comboBoxWeekFrom
            // 
            this.comboBoxWeekFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekFrom.FormattingEnabled = true;
            this.comboBoxWeekFrom.Location = new System.Drawing.Point(322, 111);
            this.comboBoxWeekFrom.Name = "comboBoxWeekFrom";
            this.comboBoxWeekFrom.Size = new System.Drawing.Size(90, 24);
            this.comboBoxWeekFrom.TabIndex = 6;
            // 
            // comboBoxWeekTo
            // 
            this.comboBoxWeekTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekTo.FormattingEnabled = true;
            this.comboBoxWeekTo.Location = new System.Drawing.Point(518, 111);
            this.comboBoxWeekTo.Name = "comboBoxWeekTo";
            this.comboBoxWeekTo.Size = new System.Drawing.Size(90, 24);
            this.comboBoxWeekTo.TabIndex = 8;
            // 
            // comboBoxYearTo
            // 
            this.comboBoxYearTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxYearTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearTo.FormattingEnabled = true;
            this.comboBoxYearTo.Location = new System.Drawing.Point(431, 111);
            this.comboBoxYearTo.Name = "comboBoxYearTo";
            this.comboBoxYearTo.Size = new System.Drawing.Size(81, 24);
            this.comboBoxYearTo.TabIndex = 7;
            // 
            // dateTimePickerMonthFrom
            // 
            this.dateTimePickerMonthFrom.CustomFormat = "MMMM yyyy";
            this.dateTimePickerMonthFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonthFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthFrom.Location = new System.Drawing.Point(235, 136);
            this.dateTimePickerMonthFrom.Name = "dateTimePickerMonthFrom";
            this.dateTimePickerMonthFrom.ShowUpDown = true;
            this.dateTimePickerMonthFrom.Size = new System.Drawing.Size(177, 22);
            this.dateTimePickerMonthFrom.TabIndex = 11;
            this.dateTimePickerMonthFrom.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerMonthTo
            // 
            this.dateTimePickerMonthTo.CustomFormat = "MMMM yyyy";
            this.dateTimePickerMonthTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthTo.Location = new System.Drawing.Point(431, 136);
            this.dateTimePickerMonthTo.Name = "dateTimePickerMonthTo";
            this.dateTimePickerMonthTo.ShowUpDown = true;
            this.dateTimePickerMonthTo.Size = new System.Drawing.Size(177, 22);
            this.dateTimePickerMonthTo.TabIndex = 12;
            this.dateTimePickerMonthTo.Value = new System.DateTime(2016, 4, 1, 0, 0, 0, 0);
            // 
            // btnShowUpdateDiagram
            // 
            this.btnShowUpdateDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUpdateDiagram.Location = new System.Drawing.Point(622, 89);
            this.btnShowUpdateDiagram.Name = "btnShowUpdateDiagram";
            this.btnShowUpdateDiagram.Size = new System.Drawing.Size(117, 24);
            this.btnShowUpdateDiagram.TabIndex = 8;
            this.btnShowUpdateDiagram.Text = "Uppdatera";
            this.btnShowUpdateDiagram.UseVisualStyleBackColor = true;
            this.btnShowUpdateDiagram.Click += new System.EventHandler(this.btnShowUpdateDiagram_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 162);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1191, 302);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            // 
            // lblTodaysDateAndTime
            // 
            this.lblTodaysDateAndTime.AutoSize = true;
            this.lblTodaysDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaysDateAndTime.Location = new System.Drawing.Point(1021, 53);
            this.lblTodaysDateAndTime.Name = "lblTodaysDateAndTime";
            this.lblTodaysDateAndTime.Size = new System.Drawing.Size(123, 16);
            this.lblTodaysDateAndTime.TabIndex = 63;
            this.lblTodaysDateAndTime.Text = "yearmmdayofweek";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(942, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(117, 24);
            this.btnBack.TabIndex = 64;
            this.btnBack.Text = "Huvudmeny";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(622, 116);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(45, 16);
            this.resultLabel.TabIndex = 66;
            this.resultLabel.Text = "label2";
            // 
            // lblFromWeek
            // 
            this.lblFromWeek.AutoSize = true;
            this.lblFromWeek.Location = new System.Drawing.Point(322, 73);
            this.lblFromWeek.Name = "lblFromWeek";
            this.lblFromWeek.Size = new System.Drawing.Size(41, 13);
            this.lblFromWeek.TabIndex = 67;
            this.lblFromWeek.Text = "Vecka:";
            // 
            // lblToWeek
            // 
            this.lblToWeek.AutoSize = true;
            this.lblToWeek.Location = new System.Drawing.Point(518, 74);
            this.lblToWeek.Name = "lblToWeek";
            this.lblToWeek.Size = new System.Drawing.Size(41, 13);
            this.lblToWeek.TabIndex = 68;
            this.lblToWeek.Text = "Vecka:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1062, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 24);
            this.button1.TabIndex = 69;
            this.button1.Text = "Avsluta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridTimeMonitoring
            // 
            this.dataGridTimeMonitoring.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTimeMonitoring.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridTimeMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTimeMonitoring.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridTimeMonitoring.Location = new System.Drawing.Point(96, 487);
            this.dataGridTimeMonitoring.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridTimeMonitoring.Name = "dataGridTimeMonitoring";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTimeMonitoring.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridTimeMonitoring.RowTemplate.Height = 24;
            this.dataGridTimeMonitoring.Size = new System.Drawing.Size(910, 162);
            this.dataGridTimeMonitoring.TabIndex = 73;
            // 
            // comboBoxShow
            // 
            this.comboBoxShow.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxShow.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxShow.FormattingEnabled = true;
            this.comboBoxShow.Location = new System.Drawing.Point(1029, 131);
            this.comboBoxShow.Name = "comboBoxShow";
            this.comboBoxShow.Size = new System.Drawing.Size(146, 24);
            this.comboBoxShow.TabIndex = 74;
            this.comboBoxShow.SelectedIndexChanged += new System.EventHandler(this.comboBoxShow_SelectedIndexChanged);
            // 
            // lblShowAs
            // 
            this.lblShowAs.AutoSize = true;
            this.lblShowAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowAs.Location = new System.Drawing.Point(1029, 110);
            this.lblShowAs.Name = "lblShowAs";
            this.lblShowAs.Size = new System.Drawing.Size(67, 16);
            this.lblShowAs.TabIndex = 75;
            this.lblShowAs.Text = "Visa som:";
            // 
            // MonitoringMeasurements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1187, 663);
            this.Controls.Add(this.lblShowAs);
            this.Controls.Add(this.comboBoxShow);
            this.Controls.Add(this.dataGridTimeMonitoring);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblToWeek);
            this.Controls.Add(this.lblFromWeek);
            this.Controls.Add(this.resultLabel);
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
            this.MaximizeBox = false;
            this.Name = "MonitoringMeasurements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IK075G - Uppföljning av mätvärden";
            this.Load += new System.EventHandler(this.MonitoringMeasurements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimeMonitoring)).EndInit();
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
        private System.Windows.Forms.Label lblTodaysDateAndTime;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label lblFromWeek;
        private System.Windows.Forms.Label lblToWeek;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridTimeMonitoring;
        private System.Windows.Forms.ComboBox comboBoxShow;
        private System.Windows.Forms.Label lblShowAs;
    }
}