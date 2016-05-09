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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeMonitoring));
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelMessage = new System.Windows.Forms.Label();
            this.lblTodaysDateAndTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartResponseTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1024, 57);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(148, 32);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Till huvudmenyn";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(404, 92);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(174, 22);
            this.dateTimePickerTo.TabIndex = 35;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(220, 92);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(174, 22);
            this.dateTimePickerFrom.TabIndex = 34;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // comboBoxAnalysis
            // 
            this.comboBoxAnalysis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxAnalysis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAnalysis.FormattingEnabled = true;
            this.comboBoxAnalysis.Location = new System.Drawing.Point(220, 37);
            this.comboBoxAnalysis.Name = "comboBoxAnalysis";
            this.comboBoxAnalysis.Size = new System.Drawing.Size(174, 24);
            this.comboBoxAnalysis.TabIndex = 31;
            this.comboBoxAnalysis.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnalysis_SelectedIndexChanged);
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxPriority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Location = new System.Drawing.Point(404, 37);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(174, 24);
            this.comboBoxPriority.TabIndex = 30;
            this.comboBoxPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriority_SelectedIndexChanged);
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(35, 37);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(174, 24);
            this.comboBoxCustomer.TabIndex = 29;
            this.comboBoxCustomer.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomer_SelectedIndexChanged);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(220, 71);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(38, 16);
            this.lblDateFrom.TabIndex = 28;
            this.lblDateFrom.Text = "Från:";
            // 
            // lblAnalysis
            // 
            this.lblAnalysis.AutoSize = true;
            this.lblAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalysis.Location = new System.Drawing.Point(220, 19);
            this.lblAnalysis.Name = "lblAnalysis";
            this.lblAnalysis.Size = new System.Drawing.Size(52, 16);
            this.lblAnalysis.TabIndex = 27;
            this.lblAnalysis.Text = "Analys:";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(404, 19);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(98, 16);
            this.lblPriority.TabIndex = 26;
            this.lblPriority.Text = "Prioritetsgrupp:";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(404, 71);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(29, 16);
            this.lblDateTo.TabIndex = 23;
            this.lblDateTo.Text = "Till:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(35, 19);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(41, 16);
            this.lblCustomer.TabIndex = 22;
            this.lblCustomer.Text = "Kund:";
            // 
            // labelTimeInterval
            // 
            this.labelTimeInterval.AutoSize = true;
            this.labelTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeInterval.Location = new System.Drawing.Point(35, 71);
            this.labelTimeInterval.Name = "labelTimeInterval";
            this.labelTimeInterval.Size = new System.Drawing.Size(84, 16);
            this.labelTimeInterval.TabIndex = 38;
            this.labelTimeInterval.Text = "Tidsintervall:";
            // 
            // comboBoxTimeInterval
            // 
            this.comboBoxTimeInterval.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxTimeInterval.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTimeInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBoxTimeInterval.FormattingEnabled = true;
            this.comboBoxTimeInterval.Location = new System.Drawing.Point(35, 90);
            this.comboBoxTimeInterval.Name = "comboBoxTimeInterval";
            this.comboBoxTimeInterval.Size = new System.Drawing.Size(174, 24);
            this.comboBoxTimeInterval.TabIndex = 37;
            this.comboBoxTimeInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeInterval_SelectedIndexChanged);
            // 
            // btnShowUpdateDiagram
            // 
            this.btnShowUpdateDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUpdateDiagram.Location = new System.Drawing.Point(599, 93);
            this.btnShowUpdateDiagram.Name = "btnShowUpdateDiagram";
            this.btnShowUpdateDiagram.Size = new System.Drawing.Size(177, 24);
            this.btnShowUpdateDiagram.TabIndex = 39;
            this.btnShowUpdateDiagram.Text = "Updatera/visa";
            this.btnShowUpdateDiagram.UseVisualStyleBackColor = true;
            this.btnShowUpdateDiagram.Click += new System.EventHandler(this.btnShowUpdateDiagram_Click);
            // 
            // chartResponseTime
            // 
            this.chartResponseTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chartResponseTime.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            customLabel1.Text = "Test 1";
            chartArea1.AxisY.CustomLabels.Add(customLabel1);
            customLabel2.ToolTip = "Test ToolTip Custom Label";
            chartArea1.AxisY2.CustomLabels.Add(customLabel2);
            chartArea1.Name = "ChartArea1";
            this.chartResponseTime.ChartAreas.Add(chartArea1);
            this.chartResponseTime.Location = new System.Drawing.Point(-6, 164);
            this.chartResponseTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartResponseTime.Name = "chartResponseTime";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chartResponseTime.Series.Add(series1);
            this.chartResponseTime.Size = new System.Drawing.Size(1197, 407);
            this.chartResponseTime.TabIndex = 41;
            this.chartResponseTime.Text = "chart1";
            title1.Name = "Test Titel1";
            this.chartResponseTime.Titles.Add(title1);
            // 
            // comboBoxYearTo
            // 
            this.comboBoxYearTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxYearTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearTo.FormattingEnabled = true;
            this.comboBoxYearTo.Location = new System.Drawing.Point(404, 119);
            this.comboBoxYearTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxYearTo.Name = "comboBoxYearTo";
            this.comboBoxYearTo.Size = new System.Drawing.Size(78, 24);
            this.comboBoxYearTo.TabIndex = 44;
            this.comboBoxYearTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearTo_SelectedIndexChanged);
            // 
            // comboBoxWeekTo
            // 
            this.comboBoxWeekTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekTo.FormattingEnabled = true;
            this.comboBoxWeekTo.Location = new System.Drawing.Point(485, 119);
            this.comboBoxWeekTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxWeekTo.Name = "comboBoxWeekTo";
            this.comboBoxWeekTo.Size = new System.Drawing.Size(91, 24);
            this.comboBoxWeekTo.TabIndex = 45;
            this.comboBoxWeekTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeekTo_SelectedIndexChanged);
            // 
            // comboBoxWeekFrom
            // 
            this.comboBoxWeekFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWeekFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWeekFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWeekFrom.FormattingEnabled = true;
            this.comboBoxWeekFrom.Location = new System.Drawing.Point(298, 119);
            this.comboBoxWeekFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxWeekFrom.Name = "comboBoxWeekFrom";
            this.comboBoxWeekFrom.Size = new System.Drawing.Size(94, 24);
            this.comboBoxWeekFrom.TabIndex = 43;
            this.comboBoxWeekFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeekFrom_SelectedIndexChanged);
            // 
            // comboBoxYearFrom
            // 
            this.comboBoxYearFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxYearFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYearFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearFrom.FormattingEnabled = true;
            this.comboBoxYearFrom.Location = new System.Drawing.Point(220, 119);
            this.comboBoxYearFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxYearFrom.Name = "comboBoxYearFrom";
            this.comboBoxYearFrom.Size = new System.Drawing.Size(74, 24);
            this.comboBoxYearFrom.TabIndex = 42;
            this.comboBoxYearFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearFrom_SelectedIndexChanged);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(599, 122);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(88, 16);
            this.labelMessage.TabIndex = 46;
            this.labelMessage.Text = "Meddelande:";
            // 
            // lblTodaysDateAndTime
            // 
            this.lblTodaysDateAndTime.AutoSize = true;
            this.lblTodaysDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaysDateAndTime.Location = new System.Drawing.Point(1024, 95);
            this.lblTodaysDateAndTime.Name = "lblTodaysDateAndTime";
            this.lblTodaysDateAndTime.Size = new System.Drawing.Size(123, 16);
            this.lblTodaysDateAndTime.TabIndex = 64;
            this.lblTodaysDateAndTime.Text = "yearmmdayofweek";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1024, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 32);
            this.button1.TabIndex = 65;
            this.button1.Text = "Avsluta programmet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimeMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.button1);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TimeMonitoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IK075G - Svarstider";
            this.Load += new System.EventHandler(this.TimeMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartResponseTime)).EndInit();
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label lblTodaysDateAndTime;
        private System.Windows.Forms.Button button1;
    }
}