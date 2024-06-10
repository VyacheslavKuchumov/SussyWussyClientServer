using NEfotobudka_githubik.ceo;
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

namespace NEfotobudka_githubik.verra_ceo
{
    public partial class Verra_ceo_employee : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        // 
        // 
        public Verra_ceo_employee()
        {
            InitializeComponent();
        }

        private void Verra_ceo_employee_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM СОТРУДНИКИ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM СОТРУДНИКИ", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            else
            {
                
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM СОТРУДНИКИ WHERE Фамилия_сотрудника = @surname", conn);
                cmd.Parameters.AddWithValue("@surname", textBoxSurname.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_menu form = new Verra_ceo_menu();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
