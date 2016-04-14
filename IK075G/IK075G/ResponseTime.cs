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
    public partial class ResponseTime : Form
    {
        public ResponseTime()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu huvudmeny = new MainMenu();
            huvudmeny.ShowDialog();
        }
    }
}
