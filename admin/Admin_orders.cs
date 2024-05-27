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
    public partial class Admin_orders : Form
    {
        public Admin_orders()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Заказ WHERE Дата_заказа BETWEEN @date1 AND @date2", conn);
            cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date2", dateTimePicker1.Value.AddDays(1).ToString("yyyy-MM-dd"));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Admin_orders_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Заказ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_clients form = new Admin_clients();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Заказ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Заказ VALUES(@date, @client, @photostudio, @photographer)", conn);
            
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@client", textBoxClient.Text);
            cmd.Parameters.AddWithValue("@photostudio", textBoxPhotostudio.Text);
            cmd.Parameters.AddWithValue("@photographer", textBoxPhotographer.Text);


            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT * FROM Заказ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Содержание_заказа WHERE Код_заказа = @id", conn);
            cmd.Parameters.AddWithValue("@id", textBoxID.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Содержание_заказа VALUES(@id, @service, @quantity, @price)", conn);
            cmd.Parameters.AddWithValue("@id", textBoxID.Text);
            cmd.Parameters.AddWithValue("@service", textBoxService.Text);
            cmd.Parameters.AddWithValue("@quantity", textBoxQuanti.Text);
            cmd.Parameters.AddWithValue("@price", textBoxPrice.Text);


            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT * FROM Содержание_заказа WHERE Код_заказа = @id", conn);
            cmd.Parameters.AddWithValue("@id", textBoxID.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (textBoxID.Text == "")
            {
                MessageBox.Show("Введите код");
            }
            else
            {

                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();


                SqlCommand cmd = new SqlCommand("DELETE FROM Заказ WHERE Код_заказа = @id", conn);
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT * FROM Заказ", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text == "")
            {
                MessageBox.Show("Введите код");
            }
            else
            {

                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();


                SqlCommand cmd = new SqlCommand("DELETE FROM Содержание_заказа WHERE Наименование_услуги = @id2 AND Код_заказа = @id", conn);
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);
                cmd.Parameters.AddWithValue("@id2", textBoxService.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT * FROM Содержание_заказа WHERE Код_заказа = @id", conn);
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }
    }
}
