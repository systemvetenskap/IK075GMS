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
    public partial class Choice3 : Form
    {
        public Choice3()
        {
            InitializeComponent();
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
            chart1.Show();
        }
    }
}
