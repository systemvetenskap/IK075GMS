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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.buttonSeries = new System.Windows.Forms.Button();
            this.labelSerieTyp = new System.Windows.Forms.Label();
            this.comboBoxSeries = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimeMonitoring)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kund:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(293, 87);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(48, 20);
            this.lblFrom.TabIndex = 25;
            this.lblFrom.Text = "Från:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(539, 87);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(36, 20);
            this.lblTo.TabIndex = 26;
            this.lblTo.Text = "Till:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tidsintervall:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(293, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Analys:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(539, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Prioritetsgrupp:";
            // 
            // comboBoxCustomerGroup
            // 
            this.comboBoxCustomerGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCustomerGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCustomerGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCustomerGroup.FormattingEnabled = true;
            this.comboBoxCustomerGroup.Location = new System.Drawing.Point(47, 46);
            this.comboBoxCustomerGroup.Name = "comboBoxCustomerGroup";
            this.comboBoxCustomerGroup.Size = new System.Drawing.Size(231, 28);
            this.comboBoxCustomerGroup.TabIndex = 0;
            this.comboBoxCustomerGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomerGroup_SelectedIndexChanged);
            this.comboBoxCustomerGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxCustomerGroup_KeyPress);
            this.comboBoxCustomerGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBoxCustomerGroup_KeyUp);
            // 
            // comboBoxAnalysis
            // 
            this.comboBoxAnalysis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxAnalysis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAnalysis.FormattingEnabled = true;
            this.comboBoxAnalysis.Location = new System.Drawing.Point(293, 46);
            this.comboBoxAnalysis.Name = "comboBoxAnalysis";
            this.comboBoxAnalysis.Size = new System.Drawing.Size(231, 28);
            this.comboBoxAnalysis.TabIndex = 1;
            this.comboBoxAnalysis.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnalysis_SelectedIndexChanged);
            this.comboBoxAnalysis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxAnalysis_KeyPress);
            this.comboBoxAnalysis.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBoxAnalysis_KeyUp);
            // 
            // comboBoxPriorityGroup
            // 
            this.comboBoxPriorityGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxPriorityGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPriorityGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriorityGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPriorityGroup.FormattingEnabled = true;
            this.comboBoxPriorityGroup.Location = new System.Drawing.Point(539, 46);
            this.comboBoxPriorityGroup.Name = "comboBoxPriorityGroup";
            this.comboBoxPriorityGroup.Size = new System.Drawing.Size(231, 28);
            this.comboBoxPriorityGroup.TabIndex = 2;
            this.comboBoxPriorityGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriorityGroup_SelectedIndexChanged);
            this.comboBoxPriorityGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxPriorityGroup_KeyPress);
            this.comboBoxPriorityGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBoxPriorityGroup_KeyUp);
            // 
            // dateTimePickerDayFrom
            // 
            this.dateTimePickerDayFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDayFrom.Location = new System.Drawing.Point(293, 113);
            this.dateTimePickerDayFrom.Name = "dateTimePickerDayFrom";
            this.dateTimePickerDayFrom.ShowUpDown = true;
            this.dateTimePickerDayFrom.Size = new System.Drawing.Size(231, 26);
            this.dateTimePickerDayFrom.TabIndex = 9;
            this.dateTimePickerDayFrom.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerDayTo
            // 
            this.dateTimePickerDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDayTo.Location = new System.Drawing.Point(539, 113);
            this.dateTimePickerDayTo.Name = "dateTimePickerDayTo";
            this.dateTimePickerDayTo.ShowUpDown = true;
            this.dateTimePickerDayTo.Size = new System.Drawing.Size(231, 26);
            this.dateTimePickerDayTo.TabIndex = 10;
            // 
            // comboBoxTimeInterval
            // 
            this.comboBoxTimeInterval.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxTimeInterval.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTimeInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTimeInterval.FormattingEnabled = true;
            this.comboBoxTimeInterval.Location = new System.Drawing.Point(47, 111);
            this.comboBoxTimeInterval.Name = "comboBoxTimeInterval";
            this.comboBoxTimeInterval.Size = new System.Drawing.Size(231, 28);
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
            this.comboBoxYearFrom.Location = new System.Drawing.Point(293, 146);
            this.comboBoxYearFrom.Name = "comboBoxYearFrom";
            this.comboBoxYearFrom.Size = new System.Drawing.Size(97, 28);
            this.comboBoxYearFrom.TabIndex = 5;
            // 
            // comboBoxWeekFrom
            // 
            this.comboBoxWeekFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekFrom.FormattingEnabled = true;
            this.comboBoxWeekFrom.Location = new System.Drawing.Point(397, 146);
            this.comboBoxWeekFrom.Name = "comboBoxWeekFrom";
            this.comboBoxWeekFrom.Size = new System.Drawing.Size(124, 28);
            this.comboBoxWeekFrom.TabIndex = 6;
            // 
            // comboBoxWeekTo
            // 
            this.comboBoxWeekTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekTo.FormattingEnabled = true;
            this.comboBoxWeekTo.Location = new System.Drawing.Point(647, 146);
            this.comboBoxWeekTo.Name = "comboBoxWeekTo";
            this.comboBoxWeekTo.Size = new System.Drawing.Size(120, 28);
            this.comboBoxWeekTo.TabIndex = 8;
            // 
            // comboBoxYearTo
            // 
            this.comboBoxYearTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxYearTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearTo.FormattingEnabled = true;
            this.comboBoxYearTo.Location = new System.Drawing.Point(539, 146);
            this.comboBoxYearTo.Name = "comboBoxYearTo";
            this.comboBoxYearTo.Size = new System.Drawing.Size(103, 28);
            this.comboBoxYearTo.TabIndex = 7;
            // 
            // dateTimePickerMonthFrom
            // 
            this.dateTimePickerMonthFrom.CustomFormat = "MMMM yyyy";
            this.dateTimePickerMonthFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonthFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthFrom.Location = new System.Drawing.Point(790, 48);
            this.dateTimePickerMonthFrom.Name = "dateTimePickerMonthFrom";
            this.dateTimePickerMonthFrom.ShowUpDown = true;
            this.dateTimePickerMonthFrom.Size = new System.Drawing.Size(177, 26);
            this.dateTimePickerMonthFrom.TabIndex = 11;
            this.dateTimePickerMonthFrom.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerMonthTo
            // 
            this.dateTimePickerMonthTo.CustomFormat = "MMMM yyyy";
            this.dateTimePickerMonthTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthTo.Location = new System.Drawing.Point(973, 48);
            this.dateTimePickerMonthTo.Name = "dateTimePickerMonthTo";
            this.dateTimePickerMonthTo.ShowUpDown = true;
            this.dateTimePickerMonthTo.Size = new System.Drawing.Size(177, 26);
            this.dateTimePickerMonthTo.TabIndex = 12;
            this.dateTimePickerMonthTo.Value = new System.DateTime(2016, 4, 1, 0, 0, 0, 0);
            // 
            // btnShowUpdateDiagram
            // 
            this.btnShowUpdateDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUpdateDiagram.Location = new System.Drawing.Point(799, 109);
            this.btnShowUpdateDiagram.Name = "btnShowUpdateDiagram";
            this.btnShowUpdateDiagram.Size = new System.Drawing.Size(156, 30);
            this.btnShowUpdateDiagram.TabIndex = 8;
            this.btnShowUpdateDiagram.Text = "Uppdatera";
            this.btnShowUpdateDiagram.UseVisualStyleBackColor = true;
            this.btnShowUpdateDiagram.Click += new System.EventHandler(this.btnShowUpdateDiagram_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(0, 199);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(1588, 372);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            // 
            // lblTodaysDateAndTime
            // 
            this.lblTodaysDateAndTime.AutoSize = true;
            this.lblTodaysDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaysDateAndTime.Location = new System.Drawing.Point(1365, 66);
            this.lblTodaysDateAndTime.Name = "lblTodaysDateAndTime";
            this.lblTodaysDateAndTime.Size = new System.Drawing.Size(147, 20);
            this.lblTodaysDateAndTime.TabIndex = 63;
            this.lblTodaysDateAndTime.Text = "yearmmdayofweek";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1247, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(156, 30);
            this.btnBack.TabIndex = 64;
            this.btnBack.Text = "Huvudmeny";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(799, 150);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(53, 20);
            this.resultLabel.TabIndex = 66;
            this.resultLabel.Text = "label2";
            // 
            // lblFromWeek
            // 
            this.lblFromWeek.AutoSize = true;
            this.lblFromWeek.Location = new System.Drawing.Point(401, 90);
            this.lblFromWeek.Name = "lblFromWeek";
            this.lblFromWeek.Size = new System.Drawing.Size(51, 17);
            this.lblFromWeek.TabIndex = 67;
            this.lblFromWeek.Text = "Vecka:";
            // 
            // lblToWeek
            // 
            this.lblToWeek.AutoSize = true;
            this.lblToWeek.Location = new System.Drawing.Point(643, 90);
            this.lblToWeek.Name = "lblToWeek";
            this.lblToWeek.Size = new System.Drawing.Size(51, 17);
            this.lblToWeek.TabIndex = 68;
            this.lblToWeek.Text = "Vecka:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1411, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 30);
            this.button1.TabIndex = 69;
            this.button1.Text = "Avsluta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridTimeMonitoring
            // 
            this.dataGridTimeMonitoring.BackgroundColor = System.Drawing.Color.White;
            this.dataGridTimeMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTimeMonitoring.Location = new System.Drawing.Point(124, 700);
            this.dataGridTimeMonitoring.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridTimeMonitoring.Name = "dataGridTimeMonitoring";
            this.dataGridTimeMonitoring.RowTemplate.Height = 24;
            this.dataGridTimeMonitoring.Size = new System.Drawing.Size(1213, 199);
            this.dataGridTimeMonitoring.TabIndex = 73;
            // 
            // comboBoxShow
            // 
            this.comboBoxShow.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxShow.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxShow.FormattingEnabled = true;
            this.comboBoxShow.Location = new System.Drawing.Point(1365, 161);
            this.comboBoxShow.Name = "comboBoxShow";
            this.comboBoxShow.Size = new System.Drawing.Size(193, 28);
            this.comboBoxShow.TabIndex = 74;
            this.comboBoxShow.SelectedIndexChanged += new System.EventHandler(this.comboBoxShow_SelectedIndexChanged);
            // 
            // lblShowAs
            // 
            this.lblShowAs.AutoSize = true;
            this.lblShowAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowAs.Location = new System.Drawing.Point(1365, 138);
            this.lblShowAs.Name = "lblShowAs";
            this.lblShowAs.Size = new System.Drawing.Size(84, 20);
            this.lblShowAs.TabIndex = 75;
            this.lblShowAs.Text = "Visa som:";
            // 
            // buttonSeries
            // 
            this.buttonSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeries.Location = new System.Drawing.Point(1235, 159);
            this.buttonSeries.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSeries.Name = "buttonSeries";
            this.buttonSeries.Size = new System.Drawing.Size(98, 30);
            this.buttonSeries.TabIndex = 82;
            this.buttonSeries.Text = "Lägg Till";
            this.buttonSeries.UseVisualStyleBackColor = true;
            this.buttonSeries.Click += new System.EventHandler(this.buttonSeries_Click);
            // 
            // labelSerieTyp
            // 
            this.labelSerieTyp.AutoSize = true;
            this.labelSerieTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerieTyp.Location = new System.Drawing.Point(1080, 138);
            this.labelSerieTyp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSerieTyp.Name = "labelSerieTyp";
            this.labelSerieTyp.Size = new System.Drawing.Size(47, 20);
            this.labelSerieTyp.TabIndex = 81;
            this.labelSerieTyp.Text = "Visa:";
            // 
            // comboBoxSeries
            // 
            this.comboBoxSeries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxSeries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSeries.FormattingEnabled = true;
            this.comboBoxSeries.Location = new System.Drawing.Point(1077, 161);
            this.comboBoxSeries.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSeries.Name = "comboBoxSeries";
            this.comboBoxSeries.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSeries.TabIndex = 80;
            this.comboBoxSeries.SelectedIndexChanged += new System.EventHandler(this.comboBoxSeries_SelectedIndexChanged);
            // 
            // MonitoringMeasurements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1622, 973);
            this.Controls.Add(this.buttonSeries);
            this.Controls.Add(this.labelSerieTyp);
            this.Controls.Add(this.comboBoxSeries);
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
        private System.Windows.Forms.Button buttonSeries;
        private System.Windows.Forms.Label labelSerieTyp;
        private System.Windows.Forms.ComboBox comboBoxSeries;
    }
}