using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu2
{
    public partial class FormKehoachchitieu : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-MQ3E0HG\SQLEXPRESS;Initial Catalog=QLCT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = " select * from thongtinlichchitieu";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        public FormKehoachchitieu()
        {
            InitializeComponent();
        }

        private void bt_themsukien_Click(object sender, EventArgs e)
        {
            if(txt_tensukien.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập tên sự kiện ");
                txt_tensukien.Focus(); // đưa con trỏ về lại ô đó
            }
            else if (txt_sotiensechi.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập số tiền ");
                txt_sotiensechi.Focus(); // đưa con trỏ về lại ô đó
            }
            else
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into thongtinlichchitieu values('" + txt_tensukien.Text + "', '" + dateTimePicker1.Text + "','" + txt_sotiensechi.Text + "', N'" + txt_ghichu.Text + "')";
                command.ExecuteNonQuery();
                loaddata();
            }    

        }

        private void bt_xoasukien_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from thongtinlichchitieu where tensukien= '" + txt_tensukien.Text + "' ";
            command.ExecuteNonQuery();
            MessageBox.Show("bạn chắc chắn muốn xóa sự kiện");
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txt_tensukien.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_sotiensechi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_ghichu.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void FormKehoachchitieu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void buttonQuaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMain main = new FormMain();
            main.Show();
        }

        private void bt_suasukien_Click_1(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update thongtinlichchitieu set ngaybatdau = '" + dateTimePicker1.Text + "' , sotiensechi = '" + txt_sotiensechi.Text + "' , ghichu = N'" + txt_ghichu.Text + "' where tensukien = N'" + txt_tensukien.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }

       

        private void txt_sotiensechi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show(" Bạn phải nhập số");
            }
        }

        private void FormKehoachchitieu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
