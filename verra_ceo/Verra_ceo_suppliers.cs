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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DataTable = System.Data.DataTable;

namespace NEfotobudka_githubik.verra_ceo
{
    public partial class Verra_ceo_suppliers : Form
    {
        //
        // ПОДКЛЮЧЕНИЕ К БАЗЕ БРОУ НЕ ТРОГАТБ
        private SqlConnection conn = Connection.doConnection();
        // 
        // 
        // 
        public Verra_ceo_suppliers()
        {
            InitializeComponent();
        }

        private void Verra_ceo_suppliers_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ПОСТАВЩИК", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM ПОСТАВКА", conn);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;

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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ПОСТАВЩИК", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            else
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ПОСТАВЩИК WHERE Название_поставщика = @surname", conn);
                cmd.Parameters.AddWithValue("@surname", textBoxName.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_addSupplier form = new Verra_ceo_addSupplier();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_orderShiet form = new Verra_ceo_orderShiet();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string supplierName = "";
            string supplierDirector = "";
            string customerName = "";
            string customerDirector = "";









            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Add();
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





            MessageBox.Show("Договор создан!");
        }
    }
}
