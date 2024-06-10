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
    public partial class Verra_ceo_suppliers : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        // 
        // 
        public Verra_ceo_suppliers()
        {
            InitializeComponent();
        }

        private void Verra_ceo_suppliers_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ПОСТАВЩИК", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ПОСТАВЩИК", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            else
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ПОСТАВЩИК WHERE Название_поставщика = @surname", conn);
                cmd.Parameters.AddWithValue("@surname", textBoxName.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }
    }
}
