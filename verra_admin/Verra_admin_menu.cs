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
    }
}
