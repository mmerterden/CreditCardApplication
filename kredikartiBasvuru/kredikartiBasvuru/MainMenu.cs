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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void ApplicationList_Click(object sender, EventArgs e)
        {
            ApplicationList app = new ApplicationList();
            app.Show();

        }
        private void CustomerScreen_Click(object sender, EventArgs e)
        {
            Customer b = new Customer();
            b.Show();
           
        }

        
        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        
      
    }
}
