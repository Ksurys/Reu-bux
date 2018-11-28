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
    public partial class RabVrem : Form
    {
        Base_Using _BD = new Base_Using();
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
            
            //_BD.sotr_void();
            ////_BD.paspartu_articul_void();
            ////_BD.slip_articul_void();
            //dataGridView1.DataSource = Program.STR;
            //dataGridView1.Columns[0].HeaderText = "Артикул";
            //dataGridView1.Columns[1].HeaderText = "Остаток";
            //dataGridView1.Columns[2].HeaderText = "Цена";
            //dataGridView1.Columns[3].HeaderText = "Количество";
        }

        private void RabVrem_Load(object sender, EventArgs e)
        {
            Grid_Load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                textBox1.Text = (dataGridView1.CurrentRow.Cells[1].Value.ToString()+' '+ dataGridView1.CurrentRow.Cells[2].Value.ToString() + ' ' + dataGridView1.CurrentRow.Cells[3].Value.ToString());
                comboBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                //textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                //textBox4.Text = "";
                //textBox5.Text = "";
                //textBox7.Text = "";
                //textBox8.Text = "";
                //listBox1.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value.ToString());
                //switch (Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value.ToString()))
                //{
                //    case 0:
                //        comboBox1.SelectedIndex = 0;
                //        break;
                //    case 1:
                //        comboBox1.SelectedIndex = 1;
                //        break;
                //    case 2:
                //        comboBox1.SelectedIndex = 2;
                //        break;
                //}
            }
            catch
            {
                Reg_Info _RI = new Reg_Info();
                _RI.Connection.Close();
                MessageBox.Show("Выберите строку, содержащую данные!", "Учет времени!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _BD.Sotr_edit_void(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), comboBox3.Text, comboBox4.Text);
                Grid_Load();
            }
            catch (Exception ex)
            {
                Reg_Info _RI = new Reg_Info();
                _RI.Connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
