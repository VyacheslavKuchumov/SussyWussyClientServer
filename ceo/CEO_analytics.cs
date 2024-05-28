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
    public partial class CEO_analytics : Form
    {
        public CEO_analytics()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CEO_company_management form = new CEO_company_management();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Наименование_услуги, COUNT(Наименование_услуги) AS Количество_выполнненных_заказов FROM Содержание_заказа, Заказ WHERE (Дата_заказа BETWEEN @date1 AND @date2) AND Заказ.Код_заказа = Содержание_заказа.Код_заказа GROUP BY Наименование_услуги ORDER BY Количество_выполнненных_заказов DESC", conn);
            cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
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
            SqlCommand cmd = new SqlCommand("SELECT SUM(Количество*Стоимость_за_ед) AS Выручка FROM Содержание_заказа, Заказ WHERE (Дата_заказа BETWEEN @date1 AND @date2) AND Заказ.Код_заказа = Содержание_заказа.Код_заказа", conn);
            cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
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
            SqlCommand cmd = new SqlCommand("SELECT Код_фотографа, SUM(Количество*Стоимость_за_ед) AS Выручка FROM Содержание_заказа, Заказ WHERE (Дата_заказа BETWEEN @date1 AND @date2) AND Заказ.Код_заказа = Содержание_заказа.Код_заказа GROUP BY Код_фотографа", conn);
            cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
