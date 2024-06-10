using NEfotobudka_githubik.verra_ceo;
using NEfotobudka_githubik.verra_admin;
using NEfotobudka_githubik.verra_trainer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEfotobudka_githubik
{
    public partial class Vhod : Form
    {
        public Vhod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_ceo_menu form = new Verra_ceo_menu();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_admin_menu form = new Verra_admin_menu();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
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
