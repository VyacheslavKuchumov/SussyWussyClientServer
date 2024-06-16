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
            SqlCommand cmd = new SqlCommand("INSERT INTO СОТРУДНИКИ VALUES(@surname, @name, @otchestvo, @Dob, @Pol, @phone, @CodeStudio, @DateOfStart, @Oklad, @Profession)", conn);
            cmd.Parameters.AddWithValue("@surname", textBoxSurname.Text);
            cmd.Parameters.AddWithValue("@name", textBoxName.Text);
            cmd.Parameters.AddWithValue("@otchestvo", textBoxOtchestvo.Text);
            cmd.Parameters.AddWithValue("@Dob", textBoxDob.Text);
            cmd.Parameters.AddWithValue("@Pol", textBoxPol.Text);
            cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
            cmd.Parameters.AddWithValue("@CodeStudio", textBoxCodeStudio.Text);
            cmd.Parameters.AddWithValue("@DateOfStart", textBoxDateOfStart.Text);
            cmd.Parameters.AddWithValue("@Oklad", textBoxOklad.Text);
            cmd.Parameters.AddWithValue("@Profession", textBoxProfession.Text);

            cmd.ExecuteNonQuery();

           
            conn.Close();

            MessageBox.Show("Сотрудник принят на работу");
            // Instantiate the second form
            Verra_ceo_employee form = new Verra_ceo_employee();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_employee form = new Verra_ceo_employee();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }
    }
}
