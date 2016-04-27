using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace IK075G
{
    public partial class groupBoxFrom : Form
    {
        // Upprättar koppling mot databas
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;UserId=postgres;Password=carlo;Database=IK075G;");
        NpgsqlCommand cmd;

        public groupBoxFrom()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu huvudmeny = new MainMenu();
            huvudmeny.ShowDialog();
        }

        private void TimeMonitoring_Load(object sender, EventArgs e)
        {
            comboBoxTimeInterval.SelectedItem = "DAGVIS";
            LoadCustomerGroups();
            LoadAnalysis();
            LoadPriorityGroup();
            LoadTimeInterval();
            LoadYears();
            LoadWeekNumbers();
            SetCustomMinMaxDate();
            comboBoxYearFrom.Visible = false;
            comboBoxYearTo.Visible = false;
            comboBoxWeekFrom.Visible = false;
            comboBoxWeekTo.Visible = false;
        }

        // Egna metoder        
        public void LoadCustomerGroups() //Metod för att ladda kundgrupper i comboboxen 
        {
            string sql = "SELECT cuco FROM cuco_sub2 ORDER BY cuco";
            conn.Open();
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string cuco = dr["cuco"].ToString();
                comboBoxCustomerGrp.Items.Add(cuco);
            }
            conn.Close();
        }

        public void LoadAnalysis() //Metod för att ladda analyser i comboboxen 
        {
            string sql = "SELECT DISTINCT anco FROM a_ana_tab ORDER BY anco";
            conn.Open();
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string anco = dr["anco"].ToString();
                comboBoxAnalysis.Items.Add(anco);
            }
            conn.Close();
        }

        public void LoadPriorityGroup() //Metod för att ladda prioritetsgrupper i comboboxen
        {
            string sql = "SELECT DISTINCT prio FROM a_ana_tab ORDER BY prio";
            conn.Open();
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string prio = dr["prio"].ToString();
                comboBoxPriority.Items.Add(prio);
            }
            conn.Close();
        }

        public void LoadTimeInterval() //Metod för att fylla comboboxen med tidsintervall
        {
            comboBoxTimeInterval.Items.Add("Timvis");
            comboBoxTimeInterval.Items.Add("Dagvis");
            comboBoxTimeInterval.Items.Add("Veckovis");
            comboBoxTimeInterval.Items.Add("Månadsvis");
            comboBoxTimeInterval.Items.Add("Årsvis");
        }

        public void LoadYears() // Metod för att LADDA in årtal i comboboxar från och till
        {
            // Från år
            string sql1 = "SELECT DISTINCT substr(altm,1,2) altm FROM a_ana_tab WHERE LENGTH(REPLACE(altm, ' ','')) > 0 ORDER BY altm";
            conn.Open();
            cmd = new NpgsqlCommand(sql1, conn);
            NpgsqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                string yearOrderedbyLowest = dr1["altm"].ToString();
                comboBoxYearFrom.Items.Add(yearOrderedbyLowest);
            }
            conn.Close();
            //Till år
            string sql2 = "SELECT DISTINCT substr(altm,1,2) altm FROM a_ana_tab WHERE LENGTH(REPLACE(altm, ' ','')) > 0 ORDER BY altm";
            conn.Open();
            cmd = new NpgsqlCommand(sql2, conn);
            NpgsqlDataReader dr2 = cmd.ExecuteReader();
            while (dr2.Read())
            {
                string yearOrderedbyLowest = dr2["altm"].ToString();
                comboBoxYearTo.Items.Add(yearOrderedbyLowest);
            }
            conn.Close();
        }

        public void LoadWeekNumbers() //Metod för att FYLLA comboboxarna med veckonummer
        {
            for (int i = 1; i <= 53; i++)
            {
                comboBoxWeekFrom.Items.Add(i.ToString());
                comboBoxWeekTo.Items.Add(i.ToString());
            }
        }

        public void SetCustomMinMaxDate() // Används för att sätta start och stop år i kalender beroende på minsta 
        {
            DateTime newMinDateTime = new DateTime();
            // Från år
            string sql = "SELECT MIN(to_date(altm,'YYDDMMHH24MI')) AS altm FROM a_ana_tab WHERE LENGTH(REPLACE(altm, ' ','')) > 0";
            conn.Open();
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                newMinDateTime = Convert.ToDateTime(dr["altm"]);
            }
            conn.Close();
            dateTimePickerFrom.MinDate = newMinDateTime;

            // Till år
            DateTime newMaxDateTime = new DateTime();
            newMaxDateTime = DateTime.Now;

            // Sätter värdena i kallender            
            dateTimePickerFrom.MinDate = newMinDateTime;
            dateTimePickerFrom.MaxDate = newMaxDateTime;
            dateTimePickerFrom.Value = newMinDateTime;

            dateTimePickerTo.MinDate = newMinDateTime;
            dateTimePickerTo.MaxDate = newMaxDateTime;
            dateTimePickerTo.Value = newMaxDateTime;

        }

        public void SetCustomFormat(string format) // Används för att definera format i kallender 
        {
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = format;
            dateTimePickerFrom.ShowUpDown = true;

            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = format;
            dateTimePickerTo.ShowUpDown = true;
        }

        public List<ResponseTimes> GetResponseByYear(string customerGroup, string analys, string prio, string yearFrom, string yearTo)
        {
            List<ResponseTimes> newListMember = new List<ResponseTimes>();

            yearFrom = yearFrom.PadLeft(2, '0');
            yearTo = yearTo.PadLeft(2, '0');

            conn.Open();

            string sql = string.Empty;
            sql = sql + "SELECT ";
            sql = sql + "    prio AS prio,";
            sql = sql + "    anco AS anco,";
            sql = sql + "    to_char(tetm_date,'YYYY') AS year,";
            sql = sql + "    count(anco) AS quantity,";
            sql = sql + "    to_char(min(diff_interval),'HH24:MI') AS min_time,";
            sql = sql + "    to_char(max(diff_interval),'HH24:MI') AS max_time,";
            sql = sql + "    to_char(avg(diff_interval),'HH24:MI') AS avg_time,";
            sql = sql + "    round(min( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS min_value,";
            sql = sql + "    round(max( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS max_value,";
            sql = sql + "    round(avg( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS avg_value";
            sql = sql + " FROM xxx_time_monitoring_vw";
            sql = sql + " WHERE 1 = 1";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newAnco";
            sql = sql + " AND ( (diff_days * 24) + (diff_hours*60)+diff_minutes ) > 0 AND ( (diff_days * 24) + (diff_hours*60)+diff_minutes ) < (1440*3)";
            sql = sql + " AND to_char(tetm_date,'YYYY') BETWEEN :newFrom AND :newTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYY')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYY')";

            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customerGroup;
            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prio;
            cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
            cmd.Parameters["newAnco"].Value = analys;

            cmd.Parameters.Add(new NpgsqlParameter("newFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newFrom"].Value = yearFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newTo"].Value = yearTo;

            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ResponseTimes newResponseTimes = new ResponseTimes();
                newResponseTimes.customerGroup = customerGroup;
                newResponseTimes.prio = prio;
                newResponseTimes.analys = analys;
                newResponseTimes.year = Convert.ToString(dr["year"]);
                newResponseTimes.quantity = Convert.ToString(dr["quantity"]);
                newResponseTimes.minTime = Convert.ToString(dr["min_time"]);
                newResponseTimes.maxTime = Convert.ToString(dr["max_time"]);
                newResponseTimes.avgTime = Convert.ToString(dr["avg_time"]);
                newResponseTimes.minValue = Convert.ToString(dr["min_value"]);
                newResponseTimes.maxValue = Convert.ToString(dr["max_value"]);
                newResponseTimes.avgValue = Convert.ToString(dr["avg_value"]);
                newListMember.Add(newResponseTimes);
            }
            conn.Close();
            return newListMember;
        }

        // Metod för att hämta matris        
        public List<ResponseTimes> GetResponseByMonth(string customerGroup, string analys, string prio, string yearFrom, string yearTo, string monthFrom, string monthTo)
        {
            List<ResponseTimes> newListMember = new List<ResponseTimes>();

            monthFrom = monthFrom.PadLeft(2, '0');
            monthTo = monthTo.PadLeft(2, '0');

            conn.Open();

            string sql = string.Empty;
            sql = sql + "SELECT ";
            // sql = sql + "    cuco AS cuco,";
            sql = sql + "    prio AS prio,";
            sql = sql + "    anco AS anco,";
            sql = sql + "    to_char(tetm_date,'YYYYMM') AS month,";
            sql = sql + "    count(anco) AS quantity,";
            sql = sql + "    to_char(min(diff_interval),'HH24:MI') AS min_time,";
            sql = sql + "    to_char(max(diff_interval),'HH24:MI') AS max_time,";
            sql = sql + "    to_char(avg(diff_interval),'HH24:MI') AS avg_time,";
            sql = sql + "    round(min( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS min_value,";
            sql = sql + "    round(max( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS max_value,";
            sql = sql + "    round(avg( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS avg_value";
            sql = sql + " FROM xxx_time_monitoring_vw";
            sql = sql + " WHERE 1 = 1";
            // sql = sql + " AND cuco = :newCuco";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newAnco";
            sql = sql + " AND ( (diff_days * 24) + (diff_hours*60)+diff_minutes ) > 0 AND ( (diff_days * 24) + (diff_hours*60)+diff_minutes ) < (1440*3)";
            sql = sql + " AND to_char(tetm_date,'YYYYMM') BETWEEN :newFrom AND :newTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYYMM')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYYMM')";

            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newCuco", NpgsqlDbType.Varchar));
            cmd.Parameters["newCuco"].Value = customerGroup;
            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prio;
            cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
            cmd.Parameters["newAnco"].Value = analys;
            cmd.Parameters.Add(new NpgsqlParameter("newFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newFrom"].Value = yearFrom + monthFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newTo"].Value = yearTo + monthTo;

            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ResponseTimes newResponseTimes = new ResponseTimes();
                newResponseTimes.customerGroup = customerGroup;
                newResponseTimes.prio = prio;
                newResponseTimes.analys = analys;
                newResponseTimes.month = Convert.ToString(dr["month"]);
                newResponseTimes.quantity = Convert.ToString(dr["quantity"]);
                newResponseTimes.minTime = Convert.ToString(dr["min_time"]);
                newResponseTimes.maxTime = Convert.ToString(dr["max_time"]);
                newResponseTimes.avgTime = Convert.ToString(dr["avg_time"]);
                newResponseTimes.minValue = Convert.ToString(dr["min_value"]);
                newResponseTimes.maxValue = Convert.ToString(dr["max_value"]);
                newResponseTimes.avgValue = Convert.ToString(dr["avg_value"]);
                newListMember.Add(newResponseTimes);
            }
            conn.Close();
            return newListMember;
        }

        // Metod för att hämta matris
        public List<ResponseTimes> GetResponseByWeek(string customerGroup, string analys, string prio, string yearFrom, string yearTo, string weekFrom, string weekTo)
        {
            List<ResponseTimes> newListMember = new List<ResponseTimes>();

            weekFrom = weekFrom.PadLeft(2, '0');
            weekTo = weekTo.PadLeft(2, '0');

            conn.Open();

            string sql = string.Empty;
            sql = sql + "SELECT ";
            sql = sql + "    prio AS prio,";
            sql = sql + "    anco AS anco,";
            sql = sql + "    to_char(tetm_date,'YYYYWW') AS week,";
            sql = sql + "    count(anco) AS quantity,";
            sql = sql + "    to_char(min(diff_interval),'HH24:MI') AS min_time,";
            sql = sql + "    to_char(max(diff_interval),'HH24:MI') AS max_time,";
            sql = sql + "    to_char(avg(diff_interval),'HH24:MI') AS avg_time,";
            sql = sql + "    round(min( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS min_value,";
            sql = sql + "    round(max( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS max_value,";
            sql = sql + "    round(avg( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS avg_value";
            sql = sql + " FROM xxx_time_monitoring_vw";
            sql = sql + " WHERE 1 = 1";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newAnco";
            sql = sql + " AND ( (diff_days * 24) + (diff_hours*60)+diff_minutes ) > 0 AND ( (diff_days * 24) + (diff_hours*60)+diff_minutes ) < (1440*3)";
            sql = sql + " AND to_char(tetm_date,'YYYYMM') BETWEEN :newFrom AND :newTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYYWW')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYYWW')";

            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customerGroup;
            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prio;
            cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
            cmd.Parameters["newAnco"].Value = analys;
            cmd.Parameters.Add(new NpgsqlParameter("newFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newFrom"].Value = yearFrom + weekFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newTo"].Value = yearTo + weekTo;

            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ResponseTimes newResponseTimes = new ResponseTimes();
                newResponseTimes.customerGroup = customerGroup;
                newResponseTimes.prio = prio;
                newResponseTimes.analys = analys;
                newResponseTimes.week = Convert.ToString(dr["week"]);
                newResponseTimes.quantity = Convert.ToString(dr["quantity"]);
                newResponseTimes.minTime = Convert.ToString(dr["min_time"]);
                newResponseTimes.maxTime = Convert.ToString(dr["max_time"]);
                newResponseTimes.avgTime = Convert.ToString(dr["avg_time"]);
                newResponseTimes.minValue = Convert.ToString(dr["min_value"]);
                newResponseTimes.maxValue = Convert.ToString(dr["max_value"]);
                newResponseTimes.avgValue = Convert.ToString(dr["avg_value"]);
                newListMember.Add(newResponseTimes);
            }
            conn.Close();
            return newListMember;
        }

        // Metod för att hämta matris
        public List<ResponseTimes> GetResponseByDay(string customerGroup, string analys, string prio, string dayFrom, string dayTo)
        {
            List<ResponseTimes> newListMember = new List<ResponseTimes>();

            conn.Open();

            string sql = string.Empty;
            sql = sql + "SELECT ";
            sql = sql + "    prio AS prio,";
            sql = sql + "    anco AS anco,";
            sql = sql + "    to_char(tetm_date,'YYYYMMDD') AS day,";
            sql = sql + "    count(anco) AS quantity,";
            sql = sql + "    to_char(min(diff_interval),'HH24:MI') AS min_time,";
            sql = sql + "    to_char(max(diff_interval),'HH24:MI') AS max_time,";
            sql = sql + "    to_char(avg(diff_interval),'HH24:MI') AS avg_time,";
            sql = sql + "    round(min( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS min_value,";
            sql = sql + "    round(max( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS max_value,";
            sql = sql + "    round(avg( (diff_days * 1440) + (diff_hours * 60) + (diff_minutes) ),2) AS avg_value";
            sql = sql + " FROM xxx_time_monitoring_vw";
            sql = sql + " WHERE 1 = 1";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newAnco";
            sql = sql + " AND ( (diff_days * 24) + (diff_hours*60)+diff_minutes ) > 0 AND ( (diff_days * 24) + (diff_hours*60)+diff_minutes ) < (1440*3)";
            sql = sql + " AND to_char(tetm_date,'YYYY-MM-DD') BETWEEN :newFrom AND :newTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYYMMDD')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYYMMDD')";

            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customerGroup;
            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prio;
            cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
            cmd.Parameters["newAnco"].Value = analys;
            cmd.Parameters.Add(new NpgsqlParameter("newFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newFrom"].Value = dayFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newTo"].Value = dayTo;

            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ResponseTimes newResponseTimes = new ResponseTimes();
                newResponseTimes.customerGroup = customerGroup;
                newResponseTimes.prio = prio;
                newResponseTimes.analys = analys;
                newResponseTimes.day = Convert.ToString(dr["day"]);
                newResponseTimes.quantity = Convert.ToString(dr["quantity"]);
                newResponseTimes.minTime = Convert.ToString(dr["min_time"]);
                newResponseTimes.maxTime = Convert.ToString(dr["max_time"]);
                newResponseTimes.avgTime = Convert.ToString(dr["avg_time"]);
                newResponseTimes.minValue = Convert.ToString(dr["min_value"]);
                newResponseTimes.maxValue = Convert.ToString(dr["max_value"]);
                newResponseTimes.avgValue = Convert.ToString(dr["avg_value"]);
                newListMember.Add(newResponseTimes);
            }
            conn.Close();
            return newListMember;
        }

        public double FindMaxValue(List<ResponseTimes> newListMember) // Metod för att hitta högsta värdet
        {
            double maxValue = double.MinValue;
            foreach (ResponseTimes item in newListMember)
            {
                if (Convert.ToDouble(item.maxValue) > maxValue)
                {
                    maxValue = Convert.ToDouble(item.maxValue);
                }
            }
            return maxValue;
        }

        // Events
        private void btnShowUpdateDiagram_Click(object sender, EventArgs e)
        {
            List<ResponseTimes> newListMember = new List<ResponseTimes>();

            string customerGroup = comboBoxCustomerGrp.Text;
            string analys = comboBoxAnalysis.Text;
            string prio = comboBoxPriority.Text;
            string timeInterval = comboBoxTimeInterval.Text.ToUpper();
            DateTime dateFrom;
            DateTime dateTo;
            string yearFrom;
            string yearTo;
            string weekFrom;
            string monthFrom;
            string monthTo;
            string weekTo;
            string dayFrom;
            string dayTo;
            // string hoursFrom;
            // string hoursTo;
            // string minutesFrom;
            // string minutesTo;

            if (timeInterval == "TIMVIS")
            {
                // från kalender string format = "dd MMMM yyyy"
                dateFrom = dateTimePickerFrom.Value;
                dateTo = dateTimePickerTo.Value;

                dayFrom = dateFrom.ToShortDateString();
                dayTo = dateTo.ToShortDateString();

                // hoursFrom = dateFrom.Hour.ToString();
                // hoursTo = dateTo.Hour.ToString();
                // newListMember = GetResponseByHours(customerGroup, analys, prio, yearFrom, yearTo, hoursFrom, hoursTo);
            }
            else if (timeInterval == "DAGVIS")
            {
                // från kallender
                dateFrom = dateTimePickerFrom.Value;
                dateTo = dateTimePickerTo.Value;

                dayFrom = dateFrom.ToShortDateString();
                dayTo = dateTo.ToShortDateString();

                newListMember = GetResponseByDay(customerGroup, analys, prio, dayFrom, dayTo);
            }
            else if (timeInterval == "VECKOVIS")
            {
                // från boxar för år och vecka, string format = "yyyy";
                yearFrom = comboBoxYearFrom.Text;
                weekFrom = comboBoxWeekFrom.Text;
                yearTo = comboBoxYearTo.Text;
                weekTo = comboBoxWeekTo.Text;

                newListMember = GetResponseByWeek(customerGroup, analys, prio, yearFrom, yearTo, weekFrom, weekTo);
            }
            else if (timeInterval == "MÅNADSVIS")
            {
                // från kallender, string format = "MMMM yyyy";
                dateFrom = dateTimePickerFrom.Value;
                dateTo = dateTimePickerTo.Value;

                yearFrom = dateFrom.Year.ToString();
                yearTo = dateTo.Year.ToString();
                monthFrom = dateFrom.Month.ToString();
                monthTo = dateTo.Month.ToString();

                newListMember = GetResponseByMonth(customerGroup, analys, prio, yearFrom, yearTo, monthFrom, monthTo);
            }
            else if (timeInterval == "ÅRSVIS")
            {
                // från listbox
                yearFrom = comboBoxYearFrom.Text;
                yearTo = comboBoxYearTo.Text;

                newListMember = GetResponseByYear(customerGroup, analys, prio, yearFrom, yearTo);
            }

            // Diagrammet ********************************************************************* START
            chartResponseTime.ChartAreas.Clear();
            chartResponseTime.Titles.Clear();
            chartResponseTime.Series.Clear();

            // Titel ovanför diagramet  
            // chartResponseTime.Titles.Add("Response Time");

            chartResponseTime.ChartAreas.Add("");
            chartResponseTime.ChartAreas[0].AxisY.Title = "AxisY Title";
            chartResponseTime.ChartAreas[0].AxisX.Title = "AxisX Title";

            chartResponseTime.Legends.Add("");
            chartResponseTime.Legends[0].Title = "Legend";

            chartResponseTime.Series.Add("Series1");
            chartResponseTime.Series["Series1"].ChartArea = "ChartArea1";
            chartResponseTime.Series["Series1"].LegendText = "Medel";
            chartResponseTime.Series["Series1"].XValueType = ChartValueType.DateTime;
            chartResponseTime.Series["Series1"].YValueType = ChartValueType.Time;
            chartResponseTime.Series["Series1"].ChartType = SeriesChartType.Line;
            chartResponseTime.Series["Series1"].ChartType = SeriesChartType.Column;

            chartResponseTime.Series.Add("Series2");
            chartResponseTime.Series["Series2"].ChartArea = "ChartArea1";
            chartResponseTime.Series["Series2"].LegendText = "Minsta";
            chartResponseTime.Series["Series2"].XValueType = ChartValueType.DateTime;
            chartResponseTime.Series["Series2"].YValueType = ChartValueType.Time;
            chartResponseTime.Series["Series2"].ChartType = SeriesChartType.Line;
            chartResponseTime.Series["Series2"].ChartType = SeriesChartType.Column;

            chartResponseTime.Series.Add("Series3");
            chartResponseTime.Series["Series3"].ChartArea = "ChartArea1";
            chartResponseTime.Series["Series3"].LegendText = "Högsta";
            chartResponseTime.Series["Series3"].XValueType = ChartValueType.DateTime;
            chartResponseTime.Series["Series3"].YValueType = ChartValueType.Time;
            chartResponseTime.Series["Series3"].ChartType = SeriesChartType.Line;
            chartResponseTime.Series["Series3"].ChartType = SeriesChartType.Column;

            chartResponseTime.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Auto;

            // om den max värdet överstiger 24 timmar skall det vissa som dagar  
            DateTimeIntervalType newAxisYIntervalType = new DateTimeIntervalType();

            int div = 1;
            double maxValue = 0.0;
            maxValue = FindMaxValue(newListMember);
            if (maxValue > 1440.0)
            {
                newAxisYIntervalType = DateTimeIntervalType.Days;
                chartResponseTime.Titles.Add("Response Time " + Convert.ToString(newAxisYIntervalType));
                chartResponseTime.Series["Series3"].YValueType = ChartValueType.DateTime;
                chartResponseTime.ChartAreas[0].AxisY.Interval = 4;
                div = 1440;
            }
            // 1440 minuter d.v.s. 24 och två timmar 
            else if (maxValue < 1440.0 && maxValue > 60.0)
            {
                newAxisYIntervalType = DateTimeIntervalType.Hours;
                chartResponseTime.Titles.Add("Response Time " + Convert.ToString(newAxisYIntervalType));
                chartResponseTime.Series["Series3"].YValueType = ChartValueType.Time;
                chartResponseTime.ChartAreas[0].AxisY.Interval = 4;
                div = 60;
            }
            // 60 minuter d.v.s. en timme
            else if (maxValue < 60.0)
            {
                newAxisYIntervalType = DateTimeIntervalType.Minutes;
                chartResponseTime.Titles.Add("Response Time " + Convert.ToString(newAxisYIntervalType));
                chartResponseTime.Series["Series3"].YValueType = ChartValueType.Time;
                chartResponseTime.ChartAreas[0].AxisY.Interval = 4;
                div = 1;
            }

            foreach (var item in newListMember)
            {
                DataPoint newAveragePoint = new DataPoint();
                if (timeInterval == "TIMVIS")
                {
                    // newAveragePoint.AxisLabel = hours.ToString();
                }
                else if (timeInterval == "DAGVIS")
                {
                    newAveragePoint.AxisLabel = item.year + item.month + item.day;
                    chartResponseTime.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Days;
                }
                else if (timeInterval == "VECKOVIS")
                {
                    newAveragePoint.AxisLabel = item.year + item.week;
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
                }
                else if (timeInterval == "MÅNADSVIS")
                {
                    newAveragePoint.AxisLabel = item.year + item.month;
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                }
                else if (timeInterval == "ÅRSVIS")
                {
                    newAveragePoint.AxisLabel = item.year;
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
                }

                chartResponseTime.ChartAreas[0].AxisY.IntervalType = newAxisYIntervalType;
                chartResponseTime.ChartAreas[0].AxisY.Maximum = Math.Round(maxValue / div, 0);

                newAveragePoint.SetValueY(Convert.ToDouble(item.avgValue) / div);
                chartResponseTime.Series["Series1"].Points.Add(newAveragePoint);

                DataPoint newMinPoint = new DataPoint();
                newMinPoint.SetValueY(Convert.ToDouble(item.minValue) / div);
                chartResponseTime.Series["Series2"].Points.Add(newMinPoint);

                DataPoint newMaxPoint = new DataPoint();
                newMaxPoint.SetValueY(Convert.ToDouble(item.maxValue) / div);
                chartResponseTime.Series["Series3"].Points.Add(newMaxPoint);

            }
            chartResponseTime.ChartAreas[0].RecalculateAxesScale();
            chartResponseTime.Show();
            // Diagrammet ********************************************************************* STOP
        }

        private void comboBoxTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sätter min och max datum i kallender beroende min oxh max datum för analys (a_ana_tab)
            SetCustomMinMaxDate();
            // sätter format i kallender beroende på vald tids interval    
            string timeInterval = comboBoxTimeInterval.Text.ToUpper();
            if (timeInterval == "TIMVIS")
            {
                // från kalender
                string format = "dd MMMM yyyy"; // MMMM yyyy
                SetCustomFormat(format);
                dateTimePickerFrom.Visible = true;
                dateTimePickerTo.Visible = true;
                comboBoxYearFrom.Visible = false;
                comboBoxYearTo.Visible = false;
                comboBoxWeekFrom.Visible = false;
                comboBoxWeekTo.Visible = false;
            }
            else if (timeInterval == "DAGVIS")
            {
                // från kalender
                string format = "dd MMMM yyyy";
                SetCustomFormat(format);
                dateTimePickerFrom.Visible = true;
                dateTimePickerTo.Visible = true;
                comboBoxYearFrom.Visible = false;
                comboBoxYearTo.Visible = false;
                comboBoxWeekFrom.Visible = false;
                comboBoxWeekTo.Visible = false;
            }
            else if (timeInterval == "VECKOVIS")
            {
                // från boxar för år och vecka
                string format = "yyyy";
                SetCustomFormat(format);
                dateTimePickerFrom.Visible = false;
                dateTimePickerTo.Visible = false;
                comboBoxYearFrom.Visible = true;
                comboBoxYearTo.Visible = true;
                comboBoxWeekFrom.Visible = true;
                comboBoxWeekTo.Visible = true;
            }
            else if (timeInterval == "MÅNADSVIS")
            {
                // från kallender
                string format = "MMMM yyyy";
                SetCustomFormat(format);
                dateTimePickerFrom.Visible = true;
                dateTimePickerTo.Visible = true;
                comboBoxYearFrom.Visible = false;
                comboBoxYearTo.Visible = false;
                comboBoxWeekFrom.Visible = false;
                comboBoxWeekTo.Visible = false;
            }
            else if (timeInterval == "ÅRSVIS")
            {
                // från boxen för år
                string format = "yyyy";
                SetCustomFormat(format);
                dateTimePickerFrom.Visible = false;
                dateTimePickerTo.Visible = false;
                comboBoxYearFrom.Visible = true;
                comboBoxYearTo.Visible = true;
                comboBoxWeekFrom.Visible = false;
                comboBoxWeekTo.Visible = false;
            }
        }
    }
}
