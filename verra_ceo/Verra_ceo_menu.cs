using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEfotobudka_githubik.verra_ceo
{
    public partial class Verra_ceo_menu : Form
    {
        public Verra_ceo_menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_employee form = new Verra_ceo_employee();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_suppliers form = new Verra_ceo_suppliers();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_ostatki form = new Verra_ceo_ostatki();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void Verra_ceo_menu_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_studio form = new Verra_ceo_studio();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_analytics form = new Verra_ceo_analytics();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_otchetik form = new Verra_ceo_otchetik();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Vhod form = new Vhod();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }
    }
}
