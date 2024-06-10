using NEfotobudka_githubik.verra_ceo;
using NEfotobudka_githubik.verra_trainer;
using NEfotobudka_githubik.verra_admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEfotobudka_githubik.verra_admin
{
    public partial class Verra_admin_menu : Form
    {
        public Verra_admin_menu()
        {
            InitializeComponent();
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
        
        private void Verra_admin_menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_admin_clients form = new Verra_admin_clients();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_admin_suppliers form = new Verra_admin_suppliers();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
                // Instantiate the second form
                Verra_admin_sostav_group form = new Verra_admin_sostav_group();
                // Show the second form
                form.Show();
                // Optionally, hide the current form
                this.Hide();
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_admin_group form = new Verra_admin_group();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_admin_programms form = new Verra_admin_programms();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_admin_individ form = new Verra_admin_individ();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }
    }
}
