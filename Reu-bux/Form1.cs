using System;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form RV = new RabVrem();
            RV.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form St = new Stat();
            St.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form RC = new Raschet();
            RC.Show();
            this.Hide();
        }
    }
}
