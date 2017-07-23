using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kredikartiBasvuru
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "123")
            {
                MainMenu yeni = new MainMenu();
                yeni.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı giriş.Tekrar Deneyiniz.");
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        

        

        
    }
}
