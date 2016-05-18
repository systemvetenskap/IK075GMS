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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel5 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel6 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btnBack = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.comboBoxAnalysis = new System.Windows.Forms.ComboBox();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblAnalysis = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.labelTimeInterval = new System.Windows.Forms.Label();
            this.comboBoxTimeInterval = new System.Windows.Forms.ComboBox();
            this.btnShowUpdateDiagram = new System.Windows.Forms.Button();
            this.chartResponseTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxYearTo = new System.Windows.Forms.ComboBox();
            this.comboBoxWeekTo = new System.Windows.Forms.ComboBox();
            this.comboBoxWeekFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxYearFrom = new System.Windows.Forms.ComboBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.lblTodaysDateAndTime = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.lblFromWeek = new System.Windows.Forms.Label();
            this.lblToWeek = new System.Windows.Forms.Label();
            this.comboBoxShow = new System.Windows.Forms.ComboBox();
            this.dataGridResponseTime = new System.Windows.Forms.DataGridView();
            this.lblShowAs = new System.Windows.Forms.Label();
            this.labelSerieTyp = new System.Windows.Forms.Label();
            this.comboBoxSerieTyp = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartResponseTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResponseTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1247, 14);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(156, 30);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Huvudmenyn";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(539, 113);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(231, 26);
            this.dateTimePickerTo.TabIndex = 5;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(293, 113);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(231, 26);
            this.dateTimePickerFrom.TabIndex = 4;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // comboBoxAnalysis
            // 
            this.comboBoxAnalysis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxAnalysis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAnalysis.FormattingEnabled = true;
            this.comboBoxAnalysis.Location = new System.Drawing.Point(293, 46);
            this.comboBoxAnalysis.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAnalysis.Name = "comboBoxAnalysis";
            this.comboBoxAnalysis.Size = new System.Drawing.Size(231, 28);
            this.comboBoxAnalysis.TabIndex = 1;
            this.comboBoxAnalysis.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnalysis_SelectedIndexChanged);
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxPriority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Location = new System.Drawing.Point(539, 46);
            this.comboBoxPriority.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(231, 28);
            this.comboBoxPriority.TabIndex = 2;
            this.comboBoxPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriority_SelectedIndexChanged);
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(47, 46);
            this.comboBoxCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(231, 28);
            this.comboBoxCustomer.TabIndex = 0;
            this.comboBoxCustomer.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomer_SelectedIndexChanged);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(293, 87);
            this.lblDateFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(48, 20);
            this.lblDateFrom.TabIndex = 28;
            this.lblDateFrom.Text = "Från:";
            this.lblDateFrom.Click += new System.EventHandler(this.lblDateFrom_Click);
            // 
            // lblAnalysis
            // 
            this.lblAnalysis.AutoSize = true;
            this.lblAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalysis.Location = new System.Drawing.Point(293, 23);
            this.lblAnalysis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnalysis.Name = "lblAnalysis";
            this.lblAnalysis.Size = new System.Drawing.Size(64, 20);
            this.lblAnalysis.TabIndex = 27;
            this.lblAnalysis.Text = "Analys:";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(539, 23);
            this.lblPriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(124, 20);
            this.lblPriority.TabIndex = 26;
            this.lblPriority.Text = "Prioritetsgrupp:";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(539, 87);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(36, 20);
            this.lblDateTo.TabIndex = 23;
            this.lblDateTo.Text = "Till:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(47, 23);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(52, 20);
            this.lblCustomer.TabIndex = 22;
            this.lblCustomer.Text = "Kund:";
            // 
            // labelTimeInterval
            // 
            this.labelTimeInterval.AutoSize = true;
            this.labelTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeInterval.Location = new System.Drawing.Point(47, 87);
            this.labelTimeInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeInterval.Name = "labelTimeInterval";
            this.labelTimeInterval.Size = new System.Drawing.Size(104, 20);
            this.labelTimeInterval.TabIndex = 38;
            this.labelTimeInterval.Text = "Tidsintervall:";
            this.labelTimeInterval.Click += new System.EventHandler(this.labelTimeInterval_Click);
            // 
            // comboBoxTimeInterval
            // 
            this.comboBoxTimeInterval.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxTimeInterval.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTimeInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBoxTimeInterval.FormattingEnabled = true;
            this.comboBoxTimeInterval.Location = new System.Drawing.Point(47, 111);
            this.comboBoxTimeInterval.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTimeInterval.Name = "comboBoxTimeInterval";
            this.comboBoxTimeInterval.Size = new System.Drawing.Size(231, 28);
            this.comboBoxTimeInterval.TabIndex = 3;
            this.comboBoxTimeInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeInterval_SelectedIndexChanged);
            // 
            // btnShowUpdateDiagram
            // 
            this.btnShowUpdateDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUpdateDiagram.Location = new System.Drawing.Point(799, 114);
            this.btnShowUpdateDiagram.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowUpdateDiagram.Name = "btnShowUpdateDiagram";
            this.btnShowUpdateDiagram.Size = new System.Drawing.Size(156, 30);
            this.btnShowUpdateDiagram.TabIndex = 10;
            this.btnShowUpdateDiagram.Text = "Uppdatera";
            this.btnShowUpdateDiagram.UseVisualStyleBackColor = true;
            this.btnShowUpdateDiagram.Click += new System.EventHandler(this.btnShowUpdateDiagram_Click);
            // 
            // chartResponseTime
            // 
            this.chartResponseTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chartResponseTime.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            customLabel5.Text = "Test 1";
            chartArea3.AxisY.CustomLabels.Add(customLabel5);
            customLabel6.ToolTip = "Test ToolTip Custom Label";
            chartArea3.AxisY2.CustomLabels.Add(customLabel6);
            chartArea3.Name = "ChartArea1";
            this.chartResponseTime.ChartAreas.Add(chartArea3);
            this.chartResponseTime.Location = new System.Drawing.Point(0, 199);
            this.chartResponseTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartResponseTime.Name = "chartResponseTime";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            this.chartResponseTime.Series.Add(series3);
            this.chartResponseTime.Size = new System.Drawing.Size(1588, 372);
            this.chartResponseTime.TabIndex = 41;
            this.chartResponseTime.Text = "chart1";
            title3.Name = "Test Titel1";
            this.chartResponseTime.Titles.Add(title3);
            // 
            // comboBoxYearTo
            // 
            this.comboBoxYearTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxYearTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearTo.FormattingEnabled = true;
            this.comboBoxYearTo.Location = new System.Drawing.Point(539, 146);
            this.comboBoxYearTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxYearTo.Name = "comboBoxYearTo";
            this.comboBoxYearTo.Size = new System.Drawing.Size(103, 28);
            this.comboBoxYearTo.TabIndex = 8;
            this.comboBoxYearTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearTo_SelectedIndexChanged);
            // 
            // comboBoxWeekTo
            // 
            this.comboBoxWeekTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekTo.FormattingEnabled = true;
            this.comboBoxWeekTo.Location = new System.Drawing.Point(647, 146);
            this.comboBoxWeekTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxWeekTo.Name = "comboBoxWeekTo";
            this.comboBoxWeekTo.Size = new System.Drawing.Size(120, 28);
            this.comboBoxWeekTo.TabIndex = 9;
            this.comboBoxWeekTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeekTo_SelectedIndexChanged);
            // 
            // comboBoxWeekFrom
            // 
            this.comboBoxWeekFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekFrom.FormattingEnabled = true;
            this.comboBoxWeekFrom.Location = new System.Drawing.Point(397, 146);
            this.comboBoxWeekFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxWeekFrom.Name = "comboBoxWeekFrom";
            this.comboBoxWeekFrom.Size = new System.Drawing.Size(124, 28);
            this.comboBoxWeekFrom.TabIndex = 7;
            this.comboBoxWeekFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeekFrom_SelectedIndexChanged);
            // 
            // comboBoxYearFrom
            // 
            this.comboBoxYearFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxYearFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearFrom.FormattingEnabled = true;
            this.comboBoxYearFrom.Location = new System.Drawing.Point(293, 146);
            this.comboBoxYearFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxYearFrom.Name = "comboBoxYearFrom";
            this.comboBoxYearFrom.Size = new System.Drawing.Size(97, 28);
            this.comboBoxYearFrom.TabIndex = 6;
            this.comboBoxYearFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearFrom_SelectedIndexChanged);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(799, 150);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(104, 20);
            this.labelMessage.TabIndex = 46;
            this.labelMessage.Text = "Meddelande:";
            // 
            // lblTodaysDateAndTime
            // 
            this.lblTodaysDateAndTime.AutoSize = true;
            this.lblTodaysDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaysDateAndTime.Location = new System.Drawing.Point(1365, 66);
            this.lblTodaysDateAndTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTodaysDateAndTime.Name = "lblTodaysDateAndTime";
            this.lblTodaysDateAndTime.Size = new System.Drawing.Size(147, 20);
            this.lblTodaysDateAndTime.TabIndex = 64;
            this.lblTodaysDateAndTime.Text = "yearmmdayofweek";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(1411, 14);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(156, 30);
            this.buttonExit.TabIndex = 65;
            this.buttonExit.Text = "Avsluta";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // lblFromWeek
            // 
            this.lblFromWeek.AutoSize = true;
            this.lblFromWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromWeek.Location = new System.Drawing.Point(393, 87);
            this.lblFromWeek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFromWeek.Name = "lblFromWeek";
            this.lblFromWeek.Size = new System.Drawing.Size(60, 20);
            this.lblFromWeek.TabIndex = 68;
            this.lblFromWeek.Text = "Vecka:";
            this.lblFromWeek.Click += new System.EventHandler(this.lblFromWeek_Click);
            // 
            // lblToWeek
            // 
            this.lblToWeek.AutoSize = true;
            this.lblToWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToWeek.Location = new System.Drawing.Point(643, 87);
            this.lblToWeek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToWeek.Name = "lblToWeek";
            this.lblToWeek.Size = new System.Drawing.Size(60, 20);
            this.lblToWeek.TabIndex = 69;
            this.lblToWeek.Text = "Vecka:";
            this.lblToWeek.Click += new System.EventHandler(this.lblToWeek_Click);
            // 
            // comboBoxShow
            // 
            this.comboBoxShow.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxShow.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxShow.FormattingEnabled = true;
            this.comboBoxShow.Location = new System.Drawing.Point(1365, 161);
            this.comboBoxShow.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxShow.Name = "comboBoxShow";
            this.comboBoxShow.Size = new System.Drawing.Size(193, 28);
            this.comboBoxShow.TabIndex = 70;
            this.comboBoxShow.SelectedIndexChanged += new System.EventHandler(this.comboBoxShow_SelectedIndexChanged);
            // 
            // dataGridResponseTime
            // 
            this.dataGridResponseTime.BackgroundColor = System.Drawing.Color.White;
            this.dataGridResponseTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResponseTime.Location = new System.Drawing.Point(128, 599);
            this.dataGridResponseTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridResponseTime.Name = "dataGridResponseTime";
            this.dataGridResponseTime.RowTemplate.Height = 24;
            this.dataGridResponseTime.Size = new System.Drawing.Size(1213, 199);
            this.dataGridResponseTime.TabIndex = 72;
            // 
            // lblShowAs
            // 
            this.lblShowAs.AutoSize = true;
            this.lblShowAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowAs.Location = new System.Drawing.Point(1365, 138);
            this.lblShowAs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShowAs.Name = "lblShowAs";
            this.lblShowAs.Size = new System.Drawing.Size(84, 20);
            this.lblShowAs.TabIndex = 76;
            this.lblShowAs.Text = "Visa som:";
            // 
            // labelSerieTyp
            // 
            this.labelSerieTyp.AutoSize = true;
            this.labelSerieTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerieTyp.Location = new System.Drawing.Point(1187, 138);
            this.labelSerieTyp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSerieTyp.Name = "labelSerieTyp";
            this.labelSerieTyp.Size = new System.Drawing.Size(47, 20);
            this.labelSerieTyp.TabIndex = 78;
            this.labelSerieTyp.Text = "Visa:";
            // 
            // comboBoxSerieTyp
            // 
            this.comboBoxSerieTyp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxSerieTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSerieTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerieTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSerieTyp.FormattingEnabled = true;
            this.comboBoxSerieTyp.Location = new System.Drawing.Point(1184, 161);
            this.comboBoxSerieTyp.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerieTyp.Name = "comboBoxSerieTyp";
            this.comboBoxSerieTyp.Size = new System.Drawing.Size(173, 28);
            this.comboBoxSerieTyp.TabIndex = 77;
            this.comboBoxSerieTyp.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerieTyp_SelectedIndexChanged);
            // 
            // TimeMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1583, 816);
            this.Controls.Add(this.labelSerieTyp);
            this.Controls.Add(this.comboBoxSerieTyp);
            this.Controls.Add(this.lblShowAs);
            this.Controls.Add(this.dataGridResponseTime);
            this.Controls.Add(this.comboBoxShow);
            this.Controls.Add(this.lblToWeek);
            this.Controls.Add(this.lblFromWeek);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.lblTodaysDateAndTime);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.comboBoxWeekTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.comboBoxYearTo);
            this.Controls.Add(this.comboBoxYearFrom);
            this.Controls.Add(this.comboBoxWeekFrom);
            this.Controls.Add(this.chartResponseTime);
            this.Controls.Add(this.btnShowUpdateDiagram);
            this.Controls.Add(this.labelTimeInterval);
            this.Controls.Add(this.comboBoxTimeInterval);
            this.Controls.Add(this.comboBoxAnalysis);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.lblAnalysis);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "TimeMonitoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IK075G - Svarstider";
            this.Load += new System.EventHandler(this.TimeMonitoring_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeMonitoring_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.chartResponseTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResponseTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.ComboBox comboBoxAnalysis;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblAnalysis;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label labelTimeInterval;
        private System.Windows.Forms.ComboBox comboBoxTimeInterval;
        private System.Windows.Forms.Button btnShowUpdateDiagram;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResponseTime;
        private System.Windows.Forms.ComboBox comboBoxYearTo;
        private System.Windows.Forms.ComboBox comboBoxWeekTo;
        private System.Windows.Forms.ComboBox comboBoxWeekFrom;
        private System.Windows.Forms.ComboBox comboBoxYearFrom;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label lblTodaysDateAndTime;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label lblFromWeek;
        private System.Windows.Forms.Label lblToWeek;
        private System.Windows.Forms.ComboBox comboBoxShow;
        private System.Windows.Forms.DataGridView dataGridResponseTime;
        private System.Windows.Forms.Label lblShowAs;
        private System.Windows.Forms.Label labelSerieTyp;
        private System.Windows.Forms.ComboBox comboBoxSerieTyp;
    }
}