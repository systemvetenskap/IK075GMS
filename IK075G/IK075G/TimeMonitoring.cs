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
        string allGroups = "ALLA";
        string allPriority = "ALLA";

        string timeInterval = string.Empty;
        string hourly = "Timvis";
        string daily = "Dagvis";
        string weekly = "Veckovis";
        string monthly = "Månadsvis";
        string byyear = "Årsvis";
        
        // Upprättar koppling mot databas
        // CommandTimeout=200000 d.v.s 200 sekunder - 3 minuter;
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

            // Hantering av samtliga
            comboBoxCustomer.Items.Add(allGroups);
            comboBoxPriority.Items.Add(allPriority);

            LoadCustomers();
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

            comboBoxCustomer.SelectedItem = allGroups;
            comboBoxPriority.SelectedItem = allGroups;

            //Datum
            lblTodaysDateAndTime.Text = DateTime.Now.ToString("ddddd, M MMMM, yyyy");

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

        public void LoadTimeInterval() //Metod för att fylla comboboxen med tidsintervall
        {
            // comboBoxTimeInterval.Items.Add(hourly);
            comboBoxTimeInterval.Items.Add(daily);
            comboBoxTimeInterval.Items.Add(weekly);
            comboBoxTimeInterval.Items.Add(monthly);
            comboBoxTimeInterval.Items.Add(byyear);
        }

        public void LoadYears() // Metod för att LADDA in årtal i comboboxar från och till
        {
            // Från år
            try
            {
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
            
            // Till år            
            try
            {
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
                string sql = "SELECT MIN(to_date(altm,'YYDDMMHH24MI')) AS altm FROM a_ana_tab WHERE LENGTH(REPLACE(altm, ' ','')) > 0";
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    newMinDateTime = Convert.ToDateTime(dr["altm"]);
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
        
        public void SetCustomFormat(string format) // Används för att definera format i kallender 
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
            List<ResponseTimes> newListMember = new List<ResponseTimes>();
            try
            {
                conn.Open();

                string sql = string.Empty;
                sql = sql + "SELECT ";
                sql = sql + "   cuco,";
                sql = sql + "   prio,";
                sql = sql + "   anco,";
                sql = sql + "   to_char(tetm_date,'YYYY') AS year,";
                sql = sql + "   count(difference_value) AS quantity,";
                sql = sql + "   min(difference_interval) AS min_time,";
                sql = sql + "   max(difference_interval) AS max_time,";
                sql = sql + "   avg(difference_interval) AS avg_time,";
                sql = sql + "   round(min(difference_value),2) AS min_value,";
                sql = sql + "   round(max(difference_value),2) AS max_value,";
                sql = sql + "   round(avg(difference_value),2) AS avg_value";
                sql = sql + " FROM xxx_time_control_vw";
                sql = sql + " WHERE 1 = 1";
                sql = sql + " AND cuco LIKE :newCuco";
                sql = sql + " AND anco = :newAnco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YY') BETWEEN :newFrom AND :newTo";
                sql = sql + " GROUP BY cuco, prio, anco, to_char(tetm_date,'YYYY')";
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
                    newResponseTimes.minValue = Convert.ToString(dr["min_value"]);
                    newResponseTimes.maxValue = Convert.ToString(dr["max_value"]);
                    newResponseTimes.avgValue = Convert.ToString(dr["avg_value"]);
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
            List<ResponseTimes> newListMember = new List<ResponseTimes>();
            try
            {
                monthFrom = monthFrom.PadLeft(2, '0');
                monthTo = monthTo.PadLeft(2, '0');

                conn.Open();

                string sql = string.Empty;
                sql = sql + "SELECT ";
                sql = sql + "   cuco,";
                sql = sql + "   prio,";
                sql = sql + "   anco,";
                sql = sql + "   to_char(tetm_date,'YYYYMM') AS month,";
                sql = sql + "   count(difference_value) AS quantity,";
                sql = sql + "   min(difference_interval) AS min_time,";
                sql = sql + "   max(difference_interval) AS max_time,";
                sql = sql + "   avg(difference_interval) AS avg_time,";
                sql = sql + "   round(min(difference_value),2) AS min_value,";
                sql = sql + "   round(max(difference_value),2) AS max_value,";
                sql = sql + "   round(avg(difference_value),2) AS avg_value";
                sql = sql + " FROM xxx_time_control_vw";
                sql = sql + " WHERE 1 = 1";
                sql = sql + " AND cuco LIKE :newCuco";
                sql = sql + " AND anco = :newAnco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYYY-MM') BETWEEN :newFrom AND :newTo";
                sql = sql + " GROUP BY cuco, prio, anco, to_char(tetm_date,'YYYYMM')";
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
                    newResponseTimes.minValue = Convert.ToString(dr["min_value"]);
                    newResponseTimes.maxValue = Convert.ToString(dr["max_value"]);
                    newResponseTimes.avgValue = Convert.ToString(dr["avg_value"]);
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
            List<ResponseTimes> newListMember = new List<ResponseTimes>();
            try
            {
                weekFrom = weekFrom.PadLeft(2, '0');
                weekTo = weekTo.PadLeft(2, '0');

                conn.Open();

                string sql = string.Empty;
                sql = sql + "SELECT ";
                sql = sql + "   cuco,";
                sql = sql + "   prio,";
                sql = sql + "   anco,";
                sql = sql + "   to_char(tetm_date,'YYYYWW') AS week,";
                sql = sql + "   count(difference_value) AS quantity,";
                sql = sql + "   min(difference_interval) AS min_time,";
                sql = sql + "   max(difference_interval) AS max_time,";
                sql = sql + "   avg(difference_interval) AS avg_time,";
                sql = sql + "   round(min(difference_value),2) AS min_value,";
                sql = sql + "   round(max(difference_value),2) AS max_value,";
                sql = sql + "   round(avg(difference_value),2) AS avg_value";
                sql = sql + " FROM xxx_time_control_vw";
                sql = sql + " WHERE 1 = 1";
                sql = sql + " AND cuco LIKE :newCuco";
                sql = sql + " AND anco = :newAnco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYWW') BETWEEN :newFrom AND :newTo";
                sql = sql + " GROUP BY cuco, prio, anco, to_char(tetm_date,'YYYYWW')";
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
                    newResponseTimes.minValue = Convert.ToString(dr["min_value"]);
                    newResponseTimes.maxValue = Convert.ToString(dr["max_value"]);
                    newResponseTimes.avgValue = Convert.ToString(dr["avg_value"]);
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
            List<ResponseTimes> newListMember = new List<ResponseTimes>();
            try
            {
                conn.Open();
                string sql = string.Empty;
                sql = sql + "SELECT ";
                sql = sql + "   cuco,";
                sql = sql + "   prio,";
                sql = sql + "   anco,";
                sql = sql + "   to_char(tetm_date,'YYYYMMDD') AS day,";
                sql = sql + "   count(difference_value) AS quantity,";
                sql = sql + "   min(difference_interval) AS min_time,";
                sql = sql + "   max(difference_interval) AS max_time,";
                sql = sql + "   avg(difference_interval) AS avg_time,";
                sql = sql + "   round(min(difference_value),2) AS min_value,";
                sql = sql + "   round(max(difference_value),2) AS max_value,";
                sql = sql + "   round(avg(difference_value),2) AS avg_value";
                sql = sql + " FROM xxx_time_control_vw";
                sql = sql + " WHERE 1 = 1";
                sql = sql + " AND cuco LIKE :newCuco";
                sql = sql + " AND anco = :newAnco";
                sql = sql + " AND prio LIKE :newPrio";
                sql = sql + " AND to_char(tetm_date,'YYYY-MM-DD') BETWEEN :newFrom AND :newTo";
                sql = sql + " GROUP BY cuco, prio, anco, to_char(tetm_date,'YYYYMMDD')";
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
                    newResponseTimes.minValue = Convert.ToString(dr["min_value"]);
                    newResponseTimes.maxValue = Convert.ToString(dr["max_value"]);
                    newResponseTimes.avgValue = Convert.ToString(dr["avg_value"]);
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

        // Events
        private void btnShowUpdateDiagram_Click(object sender, EventArgs e)
        {
            try 
	        {
                List<ResponseTimes> newListMember = new List<ResponseTimes>();
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
                // string hoursFrom;
                // string hoursTo;

                if (timeInterval == hourly.ToUpper())
                {
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

                // diagram
                chartResponseTime.Titles.Clear();
                chartResponseTime.Series.Clear();
                chartResponseTime.ChartAreas.Clear();
                chartResponseTime.ChartAreas.Add("");
                chartResponseTime.Legends.Clear();
                
                // diagram titel 
                string titel = "Visar uppföljning av svarstider " + timeInterval.ToLower() + " för analys: " + analys + ", från kund: " + customer;
                chartResponseTime.Titles.Add(titel);
                //chartResponseTime.ChartAreas[0].AxisX.Title = "Svarstider (" + timeInterval.ToLower() + ")";

                chartResponseTime.Legends.Add("Legend");

                // medel
                chartResponseTime.Series.Add("Series1");
                chartResponseTime.Series["Series1"].ChartType = SeriesChartType.Line;
                chartResponseTime.Series["Series1"].LegendText = "Medel värde";
                chartResponseTime.Series["Series1"].XValueType = ChartValueType.DateTime;
                chartResponseTime.Series["Series1"].YValueType = ChartValueType.Double;

                // minsta
                chartResponseTime.Series.Add("Series2");
                chartResponseTime.Series["Series2"].ChartType = SeriesChartType.Line;
                chartResponseTime.Series["Series2"].LegendText = "Minsta värde";
                chartResponseTime.Series["Series2"].XValueType = ChartValueType.DateTime;
                chartResponseTime.Series["Series2"].YValueType = ChartValueType.Double;

                // högsta
                chartResponseTime.Series.Add("Series3");
                chartResponseTime.Series["Series3"].ChartType = SeriesChartType.Line;
                chartResponseTime.Series["Series3"].LegendText = "Högsta värde";
                chartResponseTime.Series["Series3"].XValueType = ChartValueType.DateTime;
                chartResponseTime.Series["Series3"].YValueType = ChartValueType.Double;
                
                int i = 0;
                string serie = string.Empty;
                string info = string.Empty;

                foreach (ResponseTimes item in newListMember)
                {
                    // ritar diagrammet
                    DataPoint newAveragePoint = new DataPoint();
                    if (timeInterval == daily.ToUpper())
                    {
                        chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                        newAveragePoint.AxisLabel = item.day;
                    }
                    else if (timeInterval == weekly.ToUpper())
                    {
                        chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
                        newAveragePoint.AxisLabel = item.week;
                    }
                    else if (timeInterval == monthly.ToUpper())
                    {
                        chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                        newAveragePoint.AxisLabel = item.month;
                    }
                    else if (timeInterval == byyear.ToUpper())
                    {
                        chartResponseTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
                        newAveragePoint.AxisLabel = item.year;
                    }
                    newAveragePoint.SetValueY(Convert.ToDouble(item.avgValue));
                    chartResponseTime.Series["Series1"].Points.Add(newAveragePoint);

                    serie = chartResponseTime.Series["Series1"].LegendText;
                    info = info + "Serie : " + serie + "\n";
                    info = info + "Värde : " + item.avgValue + "\n";
                    info = info + item.avgTime + "\n";
                    info = info + "Antal analyser: " + item.quantity + "\n";
                    info = info + "Datum : " + newAveragePoint.AxisLabel.ToString() + "\n";
                    chartResponseTime.Series["Series1"].Points[i].ToolTip = info;
                    info = string.Empty;

                    DataPoint newMinPoint = new DataPoint();
                    newMinPoint.SetValueY(Convert.ToDouble(item.minValue));
                    chartResponseTime.Series["Series2"].Points.Add(newMinPoint);

                    serie = chartResponseTime.Series["Series2"].LegendText;
                    info = info + "Serie : " + serie + "\n";
                    info = info + "Värde : " + item.minValue + "\n";
                    info = info + item.minTime + "\n";
                    info = info + "Antal analyser: " + item.quantity + "\n";
                    info = info + "Datum : " + newAveragePoint.AxisLabel.ToString() + "\n";
                    chartResponseTime.Series["Series2"].Points[i].ToolTip = info;
                    info = string.Empty;

                    DataPoint newMaxPoint = new DataPoint();
                    newMaxPoint.SetValueY(Convert.ToDouble(item.maxValue));
                    chartResponseTime.Series["Series3"].Points.Add(newMaxPoint);
                    
                    serie = chartResponseTime.Series["Series3"].LegendText;
                    info = info + "Serie : " + serie + "\n";
                    info = info + "Värde : " + item.maxValue + "\n";
                    info = info + item.maxTime + "\n";
                    info = info + "Antal analyser: " + item.quantity + "\n";
                    info = info + "Datum : " + newAveragePoint.AxisLabel.ToString() + "\n";
                    chartResponseTime.Series["Series3"].Points[i].ToolTip = info;
                    info = string.Empty;
                    
                    // används för att räkna points
                    i = i + 1;
                }
                chartResponseTime.Show();
                labelMessage.Text = "Klart";
                Cursor = Cursors.Default;		
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
            // Diagrammet stop
        }

        private void comboBoxTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
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
            }
            labelMessage.Text = "";
        }

        private void comboBoxAnalysis_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
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

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }

        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            chartResponseTime.Titles.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
