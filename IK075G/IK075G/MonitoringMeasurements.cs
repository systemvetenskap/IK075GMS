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

namespace IK075G
{
    public partial class MonitoringMeasurements : Form
    {
        //Upprättar koppling mot databas
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;UserId=postgres;Password=carlo;Database=IK075G;");
        NpgsqlCommand cmd;

        public MonitoringMeasurements()
        {
            InitializeComponent();

        }
        private void MonitoringMeasurements_Load(object sender, EventArgs e) //Formuläret laddas
        {
            DisableDatePick();
            LoadTimeInterval();
            LoadCustomerGroups();
            LoadAnalysis();
            LoadPriorityGroup();

            comboBoxPriorityGroup.Enabled = false;
            comboBoxAnalysis.Enabled = false;
            comboBoxTimeInterval.Enabled = false;
            btnShowUpdateDiagram.Enabled = false;

            //Klocka och datum
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(this.timer1_Tick);
            timer1.Start();
        }
        private void btnBack_Click(object sender, EventArgs e) //Till huvudmenyn
        {
            this.Hide();
            MainMenu huvudmeny = new MainMenu();
            huvudmeny.ShowDialog();
        }
        private void btnShowUpdateDiagram_Click(object sender, EventArgs e) //Updatera/visa diagram
        {
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            string customergroup = comboBoxCustomerGroup.Text;
            string analysis = comboBoxAnalysis.Text;
            string prioritygroup = comboBoxPriorityGroup.Text;
            string timeinterval = comboBoxTimeInterval.Text;

            if (timeinterval == "DAGSVIS")
            {
                string yearfrom = dateTimePickerDayFrom.Value.Year.ToString();
                string yearto = dateTimePickerDayTo.Value.Year.ToString();
                string dayfrom = dateTimePickerDayFrom.Value.ToShortDateString();
                string dayto = dateTimePickerDayTo.Value.ToShortDateString();

                newListMember = getDayValues(customergroup, analysis, prioritygroup, timeinterval, yearfrom, yearto, dayfrom, dayto);
            }
            else if (timeinterval == "VECKOVIS")
            {
                string yearfrom = comboBoxYearFrom.Text;
                string weekfrom = comboBoxWeekFrom.Text;
                string yearto = comboBoxYearTo.Text;
                string weekto = comboBoxWeekTo.Text;

                newListMember = getWeekValues(customergroup, analysis, prioritygroup, timeinterval, yearfrom, yearto, weekfrom, weekto);
            }
            else if (timeinterval == "MÅNADSVIS")
            {
                string monthfrom = dateTimePickerMonthFrom.Value.ToShortDateString();
                string monthto = dateTimePickerMonthTo.Value.ToShortDateString();
            }

            chart1.Titles.Clear();
            chart1.Series.Clear();

            // Titel ovanför diagramet  
            chart1.Titles.Add("Enhet");

            //Kurva för medelvärde
            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.Series["Series1"].LegendText = "Medel värde";
            //chart1.Series["Series1"].YValueType = ChartValueType.Double;

            //Kurva för minsta värde
            chart1.Series.Add("Series2");
            chart1.Series["Series2"].ChartType = SeriesChartType.Line;
            chart1.Series["Series2"].LegendText = "Minsta värde";
            //chart1.Series["Series2"].YValueType = ChartValueType.Double;

            //Kurva för högsta värde
            chart1.Series.Add("Series3");
            chart1.Series["Series3"].ChartType = SeriesChartType.Line;
            chart1.Series["Series3"].LegendText = "Högsta värde";
            //chart1.Series["Series3"].YValueType = ChartValueType.Double;

            foreach (MeasurementMonitoring item in newListMember)
            {
                //Ritar ut diagrammet punkt för punkt
                DataPoint newAveragePoint = new DataPoint();
                newAveragePoint.AxisLabel = item.week;
                //newAveragePoint.SetValueY(Convert.ToDouble(item.medelrawr));
                newAveragePoint.SetValueY(item.medelrawr);
                chart1.Series["Series1"].Points.Add(newAveragePoint);

                DataPoint newMinPoint = new DataPoint();
                newMinPoint.SetValueY(item.minrawr);
                chart1.Series["Series2"].Points.Add(newMinPoint);

                DataPoint newMaxPoint = new DataPoint();
                newMaxPoint.SetValueY(item.maxrawr);
                chart1.Series["Series3"].Points.Add(newMaxPoint);
            }
            chart1.Show();
        }

        //Egna metoder
        public void LoadCustomerGroups() //Metod för att LADDA kundgrupper i comboboxen
        {
            string sql = "SELECT cuco FROM cuco_sub2 ORDER BY cuco";
            conn.Open();
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string cuco = dr["cuco"].ToString();
                comboBoxCustomerGroup.Items.Add(cuco);
            }
            conn.Close();
        }
        public void LoadAnalysis() //Metod för att LADDA analyser i comboboxen
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
        public void LoadPriorityGroup() //Metod för att LADDA prioritetsgrupper i comboboxen
        {
            string sql = "SELECT DISTINCT prio FROM a_ana_tab ORDER BY prio";
            conn.Open();
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string prio = dr["prio"].ToString();
                comboBoxPriorityGroup.Items.Add(prio);
            }
            conn.Close();
        }
        public void LoadTimeInterval() //Metod för att FYLLA comboboxen med tidsintervall
        {
            comboBoxTimeInterval.Items.Add("DAGSVIS");
            comboBoxTimeInterval.Items.Add("VECKOVIS");
            comboBoxTimeInterval.Items.Add("MÅNADSVIS");
        }       
        public void LoadWeekNumbers() //Metod för att FYLLA comboboxarna med veckonummer
        {
            comboBoxYearFrom.Enabled = true;
            comboBoxWeekFrom.Enabled = false;
            comboBoxYearTo.Enabled = false;
            comboBoxWeekTo.Enabled = false;

            if (comboBoxYearFrom.Text!="Startår")
            {
                comboBoxWeekFrom.Enabled = true;
                if (comboBoxWeekFrom.Text!="Startvecka")
                {
                    comboBoxYearTo.Enabled = true;
                    if (comboBoxYearTo.Text!="Slutår")
                    {
                        comboBoxWeekTo.Enabled = true;
                    }
                }
            }

            for (int i = 1; i <= 52; i++)
            {
                comboBoxWeekFrom.Items.Add(i.ToString());
                comboBoxWeekTo.Items.Add(i.ToString());
            }
            
        }      
        public void LoadYears() // Metod för att LADDA in årtal i comboboxar från och till
        {
            // Rensar båda comboboxar på grund av dubletter.
            if (comboBoxYearFrom.Items.Count > 0)
            {
               comboBoxYearFrom.Items.Clear(); 
            }            
            if (comboBoxYearTo.Items.Count > 0)
            {
                comboBoxYearTo.Items.Clear();
            }
            
            // Från år
            string sql1 = "SELECT DISTINCT substr(altm,1,2) altm FROM a_ana_tab WHERE LENGTH(REPLACE(altm, ' ','')) >0 ORDER BY altm";
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
            string sql2 = "SELECT DISTINCT substr(altm,1,2) altm FROM a_ana_tab WHERE LENGTH(REPLACE(altm, ' ','')) >0 ORDER BY altm";
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
        public void DisableDatePick() //Metod för att dölja tids valen
        {
            //Dagsvis
            dateTimePickerDayFrom.Visible = false;
            dateTimePickerDayTo.Visible = false;
            dateTimePickerDayFrom.Enabled = false;
            dateTimePickerDayTo.Enabled = false;
            //Veckovis
            comboBoxYearFrom.Visible = false;
            comboBoxWeekFrom.Visible = false;
            comboBoxYearTo.Visible = false;
            comboBoxWeekTo.Visible = false;
            //Månadsvis
            dateTimePickerMonthFrom.Visible = false;
            dateTimePickerMonthTo.Visible = false;
        }
        private void OnlyBigLetters(object sender, KeyPressEventArgs e) //Metod för stora bokstäver
        {
            {
                if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                    e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
            }
        }
        private void OnlyDigits(object sender, KeyPressEventArgs e) //Metod för endast siffror
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public List<MeasurementMonitoring> getWeekValues(string customergroup, string analysis, string prioritygroup, string timeinterval, string yearfrom, string yearto, string weekfrom, string weekto) //Metod för att visa veckovis
        {          
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            conn.Open();

            weekfrom = weekfrom.PadLeft(2, '0');
            weekto = weekto.PadLeft(2, '0');
            
            string sql = string.Empty;
            sql = sql + "SELECT '' cuco, ";
            sql = sql + "	anco, ";
            sql = sql + " 	prio, ";
            sql = sql + "	to_char(to_timestamp(altm, 'yymmddhh24mi'),'YYYYWW') week,";
            sql = sql + "	count(anco),		";
            sql = sql + "	min(cast(replace(rawr, ',', '.') AS numeric)*100) minrawr, ";
            sql = sql + "	max(cast(replace(rawr, ',', '.') AS numeric)*100) maxrawr, ";
            sql = sql + "	avg(cast(replace(rawr, ',', '.') AS numeric)*100) medelrawr ";
            sql = sql + " FROM a_ana_tab  ";
            sql = sql + " WHERE length(replace(altm,' ','')) > 0";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newFirstanco";
            sql = sql + " AND to_char(to_date(altm,'yymmddhh24mi'),'YY') BETWEEN :newyearFrom AND :newyearTo";
            sql = sql + " AND to_char(to_date(altm,'yymmddhh24mi'),'WW') BETWEEN :newweekFrom AND :newweekTo";
            sql = sql + " GROUP BY prio, anco, to_char(to_timestamp(altm, 'yymmddhh24mi'),'YYYYWW')";
            sql = sql + " ORDER BY prio, anco, to_char(to_timestamp(altm, 'yymmddhh24mi'),'YYYYWW')";
            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newFirstanco", NpgsqlDbType.Varchar));
            cmd.Parameters["newFirstanco"].Value = analysis;

            cmd.Parameters.Add(new NpgsqlParameter("newyearFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newyearFrom"].Value = yearfrom;

            cmd.Parameters.Add(new NpgsqlParameter("newyearTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newyearTo"].Value = yearto;

            cmd.Parameters.Add(new NpgsqlParameter("newweekFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newweekFrom"].Value = weekfrom;

            cmd.Parameters.Add(new NpgsqlParameter("newweekTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newweekTo"].Value = weekto;

            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prioritygroup;

            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customergroup;

            NpgsqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                MeasurementMonitoring newMonitorByWeek = new MeasurementMonitoring();
                newMonitorByWeek.week = dr1["week"].ToString();
                newMonitorByWeek.prio = dr1["prio"].ToString();
                newMonitorByWeek.analysis = dr1["anco"].ToString();
                newMonitorByWeek.minrawr = dr1["minrawr"].ToString();
                newMonitorByWeek.maxrawr = dr1["maxrawr"].ToString();
                newMonitorByWeek.medelrawr = dr1["medelrawr"].ToString();

                newListMember.Add(newMonitorByWeek);
            }
            conn.Close();
            return newListMember;
        }
        public List<MeasurementMonitoring> getDayValues(string customergroup, string analysis, string prioritygroup, string timeinterval, string yearfrom, string yearto, string dayfrom, string dayto) //Metod för att visa dagvis
        {
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            conn.Open();

            dayfrom = dayfrom.PadLeft(2, '0');
            dayto = dayto.PadLeft(2, '0');

            string sql = string.Empty;

            sql = sql + "SELECT '' cuco, ";
            sql = sql + "anco, ";
            sql = sql + "prio, ";
            sql = sql + "to_char(to_timestamp(altm, 'yymmddhh24mi'), 'YYYYDD') myday, ";
            sql = sql + "count(anco), ";
            sql = sql + "min(cast(replace(rawr, ',', '.') AS numeric)) minrawr, ";
            sql = sql + "max(cast(replace(rawr, ',', '.') AS numeric)) maxrawr, ";
            sql = sql + "avg(cast(replace(rawr, ',', '.') AS numeric)) medelrawr ";
            sql = sql + "FROM a_ana_tab ";
            sql = sql + "WHERE length(replace(altm, ' ', '')) > 0 ";
            sql = sql + "AND prio = :newPrio ";
            sql = sql + "AND anco = :newFirstanco ";
            sql = sql + "AND to_char(to_date(altm, 'yymmddhh24mi'), 'YYYY') BETWEEN :newyearFrom AND :newyearTo ";
            sql = sql + "AND to_char(to_date(altm, 'yymmddhh24mi'), 'YYYY-MM-DD') BETWEEN :newdayFrom AND :newdayTo ";
            sql = sql + "GROUP BY prio, anco, to_char(to_timestamp(altm, 'yymmddhh24mi'), 'YYYYDD') ";
            sql = sql + "ORDER BY prio, anco, to_char(to_timestamp(altm, 'yymmddhh24mi'), 'YYYYDD') ";
            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newFirstanco", NpgsqlDbType.Varchar));
            cmd.Parameters["newFirstanco"].Value = analysis;

            cmd.Parameters.Add(new NpgsqlParameter("newyearFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newyearFrom"].Value = yearfrom;

            cmd.Parameters.Add(new NpgsqlParameter("newyearTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newyearTo"].Value = yearto;

            cmd.Parameters.Add(new NpgsqlParameter("newdayFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newdayFrom"].Value = dayfrom;

            cmd.Parameters.Add(new NpgsqlParameter("newdayTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newdayTo"].Value = dayto;

            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prioritygroup;

            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customergroup;

            NpgsqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                MeasurementMonitoring newMonitorByDay = new MeasurementMonitoring();
                newMonitorByDay.day = dr1["myday"].ToString();
                newMonitorByDay.prio = dr1["prio"].ToString();
                newMonitorByDay.analysis = dr1["anco"].ToString();
                newMonitorByDay.minrawr = dr1["minrawr"].ToString();
                newMonitorByDay.maxrawr = dr1["maxrawr"].ToString();
                newMonitorByDay.medelrawr = dr1["medelrawr"].ToString();

                newListMember.Add(newMonitorByDay);
            }
            conn.Close();
            return newListMember;
        }

        //Comboboxar
        private void comboBoxCustomerGroup_SelectedIndexChanged(object sender, EventArgs e) //Kundgrupp
        {
            if (comboBoxCustomerGroup.SelectedItem.ToString().Equals(""))
            {
                comboBoxAnalysis.Enabled = false;
            }
            else
            {
                comboBoxAnalysis.Enabled = true;
            }
        }
        private void comboBoxTimeInterval_SelectedIndexChanged(object sender, EventArgs e) //Tidsintervall
        {
            btnShowUpdateDiagram.Enabled = false;
            if (comboBoxTimeInterval.SelectedIndex<0)
            {
                DisableDatePick();
            }

            else if (comboBoxTimeInterval.SelectedIndex>=0)
            {

                if (comboBoxTimeInterval.Text == "DAGSVIS")
                {
                    comboBoxYearFrom.Visible = false;
                    comboBoxWeekFrom.Visible = false;
                    comboBoxYearTo.Visible = false;
                    comboBoxWeekTo.Visible = false;
                    dateTimePickerMonthFrom.Visible = false;
                    dateTimePickerMonthTo.Visible = false;
                    dateTimePickerDayFrom.Visible = true;
                    dateTimePickerDayTo.Visible = true;
                }
                else if (comboBoxTimeInterval.Text == "VECKOVIS")
                {
                    comboBoxYearFrom.Visible = true;
                    comboBoxWeekFrom.Visible = true;
                    comboBoxYearTo.Visible = true;
                    comboBoxWeekTo.Visible = true;
                    dateTimePickerMonthFrom.Visible = false;
                    dateTimePickerMonthTo.Visible = false;
                    dateTimePickerDayFrom.Visible = false;
                    dateTimePickerDayTo.Visible = false;
                    LoadYears();
                    LoadWeekNumbers();
                }
                else if (comboBoxTimeInterval.Text == "MÅNADSVIS")
                {
                    comboBoxYearFrom.Visible = false;
                    comboBoxWeekFrom.Visible = false;
                    comboBoxYearTo.Visible = false;
                    comboBoxWeekTo.Visible = false;
                    dateTimePickerMonthFrom.Visible = true;
                    dateTimePickerMonthTo.Visible = true;
                    dateTimePickerDayFrom.Visible = false;
                    dateTimePickerDayTo.Visible = false;
                }
            }

        }
        private void comboBoxYearFrom_SelectedIndexChanged(object sender, EventArgs e) //Startår
        {
            LoadWeekNumbers();
        }
        private void comboBoxYearTo_SelectedIndexChanged(object sender, EventArgs e) //Slutår
        {
            LoadWeekNumbers();
        }
        private void comboBoxWeekFrom_SelectedIndexChanged(object sender, EventArgs e) //Startvecka
        {
            LoadWeekNumbers();
        }
        private void comboBoxWeekTo_SelectedIndexChanged(object sender, EventArgs e) //Slutvecka
        {
            btnShowUpdateDiagram.Enabled = true;
        }
        private void comboBoxAnalysis_SelectedIndexChanged(object sender, EventArgs e) //Analys
        {
            if (comboBoxAnalysis.SelectedItem.ToString().Equals(""))
            {
                comboBoxPriorityGroup.Enabled = false;
            }
            else
            {
                comboBoxPriorityGroup.Enabled = true;
            }
        }
        private void comboBoxPriorityGroup_SelectedIndexChanged(object sender, EventArgs e) //Prioritetsgrupp
        {
            if (comboBoxPriorityGroup.SelectedItem.ToString().Equals(""))
            {
                comboBoxTimeInterval.Enabled = false;
            }
            else
            {
                comboBoxTimeInterval.Enabled = true;
                dateTimePickerDayFrom.Enabled = true;
                dateTimePickerDayTo.Enabled = true;
            }
        }

        //Klocka
        private void timer1_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            string time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            lblTodaysDateAndTime.Text = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.DayOfWeek + "  " + time;


        } //Klocka och datum

        //Datetimepickers
        private void dateTimePickerDayFrom_ValueChanged(object sender, EventArgs e) //Dag från
        {

        }
        private void dateTimePickerDayTo_ValueChanged(object sender, EventArgs e) //Dag till
        {
            btnShowUpdateDiagram.Enabled = true;
        }
        private void dateTimePickerMonthFrom_ValueChanged(object sender, EventArgs e) //Månad från
        {

        }
        private void dateTimePickerMonthTo_ValueChanged(object sender, EventArgs e) //Månad till
        {
            btnShowUpdateDiagram.Enabled = true;
        }

        //Keypress events
        private void comboBoxCustomerGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyBigLetters(sender, e);
        }
        private void comboBoxAnalysis_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyBigLetters(sender, e);
        }
        private void comboBoxPriorityGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDigits(sender, e);
        }
        private void comboBoxTimeInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyBigLetters(sender, e);
        }
    }
}
