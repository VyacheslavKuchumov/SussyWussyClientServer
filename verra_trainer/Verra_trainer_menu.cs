using NEfotobudka_githubik.verra_ceo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEfotobudka_githubik.verra_trainer
{
    public partial class Verra_trainer_menu : Form
    {
        public Verra_trainer_menu()
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_trainer_gr_schedule form = new Verra_trainer_gr_schedule();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_trainer_ind_schedule form = new Verra_trainer_ind_schedule();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Instantiate the second form
            Verra_trainer_sostav_group form = new Verra_trainer_sostav_group();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();

        }
    }
}
