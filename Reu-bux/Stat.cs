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
    public partial class Stat : Form
    {
        public Stat()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form MM = new MainMenu();
            MM.Show();
            this.Hide();
        }

        private void Stat_Load(object sender, EventArgs e)
        {

        }
    }
}
