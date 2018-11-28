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

        private bool checking = true;
        private bool get_server_list = true;


        public Connect()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            switch (toolStripButton1.Text)
            {
                case "Вход в систему":
                    toolStripLabel2.Visible = true;
                    toolStripTextBox1.Visible = true;
                    toolStripButton2.Visible = true;
                    toolStripTextBox1.Clear();
                    toolStripButton1.Text = "Закрыть авторизацию";
                    break;
                case "Закрыть авторизацию":
                    toolStripLabel2.Visible = false;
                    toolStripTextBox1.Visible = false;
                    toolStripButton2.Visible = false;
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
            //Program.SYSACCESS = Convert.ToInt32(_CmdSql.ExecuteScalar().ToString());
            {
                switch (toolStripTextBox1.Text == "")
                {
                    case (true):
                        toolStripTextBox1.BackColor = Color.Red;
                        break;
                    case (false):
                        _BU = new Base_Using();
                        _BU.Autorization(toolStripTextBox1.Text);
                        if (Program.AUTH == 1)
                        {
                            Form MM = new MainMenu();
                            MM.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден");
                        }
                        toolStripTextBox1.BackColor = Color.White;
                        break;
                }
            }
//ПРОБОВАЛА РАЗГРАНИЧЕНИЕ

            //_RI.Set_Connection(); //Установка соединения с базой
            //_RI.Connection.Open();
            //switch (Program.SYSACCESS) //Проверка значения из переменной SYSACCESS в классе Program
            //{
                                  
            //    case 0:
            //        _RI.Connection.Close();
            //        Program.ADMINACCESS = false;
            //        //Program.BACKTOADMIN = true;
            //        MainMenu MM = new MainMenu();
            //        MM.Show();
            //        this.Close();
            //        break;
            //    case 1:
            //        _RI.Connection.Close();
            //        Program.ADMINACCESS = true;
            //        //Program.BACKTOADMIN = true;
            //        MainMenu MN = new MainMenu();
            //        MN.Show();
            //        this.Close();
            //        break;

            //}
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime Day = DateTime.Today;
            DateTime Time = DateTime.Now;
            toolStripStatusLabel1.Text = "Сегодня: " + Day.ToString("yyyy-MM-dd");
            toolStripStatusLabel2.Text = "Время: " + Time.ToString("hh:mm:ss");
            switch (checking)
            {
                case (true):
                    if (toolStripStatusLabel3.Text.Length > 23)
                    {
                        toolStripStatusLabel3.Text = "Проверка подключения";
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + ".";
                    }
                    break;
            }
            switch (get_server_list)
            {
                case (true):
                    if (toolStripStatusLabel3.Text.Length > 27)
                    {
                        toolStripStatusLabel3.Text = "Получение списка серверов";
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + ".";
                    }
                    break;
            }
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            _BU = new Base_Using();
            _BU.Status += _BU_Status;
            toolStripStatusLabel3.Text = "Проверка подключения";
            Thread Th1 = new Thread(_BU.Connection_State);
            Th1.Start();
        }

        public void _BU_Status(bool value)
        {
            Action Act = () =>
            {
                checking = false;
                switch (value)
                {
                    case (true):
                        get_server_list = false;
                        toolStripStatusLabel3.Text = "Подключение установлено!";
                        toolStripButton1.Enabled = true;
                        break;
                    case (false):
                        toolStripStatusLabel3.Text = "Отсутствует подключение!";
                        panel1.Visible = true;
                        _BU = new Base_Using();
                        _BU.List_Server += _BU_List_Server;
                        Thread Th1 = new Thread(_BU.Get_Server_List);
                        Th1.Start();
                        break;
                }
            };
            Invoke(Act);
        }

        public void _BU_List_Server(DataTable value)
        {
            Action Act = () =>
            {
                get_server_list = false;
                foreach (DataRow Row in value.Rows)
                {
                   comboBox1.Items.Add(Row[0] + "\\" + Row[1]);
                }
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                toolStripStatusLabel3.Text = "Список серверов получен.";
            };
            Invoke(Act);
        }
    }
}
