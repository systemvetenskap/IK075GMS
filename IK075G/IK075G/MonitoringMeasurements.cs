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
        public void LoadCustomerGroups()
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
        }//Metod för att LADDA kundgrupper i comboboxen
        public void LoadAnalysis()
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
        }//Metod för att LADDA analyser i comboboxen
        public void LoadPriorityGroup()
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
        }//Metod för att LADDA prioritetsgrupper i comboboxen
        public void LoadTimeInterval()
        {
            comboBoxTimeInterval.Items.Add("Dagsvis");
            comboBoxTimeInterval.Items.Add("Veckovis");
            comboBoxTimeInterval.Items.Add("Månadsvis");
        }//Metod för att FYLLA comboboxen med tidsintervall
        public void DisableDatePick()
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
            //Tillbaks till huvudmenyn
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
    }
}
