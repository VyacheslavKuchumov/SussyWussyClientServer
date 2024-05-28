using NEfotobudka_githubik.admin;
using NEfotobudka_githubik.ceo;
using NEfotobudka_githubik.photo;
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

namespace NEfotobudka_githubik
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-E1GMR9K;Initial Catalog=NE_photo_DB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT password FROM users WHERE username = @name";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", textBoxLogin.Text);

                    // Execute the query and retrieve the password
                    object result = cmd.ExecuteScalar();
                    
                    if (result != null)
                    {
                        string password = result.ToString();
                        if (password == textBoxPass.Text)
                        {
                            switch (textBoxLogin.Text) {
                                case "boss":
                                    CEO_menu form = new CEO_menu();
                                    // Show the second form
                                    form.Show();
                                    // Optionally, hide the current form
                                    this.Hide();
                                    break;
                                case "admin":
                                    Admin_menu form1 = new Admin_menu();
                                    // Show the second form
                                    form1.Show();
                                    // Optionally, hide the current form
                                    this.Hide();
                                    break;
                                case "photo":
                                    Photo_menu form3 = new Photo_menu();
                                    // Show the second form
                                    form3.Show();
                                    // Optionally, hide the current form
                                    this.Hide();
                                    break;


                            }
                        }
                        else
                        {
                            MessageBox.Show("Введен неверный пароль!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введен неверный логин или пароль!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
