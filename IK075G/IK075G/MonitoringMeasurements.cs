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
using System.Configuration;

namespace IK075G
{
    public partial class MonitoringMeasurements : Form
    {
        // deklarerar konstanter  
        const string allGroups = "ALLA";
        const string allPriority = "ALLA";
        string timeInterval = string.Empty;

        // deklarer period, används i titel 
        string period_from = "";
        string period_to = "";

        const string hourly = "Timvis";
        const string daily = "Dagvis";
        const string weekly = "Veckovis";
        const string monthly = "Månadsvis";
        const string byyear = "Årsvis";

        // deklarer serier 
        const string min_serie = "minimum_serie", min_desc = "Minsta värden";
        const string max_serie = "maximum_serie", max_desc = "Högsta värden";
        const string avg_serie = "average_serie", avg_desc = "Medelvärde   ";
        // const string med_serie = "median_serie", med_desc = "Medianvärde  ";

        const string remove_serie = "Ta bort";
        const string add_serie = "Lägg till";

        const string as_chart = "Diagram";
        const string as_both = "Diagram och tabell";

        // deklarer listor
        List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
        List<ChartSeries> newSerieList = new List<ChartSeries>();

        //Upprättar koppling mot databas
        NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IK075G"].ConnectionString);
        NpgsqlCommand cmd;

        public MonitoringMeasurements()
        {
            InitializeComponent();
        }
        private void MonitoringMeasurements_Load(object sender, EventArgs e) //Formuläret laddas
        {
            // Hantering av samtliga
            comboBoxCustomerGroup.Items.Add(allGroups);
            comboBoxPriorityGroup.Items.Add(allPriority);
            DisableDatePick();
            LoadTimeInterval();
            LoadCustomerGroups();
            LoadAnalysis();
            LoadPriorityGroup();

            // Hantering av samtliga
            comboBoxCustomerGroup.SelectedItem = allGroups;
            comboBoxPriorityGroup.SelectedItem = allGroups;
            
            // Hanterar tillgänglighet för de olika boxar  
            comboBoxAnalysis.Enabled = true;
            comboBoxPriorityGroup.Enabled = false;
            comboBoxTimeInterval.Enabled = false;
            btnShowUpdateDiagram.Enabled = false;

            lblFrom.Visible = false;
            lblTo.Visible = false;
            lblFromWeek.Visible = false;
            lblToWeek.Visible = false;

            resultLabel.Visible = false;

            SetCustomMinMaxDate();

            //Datum
            lblTodaysDateAndTime.Text = DateTime.Now.ToString("ddddd, M MMMM, yyyy");

            // Ordnar position för kallender och komboboxar
            //Från
            int y = 0;
            int x = 0;

            y = dateTimePickerDayFrom.Location.Y;
            x = dateTimePickerDayFrom.Location.X;

            dateTimePickerDayFrom.Location = new Point(x, y);
            comboBoxYearFrom.Location = new Point(x, y);
            dateTimePickerMonthFrom.Location = new Point(x, y);

            x = comboBoxWeekFrom.Location.X;
            comboBoxWeekFrom.Location = new Point(x, y);

            //Till
            y = dateTimePickerDayTo.Location.Y;
            x = dateTimePickerDayTo.Location.X;

            dateTimePickerDayTo.Location = new Point(x, y);
            comboBoxYearTo.Location = new Point(x, y);
            dateTimePickerMonthTo.Location = new Point(x, y);

            x = comboBoxWeekTo.Location.X;
            comboBoxWeekTo.Location = new Point(x, y);

            // Laddar olika serie alternativ  
            ChartSeries newSerie1 = new ChartSeries();
            newSerie1.serieName = avg_serie;
            newSerie1.serieDesc = avg_desc;
            newSerie1.serieSelected = true;
            newSerieList.Add(newSerie1);

            ChartSeries newSerie2 = new ChartSeries();
            newSerie2.serieName = min_serie;
            newSerie2.serieDesc = min_desc;
            newSerie2.serieSelected = false;
            newSerieList.Add(newSerie2);

            ChartSeries newSerie3 = new ChartSeries();
            newSerie3.serieName = max_serie;
            newSerie3.serieDesc = max_desc;
            newSerie3.serieSelected = false;
            newSerieList.Add(newSerie3);

            //ChartSeries newSerie4 = new ChartSeries();
            //newSerie4.serieName = med_serie;
            //newSerie4.serieDesc = med_desc;
            //newSerie4.serieSelected = false;
            //newSerieList.Add(newSerie4);

            LoadSerieType();
            comboBoxSeries.SelectedItem = avg_desc;

            // Laddar komboboxen visa med alternativ och väljer digram som default alternativ  
            LoadShow();
            // Digram storlek anpassas i comboBoxShow_SelectedIndexChanged
            comboBoxShow.SelectedItem = as_chart;

            dataGridTimeMonitoring.Visible = false;
            comboBoxShow.Visible = false;
            lblShowAs.Visible = false;

            // Lägger till menyn
            AddMenu();
        }
        private void btnBack_Click_1(object sender, EventArgs e) //Till huvudmenyn
        {
            this.Hide();
            MainMenu huvudmeny = new MainMenu();
            huvudmeny.ShowDialog();
        }
        private void btnShowUpdateDiagram_Click(object sender, EventArgs e) //Updatera/visa diagram
        {
            // Orginal kod start
            try
            {
                resultLabel.Visible = false;
                if (comboBoxTimeInterval.Text == "VECKOVIS")
                {
                    if (comboBoxYearFrom.Text.Equals("") || comboBoxYearTo.Text.Equals("") || comboBoxWeekFrom.Text.Equals("") || comboBoxWeekTo.Text.Equals(""))
                    {
                        resultLabel.Visible = true;
                        resultLabel.ForeColor = Color.Tomato;
                        resultLabel.Text = "Vänligen välj år samt vecka";
                        return;
                    }

                }                
                
                string timeinterval = comboBoxTimeInterval.Text;
                string customergroup = comboBoxCustomerGroup.Text.ToString().ToUpper();
                if (customergroup == allGroups)
                {
                    customergroup = "%";
                }
                string analysis = comboBoxAnalysis.Text.ToString().ToUpper();

                string prioritygroup = comboBoxPriorityGroup.Text.ToString().ToUpper();
                if (prioritygroup == allPriority)
                {
                    prioritygroup = "%";
                }

                newListMember.Clear(); 
                if (timeinterval == "DAGVIS")
                {
                    string dayfrom = dateTimePickerDayFrom.Value.ToShortDateString();
                    string dayto = dateTimePickerDayTo.Value.ToShortDateString();
                    
                    Cursor = Cursors.WaitCursor;
                    newListMember = getDayValues(customergroup, analysis, prioritygroup, timeinterval, dayfrom, dayto);
                }
                else if (timeinterval == "VECKOVIS")
                {
                    string weekfrom = comboBoxYearFrom.Text + comboBoxWeekFrom.Text.PadLeft(2, '0');
                    string weekto = comboBoxYearTo.Text + comboBoxWeekTo.Text.PadLeft(2, '0');
                    
                    Cursor = Cursors.WaitCursor;
                    newListMember = getWeekValues(customergroup, analysis, prioritygroup, timeinterval, weekfrom, weekto);
                }
                else if (timeinterval == "MÅNADSVIS")
                {
                    string monthfrom = dateTimePickerMonthFrom.Value.ToShortDateString();
                    string monthto = dateTimePickerMonthTo.Value.ToShortDateString();
                    
                    Cursor = Cursors.WaitCursor;
                    newListMember = getMonthValues(customergroup, analysis, prioritygroup, timeinterval, monthfrom, monthto);
                }

                // Hanterar diagram
                ClearChart();
                AddChartTitle(timeInterval.ToLower(), analysis, customergroup);
                AddChartArea();

                foreach (ChartSeries item in newSerieList)
                {
                    if (item.serieSelected == true)
                    {
                        AddSerie(item.serieName, item.serieDesc, newListMember);
                    }
                }

                // Lägg till data till griden (enbart vid hämtning av data)
                AddGridValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            // Orginal kod stop
        }

        //Egna metoder
        public void LoadCustomerGroups() //Metod för att LADDA kundgrupper i comboboxen
        {
            string sql = "SELECT cuco AS cuco FROM cuco_sub2 WHERE LENGTH(REPLACE(cuco, ' ','')) > 0 ORDER BY cuco";
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
            string sql = "SELECT anco FROM anco_tab ORDER BY anco";
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
            comboBoxTimeInterval.Items.Add("DAGVIS");
            comboBoxTimeInterval.Items.Add("VECKOVIS");
            comboBoxTimeInterval.Items.Add("MÅNADSVIS");
        }       
        public void LoadWeekNumbers() //Metod för att FYLLA comboboxarna med veckonummer
        {
            comboBoxWeekFrom.Items.Clear();
            comboBoxWeekTo.Items.Clear();
            for (int i = 1; i <= 53; i++)
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

            // Från år - Till år
            string sql1 = "SELECT DISTINCT substr(tetm,1,2) tetm FROM a_ana_tab WHERE LENGTH(REPLACE(tetm, ' ','')) > 0 ORDER BY tetm";
            conn.Open();
            cmd = new NpgsqlCommand(sql1, conn);
            NpgsqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                string yearOrderedbyLowest = dr1["tetm"].ToString();
                comboBoxYearFrom.Items.Add(yearOrderedbyLowest);
                comboBoxYearTo.Items.Add(yearOrderedbyLowest);
            }
            conn.Close();
        }
        public void LoadShow() //Metod för att fylla comboboxen med alternativ
        {
            comboBoxShow.Items.Add(as_chart);
            comboBoxShow.Items.Add(as_both);
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
        public void SetCustomMinMaxDate() // Används för att sätta start och stop år i kalender beroende på minsta 
        {
            DateTime newMinDateTime = new DateTime();
            // Från år
            try
            {
                string sql = "SELECT MIN(to_date(tetm,'YYDDMMHH24MI')) AS tetm FROM a_ana_tab WHERE LENGTH(REPLACE(tetm, ' ','')) > 0";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    newMinDateTime = Convert.ToDateTime(dr["tetm"]);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            dateTimePickerDayFrom.MinDate = newMinDateTime;

            // Till år
            DateTime newMaxDateTime = new DateTime();
            newMaxDateTime = DateTime.Now;

            // Sätter värdena i kallender            
            dateTimePickerDayFrom.MinDate = newMinDateTime;
            dateTimePickerDayFrom.MaxDate = newMaxDateTime;
            dateTimePickerDayFrom.Value = newMinDateTime;

            dateTimePickerDayTo.MinDate = newMinDateTime;
            dateTimePickerDayTo.MaxDate = newMaxDateTime;
            dateTimePickerDayTo.Value = newMaxDateTime;

            // används för att sätta värdena i komboboxar  
            SetYearAndWeek();
        }
        public void SetYearAndWeek() // Används för att sätta start och stop år respektive start och stop vecka beroende på värdena i kalender
        {
            DateTime dateFrom = dateTimePickerDayFrom.Value;
            DateTime dateTo = dateTimePickerDayTo.Value;

            string yearFrom = dateFrom.Year.ToString().Substring(2, 2);
            comboBoxYearFrom.SelectedItem = yearFrom;

            var cal1 = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            string weekFrom = cal1.GetWeekOfYear(dateFrom, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();
            comboBoxWeekFrom.SelectedItem = weekFrom;

            string yearTo = dateTo.Year.ToString().Substring(2, 2);
            comboBoxYearTo.SelectedItem = yearTo;

            var cal2 = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            string weekTo = cal2.GetWeekOfYear(dateTo, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();
            comboBoxWeekTo.SelectedItem = weekTo;

            dateTimePickerMonthFrom.Value = dateFrom;
            dateTimePickerMonthTo.Value = dateTo;
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
            try
            {
                conn.Open();

                weekfrom = weekfrom.PadLeft(2, '0');
                weekto = weekto.PadLeft(2, '0');

                string sql = string.Empty;
                sql = sql + "SELECT ";
                sql = sql + "   to_char(tetm_date,'YYYYWW') AS myweek,";
                sql = sql + "   count(rawr) AS quantity,";
                sql = sql + "   round(min(rawr),3) AS minrawr, ";
                sql = sql + "   round(max(rawr),3) AS maxrawr, ";
                sql = sql + "   round(avg(rawr),3) AS medelrawr ";
                sql = sql + " FROM xxx_monitoring_measure_vw";
                sql = sql + " WHERE cuco LIKE :newcustomerGroup";
                sql = sql + " AND anco = :newFirstanco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYWW') BETWEEN :newweekFrom AND :newweekTo";
                sql = sql + " GROUP BY to_char(tetm_date,'YYYYWW')";
                sql = sql + " ORDER BY to_char(tetm_date,'YYYYWW')";
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

                period_from = weekfrom;
                period_to = weekto;

                NpgsqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    MeasurementMonitoring newMonitorByWeek = new MeasurementMonitoring();
                    newMonitorByWeek.customer = customergroup;
                    newMonitorByWeek.prio = prioritygroup;
                    newMonitorByWeek.analysis = analysis;
                    newMonitorByWeek.week = dr1["myweek"].ToString();
                    newMonitorByWeek.quantity = dr1["quantity"].ToString();
                    newMonitorByWeek.minrawr = Convert.ToDouble(dr1["minrawr"]).ToString();
                    newMonitorByWeek.maxrawr = Convert.ToDouble(dr1["maxrawr"]).ToString();
                    newMonitorByWeek.medelrawr = Convert.ToDouble(dr1["medelrawr"]).ToString();

                    newListMember.Add(newMonitorByWeek);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            finally
            {
                conn.Close();
            }

            return newListMember;
        }
        public List<MeasurementMonitoring> getDayValues(string customergroup, string analysis, string prioritygroup, string timeinterval, string dayfrom, string dayto) //Metod för att visa dagvis
        {
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            try
            {
                conn.Open();

                dayfrom = dayfrom.PadLeft(2, '0');
                dayto = dayto.PadLeft(2, '0');

                string sql = string.Empty;
                sql = sql + "SELECT ";
                sql = sql + "   to_char(tetm_date,'YYYYMMDD') AS myday,";
                sql = sql + "   count(rawr) AS quantity,";
                sql = sql + "   round(min(rawr),3) AS minrawr, ";
                sql = sql + "   round(max(rawr),3) AS maxrawr, ";
                sql = sql + "   round(avg(rawr),3) AS medelrawr ";
                sql = sql + " FROM xxx_monitoring_measure_vw";
                sql = sql + " WHERE cuco LIKE :newcustomerGroup";
                sql = sql + " AND anco = :newFirstanco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYYY-MM-DD') BETWEEN :newdayFrom AND :newdayTo";
                sql = sql + " GROUP BY to_char(tetm_date,'YYYYMMDD')";
                sql = sql + " ORDER BY to_char(tetm_date,'YYYYMMDD')";
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

                period_from = dayfrom;
                period_to = dayto;

                NpgsqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    MeasurementMonitoring newMonitorByDay = new MeasurementMonitoring();
                    newMonitorByDay.customer = customergroup;
                    newMonitorByDay.prio = prioritygroup;
                    newMonitorByDay.analysis = analysis;
                    newMonitorByDay.day = dr1["myday"].ToString();
                    newMonitorByDay.quantity = dr1["quantity"].ToString();
                    newMonitorByDay.minrawr = Convert.ToDouble(dr1["minrawr"]).ToString();
                    newMonitorByDay.maxrawr = Convert.ToDouble(dr1["maxrawr"]).ToString();
                    newMonitorByDay.medelrawr = Convert.ToDouble(dr1["medelrawr"]).ToString();

                    newListMember.Add(newMonitorByDay);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            finally
            {
                conn.Close();
            }

            return newListMember;
        }
        public List<MeasurementMonitoring> getMonthValues(string customergroup, string analysis, string prioritygroup, string timeinterval, string monthfrom, string monthto) //Metod för att visa månadsvis
        {
            List<MeasurementMonitoring> newListMember = new List<MeasurementMonitoring>();
            try
            {
                conn.Open();

                monthfrom = monthfrom.PadLeft(2, '0');
                monthto = monthto.PadLeft(2, '0');

                string sql = string.Empty;

                sql = sql + "SELECT ";
                sql = sql + "   to_char(tetm_date,'YYYYMM') AS mymonth,";
                sql = sql + "   count(rawr) AS quantity,";
                sql = sql + "   round(min(rawr),3) AS minrawr, ";
                sql = sql + "   round(max(rawr),3) AS maxrawr, ";
                sql = sql + "   round(avg(rawr),3) AS medelrawr ";
                sql = sql + " FROM xxx_monitoring_measure_vw";
                sql = sql + " WHERE cuco LIKE :newcustomerGroup";
                sql = sql + " AND anco = :newFirstanco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYYY-MM') BETWEEN :newmonthFrom AND :newmonthTo";
                sql = sql + " GROUP BY to_char(tetm_date,'YYYYMM')";
                sql = sql + " ORDER BY to_char(tetm_date,'YYYYMM')";
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

                period_from = monthfrom;
                period_to = monthto;

                NpgsqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    MeasurementMonitoring newMonitorByMonth = new MeasurementMonitoring();
                    newMonitorByMonth.customer = customergroup;
                    newMonitorByMonth.prio = prioritygroup;
                    newMonitorByMonth.analysis = analysis;
                    newMonitorByMonth.month = dr1["mymonth"].ToString();
                    newMonitorByMonth.quantity = dr1["quantity"].ToString();
                    newMonitorByMonth.minrawr = Convert.ToDouble(dr1["minrawr"]).ToString();
                    newMonitorByMonth.maxrawr = Convert.ToDouble(dr1["maxrawr"]).ToString();
                    newMonitorByMonth.medelrawr = Convert.ToDouble(dr1["medelrawr"]).ToString();

                    newListMember.Add(newMonitorByMonth);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            finally
            {
                conn.Close();
            }
            return newListMember;
        }

        private void AddMenu() // Metod för all lägga till mennyn till form
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Export data till Excel", null,
                new System.EventHandler(ShortcutMenuClick));

            ContextMenuStrip exportMenu = new ContextMenuStrip();
            exportMenu.Items.Add(menuItem);

            this.ContextMenuStrip = exportMenu;
            this.MouseDown += new MouseEventHandler(MonitoringMeasurements_MouseDown);
            this.ContextMenuStrip.Enabled = false;
        }
        public void ExportGridData(object sender, EventArgs e) // Metod för exportera data till excel
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.ActiveSheet;

            worksheet.Cells.NumberFormat = "@";

            for (int i = 1; i < dataGridTimeMonitoring.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridTimeMonitoring.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i <= dataGridTimeMonitoring.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridTimeMonitoring.Columns.Count; j++)
                {
                    DataGridViewCell cell = dataGridTimeMonitoring[j, i];
                    if (cell.Value.ToString() != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = cell.Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }
        public void LoadSerieType() //Metod för att ladda series i komboboxen
        {
            comboBoxSeries.DataSource = null;
            comboBoxSeries.DataSource = newSerieList;
        }
        public void ClearChart()
        {
            chart1.Titles.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.ChartAreas.Clear();
        }
        public void AddChart()
        {
            // Suad start, Chart properties
        }
        public void AddChartArea()
        {
            chart1.ChartAreas.Add("");
        }        

        public void AddChartTitle(string timeInterval, string analys, string customer)
        {
            //Titeln för charten beroende på sorteringen som valts
            string titel = "Visar uppföljning av mätvärden " + timeInterval + " för analys:  " + analys + ", från kund: " + customer;
            chart1.Titles.Add(titel);
            chart1.Titles[0].Alignment = ContentAlignment.TopLeft;
            chart1.Legends.Add("Legend");
        }
        private void AddSerie(string serie_name, string serie_desc, List<MeasurementMonitoring> newListMember) // Metod för all lägga till en ny serie till diagrammet
        {
            chart1.Series.Add(serie_name);

            chart1.ChartAreas[0].BorderColor = Color.Black;
            chart1.ChartAreas[0].BorderWidth = 2;

            chart1.Series[serie_name].ChartType = SeriesChartType.Line;
            chart1.Series[serie_name].LegendText = serie_desc;
            chart1.Series[serie_name].XValueType = ChartValueType.DateTime;
            chart1.Series[serie_name].YValueType = ChartValueType.Double;

            // Axis X
            chart1.ChartAreas[0].AxisX.Title = "Tidsperiod " + timeInterval.ToLower() + " från och med " + period_from + " till och med " + period_to;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart1.ChartAreas[0].AxisX.Interval = 20;

            // Axis Y
            chart1.ChartAreas[0].AxisY.Title = "Mätvärden ";

            int i = 0;
            string serie = string.Empty;
            string info = string.Empty;

            foreach (MeasurementMonitoring item in newListMember)
            {
                // ritar serie
                DataPoint newPoint = new DataPoint();
                if (timeInterval == daily.ToUpper())
                {
                    newPoint.AxisLabel = item.day;
                }
                else if (timeInterval == weekly.ToUpper())
                {
                    newPoint.AxisLabel = item.week;
                }
                else if (timeInterval == monthly.ToUpper())
                {
                    newPoint.AxisLabel = item.month;
                }               
                
                double current_value = 0.00;
                if (serie_name == avg_serie)
                {
                    current_value = Convert.ToDouble(item.medelrawr);
                }
                else if (serie_name == min_serie)
                {
                    current_value = Convert.ToDouble(item.minrawr);
                }
                else if (serie_name == max_serie)
                {
                    current_value = Convert.ToDouble(item.maxrawr);
                }
                //else if (serie_name == med_serie)
                //{
                    // Föreberder för median serien
                    // current_value = Convert.ToDouble(item.medValue);
                    // current_time = item.maxTime;
                //}

                newPoint.SetValueY(current_value);
                chart1.Series[serie_name].Points.Add(newPoint);

                // ToolTip punkt beskrivning
                serie = chart1.Series[serie_name].LegendText;
                info = info + "Serie : " + serie + "\n";
                info = info + "Värde : " + current_value + "\n";
                info = info + "Antal analyser : " + item.quantity + "\n";
                info = info + "Datum : " + newPoint.AxisLabel.ToString() + "\n";
                chart1.Series[serie_name].Points[i].ToolTip = info;
                info = string.Empty;

                // Används för att räkna points
                i = i + 1;
            }
            
            chart1.Show();
            resultLabel.Visible = true;
            resultLabel.ForeColor = Color.Green;
            resultLabel.Text = "Klart";
            Cursor = Cursors.Default;

            lblShowAs.Visible = true;
            comboBoxShow.Visible = true;
            // Diagrammet stop
        }
        public void AddGridValue() // Metod för att hantera griden 
        {
            dataGridTimeMonitoring.DataSource = string.Empty;
            if (newListMember.Count >= 0)
            {
                dataGridTimeMonitoring.DataSource = newListMember;
                // Ordnar kolumn namnen
                foreach (DataGridViewColumn column in dataGridTimeMonitoring.Columns)
                {
                    if (column.Name.ToString() == "customer")
                    {
                        dataGridTimeMonitoring.Columns["customer"].HeaderText = "Kund";
                    }
                    else if (column.Name.ToString() == "week")
                    {
                        dataGridTimeMonitoring.Columns["week"].HeaderText = "Vecka";
                    }
                    else if (column.Name.ToString() == "month")
                    {
                        dataGridTimeMonitoring.Columns["month"].HeaderText = "Månad";
                    }
                    else if (column.Name.ToString() == "day")
                    {
                        dataGridTimeMonitoring.Columns["day"].HeaderText = "Dag";
                    }
                    else if (column.Name.ToString() == "prio")
                    {
                        dataGridTimeMonitoring.Columns["prio"].HeaderText = "Prioritet";
                    }
                    else if (column.Name.ToString() == "analysis")
                    {
                        dataGridTimeMonitoring.Columns["analysis"].HeaderText = "Analys";
                    }
                    else if (column.Name.ToString() == "minrawr")
                    {
                        dataGridTimeMonitoring.Columns["minrawr"].HeaderText = "Minsta värde";
                    }
                    else if (column.Name.ToString() == "maxrawr")
                    {
                        dataGridTimeMonitoring.Columns["maxrawr"].HeaderText = "Högsta värde";
                    }
                    else if (column.Name.ToString() == "medelrawr")
                    {
                        dataGridTimeMonitoring.Columns["medelrawr"].HeaderText = "Medelvärde";
                    }
                    else if (column.Name.ToString() == "quantity")
                    {
                        dataGridTimeMonitoring.Columns["quantity"].HeaderText = "Antal";
                    }
                }
                // Tar bort överflödiga kolumner för respektive tidsinterval 
                if (timeInterval.ToUpper() == daily.ToUpper())
                {
                    dataGridTimeMonitoring.Columns.Remove("year");
                    dataGridTimeMonitoring.Columns.Remove("month");
                    dataGridTimeMonitoring.Columns.Remove("week");
                }
                else if (timeInterval.ToUpper() == weekly.ToUpper())
                {
                    dataGridTimeMonitoring.Columns.Remove("year");
                    dataGridTimeMonitoring.Columns.Remove("month");
                    dataGridTimeMonitoring.Columns.Remove("day");
                }
                else if (timeInterval.ToUpper() == monthly.ToUpper())
                {
                    dataGridTimeMonitoring.Columns.Remove("year");
                    dataGridTimeMonitoring.Columns.Remove("week");
                    dataGridTimeMonitoring.Columns.Remove("day");
                }
                comboBoxShow.Visible = true;
                lblShowAs.Visible = true;
            }
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
            ActivateTimeInterval();
            resultLabel.Text = "";
            chart1.Titles.Clear();
        }
        private void comboBoxTimeInterval_SelectedIndexChanged(object sender, EventArgs e) //Tidsintervall
        {
            if (comboBoxTimeInterval.SelectedIndex < 0)
            {
                comboBoxYearFrom.Visible = false;
                comboBoxYearTo.Visible = false;
                comboBoxWeekFrom.Visible = false;
                comboBoxWeekTo.Visible = false;                
                dateTimePickerMonthFrom.Visible = false;
                dateTimePickerMonthTo.Visible = false;
                dateTimePickerDayFrom.Visible = false;
                dateTimePickerDayTo.Visible = false;
                lblFromWeek.Visible = false;
                lblToWeek.Visible = false;
                lblFrom.Visible = false;
                lblTo.Visible = false;
                btnShowUpdateDiagram.Enabled = false;
            }
            else
            {
                timeInterval = comboBoxTimeInterval.SelectedItem.ToString().ToUpper();
                // sätter min och max värde i boxar beroende på värdena i kallender     
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
                SetYearAndWeek();            
            }
        }
        private void ActivateTimeInterval() // Används för att hantera tillgänglighet för tidsinterval
        {
            if ((comboBoxCustomerGroup.Text.ToString() == string.Empty)
                || (comboBoxAnalysis.Text.ToString() == string.Empty)
                    || (comboBoxPriorityGroup.Text.ToString() == string.Empty))
            {
                comboBoxTimeInterval.Text = string.Empty;
                comboBoxTimeInterval.SelectedIndex = -1;
                comboBoxTimeInterval.Enabled = false;
            }
            else
            {
                comboBoxTimeInterval.Enabled = true;
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
            ActivateTimeInterval();
            resultLabel.Text = "";
            chart1.Titles.Clear();
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
            ActivateTimeInterval();
            resultLabel.Text = "";
            chart1.Titles.Clear();
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
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void comboBoxShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShow.SelectedItem.ToString() == as_both)
            {
                chart1.Height = 350;
                int y = 0;
                int x = 0;
                x = dataGridTimeMonitoring.Location.X;
                y = dataGridTimeMonitoring.Location.Y;
                y = 520;
                dataGridTimeMonitoring.Location = new Point(x, y);

                dataGridTimeMonitoring.Height = 130;
                dataGridTimeMonitoring.Visible = true;
            }
            else
            {
                chart1.Height = 480;
                dataGridTimeMonitoring.Height = 130;
                dataGridTimeMonitoring.Visible = false;
            }
        }
        private void ShortcutMenuClick(object sender, System.EventArgs e)
        {
            ExportGridData(sender, e);
        }
        private void MonitoringMeasurements_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridTimeMonitoring.RowCount == 0)
                {
                    this.ContextMenuStrip.Visible = false;
                    this.ContextMenuStrip.Enabled = false;
                }
                else
                {
                    this.ContextMenuStrip.Visible = true;
                    this.ContextMenuStrip.Enabled = true;
                }
            }
        }
        private void comboBoxSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartSeries newChartSerie = new ChartSeries();
            newChartSerie = (ChartSeries)comboBoxSeries.SelectedItem;
            string serieName = newChartSerie.serieName;
            bool serieSelected = newChartSerie.serieSelected;
            if (serieSelected == true)
            {
                buttonSeries.Text = remove_serie;
            }
            else
            {
                buttonSeries.Text = add_serie;
            }
        }
        private void buttonSeries_Click(object sender, EventArgs e)
        {
            // hämtar serie namn för uppdatering 
            ChartSeries newChartSerie = new ChartSeries();
            newChartSerie = (ChartSeries)comboBoxSeries.SelectedItem;
            string serieName = newChartSerie.serieName;

            bool serieSelected;
            if (buttonSeries.Text == remove_serie)
            {
                serieSelected = false;
                buttonSeries.Text = add_serie;
            }
            else
            {
                serieSelected = true;
                buttonSeries.Text = remove_serie;
            }

            // uppdatera aktuell serie 
            for (int i = 0; i < newSerieList.Count; i++)
            {
                if (newSerieList[i].serieName.ToString() == serieName)
                {
                    newSerieList[i].serieSelected = serieSelected;
                }
            }

            // Hämtar parametrar
            string customer = comboBoxCustomerGroup.Text.ToString().ToUpper();
            if (customer == allGroups)
            {
                customer = "%";
            }
            string analys = comboBoxAnalysis.Text.ToString().ToUpper();
            string prio = comboBoxCustomerGroup.Text.ToString().ToUpper();
            if (prio == allPriority)
            {
                prio = "%";
            }

            // Hanterar diagram 
            ClearChart();
            AddChartTitle(timeInterval.ToLower(), analys, customer);
            AddChartArea();

            foreach (ChartSeries item in newSerieList)
            {
                if (item.serieSelected == true)
                {
                    AddSerie(item.serieName, item.serieDesc, newListMember);
                }
            }

            // Klart
            Cursor = Cursors.Default;
            resultLabel.Visible = true;
            resultLabel.ForeColor = Color.Green;
            resultLabel.Text = "Klart";
        }
        private void comboBoxCustomerGroup_KeyUp(object sender, KeyEventArgs e)
        {
            ActivateTimeInterval();
            resultLabel.Text = "";
            chart1.Titles.Clear();
        }
        private void comboBoxPriorityGroup_KeyUp(object sender, KeyEventArgs e)
        {
            ActivateTimeInterval();
            resultLabel.Text = "";
            chart1.Titles.Clear();
        }
        private void comboBoxAnalysis_KeyUp(object sender, KeyEventArgs e)
        {
            ActivateTimeInterval();
            resultLabel.Text = "";
            chart1.Titles.Clear();
        }
    }
}
