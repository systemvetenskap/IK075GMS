﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IK075G
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnMonitoringMeasurements_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonitoringMeasurements GotoMonitoringM = new MonitoringMeasurements();
            GotoMonitoringM.ShowDialog();
        }

        private void btnTimeMonitoring_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeMonitoring GotoTimeM = new TimeMonitoring();
            GotoTimeM.ShowDialog();
        }

        private void btnOperationMethod_Click(object sender, EventArgs e)
        {
           
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            btnOperationMethod.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
