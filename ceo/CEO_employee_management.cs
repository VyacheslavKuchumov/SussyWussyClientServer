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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NEfotobudka_githubik.ceo
{
    public partial class CEO_employee_management : Form
    {
        
        public CEO_employee_management()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CEO_menu form = new CEO_menu();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Сотрудник", conn);
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Сотрудник WHERE Фамилия_сотрудника = @surname", conn);
                cmd.Parameters.AddWithValue("@surname", textBoxSurname.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }
       

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CEO_employee_management_Load_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Сотрудник", conn);
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


                SqlCommand cmd = new SqlCommand("DELETE FROM Сотрудник WHERE Код_сотрудника = @id", conn);
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT * FROM Сотрудник", conn);
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
            SqlCommand cmd = new SqlCommand("INSERT INTO Сотрудник VALUES(@surname, @name, @otchestvo, @photostudio, @dayOfBirth, @position, @phone)", conn);
            cmd.Parameters.AddWithValue("@surname", textBoxSurname.Text);
            cmd.Parameters.AddWithValue("@name", textBoxName.Text);
            cmd.Parameters.AddWithValue("@otchestvo", textBoxOtchestvo.Text);
            cmd.Parameters.AddWithValue("@photostudio", textBoxPhotostudio.Text);
            cmd.Parameters.AddWithValue("@dayOfBirth", textBoxDOB.Text);
            cmd.Parameters.AddWithValue("@position", textBoxPosition.Text);
            cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
            
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT * FROM Сотрудник", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
