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
    public partial class CEO_reports : Form
    {
        public CEO_reports()
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
            SqlCommand cmd = new SqlCommand("SELECT    Сотрудник.Фамилия_сотрудника,    COUNT(DISTINCT Заказ.Код_заказа) AS Количество_заказов FROM     Заказ JOIN     Сотрудник ON Заказ.Код_фотографа = Сотрудник.Код_сотрудника WHERE   Заказ.Дата_заказа BETWEEN @date1 AND @date2 GROUP BY   Сотрудник.Фамилия_сотрудника ORDER BY Количество_заказов DESC; ", conn);
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
            SqlCommand cmd = new SqlCommand("SELECT Название_поставщика, COUNT(Код_поставки) AS Количество_поставок FROM Поставщик, Поставка WHERE (Дата_поставки BETWEEN @date1 AND @date2) AND Поставщик.Код_поставщика = Поставка.Код_поставщика GROUP BY Название_поставщика ORDER BY Количество_поставок DESC", conn);
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
            SqlCommand cmd = new SqlCommand("SELECT Фотостудия.Код_фотостудии, COUNT(Код_заказа) AS Количество_заказов FROM Фотостудия, Заказ WHERE (Дата_заказа BETWEEN @date1 AND @date2) AND Заказ.Код_фотостудии = Фотостудия.Код_фотостудии GROUP BY Фотостудия.Код_фотостудии ORDER BY Количество_заказов DESC", conn);
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
