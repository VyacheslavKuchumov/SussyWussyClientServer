﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEfotobudka_githubik.admin
{
    public partial class Admin_menu : Form
    {
        public Admin_menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            // Show the second form
            form.Show();
            // Optionally, hide the current form
            this.Hide();
        }
    }
}
