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
        public void LoadCustomerGroups()//Metod för att LADDA kundgrupper i comboboxen
        {
            string sql = "SELECT cugr FROM imp_cugr_tab";
            conn.Open();
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string cugr = dr["cugr"].ToString();
                comboBoxCustomerGroup.Items.Add(cugr);
            }
            conn.Close();
        }
        public void LoadAnalysis()//Metod för att LADDA analyser i comboboxen
        {
            string sql = "SELECT DISTINCT anco FROM imp_a_ana_tab ORDER BY anco";
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
        public void LoadPriorityGroup()//Metod för att LADDA prioritetsgrupper i comboboxen
        {
            string sql = "SELECT DISTINCT prio FROM imp_a_ana_tab ORDER BY prio";
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
        public void LoadTimeInterval()//Metod för att FYLLA comboboxen med tidsintervall
        {
            comboBoxTimeInterval.Items.Add("Dagsvis");
            comboBoxTimeInterval.Items.Add("Veckovis");
            comboBoxTimeInterval.Items.Add("Månadsvis");
        }
        public void LoadWeekNumbers()//Metod för att FYLLA comboboxarna med veckonummer
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
        public void LoadYears()// Metod för att LADDA in årtal i comboboxar -från och till
        {
            //Från år
            string sql1 = "SELECT DISTINCT substr(altm,1,2) altm FROM imp_a_ana_tab WHERE LENGTH(REPLACE(altm, ' ','')) >0 ORDER BY altm";
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
            string sql2 = "SELECT DISTINCT substr(altm,1,2) altm FROM imp_a_ana_tab WHERE LENGTH(REPLACE(altm, ' ','')) >0 ORDER BY altm";
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
        public void DisableDatePick()//Metod för att dölja tids valen
        {
            //Dagsvis
            dateTimePickerDayFrom.Visible = false;
            dateTimePickerDayTo.Visible = false;
            //Veckovis
            comboBoxYearFrom.Visible = false;
            comboBoxWeekFrom.Visible = false;
            comboBoxYearTo.Visible = false;
            comboBoxWeekTo.Visible = false;
            //Månadsvis
            dateTimePickerMonthFrom.Visible = false;
            dateTimePickerMonthTo.Visible = false;
        }
        public List<MonitorByWeek> getWeekValues(string Analysis, string yearFrom, string yearTo, string weekFrom, string weekTo, string prio, string customerGroup)
        {
            List<MonitorByWeek> newListMember = new List<MonitorByWeek>();

            string sql1 = "SELECT to_char(to_date(substr(altm,1,6), 'YYMMDD'),'YYYY') year, to_char(to_date(substr(altm,1,6), 'YYMMDD'),'WW') week,";
            sql1 = sql1 + "prio, anco,min(cast(replace(rawr, ',', '.') AS numeric)) minrawr,max(cast(replace(rawr, ',', '.') AS numeric)) maxrawr,";
            sql1 = sql1 + "avg(cast(replace(rawr, ',', '.') AS numeric)) medelrawr";
            sql1 = sql1 + "FROM imp_a_ana_tab";
            sql1 = sql1 + " WHERE 1 = 1";
            sql1 = sql1 + "AND anco = :newFirstanco";
            sql1 = sql1 + "AND substr(altm,1, 2) BETWEEN :yearFrom AND :yearTo";
            sql1 = sql1 + "AND to_char(to_date(substr(altm, 1, 6), 'YYMMDD'), 'WW') BETWEEN :weekFrom AND :weekTo";
            sql1 = sql1 + "AND length(altm) > 0";
            sql1 = sql1 + "GROUP BY to_char(to_date(substr(altm, 1, 6), 'YYMMDD'), 'YYYY'), to_char(to_date(substr(altm, 1, 6), 'YYMMDD'), 'WW'), prio, anco";
            sql1 = sql1 + "ORDER BY to_char(to_date(substr(altm, 1, 6), 'YYMMDD'), 'YYYY'), to_char(to_date(substr(altm, 1, 6), 'YYMMDD'), 'WW'), prio, anco; ";

            cmd.Parameters.Add(new NpgsqlParameter("newFirstanco", NpgsqlDbType.Varchar));
            cmd.Parameters["newFirstanco"].Value = Analysis;
            cmd.Parameters.Add(new NpgsqlParameter("newyearFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newyearFrom"].Value = yearFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newyearTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newyearTo"].Value = yearTo;
            cmd.Parameters.Add(new NpgsqlParameter("newweekFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newweekFrom"].Value = weekFrom;
            cmd.Parameters.Add(new NpgsqlParameter("newweekTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newweekTo"].Value = weekTo;
            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prio;
            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customerGroup;

            conn.Open();
            cmd = new NpgsqlCommand(sql1, conn);
            NpgsqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                MonitorByWeek newMonitorByWeek = new MonitorByWeek();
                newMonitorByWeek.year = dr1["year"].ToString();
                newMonitorByWeek.week = dr1["week"].ToString();
                newMonitorByWeek.prio = dr1["prio"].ToString();
                newMonitorByWeek.analysis = dr1["analysis"].ToString();
                newMonitorByWeek.minrawr = dr1["minrawr"].ToString();
                newMonitorByWeek.maxrawr = dr1["maxrawr"].ToString();
                newMonitorByWeek.medelrawr = dr1["medelrawr"].ToString();

                newListMember.Add(newMonitorByWeek);
            }
            conn.Close();
            return newListMember;
        }
        private void MonitoringMeasurements_Load(object sender, EventArgs e)
        {
            DisableDatePick();
            LoadTimeInterval();
            comboBoxTimeInterval.SelectedItem = "Dagsvis";
            LoadCustomerGroups();
            LoadAnalysis();
            LoadPriorityGroup();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu huvudmeny = new MainMenu();
            huvudmeny.ShowDialog();
        }
        private void btnShowUpdateDiagram_Click(object sender, EventArgs e)
        {
            //Knapp för att updatera/visa diagrammet
            string customergroup = comboBoxCustomerGroup.SelectedText;
            string analysis = comboBoxAnalysis.SelectedText;
            string prioritygroup = comboBoxPriorityGroup.SelectedText;
            string timeinterval = comboBoxTimeInterval.SelectedText;

            if (timeinterval=="Dagvis")
            {
                string dayfrom = dateTimePickerDayFrom.Value.ToShortDateString();
                string dayto = dateTimePickerDayTo.Value.ToShortDateString();
            }
            else if (timeinterval=="Veckovis")
            {
                string yearfrom = comboBoxYearFrom.Text;
                string weekfrom = comboBoxWeekFrom.Text;

                string yearto = comboBoxYearTo.Text;
                string weekto = comboBoxWeekTo.Text;
            }
            else if (timeinterval=="Månadsvis")
            {
                string monthfrom = dateTimePickerMonthFrom.Value.ToShortDateString();
                string monthto = dateTimePickerMonthTo.Value.ToShortDateString();
            }
            // titel ovanför diagramet  
            chart1.Titles.Add("Enhet");

            chart1.Series["Series1"].ChartType= SeriesChartType.Line;

            // se legend  
            chart1.Series["Series1"].Name = "Analys1";

            // Detta är temporört, tills man inte hämtar veckor från db... 
            for (int i = 0; i <= 10; i++)
            {
                DataPoint newDataPoint = new DataPoint();
                newDataPoint.AxisLabel = i.ToString();

                //här sätts ett värde från databasen
                newDataPoint.SetValueY(i);
                // här skall veckan anges
                chart1.Series["Analys1"].Points.Add(newDataPoint);

            }
            chart1.Show();

        }
        private void comboBoxCustomerGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTimeInterval.SelectedIndex<0)
            {
                DisableDatePick();
            }
            else if (comboBoxTimeInterval.SelectedIndex>=0)
            {
                if (comboBoxTimeInterval.Text == "Dagsvis")
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
                else if (comboBoxTimeInterval.Text == "Veckovis")
                {
                    comboBoxYearFrom.Visible = true;
                    comboBoxWeekFrom.Visible = true;
                    comboBoxYearTo.Visible = true;
                    comboBoxWeekTo.Visible = true;
                    dateTimePickerMonthFrom.Visible = false;
                    dateTimePickerMonthTo.Visible = false;
                    dateTimePickerDayFrom.Visible = false;
                    dateTimePickerDayTo.Visible = false;
                    LoadWeekNumbers();
                    LoadYears();
                }
                else if (comboBoxTimeInterval.Text == "Månadsvis")
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
        private void comboBoxYearFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWeekNumbers();
        }
        private void comboBoxYearTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWeekNumbers();
        }
        private void comboBoxWeekFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWeekNumbers();
        }
        private void comboBoxAnalysis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxPriorityGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
