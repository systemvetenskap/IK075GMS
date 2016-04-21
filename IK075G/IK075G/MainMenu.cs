using System;
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

        private void btnChoice1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Choice1 val1 = new Choice1();
            val1.ShowDialog();
            
        }

        private void btnChoice2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeMonitoring val2 = new TimeMonitoring();
            val2.ShowDialog();
        }

        private void btnChoice3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonitoringMeasurements val3 = new MonitoringMeasurements();
            val3.ShowDialog();
        }
    }
}
