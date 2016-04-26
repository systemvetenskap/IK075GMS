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
// 

using System.Globalization;

namespace IK075G
{
    public partial class TimeMonitoring : Form
    {
        // Upprättar koppling mot databas
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;UserId=postgres;Password=carlo;Database=IK075G;");
        NpgsqlCommand cmd;

        public TimeMonitoring()
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
            comboBoxTimeInterval.SelectedItem = "Dagsvis";
            LoadCustomerGroups();
            LoadAnalysis();
            LoadPriorityGroup();
            LoadTimeInterval();
        }

        //Egna metoder        
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
            comboBoxTimeInterval.Items.Add("Dagsvis");
            comboBoxTimeInterval.Items.Add("Veckovis");
            comboBoxTimeInterval.Items.Add("Månadsvis");
            comboBoxTimeInterval.Items.Add("Årsvis");
        }

        public void SetCustomMinMaxDate() // Används för att sätta start och stop år i kalender beroende på minsta 
        {
            DateTime newMinDateTime = new DateTime();
            // Än så länge hårdkodad värde för start år. Skall senare sättas till minsta analys datum 
            newMinDateTime.AddYears(2009);
            newMinDateTime.AddMonths(1);
            newMinDateTime.AddDays(1);
            newMinDateTime.AddHours(0.00);
            newMinDateTime.AddMinutes(0.00);
            newMinDateTime.AddSeconds(0.00);
            newMinDateTime.AddMilliseconds(0.00);
            dateTimePickerFrom.MinDate = newMinDateTime;

            DateTime newMaxDateTime = new DateTime();
            // Fram till idag
            newMaxDateTime = DateTime.Now;
            dateTimePickerFrom.MinDate = newMinDateTime;
            dateTimePickerFrom.MaxDate = newMaxDateTime;
            dateTimePickerTo.MinDate = newMinDateTime;
            dateTimePickerTo.MaxDate = newMaxDateTime;
        }

        public void SetCustomFormat(string format) // Används för att definera format i kallender 
        {
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = format;

            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = format;
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
            sql = sql + "    to_char(tetm_date,'YYYY') AS year,";
            sql = sql + "    to_char(tetm_date,'MM') AS month,";
            sql = sql + "    to_char(tetm_date,'WW') AS week,";
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
            sql = sql + " AND to_char(tetm_date,'YYYY') BETWEEN :newyearFrom AND :newyearTo";
            sql = sql + " AND to_char(tetm_date,'WW') BETWEEN :newweekFrom AND :newweekTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYY'), to_char(tetm_date,'MM'), to_char(tetm_date,'WW')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYY'), to_char(tetm_date,'MM'), to_char(tetm_date,'WW')";

            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customerGroup;
            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prio;
            cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
            cmd.Parameters["newAnco"].Value = analys;
            cmd.Parameters.Add(new NpgsqlParameter("newyearFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newyearFrom"].Value = yearFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newyearTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newyearTo"].Value = yearTo;
            cmd.Parameters.Add(new NpgsqlParameter("newweekFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newweekFrom"].Value = weekFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newweekTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newweekTo"].Value = weekTo;

            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ResponseTimes newResponseTimes = new ResponseTimes();
                newResponseTimes.customerGroup = customerGroup;
                newResponseTimes.prio = prio;
                newResponseTimes.analys = analys;
                newResponseTimes.year = Convert.ToString(dr["year"]);
                newResponseTimes.month = Convert.ToString(dr["month"]);
                newResponseTimes.week = Convert.ToString(dr["week"]);
                // newResponseTimes.day = Convert.ToString(dr["day"]);
                // newResponseTimes.hour = hour;
                // newResponseTimes.minute = minute;
                // newResponseTimes.current_date = Convert.ToString(dr["current_date"]);
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
            sql = sql + "    to_char(tetm_date,'YYYY') AS year,";
            sql = sql + "    to_char(tetm_date,'MM') AS month,";
            sql = sql + "    to_char(tetm_date,'WW') AS week,";
            sql = sql + "    to_char(tetm_date,'DD') AS day,";
            sql = sql + "    to_char(tetm_date,'YYYYMMDD') AS current_date,";
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
            sql = sql + " AND to_char(tetm_date,'YYYY-MM-DD HH24') BETWEEN :newdayFrom AND :newdayTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYY'), to_char(tetm_date,'MM'), to_char(tetm_date,'WW'), to_char(tetm_date,'DD'), to_char(tetm_date,'YYYYMMDD')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYY'), to_char(tetm_date,'MM'), to_char(tetm_date,'WW'), to_char(tetm_date,'DD'), to_char(tetm_date,'YYYYMMDD')";

            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customerGroup;
            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prio;
            cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
            cmd.Parameters["newAnco"].Value = analys;
            cmd.Parameters.Add(new NpgsqlParameter("newdayFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newdayFrom"].Value = dayFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newdayTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newdayTo"].Value = dayTo;

            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ResponseTimes newResponseTimes = new ResponseTimes();
                newResponseTimes.customerGroup = customerGroup;
                newResponseTimes.prio = prio;
                newResponseTimes.analys = analys;
                newResponseTimes.year = Convert.ToString(dr["year"]);
                newResponseTimes.month = Convert.ToString(dr["month"]);
                newResponseTimes.week = Convert.ToString(dr["week"]);
                newResponseTimes.day = Convert.ToString(dr["day"]);
                // newResponseTimes.hour = hour;
                // newResponseTimes.minute = minute;
                newResponseTimes.current_date = Convert.ToString(dr["current_date"]);
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

        // Metod för att hitta högsta värdet
        public double FindMaxValue(List<ResponseTimes> newListMember)
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
        private void comboBoxTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sätter min och max datum i kallender beroende min oxh max datum för analys (a_ana_tab)
            SetCustomMinMaxDate();

            // sätter format i kallender beroende på vald tids interval    
            string timeInterval = comboBoxTimeInterval.Text;
            if (timeInterval == "Timvis")
            {
                string format = "MMMM dd, yyyy - dddd HH24";
                SetCustomFormat(format);
            }
            else if (timeInterval == "Dagvis")
            {
                string format = "MMMM dd, yyyy - dddd";
                SetCustomFormat(format);
            }
            else if (timeInterval == "Veckovis")
            {
                // kontrolleras och ersätts med komboboxar
                string format = "MMMM dd, yyyy - ww";
                SetCustomFormat(format);
            }
            else if (timeInterval == "Månadsvis")
            {
                string format = "MMMM dd, yyyy - mmmm";
                SetCustomFormat(format);
            }
            else if (timeInterval == "Årsvis")
            {
                string format = "MMMM dd, yyyy";
                SetCustomFormat(format);
            }
        }

        private void btnShowUpdateDiagram_Click(object sender, EventArgs e)
        {
            List<ResponseTimes> newListMember = new List<ResponseTimes>();

            string customerGroup = comboBoxCustomerGrp.Text;
            string analys = comboBoxAnalysis.Text;
            string prio = comboBoxPriority.Text;
            string timeInterval = comboBoxTimeInterval.Text;

            DateTime dateFrom = dateTimePickerFrom.Value;
            DateTime dateTo = dateTimePickerTo.Value;

            string yearFrom = dateFrom.Year.ToString();
            string monthFrom = dateFrom.Month.ToString();
            var cal1 = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            string weekFrom = cal1.GetWeekOfYear(dateFrom, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();
            string dayFrom = dateFrom.ToShortDateString();
            dateFrom.Day.ToString();
            string hoursFrom = dateFrom.Hour.ToString();
            string minutesFrom = dateFrom.Minute.ToString();

            string yearTo = dateTo.Year.ToString();
            string monthTo = dateTo.Month.ToString();
            var cal2 = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            string weekTo = cal2.GetWeekOfYear(dateTo, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();
            string dayTo = dateTo.ToShortDateString();
            dateTo.Day.ToString();
            string hoursTo = dateTo.Hour.ToString();
            string minutesTo = dateTo.Minute.ToString();

            if (timeInterval == "Timvis")
            {
                // newListMember = GetResponseByWeek(customerGroup, analys, prio, yearFrom, yearTo, weekFrom, weekTo);
            }
            else if (timeInterval == "Dagsvis")
            {
                newListMember = GetResponseByDay(customerGroup, analys, prio, dayFrom, dayTo);
            }
            else if (timeInterval == "Veckovis")
            {
                newListMember = GetResponseByWeek(customerGroup, analys, prio, yearFrom, yearTo, weekFrom, weekTo);
            }
            else if (timeInterval == "Månadsvis")
            {
                // newListMember = GetResponseByWeek(customerGroup, analys, prio, yearFrom, yearTo, weekFrom, weekTo);
            }
            else if (timeInterval == "Årsvis")
            {
                // newListMember = GetResponseByWeek(customerGroup, analys, prio, yearFrom, yearTo, weekFrom, weekTo);
            }

            // Diagrammet 
            chartResponseTime.ChartAreas.Clear();
            chartResponseTime.Titles.Clear();
            chartResponseTime.Series.Clear();

            // Titel ovanför diagramet  
            chartResponseTime.Titles.Add("Response Time");

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
                if (timeInterval == "Timvis")
                {
                    // newAveragePoint.AxisLabel = hours.ToString();
                }
                else if (timeInterval == "Dagsvis")
                {
                    newAveragePoint.AxisLabel = item.year + item.month + item.day;
                    chartResponseTime.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Days;
                }
                else if (timeInterval == "Veckovis")
                {
                    newAveragePoint.AxisLabel = item.year + item.week;
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
                }
                else if (timeInterval == "Månadsvis")
                {
                    newAveragePoint.AxisLabel = item.year + item.month;
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                }
                else if (timeInterval == "Årsvis")
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
        }
    }
}
