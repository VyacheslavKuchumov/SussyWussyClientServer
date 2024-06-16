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
    public partial class Verra_ceo_orderShiet : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        //
        public Verra_ceo_orderShiet()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO ПОСТАВКА(Дата_заявки, Дата_поставки,Код_студии, Код_поставщика) VALUES(@Date1, @Date2, @IDStudio, @IDSup); SELECT SCOPE_IDENTITY();", conn);
            cmd.Parameters.AddWithValue("@Date1", textBoxDate1.Text);
            cmd.Parameters.AddWithValue("@Date2", textBoxDate2.Text);
            cmd.Parameters.AddWithValue("@IDStudio", textBoxIDStudio.Text);
            cmd.Parameters.AddWithValue("@IDSup", textBoxIDSup.Text);

            
            object result = cmd.ExecuteScalar();
            conn.Close();

            int insertedId;
            if (result != null)
            {
                insertedId = Convert.ToInt32(result);
                MessageBox.Show($"Добавлен успешно! ID: {insertedId}");
                cmd = new SqlCommand("INSERT INTO ИНВЕНТАРЬ VALUES(@id, @Name, @Vid, @Kolvo, @Srok, @Price)", conn);
                cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Vid", textBoxVid.Text);
                cmd.Parameters.AddWithValue("@Kolvo", textBoxKolvo.Text);
                cmd.Parameters.AddWithValue("@Srok", textBoxSrok.Text);
                cmd.Parameters.AddWithValue("@Price", textBoxPrice.Text);
                cmd.Parameters.AddWithValue("@id", insertedId);
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении записи.");
            }
            conn.Close();

            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Verra_ceo_orderShiet_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ИНВЕНТАРЬ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
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
    }
}
