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
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ
        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=Itogovaya;Integrated Security=True");
        // 
        // 
        // 
        public Verra_ceo_employee()
        {
            InitializeComponent();
        }

        private void Verra_ceo_employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'itogovayaDataSet.СОТРУДНИКИ' table. You can move, or remove it, as needed.
            this.сОТРУДНИКИTableAdapter.Fill(this.itogovayaDataSet.СОТРУДНИКИ);

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text == "")
            {
                MessageBox.Show("Введите код");
            }
            else
            {

                conn.Open();


                SqlCommand cmd = new SqlCommand("DELETE FROM СОТРУДНИКИ WHERE Код_сотрудника = @id", conn);
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT * FROM СОТРУДНИКИ", conn);
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
