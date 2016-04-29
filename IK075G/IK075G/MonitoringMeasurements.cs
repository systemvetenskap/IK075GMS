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

            //Backgroundworker
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

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

            lblFrom.Visible = false;
            lblTo.Visible = false;

            resultLabel.Visible = false;
            progressBar1.Visible = false;

            //Datum
            lblTodaysDateAndTime.Text = DateTime.Now.ToString("ddddd, M MMMM, yyyy");
  
        }
        private void btnBack_Click_1(object sender, EventArgs e) //Till huvudmenyn
        {
            this.Hide();
            MainMenu huvudmeny = new MainMenu();
            huvudmeny.ShowDialog();
        }
        private void btnShowUpdateDiagram_Click(object sender, EventArgs e) //Updatera/visa diagram
        {
            if (comboBoxTimeInterval.Text=="VECKOVIS")
            {
                if (comboBoxYearFrom.Text.Equals("") || comboBoxYearTo.Text.Equals("") || comboBoxWeekFrom.Text.Equals("") || comboBoxWeekTo.Text.Equals(""))
                {
                    resultLabel.Visible = true;
                    resultLabel.ForeColor = Color.Tomato;
                    resultLabel.Text = "Vänligen välj år samt vecka";
                    return;
                }

            }
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            resultLabel.Visible = true;
            resultLabel.ForeColor = Color.Tomato;
            resultLabel.Text = "Laddar diagrammet";
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            string customergroup = comboBoxCustomerGroup.Text;
            string analysis = comboBoxAnalysis.Text;
            string prioritygroup = comboBoxPriorityGroup.Text;
            string timeinterval = comboBoxTimeInterval.Text;

            if (timeinterval == "DAGVIS")
            {
                string dayfrom = dateTimePickerDayFrom.Value.ToShortDateString();
                string dayto = dateTimePickerDayTo.Value.ToShortDateString();

                newListMember = getDayValues(customergroup, analysis, prioritygroup, timeinterval, dayfrom, dayto);
            }
            else if (timeinterval == "VECKOVIS")
            {
                string weekfrom = comboBoxYearFrom.Text+comboBoxWeekFrom.Text.PadLeft(2, '0');
                string weekto = comboBoxYearTo.Text+comboBoxWeekTo.Text.PadLeft(2, '0');

                newListMember = getWeekValues(customergroup, analysis, prioritygroup, timeinterval, weekfrom, weekto);
            }
            else if (timeinterval == "MÅNADSVIS")
            {
                string monthfrom = dateTimePickerMonthFrom.Value.ToShortDateString();
                string monthto = dateTimePickerMonthTo.Value.ToShortDateString();

                newListMember = getMonthValues(customergroup, analysis, prioritygroup, timeinterval, monthfrom, monthto);
            }

            chart1.Titles.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("");

            // Titel ovanför diagramet  
            chart1.Titles.Add("Enhet");

            //Kurva för medelvärde
            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.Series["Series1"].LegendText = "Medel värde";
            chart1.Series["Series1"].XValueType = ChartValueType.DateTime;
            chart1.Series["Series1"].YValueType = ChartValueType.Double;

            //Kurva för minsta värde
            chart1.Series.Add("Series2");
            chart1.Series["Series2"].ChartType = SeriesChartType.Line;
            chart1.Series["Series2"].LegendText = "Minsta värde";
            chart1.Series["Series2"].XValueType = ChartValueType.DateTime;
            chart1.Series["Series2"].YValueType = ChartValueType.Double;

            //Kurva för högsta värde
            chart1.Series.Add("Series3");
            chart1.Series["Series3"].ChartType = SeriesChartType.Line;
            chart1.Series["Series3"].LegendText = "Högsta värde";
            chart1.Series["Series3"].XValueType = ChartValueType.DateTime;
            chart1.Series["Series3"].YValueType = ChartValueType.Double;

            foreach (MeasurementMonitoring item in newListMember)
            {
                //Ritar ut diagrammet punkt för punkt
                DataPoint newAveragePoint = new DataPoint();
                if (timeinterval== "DAGVIS")
                {
                    newAveragePoint.AxisLabel = item.day;
                }
                else if (timeinterval=="VECKOVIS")
                {
                    newAveragePoint.AxisLabel = item.week;
                }
                else if (timeinterval=="MÅNADSVIS")
                {
                    newAveragePoint.AxisLabel = item.month;
                }

                //newAveragePoint.SetValueY(Convert.ToDouble(item.medelrawr));
                newAveragePoint.SetValueY(Convert.ToDouble(item.medelrawr));
                chart1.Series["Series1"].Points.Add(newAveragePoint);

                DataPoint newMinPoint = new DataPoint();
                newMinPoint.SetValueY(Convert.ToDouble(item.minrawr));
                chart1.Series["Series2"].Points.Add(newMinPoint);

                DataPoint newMaxPoint = new DataPoint();
                newMaxPoint.SetValueY(Convert.ToDouble(item.maxrawr));
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
            comboBoxPriorityGroup.Items.Add("ALLA");
        }
        public void LoadTimeInterval() //Metod för att FYLLA comboboxen med tidsintervall
        {
            comboBoxTimeInterval.Items.Add("DAGVIS");
            comboBoxTimeInterval.Items.Add("VECKOVIS");
            comboBoxTimeInterval.Items.Add("MÅNADSVIS");
        }       
        public void LoadWeekNumbers() //Metod för att FYLLA comboboxarna med veckonummer
        {
            comboBoxWeekFrom.Items.Clear();
            comboBoxWeekTo.Items.Clear();
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
            //Dagvis
            dateTimePickerDayFrom.Visible = false;
            dateTimePickerDayTo.Visible = false;
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
        public List<MeasurementMonitoring> getWeekValues(string customergroup, string analysis, string prioritygroup, string timeinterval, string weekfrom, string weekto) //Metod för att visa veckovis
        {          
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            conn.Open();

            weekfrom = weekfrom.PadLeft(2, '0');
            weekto = weekto.PadLeft(2, '0');
            
            string sql = string.Empty;
            sql = sql + "SELECT '' cuco, ";
            sql = sql + "    prio AS prio,";
            sql = sql + "    anco AS anco,";
            sql = sql + "    to_char(tetm_date,'YYYYWW') AS myweek,";
            sql = sql + "    count(anco) AS quantity,";
            sql = sql + "   min(rawr) minrawr, ";
            sql = sql + "   max(rawr) maxrawr, ";
            sql = sql + "   avg(rawr) medelrawr ";
            sql = sql + " FROM xxx_time_monitoring_vw";
            sql = sql + " WHERE 1 = 1";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newFirstanco";
            sql = sql + " AND to_char(tetm_date,'YYWW') BETWEEN :newweekFrom AND :newweekTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYYWW')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYYWW')";
            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newFirstanco", NpgsqlDbType.Varchar));
            cmd.Parameters["newFirstanco"].Value = analysis;

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
                newMonitorByWeek.week = dr1["myweek"].ToString();
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
        public List<MeasurementMonitoring> getDayValues(string customergroup, string analysis, string prioritygroup, string timeinterval, string dayfrom, string dayto) //Metod för att visa dagvis
        {
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            conn.Open();

            dayfrom = dayfrom.PadLeft(2, '0');
            dayto = dayto.PadLeft(2, '0');

            if (comboBoxPriorityGroup.Text=="ALLA")
            {
                MessageBox.Show("Kod för alla prioritetsgrupper, dagvis");
            }

            string sql = string.Empty;
            sql = sql + "SELECT '' cuco, ";
            sql = sql + "    prio AS prio,";
            sql = sql + "    anco AS anco,";
            sql = sql + "    to_char(tetm_date,'YYYYMMDD') AS myday,";
            sql = sql + "    count(anco) AS quantity,";
            sql = sql + "   min(rawr) minrawr, ";
            sql = sql + "   max(rawr) maxrawr, ";
            sql = sql + "   avg(rawr) medelrawr ";
            sql = sql + " FROM xxx_time_monitoring_vw";
            sql = sql + " WHERE 1 = 1";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newFirstanco";
            sql = sql + " AND to_char(tetm_date,'YYYY-MM-DD') BETWEEN :newdayFrom AND :newdayTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYYMMDD')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYYMMDD')";
            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newFirstanco", NpgsqlDbType.Varchar));
            cmd.Parameters["newFirstanco"].Value = analysis;

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
        public List<MeasurementMonitoring> getMonthValues(string customergroup, string analysis, string prioritygroup, string timeinterval, string monthfrom, string monthto) //Metod för att visa månadsvis
        {
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            conn.Open();

            monthfrom = monthfrom.PadLeft(2, '0');
            monthto = monthto.PadLeft(2, '0');

            string sql = string.Empty;

            sql = sql + "SELECT '' cuco, ";
            sql = sql + "    prio AS prio,";
            sql = sql + "    anco AS anco,";
            sql = sql + "    to_char(tetm_date,'YYYYMM') AS mymonth,";
            sql = sql + "    count(anco) AS quantity,";
            sql = sql + "   min(rawr) minrawr, ";
            sql = sql + "   max(rawr) maxrawr, ";
            sql = sql + "   avg(rawr) medelrawr ";
            sql = sql + " FROM xxx_time_monitoring_vw";
            sql = sql + " WHERE 1 = 1";
            sql = sql + " AND prio = :newPrio";
            sql = sql + " AND anco = :newFirstanco";
            sql = sql + " AND to_char(tetm_date,'YYYY-MM') BETWEEN :newmonthFrom AND :newmonthTo";
            sql = sql + " GROUP BY prio, anco, to_char(tetm_date,'YYYYMM')";
            sql = sql + " ORDER BY prio, anco, to_char(tetm_date,'YYYYMM')";
            NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

            cmd.Parameters.Add(new NpgsqlParameter("newFirstanco", NpgsqlDbType.Varchar));
            cmd.Parameters["newFirstanco"].Value = analysis;

            monthfrom = monthfrom.Substring(0, 7);
            cmd.Parameters.Add(new NpgsqlParameter("newmonthFrom", NpgsqlDbType.Varchar));
            cmd.Parameters["newmonthFrom"].Value = monthfrom;

            monthto = monthto.Substring(0, 7);
            cmd.Parameters.Add(new NpgsqlParameter("newmonthTo", NpgsqlDbType.Varchar));
            cmd.Parameters["newmonthTo"].Value = monthto;

            cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
            cmd.Parameters["newPrio"].Value = prioritygroup;

            cmd.Parameters.Add(new NpgsqlParameter("newcustomerGroup", NpgsqlDbType.Varchar));
            cmd.Parameters["newcustomerGroup"].Value = customergroup;

            NpgsqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                MeasurementMonitoring newMonitorByMonth = new MeasurementMonitoring();
                newMonitorByMonth.month = dr1["mymonth"].ToString();
                newMonitorByMonth.prio = dr1["prio"].ToString();
                newMonitorByMonth.analysis = dr1["anco"].ToString();
                newMonitorByMonth.minrawr = dr1["minrawr"].ToString();
                newMonitorByMonth.maxrawr = dr1["maxrawr"].ToString();
                newMonitorByMonth.medelrawr = dr1["medelrawr"].ToString();

                newListMember.Add(newMonitorByMonth);
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

                if (comboBoxTimeInterval.Text == "DAGVIS")
                {
                    comboBoxYearFrom.Visible = false;
                    comboBoxWeekFrom.Visible = false;
                    comboBoxYearTo.Visible = false;
                    comboBoxWeekTo.Visible = false;
                    dateTimePickerMonthFrom.Visible = false;
                    dateTimePickerMonthTo.Visible = false;
                    dateTimePickerDayFrom.Visible = true;
                    dateTimePickerDayTo.Visible = true;

                    lblFrom.Visible = true;
                    lblFrom.Text = "Från:";
                    lblTo.Visible = true;
                    lblTo.Text = "Till";
                    lblFromWeek.Visible = false;
                    lblToWeek.Visible = false;

                btnShowUpdateDiagram.Enabled = true;
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

                    lblFrom.Visible = true;
                    lblFrom.Text = "Från år:";
                    lblTo.Visible = true;
                    lblTo.Text = "Till år:";

                    lblFromWeek.Visible = true;
                    lblFromWeek.Text = "Vecka:";
                    lblToWeek.Visible = true;
                    lblToWeek.Text = "Vecka:";


                    btnShowUpdateDiagram.Enabled = true;
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

                    lblFrom.Visible = true;
                    lblFrom.Text = "Från:";
                    lblTo.Visible = true;
                    lblTo.Text = "Till";
                    lblFromWeek.Visible = false;
                    lblToWeek.Visible = false;

                btnShowUpdateDiagram.Enabled = true;
                }
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
            }
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

        //Backgroundworker
        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i * 10);
                }
            }
        }
        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            resultLabel.ForeColor = Color.Green;
            resultLabel.Text = "Klart";
        }
    }
}
