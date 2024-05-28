using Microsoft.Office.Interop.Word;
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
using DataTable = System.Data.DataTable;
using Word = Microsoft.Office.Interop.Word;

namespace NEfotobudka_githubik.ceo
{
    public partial class CEO_suppliers : Form
    {
        public CEO_suppliers()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CEO_menu form = new CEO_menu();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void CEO_suppliers_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Поставщик", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Поставщик", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Поставщик WHERE Название_поставщика = @name", conn);
                cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Поставщик VALUES(@name, @adress, @CEOsurname, @CEOname, @CEOotchestvo, @phone)", conn);
            cmd.Parameters.AddWithValue("@name", textBoxName.Text);
            cmd.Parameters.AddWithValue("@adress", textBoxAdress.Text);
            cmd.Parameters.AddWithValue("@CEOsurname", textBoxCEOSurname.Text);
            cmd.Parameters.AddWithValue("@CEOname", textBoxCEOName.Text);
            cmd.Parameters.AddWithValue("@CEOotchestvo", textBoxCEOOtchestvo.Text);
            cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT * FROM Поставщик", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text == "")
            {
                MessageBox.Show("Введите код");
            }
            else
            {

                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
                conn.Open();


                SqlCommand cmd = new SqlCommand("DELETE FROM Поставщик WHERE Код_поставщика = @id", conn);
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT * FROM Поставщик", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CEO_delivery form = new CEO_delivery();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string supplierName = "";
            string supplierDirector = "";
            string customerName = "";
            string customerDirector = "";

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True");
            conn.Open();


            string query = "SELECT Фамилия_директора_компании, Имя_директора_компании, Отчество_директора_компании FROM Компания";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string фамилия = reader["Фамилия_директора_компании"].ToString();
                        string имя = reader["Имя_директора_компании"].ToString();
                        string отчество = reader["Отчество_директора_компании"].ToString();

                        customerDirector = фамилия + " " + имя + " " + отчество;
                    }
                   
                }
            }
            query = "SELECT Название_компании FROM Компания";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string company = reader["Название_компании"].ToString();
                        

                        customerName = company;
                    }

                }
            }
            query = "SELECT Фамилия_директора_поставщика, Имя_директора_поставщика, Отчество_директора_поставщика FROM Поставщик WHERE Код_поставщика = @id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string фамилия = reader["Фамилия_директора_поставщика"].ToString();
                        string имя = reader["Имя_директора_поставщика"].ToString();
                        string отчество = reader["Отчество_директора_поставщика"].ToString();

                        supplierDirector = фамилия + " " + имя + " " + отчество;
                    }

                }
            }

            query = "SELECT Название_поставщика FROM Поставщик WHERE Код_поставщика = @id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", textBoxID.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string company = reader["Название_поставщика"].ToString();


                        supplierName = company;
                    }

                }
            }


            conn.Close();

            





            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();
            wordApp.Visible = true;

            // Функция для добавления параграфа
            void AddParagraph(string text, bool bold = false, WdParagraphAlignment alignment = WdParagraphAlignment.wdAlignParagraphLeft)
            {
                Paragraph paragraph = doc.Content.Paragraphs.Add();
                paragraph.Range.Text = text;
                paragraph.Range.Bold = bold ? 1 : 0;
                paragraph.Alignment = alignment;
                paragraph.Range.InsertParagraphAfter();
            }

            AddParagraph("Договор поставки", true, WdParagraphAlignment.wdAlignParagraphCenter);
            AddParagraph("г. [Город]                                                                                \"__\" __________ 2024 г.", false, WdParagraphAlignment.wdAlignParagraphLeft);

            AddParagraph("1. Стороны договора", true);
            AddParagraph($"1.1. Поставщик: {supplierName}");
            AddParagraph($"1.2. Директор Поставщика: {supplierDirector}");
            AddParagraph($"1.3. Заказчик: {customerName}");
            AddParagraph($"1.4. Директор Заказчика: {customerDirector}");

            AddParagraph("2. Предмет договора", true);
            AddParagraph("2.1. Поставщик обязуется поставить Заказчику товары согласно спецификации, указанной в Приложении №1 к настоящему договору, а Заказчик обязуется принять и оплатить указанные товары на условиях настоящего договора.");

            AddParagraph("3. Сроки и условия поставки", true);
            AddParagraph("3.1. Срок поставки товаров: ________.");
            AddParagraph("3.2. Условия поставки: ________.");

            AddParagraph("4. Стоимость и порядок расчетов", true);
            AddParagraph("4.1. Общая стоимость товаров составляет ________.");
            AddParagraph("4.2. Порядок расчетов: ________.");

            AddParagraph("5. Права и обязанности сторон", true);
            AddParagraph("5.1. Поставщик обязуется:");
            AddParagraph("- Поставить товары надлежащего качества и в срок.");
            AddParagraph("- Предоставить все необходимые документы на товары.");

            AddParagraph("5.2. Заказчик обязуется:");
            AddParagraph("- Принять и оплатить поставленные товары в соответствии с условиями настоящего договора.");

            AddParagraph("6. Ответственность сторон", true);
            AddParagraph("6.1. В случае нарушения условий договора стороны несут ответственность в соответствии с действующим законодательством Российской Федерации.");

            AddParagraph("7. Прочие условия", true);
            AddParagraph("7.1. Все изменения и дополнения к настоящему договору действительны только при наличии письменного согласия обеих сторон.");
            AddParagraph("7.2. Настоящий договор составлен в двух экземплярах, имеющих равную юридическую силу, по одному для каждой из сторон.");

            AddParagraph("8. Реквизиты и подписи сторон", true);
            AddParagraph($"Поставщик:\nНазвание: {supplierName}\nДиректор: {supplierDirector}\nПодпись: ___________________");
            AddParagraph($"Заказчик:\nНазвание: {customerName}\nДиректор: {customerDirector}\nПодпись: ___________________");

            



            MessageBox.Show("Отчет создан!");
        }
    }
}
