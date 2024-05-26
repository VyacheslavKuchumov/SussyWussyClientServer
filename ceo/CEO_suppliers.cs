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

namespace NEfotobudka_githubik.ceo
{
    public partial class CEO_suppliers : Form
    {
        public CEO_suppliers()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CEO_menu form = new CEO_menu();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void CEO_suppliers_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Поставщик", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Поставщик", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Поставщик WHERE Название_поставщика = @name", conn);
                cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Поставщик VALUES(@name, @adress, @CEOsurname, @CEOname, @CEOotchestvo, @phone)", conn);
            cmd.Parameters.AddWithValue("@name", textBoxName.Text);
            cmd.Parameters.AddWithValue("@adress", textBoxAdress.Text);
            cmd.Parameters.AddWithValue("@CEOsurname", textBoxCEOSurname.Text);
            cmd.Parameters.AddWithValue("@CEOname", textBoxCEOName.Text);
            cmd.Parameters.AddWithValue("@CEOotchestvo", textBoxCEOOtchestvo.Text);
            cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT * FROM Поставщик", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
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


                SqlCommand cmd = new SqlCommand("DELETE FROM Поставщик WHERE Код_поставщика = @id", conn);
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT * FROM Поставщик", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
        }
    }
}
