﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reu_bux
{
    public partial class RabVrem : Form
    {
        public RabVrem()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form MM = new MainMenu();
            MM.Show();
            this.Hide();
        }
    }
}
