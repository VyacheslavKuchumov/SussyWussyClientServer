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

namespace NEfotobudka_githubik.admin
{
    public partial class Admin_clients : Form
    {
        public Admin_clients()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text == "")
            {
                MessageBox.Show("Введите код");
            }
            else
            {

                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();


                SqlCommand cmd = new SqlCommand("DELETE FROM Клиент WHERE Код_клиента = @id", conn);
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT * FROM Клиент", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
        }

        private void Admin_clients_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Клиент", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin_orders form = new Admin_orders();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Клиент WHERE Фамилия_клиента = @surname", conn);
            cmd.Parameters.AddWithValue("@surname", textBoxSurname.Text);
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Клиент VALUES(@surname, @name, @otchestvo, @phone, @email)", conn);
            cmd.Parameters.AddWithValue("@surname", textBoxSurname.Text);
            cmd.Parameters.AddWithValue("@name", textBoxName.Text);
            cmd.Parameters.AddWithValue("@otchestvo", textBoxOtchestvo.Text);
            cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
            cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);


            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT * FROM Клиент", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_menu form = new Admin_menu();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }
    }
}
