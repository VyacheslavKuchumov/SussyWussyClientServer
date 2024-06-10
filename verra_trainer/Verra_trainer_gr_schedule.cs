using NEfotobudka_githubik.verra_admin;
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

namespace NEfotobudka_githubik.verra_trainer
{
    public partial class Verra_trainer_gr_schedule : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        // 
        //
        public Verra_trainer_gr_schedule()
        {
            InitializeComponent();
        }

        private void Verra_trainer_gr_schedule_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [РАСПИСАНИЕ]", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_trainer_menu form = new Verra_trainer_menu();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }
    }
}
