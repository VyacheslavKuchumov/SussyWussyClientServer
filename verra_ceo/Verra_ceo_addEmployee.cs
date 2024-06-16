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
    public partial class Verra_ceo_addEmployee : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        // 
        public Verra_ceo_addEmployee()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO СОТРУДНИКИ VALUES(@surname, @name, @otchestvo, @photostudio, @dayOfBirth, @position, @phone)", conn);
            cmd.Parameters.AddWithValue("@surname", textBoxSurname.Text);
            cmd.Parameters.AddWithValue("@name", textBoxName.Text);
            cmd.Parameters.AddWithValue("@otchestvo", textBoxOtchestvo.Text);
            cmd.Parameters.AddWithValue("@photostudio", textBoxPhotostudio.Text);
            cmd.Parameters.AddWithValue("@dayOfBirth", textBoxDOB.Text);
            cmd.Parameters.AddWithValue("@position", textBoxPosition.Text);
            cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);

            cmd.ExecuteNonQuery();

           
            conn.Close();
        }
    }
}
