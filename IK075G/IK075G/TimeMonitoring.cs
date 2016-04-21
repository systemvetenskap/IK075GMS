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

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chartResponseTime_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCustomerGrp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxAnalysis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPriorityGrp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTimeInterval_SelectedIndexChanged_1(object sender, EventArgs e)
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

        #region Egna metoder

        //Metod för att ladda kundgrupper i comboboxen
        public void LoadCustomerGroups()
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

        //Metod för att ladda analyser i comboboxen
        public void LoadAnalysis()
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

        //Metod för att ladda prioritetsgrupper i comboboxen
        public void LoadPriorityGroup()
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

        //Metod för att fylla comboboxen med tidsintervall
        public void LoadTimeInterval()
        {
            comboBoxTimeInterval.Items.Add("Timvis");
            comboBoxTimeInterval.Items.Add("Dagsvis");
            comboBoxTimeInterval.Items.Add("Veckovis");
            comboBoxTimeInterval.Items.Add("Månadsvis");
            comboBoxTimeInterval.Items.Add("Årsvis");
        }

        // Används för att sätta start och stop år i kalender beroende på minsta 
        public void SetCustomMinMaxDate()
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

        // Används för att definera format i kallender 
        public void SetCustomFormat(string format)
        {
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = format;

            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = format;
        }

        // Metod för att hämta matris per vecka
        public List<ResponseTimes> GetResponseByWeek(string customerGroup, string analys, string prio, string yearFrom, string yearTo, string weekFrom, string weekTo)
        {
            List<ResponseTimes> newListMember = new List<ResponseTimes>();

            conn.Open();

            weekFrom = weekFrom.PadLeft(2, '0');
            weekTo = weekTo.PadLeft(2, '0');

            string sql = string.Empty;
            sql = sql + "SELECT 'Kund' cuco,";
            sql = sql + "   prio AS prio, ";
            sql = sql + "   anco AS anco, ";
            sql = sql + "   to_char(to_timestamp(altm, 'yymmddhh24mi'),'YYYY') AS year, ";
            sql = sql + "   to_char(to_timestamp(altm, 'yymmddhh24mi'),'WW') AS week, ";
            sql = sql + "   count(anco) AS quantity,";
            sql = sql + "   to_char(min(to_timestamp(tetm, 'yymmddhh24mi') - to_timestamp(artm, 'yymmddhh24mi')),'DD hh24:mi') AS mintime, ";
            sql = sql + "   to_char(max(to_timestamp(tetm, 'yymmddhh24mi') - to_timestamp(artm, 'yymmddhh24mi')),'DD hh24:mi') AS maxtime, ";
            sql = sql + "   to_char(avg(to_timestamp(tetm, 'yymmddhh24mi') - to_timestamp(artm, 'yymmddhh24mi')),'DD hh24:mi') AS avgtime ";
            sql = sql + " FROM a_ana_tab";
            sql = sql + "   LEFT JOIN a_samp_tab AS a_samp_tab ON (a_samp_tab.lidn = a_ana_tab.lidn)";
            sql = sql + " WHERE length(replace(altm,' ','')) > 0";
            sql = sql + " AND length(replace(artm,' ','')) > 0";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newAnco";
            sql = sql + " AND to_char(to_date(altm,'yymmddhh24mi'),'YYYY') BETWEEN :newyearFrom AND :newyearTo";
            sql = sql + " AND to_char(to_date(altm,'yymmddhh24mi'),'WW') BETWEEN :newweekFrom AND :newweekTo";
            sql = sql + " GROUP BY prio, anco, to_char(to_timestamp(altm, 'yymmddhh24mi'),'YYYY'), to_char(to_timestamp(altm, 'yymmddhh24mi'),'WW')";
            sql = sql + " ORDER BY prio, anco, to_char(to_timestamp(altm, 'yymmddhh24mi'),'YYYY'), to_char(to_timestamp(altm, 'yymmddhh24mi'),'WW')";

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
                // newResponseTimes.year = year;
                // newResponseTimes.month = month;
                // newResponseTimes.week = week;
                // newResponseTimes.day = day;
                // newResponseTimes.hour = hour;
                // newResponseTimes.minute = minute;
                newResponseTimes.year = Convert.ToString(dr["year"]); 
                newResponseTimes.week = Convert.ToString(dr["week"]);
                newResponseTimes.quantity = Convert.ToString(dr["quantity"]);                
                newResponseTimes.avgTime = Convert.ToString(dr["avgTime"]);
                newResponseTimes.minTime = Convert.ToString(dr["minTime"]);
                newResponseTimes.maxtime = Convert.ToString(dr["maxtime"]);
                newListMember.Add(newResponseTimes);
            }
            conn.Close();
            return newListMember;
        }
                
        #endregion

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
            string dayFrom = dateFrom.Day.ToString();
            string hoursFrom = dateFrom.Hour.ToString();
            string minutesFrom = dateFrom.Minute.ToString();

            string yearTo = dateTo.Year.ToString();
            string monthTo = dateTo.Year.ToString();
            var cal2 = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            string weekTo = cal2.GetWeekOfYear(dateTo, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();
            string dayTo = dateTo.Year.ToString();
            string hoursTo = dateTo.Year.ToString();
            string minutesTo = dateTo.Year.ToString();

            newListMember = GetResponseByWeek(customerGroup, analys, prio, yearFrom, yearTo, weekFrom, weekTo);
            
            // Diagrammet
            chartResponseTime.Titles.Clear();
            chartResponseTime.Series.Clear();

            // Titel ovanför diagramet  
            chartResponseTime.Titles.Add("Respons");

            chartResponseTime.Series.Add("Series1");
            chartResponseTime.Series["Series1"].ChartArea = "ChartArea1";
            chartResponseTime.Series["Series1"].LegendText = "Medel";
            chartResponseTime.Series["Series1"].YValueType = ChartValueType.Time;
            
            chartResponseTime.Series.Add("Series2");
            chartResponseTime.Series["Series2"].ChartArea = "ChartArea1";
            chartResponseTime.Series["Series2"].LegendText = "Min";
            chartResponseTime.Series["Series2"].YValueType = ChartValueType.Time;

            chartResponseTime.Series.Add("Series3");
            chartResponseTime.Series["Series3"].ChartArea = "ChartArea1";
            chartResponseTime.Series["Series3"].LegendText = "Max";
            chartResponseTime.Series["Series3"].YValueType = ChartValueType.Time;

            foreach (ResponseTimes item in newListMember)            
            {
                DataPoint newAveragePoint = new DataPoint();
                newAveragePoint.AxisLabel = item.week;
                newAveragePoint.SetValueY(item.avgTime);
                chartResponseTime.Series["Series1"].Points.Add(newAveragePoint);

                DataPoint newMinPoint = new DataPoint();
                newMinPoint.SetValueY(item.minTime);
                chartResponseTime.Series["Series2"].Points.Add(newMinPoint);

                DataPoint newMaxPoint = new DataPoint();
                newMaxPoint.SetValueY(item.minTime);
                chartResponseTime.Series["Series3"].Points.Add(newMaxPoint);
            }
            chartResponseTime.Show();
        }
    }
}
