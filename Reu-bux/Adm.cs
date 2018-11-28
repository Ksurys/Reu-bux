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
    public partial class Adm : Form
    {
        Base_Using _BD = new Base_Using();
        public Adm()
        {
            InitializeComponent();
        }

        private void Adm_Load(object sender, EventArgs e)
        {
            Grid_Load();
        }
        private void Grid_Load()
            {
                _BD.sotr_void();
                dataGridView1.DataSource = Program.STR;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns[1].Width = 135;
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[2].Width = 135;
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[3].Width = 135;
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Время прихода";
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Время ухода";
                _BD.polz_void();
                dataGridView2.DataSource = Program.PLZ;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = true;
                dataGridView2.Columns[1].Width = 135;
                dataGridView2.Columns[1].HeaderText = "Фамилия";
                dataGridView2.Columns[2].Visible = true;
                dataGridView2.Columns[2].Width = 135;
                dataGridView2.Columns[2].HeaderText = "Имя";
                dataGridView2.Columns[3].Visible = true;
                dataGridView2.Columns[3].Width = 135;
                dataGridView2.Columns[3].HeaderText = "Отчество";
                dataGridView2.Columns[4].Visible = true;
                dataGridView2.Columns[4].Width = 100;
                dataGridView2.Columns[4].HeaderText = "Пароль";
                dataGridView2.Columns[5].Visible = true;
                dataGridView2.Columns[5].Width = 100;
                dataGridView2.Columns[5].HeaderText = "Доступ";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {
                Reg_Info _RI = new Reg_Info();
                _RI.Connection.Close();
                MessageBox.Show("Выберите строку, содержащую данные!", "Учет времени!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                comboBox2.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {
                Reg_Info _RI = new Reg_Info();
                _RI.Connection.Close();
                MessageBox.Show("Выберите строку, содержащую данные!", "Учет времени!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                _BD.Sotr_edit_void(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), textBox1.Text, textBox2.Text, textBox3.Text, comboBox3.Text, comboBox4.Text);
                Grid_Load();
            }
            catch (Exception ex)
            {
                Reg_Info _RI = new Reg_Info();
                _RI.Connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                _BD.Polz_edit_void(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString()), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox2.Text);
                Grid_Load();
            }
            catch (Exception ex)
            {
                Reg_Info _RI = new Reg_Info();
                _RI.Connection.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
