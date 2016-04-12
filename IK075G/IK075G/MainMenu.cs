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
            Choice2 val2 = new Choice2();
            val2.ShowDialog();
        }
    }
}
