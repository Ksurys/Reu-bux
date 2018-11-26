using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reu_bux
{
    public partial class Connect : Form
    {
        private Base_Using _BU;
        private Reg_Info _RI;

        public Connect()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            switch (toolStripButton1.Text)
            {
                case "Вход в систему":
                    toolStripLabel1.Visible = true;
                    toolStripTextBox1.Visible = true;
                    toolStripButton3.Visible = true;
                    toolStripTextBox1.Clear();
                    toolStripButton1.Text = "Закрыть авторизацию";
                    break;
                case "Закрыть авторизацию":
                    toolStripLabel1.Visible = false;
                    toolStripTextBox1.Visible = false;
                    toolStripButton3.Visible = false;
                    toolStripButton1.Text = "Вход в систему";
                    break;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            this.Enabled = false;
            switch (MessageBox.Show("Завершить работу приложения ?", "Учет времени",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    this.Enabled = true;
                    break;
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            {
                switch (toolStripTextBox1.Text == "")
                {
                    case (true):
                        toolStripTextBox1.BackColor = Color.Red;
                        break;
                    case (false):
                        _BU = new Base_Using();
                        _BU.Autentification(toolStripTextBox1.Text);
                        menuStrip1.Visible = Program.Value;
                      //  priceListToolStripMenuItem.Visible = true;
                        switch (toolStripButton3.Text)
                        {
                            case ("Авторизоваться"):
                                toolStripLabel1.Visible = false;
                                toolStripTextBox1.Visible = false;
                                toolStripButton3.Text = "Сменить пользователя";
                                switch (Program.MACCSS)
                                {
                                    case (0):
                                        корректировкаРабочегоВремениToolStripMenuItem.Visible = false;
                                        break;
                                    case (1):
                                        корректировкаРабочегоВремениToolStripMenuItem.Visible = true;
                                        break;
                                }
                                switch (Program.SACCSS)
                                {
                                    case (0):
                                        расчетШтрафовИПремийToolStripMenuItem.Visible = false;
                                        break;
                                    case (1):
                                        расчетШтрафовИПремийToolStripMenuItem.Visible = true;
                                        break;
                                }
                                switch (Program.TNSACCSS)
                                {
                                    case (0):
                                        статистикаToolStripMenuItem.Visible = false;
                                        break;
                                    case (1):
                                        статистикаToolStripMenuItem.Visible = true;
                                        break;
                                }
                                break;
                            case ("Сменить пользователя"):
                                toolStripLabel1.Visible = true;
                                toolStripTextBox1.Visible = true;
                                toolStripTextBox1.Clear();
                                toolStripButton3.Text = "Авторизоваться";
                                menuStrip1.Visible = false;
                                Program.MACCSS = 0;
                                Program.SACCSS = 0;
                                Program.SYACCSS = 0;
                                Program.TNSACCSS = 0;
                                Program.UID = 0;
                                break;
                        }
                        toolStripTextBox1.BackColor = Color.White;
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _BU = new Base_Using();
            _BU.List_Dbs += _BUList_Dbs;
            Reg_Info.DS = comboBox1.Text;
            Reg_Info.UN = textBox1.Text;
            Reg_Info.UP = textBox2.Text;
            Thread Th = new Thread(_BU.Get_Base_List);
            Th.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _RI = new Reg_Info();
            _RI.Register_set(comboBox1.Text, comboBox2.Text, textBox1.Text, textBox2.Text);
            panel1.Visible = false;
            toolStripButton1.Enabled = true;
        }

        public void _BUList_Dbs(DataSet value)
        {
            Action Act = () =>
            {
                comboBox2.DataSource = value.Tables[0];
                comboBox2.DisplayMember = "name";
                comboBox2.Enabled = true;
                button2.Enabled = true;
            };
            Invoke(Act);
        }
    }
}
