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
using System.Configuration;

namespace IK075G
{
    public partial class TimeMonitoring : Form
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
        const string med_serie = "median_serie",  med_desc = "Medianvärde  ";

        const string remove_serie = "Ta bort";
        const string add_serie = "Lägg till";

        const string as_chart = "Diagram";
        const string as_both = "Diagram och tabell";

        // deklarer listor
        List<ResponseTimes> newListMember = new List<ResponseTimes>();
        List<ChartSeries> newSerieList = new List<ChartSeries>();
        
        // Upprättar koppling mot databas
        NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IK075G"].ConnectionString);

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
            // Lägger till "ALLA" som alternativ i komboxar 
            comboBoxCustomer.Items.Add(allGroups);
            comboBoxPriority.Items.Add(allPriority);

            LoadCustomers();
            LoadAnalysis();
            LoadPriorityGroup();
            LoadTimeInterval();
            LoadYears();
            LoadWeekNumbers();
            SetCustomMinMaxDate();
            // Default
            comboBoxCustomer.SelectedItem = allGroups;
            comboBoxPriority.SelectedItem = allPriority;

            // Hanterar tillgänglighet för de olika boxar  
            // comboBoxAnalysis.Enabled = true;
            // comboBoxPriority.Enabled = true;
            comboBoxTimeInterval.Enabled = false;

            comboBoxYearFrom.Visible = false;
            comboBoxYearTo.Visible = false;
            comboBoxWeekFrom.Visible = false;
            comboBoxWeekTo.Visible = false;

            dateTimePickerFrom.Visible = false;
            dateTimePickerTo.Visible = false;

            lblFromWeek.Visible = false;
            lblToWeek.Visible = false;
            lblDateFrom.Visible = false;
            lblDateTo.Visible = false;
            
            // Datum
            lblTodaysDateAndTime.Text = DateTime.Now.ToString("ddddd, M MMMM, yyyy");

            // Ordnar position för kallender och komboboxar
            int y = 0;
            int x = 0;

            y = dateTimePickerFrom.Location.Y;
            x = dateTimePickerTo.Location.X;
            comboBoxYearTo.Location = new Point(x, y);

            x = comboBoxYearFrom.Location.X;
            comboBoxYearFrom.Location = new Point(x, y);
            x = comboBoxWeekFrom.Location.X;
            comboBoxWeekFrom.Location = new Point(x, y);

            x = comboBoxYearTo.Location.X;
            comboBoxYearTo.Location = new Point(x, y);
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

            ChartSeries newSerie4 = new ChartSeries();
            newSerie4.serieName = med_serie;
            newSerie4.serieDesc = med_desc;
            newSerie4.serieSelected = false;
            newSerieList.Add(newSerie4);

            LoadSerieType();
            comboBoxSeries.SelectedItem = avg_desc;
            
            // Laddar komboboxen visa med alternativ och väljer digram som default alternativ  
            LoadShow();

            // Digram storlek anpassas i comboBoxShow_SelectedIndexChanged     
            comboBoxShow.SelectedItem = as_chart;

            // Hanterar synlighet
            dataGridResponseTime.Visible = false;
            comboBoxShow.Visible = false;
            lblShowAs.Visible = false;

            // Lägger till HMV för att möjliggöra export till excel
            AddMenu();
        }

        // Egna metoder        
        public void LoadCustomers() //Metod för att ladda kundgrupper i comboboxen 
        {
            try
            {
                string sql = "SELECT cuco AS cuco FROM cuco_sub2 WHERE LENGTH(REPLACE(cuco, ' ','')) > 0 ORDER BY cuco";

                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string cuco = dr["cuco"].ToString();
                    comboBoxCustomer.Items.Add(cuco);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }       
        }
        public void LoadAnalysis() //Metod för att ladda analyser i comboboxen 
        {
            try 
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
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }       
        }
        public void LoadPriorityGroup() //Metod för att ladda prioritetsgrupper i comboboxen
        {
            try 
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
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }       
        }
        public void LoadShow() //Metod för att fylla comboboxen med alternativ
        {
            comboBoxShow.Items.Add(as_chart);
            comboBoxShow.Items.Add(as_both);
        }
        public void LoadTimeInterval() //Metod för att fylla comboboxen med tidsintervall
        {
            // Föreberder för "Timvis"
            // comboBoxTimeInterval.Items.Add(hourly);
            comboBoxTimeInterval.Items.Add(daily);
            comboBoxTimeInterval.Items.Add(weekly);
            comboBoxTimeInterval.Items.Add(monthly);
            comboBoxTimeInterval.Items.Add(byyear);
        }
        public void LoadYears() // Metod för att LADDA in årtal i comboboxar från och till
        {
            // Från år - Till år 
            try
            {
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
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }            
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
            
            // används för att sätta värdena i komboboxar  
            SetYearAndWeek();
        }
        public void SetYearAndWeek() // Används för att sätta start och stop år respektive start och stop vecka beroende på värdena i kalender
        { 
            DateTime dateFrom = dateTimePickerFrom.Value;
            DateTime dateTo = dateTimePickerTo.Value;

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
        }        
        public void SetCustomFormat(string format) // Används för att definera format i kalender 
        {
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = format;
            dateTimePickerFrom.ShowUpDown = true;

            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = format;
            dateTimePickerTo.ShowUpDown = true;
        }
        public List<ResponseTimes> GetResponseByYear(string customer, string analys, string prio, string yearFrom, string yearTo)
        {
            try
            {
                conn.Open();

                string sql = string.Empty;
                sql = sql + "SELECT to_char(tetm_date,'YYYY') AS year,";
                sql = sql + "   count(difference_value) AS quantity,";
                sql = sql + "   min(difference_interval) AS min_time,";
                sql = sql + "   max(difference_interval) AS max_time,";
                sql = sql + "   avg(difference_interval) AS avg_time,";
                sql = sql + "   round(min(difference_value),1) AS min_value,";
                sql = sql + "   round(max(difference_value),1) AS max_value,";
                sql = sql + "   round(avg(difference_value),1) AS avg_value";
                sql = sql + " FROM xxx_time_control_vw";
                sql = sql + " WHERE cuco LIKE :newCuco";
                sql = sql + " AND anco = :newAnco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YY') BETWEEN :newFrom AND :newTo";
                sql = sql + " GROUP BY to_char(tetm_date,'YYYY')";
                sql = sql + " ORDER BY to_char(tetm_date,'YYYY')";

                NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

                cmd.Parameters.Add(new NpgsqlParameter("newCuco", NpgsqlDbType.Varchar));
                cmd.Parameters["newCuco"].Value = customer;
                cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
                cmd.Parameters["newPrio"].Value = prio;
                cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
                cmd.Parameters["newAnco"].Value = analys;

                cmd.Parameters.Add(new NpgsqlParameter("newFrom", NpgsqlDbType.Varchar));
                cmd.Parameters["newFrom"].Value = yearFrom;
                cmd.Parameters.Add(new NpgsqlParameter("newTo", NpgsqlDbType.Varchar));
                cmd.Parameters["newTo"].Value = yearTo;

                period_from = yearFrom;
                period_to = yearTo;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ResponseTimes newResponseTimes = new ResponseTimes();
                    newResponseTimes.customer = customer;
                    newResponseTimes.prio = prio;
                    newResponseTimes.analys = analys;
                    newResponseTimes.year = Convert.ToString(dr["year"]);
                    newResponseTimes.quantity = Convert.ToString(dr["quantity"]);
                    newResponseTimes.minTime = Convert.ToString(dr["min_time"]);
                    newResponseTimes.maxTime = Convert.ToString(dr["max_time"]);
                    newResponseTimes.avgTime = Convert.ToString(dr["avg_time"]);
                    newResponseTimes.minValue = Convert.ToDouble(dr["min_value"]).ToString();
                    newResponseTimes.maxValue = Convert.ToDouble(dr["max_value"]).ToString();
                    newResponseTimes.avgValue = Convert.ToDouble(dr["avg_value"]).ToString();
                    newListMember.Add(newResponseTimes);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return newListMember;
        }
        public List<ResponseTimes> GetResponseByMonth(string customer, string analys, string prio, string monthFrom, string monthTo)
        {
            try
            {
                monthFrom = monthFrom.PadLeft(2, '0');
                monthTo = monthTo.PadLeft(2, '0');

                conn.Open();

                string sql = string.Empty;
                sql = sql + "SELECT to_char(tetm_date,'YYYYMM') AS month,";
                sql = sql + "   count(difference_value) AS quantity,";
                sql = sql + "   min(difference_interval) AS min_time,";
                sql = sql + "   max(difference_interval) AS max_time,";
                sql = sql + "   avg(difference_interval) AS avg_time,";
                sql = sql + "   round(min(difference_value),1) AS min_value,";
                sql = sql + "   round(max(difference_value),1) AS max_value,";
                sql = sql + "   round(avg(difference_value),1) AS avg_value";
                sql = sql + " FROM xxx_time_control_vw";
                sql = sql + " WHERE cuco LIKE :newCuco";
                sql = sql + " AND anco = :newAnco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYYY-MM') BETWEEN :newFrom AND :newTo";
                sql = sql + " GROUP BY to_char(tetm_date,'YYYYMM')";
                sql = sql + " ORDER BY to_char(tetm_date,'YYYYMM')";

                NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

                cmd.Parameters.Add(new NpgsqlParameter("newCuco", NpgsqlDbType.Varchar));
                cmd.Parameters["newCuco"].Value = customer;
                cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
                cmd.Parameters["newPrio"].Value = prio;
                cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
                cmd.Parameters["newAnco"].Value = analys;

                monthFrom = monthFrom.Substring(0, 7);
                cmd.Parameters.Add(new NpgsqlParameter("newFrom", NpgsqlDbType.Varchar));
                cmd.Parameters["newFrom"].Value = monthFrom;

                monthTo = monthTo.Substring(0, 7);
                cmd.Parameters.Add(new NpgsqlParameter("newTo", NpgsqlDbType.Varchar));
                cmd.Parameters["newTo"].Value = monthTo;

                period_from = monthFrom;
                period_to = monthTo;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ResponseTimes newResponseTimes = new ResponseTimes();
                    newResponseTimes.customer = customer;
                    newResponseTimes.prio = prio;
                    newResponseTimes.analys = analys;
                    newResponseTimes.month = Convert.ToString(dr["month"]);
                    newResponseTimes.quantity = Convert.ToString(dr["quantity"]);
                    newResponseTimes.minTime = Convert.ToString(dr["min_time"]);
                    newResponseTimes.maxTime = Convert.ToString(dr["max_time"]);
                    newResponseTimes.avgTime = Convert.ToString(dr["avg_time"]);
                    newResponseTimes.minValue = Convert.ToDouble(dr["min_value"]).ToString();
                    newResponseTimes.maxValue = Convert.ToDouble(dr["max_value"]).ToString();
                    newResponseTimes.avgValue = Convert.ToDouble(dr["avg_value"]).ToString();
                    newListMember.Add(newResponseTimes);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return newListMember;
        }
        public List<ResponseTimes> GetResponseByWeek(string customer, string analys, string prio, string yearFrom, string yearTo, string weekFrom, string weekTo)
        {
            try
            {
                weekFrom = weekFrom.PadLeft(2, '0');
                weekTo = weekTo.PadLeft(2, '0');

                conn.Open();
                
                string sql = string.Empty;
                sql = sql + "SELECT to_char(tetm_date,'YYYYWW') AS week,";
                sql = sql + "   count(difference_value) AS quantity,";
                sql = sql + "   min(difference_interval) AS min_time,";
                sql = sql + "   max(difference_interval) AS max_time,";
                sql = sql + "   avg(difference_interval) AS avg_time,";
                sql = sql + "   round(min(difference_value),1) AS min_value,";
                sql = sql + "   round(max(difference_value),1) AS max_value,";
                sql = sql + "   round(avg(difference_value),1) AS avg_value";
                sql = sql + " FROM xxx_time_control_vw";
                sql = sql + " WHERE cuco LIKE :newCuco";
                sql = sql + " AND anco = :newAnco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYWW') BETWEEN :newFrom AND :newTo";
                sql = sql + " GROUP BY to_char(tetm_date,'YYYYWW')";
                sql = sql + " ORDER BY to_char(tetm_date,'YYYYWW')";                

                NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

                cmd.Parameters.Add(new NpgsqlParameter("newCuco", NpgsqlDbType.Varchar));
                cmd.Parameters["newCuco"].Value = customer;
                cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
                cmd.Parameters["newPrio"].Value = prio;
                cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
                cmd.Parameters["newAnco"].Value = analys;
                cmd.Parameters.Add(new NpgsqlParameter("newFrom", NpgsqlDbType.Varchar));
                cmd.Parameters["newFrom"].Value = yearFrom + weekFrom;
                cmd.Parameters.Add(new NpgsqlParameter("newTo", NpgsqlDbType.Varchar));
                cmd.Parameters["newTo"].Value = yearTo + weekTo;

                period_from = yearFrom + weekFrom;
                period_to = yearTo + weekTo;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ResponseTimes newResponseTimes = new ResponseTimes();
                    newResponseTimes.customer = customer;
                    newResponseTimes.prio = prio;
                    newResponseTimes.analys = analys;
                    newResponseTimes.week = Convert.ToString(dr["week"]);
                    newResponseTimes.quantity = Convert.ToString(dr["quantity"]);
                    newResponseTimes.minTime = Convert.ToString(dr["min_time"]);
                    newResponseTimes.maxTime = Convert.ToString(dr["max_time"]);
                    newResponseTimes.avgTime = Convert.ToString(dr["avg_time"]);
                    newResponseTimes.minValue = Convert.ToDouble(dr["min_value"]).ToString();
                    newResponseTimes.maxValue = Convert.ToDouble(dr["max_value"]).ToString();
                    newResponseTimes.avgValue = Convert.ToDouble(dr["avg_value"]).ToString();
                    newListMember.Add(newResponseTimes);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return newListMember;
        }
        public List<ResponseTimes> GetResponseByDay(string customer, string analys, string prio, string dayFrom, string dayTo)
        {
            try
            {
                conn.Open();
                
                string sql = string.Empty;
                sql = sql + "SELECT to_char(tetm_date,'YYYYMMDD') AS day,";
                sql = sql + "   count(difference_value) AS quantity,";
                sql = sql + "   min(difference_interval) AS min_time,";
                sql = sql + "   max(difference_interval) AS max_time,";
                sql = sql + "   avg(difference_interval) AS avg_time,";
                sql = sql + "   round(min(difference_value),1) AS min_value,";
                sql = sql + "   round(max(difference_value),1) AS max_value,";
                sql = sql + "   round(avg(difference_value),1) AS avg_value";
                sql = sql + " FROM xxx_time_control_vw";
                sql = sql + " WHERE cuco LIKE :newCuco";
                sql = sql + " AND anco = :newAnco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYYY-MM-DD') BETWEEN :newFrom AND :newTo";
                sql = sql + " GROUP BY to_char(tetm_date,'YYYYMMDD')";
                sql = sql + " ORDER BY to_char(tetm_date,'YYYYMMDD')";            
                
                NpgsqlCommand cmd = new NpgsqlCommand(@sql, conn);

                cmd.Parameters.Add(new NpgsqlParameter("newCuco", NpgsqlDbType.Varchar));
                cmd.Parameters["newCuco"].Value = customer;
                cmd.Parameters.Add(new NpgsqlParameter("newPrio", NpgsqlDbType.Varchar));
                cmd.Parameters["newPrio"].Value = prio;
                cmd.Parameters.Add(new NpgsqlParameter("newAnco", NpgsqlDbType.Varchar));
                cmd.Parameters["newAnco"].Value = analys;
                cmd.Parameters.Add(new NpgsqlParameter("newFrom", NpgsqlDbType.Varchar));
                cmd.Parameters["newFrom"].Value = dayFrom;
                cmd.Parameters.Add(new NpgsqlParameter("newTo", NpgsqlDbType.Varchar));
                cmd.Parameters["newTo"].Value = dayTo;

                period_from = dayFrom;
                period_to = dayTo;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ResponseTimes newResponseTimes = new ResponseTimes();
                    newResponseTimes.customer = customer;
                    newResponseTimes.prio = prio;
                    newResponseTimes.analys = analys;
                    newResponseTimes.day = Convert.ToString(dr["day"]);
                    newResponseTimes.quantity = Convert.ToString(dr["quantity"]);
                    newResponseTimes.minTime = Convert.ToString(dr["min_time"]);
                    newResponseTimes.maxTime = Convert.ToString(dr["max_time"]);
                    newResponseTimes.avgTime = Convert.ToString(dr["avg_time"]);
                    newResponseTimes.minValue = Convert.ToDouble(dr["min_value"]).ToString();
                    newResponseTimes.maxValue = Convert.ToDouble(dr["max_value"]).ToString();
                    newResponseTimes.avgValue = Convert.ToDouble(dr["avg_value"]).ToString();
                    newListMember.Add(newResponseTimes);
                }
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }                
            finally
            {
                conn.Close();
            }
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
        private void AddMenu() // Metod för all lägga till mennyn till form
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Export data till Excel", null,
                new System.EventHandler(ShortcutMenuClick));

            ContextMenuStrip exportMenu = new ContextMenuStrip();
            exportMenu.Items.Add(menuItem);
            
            this.ContextMenuStrip = exportMenu;
            this.MouseDown += new MouseEventHandler(TimeMonitoring_MouseDown);
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

            for (int i = 1; i < dataGridResponseTime.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridResponseTime.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i <= dataGridResponseTime.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridResponseTime.Columns.Count; j++)
                {
                    DataGridViewCell cell = dataGridResponseTime[j, i];
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
            chartResponseTime.Titles.Clear();
            chartResponseTime.Series.Clear();
            chartResponseTime.ChartAreas.Clear();
            chartResponseTime.ChartAreas.Add("");
            chartResponseTime.Legends.Clear();
        }        
        public void AddChartTitle(string timeInterval, string analys, string customer)
        {
            string titel = "Visar uppföljning av svarstider för analys: " + analys + ", från kund: " + customer;
            chartResponseTime.Titles.Add(titel);
            chartResponseTime.Titles[0].Alignment = ContentAlignment.TopLeft;
            chartResponseTime.Legends.Add("Legend");
        }
        private void AddSerie(string serie_name, string serie_desc, List<ResponseTimes> newListMember) // Metod för all lägga till en ny serie till diagrammet
        {
            // serie 
            chartResponseTime.Series.Add(serie_name);
            
            chartResponseTime.Series[serie_name].ChartType = SeriesChartType.Line;
            chartResponseTime.Series[serie_name].LegendText = serie_desc;
            chartResponseTime.Series[serie_name].XValueType = ChartValueType.DateTime;
            chartResponseTime.Series[serie_name].YValueType = ChartValueType.Double;
            
            // Axis X
            chartResponseTime.ChartAreas[0].AxisX.Title = "Tidsperiod " + timeInterval.ToLower() + " från och med " + period_from + " till och med " + period_to;            
            chartResponseTime.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chartResponseTime.ChartAreas[0].AxisX.Interval = 20;

            // Axis Y
            chartResponseTime.ChartAreas[0].AxisY.Title = "Svartider " + timeInterval.ToLower() + " i antal minuter";

            int i = 0;
            string serie = string.Empty;
            string info = string.Empty;

            foreach (ResponseTimes item in newListMember)
            {
                // ritar serie
                DataPoint newPoint = new DataPoint();
                if (timeInterval == daily.ToUpper())
                {
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                    newPoint.AxisLabel = item.day;
                }
                else if (timeInterval == weekly.ToUpper())
                {
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
                    newPoint.AxisLabel = item.week;
                }
                else if (timeInterval == monthly.ToUpper())
                {
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                    newPoint.AxisLabel = item.month;
                }
                else if (timeInterval == byyear.ToUpper())
                {
                    chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
                    newPoint.AxisLabel = item.year;
                }
                
                double current_value = 0.00;
                string current_time = "";

                if (serie_name == avg_serie)
                {
                    current_value = Convert.ToDouble(item.avgValue);
                    current_time = item.avgTime;
                }
                else if (serie_name == min_serie)
                {
                    current_value = Convert.ToDouble(item.minValue);
                    current_time = item.minTime;
                }
                else if (serie_name == max_serie)
                {
                    current_value = Convert.ToDouble(item.maxValue);
                    current_time = item.maxTime;
                }
                else if (serie_name == med_serie)
                {
                    // Föreberder för median serien
                    // current_value = Convert.ToDouble(item.medValue);
                    // current_time = item.maxTime;
                }

                newPoint.SetValueY(current_value);
                chartResponseTime.Series[serie_name].Points.Add(newPoint);

                // ToolTip punkt beskrivning
                serie = chartResponseTime.Series[serie_name].LegendText;
                info = info + "Serie : " + serie + "\n";
                info = info + "Värde : " + current_value + " ( " + current_time + " )\n";
                info = info + "Antal analyser: " + item.quantity + "\n";
                info = info + "Datum : " + newPoint.AxisLabel.ToString() + "\n";
                chartResponseTime.Series[serie_name].Points[i].ToolTip = info;
                info = string.Empty;

                // Används för att räkna points
                i = i + 1;
            }
        
        }
        public void AddGridValue() // Metod för att hantera griden 
        {
            dataGridResponseTime.DataSource = string.Empty;
            if (newListMember.Count >= 0)
            {
                dataGridResponseTime.DataSource = newListMember;
                // Ordnar kolumn namnen  
                foreach (DataGridViewColumn column in dataGridResponseTime.Columns)
                {
                    if (column.Name.ToString() == "customer")
                    {
                        dataGridResponseTime.Columns["customer"].HeaderText = "Kund";
                    }
                    else if (column.Name.ToString() == "prio")
                    {
                        dataGridResponseTime.Columns["prio"].HeaderText = "Prioritet";
                    }
                    else if (column.Name.ToString() == "analys")
                    {
                        dataGridResponseTime.Columns["analys"].HeaderText = "Analys";
                    }
                    else if (column.Name.ToString() == "year")
                    {
                        dataGridResponseTime.Columns["year"].HeaderText = "År";
                    }
                    else if (column.Name.ToString() == "month")
                    {
                        dataGridResponseTime.Columns["month"].HeaderText = "Månad";
                    }
                    else if (column.Name.ToString() == "week")
                    {
                        dataGridResponseTime.Columns["week"].HeaderText = "Vecka";
                    }
                    else if (column.Name.ToString() == "day")
                    {
                        dataGridResponseTime.Columns["day"].HeaderText = "Dag";
                    }
                    else if (column.Name.ToString() == "hour")
                    {
                        dataGridResponseTime.Columns["hour"].HeaderText = "Timmar";
                    }
                    else if (column.Name.ToString() == "minute")
                    {
                        dataGridResponseTime.Columns["minute"].HeaderText = "Minuter";
                    }
                    else if (column.Name.ToString() == "quantity")
                    {
                        dataGridResponseTime.Columns["quantity"].HeaderText = "Antal";
                    }
                    else if (column.Name.ToString() == "minTime")
                    {
                        dataGridResponseTime.Columns["minTime"].HeaderText = "Minsta tid";
                    }
                    else if (column.Name.ToString() == "maxTime")
                    {
                        dataGridResponseTime.Columns["maxTime"].HeaderText = "Högsta tid";
                    }
                    else if (column.Name.ToString() == "avgTime")
                    {
                        dataGridResponseTime.Columns["avgTime"].HeaderText = "Medel tid";
                    }
                    else if (column.Name.ToString() == "minValue")
                    {
                        dataGridResponseTime.Columns["minValue"].HeaderText = "Minsta värde";
                    }
                    else if (column.Name.ToString() == "maxValue")
                    {
                        dataGridResponseTime.Columns["maxValue"].HeaderText = "Högsta värde";
                    }
                    else if (column.Name.ToString() == "avgValue")
                    {
                        dataGridResponseTime.Columns["avgValue"].HeaderText = "Medel värde";
                    }
                }

                // Tar bort överflödiga kolumner för respektive tidsinterval 
                if (timeInterval == hourly.ToUpper())
                {
                    dataGridResponseTime.Columns.Remove("year");
                    dataGridResponseTime.Columns.Remove("month");
                    dataGridResponseTime.Columns.Remove("week");
                    dataGridResponseTime.Columns.Remove("day");
                    dataGridResponseTime.Columns.Remove("minute");
                }
                else if (timeInterval == daily.ToUpper())
                {
                    dataGridResponseTime.Columns.Remove("year");
                    dataGridResponseTime.Columns.Remove("month");
                    dataGridResponseTime.Columns.Remove("week");
                    dataGridResponseTime.Columns.Remove("hour");
                    dataGridResponseTime.Columns.Remove("minute");
                }
                else if (timeInterval == weekly.ToUpper())
                {
                    dataGridResponseTime.Columns.Remove("year");
                    dataGridResponseTime.Columns.Remove("month");
                    dataGridResponseTime.Columns.Remove("day");
                    dataGridResponseTime.Columns.Remove("hour");
                    dataGridResponseTime.Columns.Remove("minute");
                }
                else if (timeInterval == monthly.ToUpper())
                {
                    dataGridResponseTime.Columns.Remove("year");
                    dataGridResponseTime.Columns.Remove("week");
                    dataGridResponseTime.Columns.Remove("day");
                    dataGridResponseTime.Columns.Remove("hour");
                    dataGridResponseTime.Columns.Remove("minute");
                }
                else if (timeInterval == byyear.ToUpper())
                {
                    dataGridResponseTime.Columns.Remove("month");
                    dataGridResponseTime.Columns.Remove("week");
                    dataGridResponseTime.Columns.Remove("day");
                    dataGridResponseTime.Columns.Remove("hour");
                    dataGridResponseTime.Columns.Remove("minute");
                }
                comboBoxShow.Visible = true;
                lblShowAs.Visible = true;
            }
        }
        private void ActivateTimeInterval() // Används för att hantera tillgänglighet för tidsinterval
        {
            if ((comboBoxCustomer.Text.ToString() == string.Empty)
                || (comboBoxAnalysis.Text.ToString() == string.Empty)
                    || (comboBoxPriority.Text.ToString() == string.Empty))
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

        // Events
        private void btnShowUpdateDiagram_Click(object sender, EventArgs e)
        {
            try 
	        {
                // Hämtar parametrar
                string customer = comboBoxCustomer.Text.ToString().ToUpper();
                if (customer == allGroups)
                {
                    customer = "%";
                }
                string analys = comboBoxAnalysis.Text.ToString().ToUpper();
                string prio = comboBoxPriority.Text.ToString().ToUpper();
                if (prio == allPriority)
                {
                    prio = "%";
                }

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
                // Föreberder för Timvis
                // string hoursFrom;
                // string hoursTo;

                // Hämtar datat
                newListMember.Clear();                
                if (timeInterval == hourly.ToUpper())
                {
                    // Föreberder för Timvis
                    // från kalender string format = "dd MMMM yyyy"
                    dateFrom = dateTimePickerFrom.Value;
                    dateTo = dateTimePickerTo.Value;
                    dayFrom = dateFrom.ToShortDateString();
                    dayTo = dateTo.ToShortDateString();
                    // hoursFrom = dateFrom.Hour.ToString();
                    // hoursTo = dateTo.Hour.ToString();
                    
                    // Hämtning av data påbörjas
                    // Cursor = Cursors.WaitCursor;
                    // newListMember = GetResponseByHours(customer, analys, prio, yearFrom, yearTo, hoursFrom, hoursTo);
                }
                else if (timeInterval == daily.ToUpper())
                {
                    // från kallender
                    dateFrom = dateTimePickerFrom.Value;
                    dateTo = dateTimePickerTo.Value;
                    dayFrom = dateFrom.ToShortDateString();
                    dayTo = dateTo.ToShortDateString();

                    // Hämtning av data påbörjas
                    Cursor = Cursors.WaitCursor;
                    newListMember = GetResponseByDay(customer, analys, prio, dayFrom, dayTo);
                }
                else if (timeInterval == weekly.ToUpper())
                {
                    // från boxar för år och vecka, string format = "yyyy";
                    yearFrom = comboBoxYearFrom.Text;
                    weekFrom = comboBoxWeekFrom.Text;
                    yearTo = comboBoxYearTo.Text;
                    weekTo = comboBoxWeekTo.Text;

                    // Hämtning av data påbörjas
                    Cursor = Cursors.WaitCursor;
                    newListMember = GetResponseByWeek(customer, analys, prio, yearFrom, yearTo, weekFrom, weekTo);
                }
                else if (timeInterval == monthly.ToUpper())
                {
                    // från kallender, string format = "MMMM yyyy";
                    monthFrom = dateTimePickerFrom.Value.ToShortDateString();
                    monthTo = dateTimePickerTo.Value.ToShortDateString();

                    // Hämtning av data påbörjas
                    Cursor = Cursors.WaitCursor;
                    newListMember = GetResponseByMonth(customer, analys, prio, monthFrom, monthTo);
                }
                else if (timeInterval == byyear.ToUpper())
                {
                    // från listbox
                    yearFrom = comboBoxYearFrom.Text;
                    yearTo = comboBoxYearTo.Text;

                    // Hämtning av data påbörjas
                    Cursor = Cursors.WaitCursor;
                    newListMember = GetResponseByYear(customer, analys, prio, yearFrom, yearTo);
                }

                // Hanterar diagram
                ClearChart();
                
                AddChartTitle(timeInterval.ToLower(), analys, customer);
                
                foreach (ChartSeries item in newSerieList)
                {
                    if (item.serieSelected == true)
                    {
                        AddSerie(item.serieName, item.serieDesc, newListMember);
                    }
                }

                // Lägg till data till griden (enbart vid hämtning av data)
                AddGridValue();

                // Klart
                Cursor = Cursors.Default;                
                labelMessage.Visible = true;
                labelMessage.ForeColor = Color.Green;
                labelMessage.Text = "Klart";
                
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }  
            finally
            {
                Cursor = Cursors.Default;
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
            string customer = comboBoxCustomer.Text.ToString().ToUpper();
            if (customer == allGroups)
            {
                customer = "%";
            }
            string analys = comboBoxAnalysis.Text.ToString().ToUpper();
            string prio = comboBoxPriority.Text.ToString().ToUpper();
            if (prio == allPriority)
            {
                prio = "%";
            }

            // Hanterar diagram 
            ClearChart();

            AddChartTitle(timeInterval.ToLower(), analys, customer);

            foreach (ChartSeries item in newSerieList)
            {
                if (item.serieSelected == true)
                {
                    AddSerie(item.serieName, item.serieDesc, newListMember);
                }
            }

            // Klart
            Cursor = Cursors.Default;
            labelMessage.Visible = true;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Klart";
        }        
        private void comboBoxTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTimeInterval.SelectedIndex < 0)
            {
                comboBoxYearFrom.Visible = false;
                comboBoxYearTo.Visible = false;
                comboBoxWeekFrom.Visible = false;
                comboBoxWeekTo.Visible = false;
                dateTimePickerFrom.Visible = false;
                dateTimePickerTo.Visible = false;
                lblFromWeek.Visible = false;
                lblToWeek.Visible = false;
                lblDateFrom.Visible = false;
                lblDateTo.Visible = false;
                btnShowUpdateDiagram.Enabled = false;
            }
            else 
            {
                timeInterval = comboBoxTimeInterval.SelectedItem.ToString().ToUpper();
                // sätter min och max värde i boxar beroende på värdena i kallender 
                SetYearAndWeek();
                // sätter format i kallender beroende på vald tids interval    
                if (timeInterval == hourly.ToUpper())
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

                    lblFromWeek.Visible = false;
                    lblToWeek.Visible = false;
                    lblDateFrom.Visible = true;
                    lblDateFrom.Text = "Från:";
                    lblDateTo.Visible = true;
                    lblDateTo.Text = "Till:";
                }
                else if (timeInterval == daily.ToUpper())
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

                    lblFromWeek.Visible = false;
                    lblToWeek.Visible = false;
                    lblDateFrom.Visible = true;
                    lblDateFrom.Text = "Från:";
                    lblDateTo.Visible = true;
                    lblDateTo.Text = "Till:";
                }
                else if (timeInterval == weekly.ToUpper())
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

                    lblFromWeek.Visible = true;
                    lblToWeek.Visible = true;
                    lblDateFrom.Visible = true;
                    lblDateFrom.Text = "Från år:";
                    lblDateTo.Visible = true;
                    lblDateTo.Text = "Till år:";
                }
                else if (timeInterval == monthly.ToUpper())
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

                    lblFromWeek.Visible = false;
                    lblToWeek.Visible = false;
                    lblDateFrom.Visible = true;
                    lblDateFrom.Text = "Från:";
                    lblDateTo.Visible = true;
                    lblDateTo.Text = "Till:";
                }
                else if (timeInterval == byyear.ToUpper())
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

                    lblFromWeek.Visible = false;
                    lblToWeek.Visible = false;
                    lblDateFrom.Visible = true;
                    lblDateFrom.Text = "Från:";
                    lblDateTo.Visible = true;
                    lblDateTo.Text = "Till:";
                }
                btnShowUpdateDiagram.Enabled = true;
                labelMessage.Text = "";
            }
        }
        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxYearFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxWeekFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxYearTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxWeekTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void comboBoxShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShow.SelectedItem.ToString() == as_both)
            {
                chartResponseTime.Height = 350;                
                int y = 0;
                int x = 0;
                x = dataGridResponseTime.Location.X;
                y = dataGridResponseTime.Location.Y;
                y = 520;
                dataGridResponseTime.Location = new Point(x, y);
                
                dataGridResponseTime.Height = 130;
                dataGridResponseTime.Visible = true;
            }
            else
            {
                chartResponseTime.Height = 480;
                dataGridResponseTime.Height = 130;
                dataGridResponseTime.Visible = false;
            }
        }
        private void ShortcutMenuClick(object sender, System.EventArgs e)
        {
            ExportGridData(sender, e);
        }
        private void TimeMonitoring_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridResponseTime.RowCount == 0)
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
        private void comboBoxCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            ActivateTimeInterval();
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxAnalysis_KeyUp(object sender, KeyEventArgs e)
        {
            ActivateTimeInterval();
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxPriority_KeyUp(object sender, KeyEventArgs e)
        {
            ActivateTimeInterval();
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivateTimeInterval();
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxAnalysis_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivateTimeInterval();
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivateTimeInterval();
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }
    }
}
