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
    public partial class Verra_ceo_analytics : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        // 
        // 

        public Verra_ceo_analytics()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 АБОНЕМЕНТЫ.Код_программы, ПРОГРАММЫ.Название_программы, COUNT(АБОНЕМЕНТЫ.Код_программы) AS Продажи\r\nFROM АБОНЕМЕНТЫ INNER JOIN ПРОГРАММЫ ON АБОНЕМЕНТЫ.Код_программы = ПРОГРАММЫ.Код_программы\r\nWHERE АБОНЕМЕНТЫ.Дата_оплаты_абонемента BETWEEN @start AND @end\r\nGROUP BY АБОНЕМЕНТЫ.Код_программы, ПРОГРАММЫ.Название_программы;\r\n", conn);
            cmd.Parameters.AddWithValue("@start", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@end", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT АБОНЕМЕНТЫ.Код_абонемента, АБОНЕМЕНТЫ.Код_программы, АБОНЕМЕНТЫ.Дата_оплаты_абонемента, АБОНЕМЕНТЫ.Цена_за_занятие, ПРОГРАММЫ.Название_программы\r\nFROM АБОНЕМЕНТЫ INNER JOIN ПРОГРАММЫ ON АБОНЕМЕНТЫ.Код_программы = ПРОГРАММЫ.Код_программы\r\nWHERE АБОНЕМЕНТЫ.Дата_оплаты_абонемента BETWEEN @start AND @end;\r\n", conn);
            cmd.Parameters.AddWithValue("@start", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@end", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT СОТРУДНИКИ.Фамилия_сотрудника, СОТРУДНИКИ.Имя_сотрудника, СОТРУДНИКИ.Отчество_сотрудника, СОТРУДНИКИ.Должность, COUNT([ИНДИВИДУАЛЬНЫЕ АБОНЕМЕНТЫ].Код_абонемента) AS Количество_индивидуальных_абонементов, COUNT([ГРУППОВЫЕ АБОНЕМЕНТЫ].Код_абонемента) AS Количество_групповых_абонементов\r\nFROM (СОТРУДНИКИ LEFT JOIN [ИНДИВИДУАЛЬНЫЕ АБОНЕМЕНТЫ] ON СОТРУДНИКИ.Код_сотрудника = [ИНДИВИДУАЛЬНЫЕ АБОНЕМЕНТЫ].Код_тренера) INNER JOIN (ГРУППЫ INNER JOIN [ГРУППОВЫЕ АБОНЕМЕНТЫ] ON ГРУППЫ.Код_группы = [ГРУППОВЫЕ АБОНЕМЕНТЫ].Код_группы) ON СОТРУДНИКИ.Код_сотрудника = ГРУППЫ.Код_тренера\r\nGROUP BY СОТРУДНИКИ.Фамилия_сотрудника, СОТРУДНИКИ.Имя_сотрудника, СОТРУДНИКИ.Отчество_сотрудника, СОТРУДНИКИ.Должность;\r\n", conn);
            cmd.Parameters.AddWithValue("@start", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@end", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
