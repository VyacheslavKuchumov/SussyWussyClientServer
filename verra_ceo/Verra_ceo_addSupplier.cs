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
    
    public partial class Verra_ceo_addSupplier : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        // 
        public Verra_ceo_addSupplier()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO ПОСТАВЩИКИ VALUES(@Name, @Phone, @Adress)", conn);
            cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
            cmd.Parameters.AddWithValue("@Phone", textBoxPhone.Text);
            cmd.Parameters.AddWithValue("@Adress", textBoxAdress.Text);
            

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Добавлен успешно!");
            // Instantiate the second form
            Verra_ceo_suppliers form = new Verra_ceo_suppliers();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_suppliers form = new Verra_ceo_suppliers();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void Verra_ceo_addSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}
