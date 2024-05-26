using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEfotobudka_githubik.ceo
{
    public partial class CEO_menu : Form
    {
        public CEO_menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            CEO_company_management form = new CEO_company_management();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            CEO_employee_management form = new CEO_employee_management();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CEO_suppliers form = new CEO_suppliers();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }
    }
}
