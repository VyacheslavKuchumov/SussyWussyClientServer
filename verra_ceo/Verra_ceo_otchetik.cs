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
    public partial class Verra_ceo_otchetik : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        // 
        // 
        public Verra_ceo_otchetik()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Код_сотрудника, Имя_сотрудника, Фамилия_сотрудника, Отчество_сотрудника, Телефон_сотрудника, Дата_начала_работы_в_компании\r\nFROM СОТРУДНИКИ\r\nWHERE Дата_начала_работы_в_компании BETWEEN @start AND @end\r\nAND Должность NOT LIKE 'директор';\r\n", conn);
            cmd.Parameters.AddWithValue("@start", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@end", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
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

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ИНВЕНТАРЬ.Код_инвентаря, ИНВЕНТАРЬ.Наименование, ПОСТАВКА.Код_поставки, ИНВЕНТАРЬ.Количество, ПОСТАВКА.Дата_поставки\r\nFROM ИНВЕНТАРЬ INNER JOIN ПОСТАВКА ON ИНВЕНТАРЬ.Код_поставки = ПОСТАВКА.Код_поставки\r\nWHERE ПОСТАВКА.Дата_поставки BETWEEN @start AND @end;\r\n", conn);
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
