using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kredikartiBasvuru
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = null;

        int CustomerId = 0;

       

        private void Form1_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           
           
            GetData();
            GetCustomerType();
         
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();

            GetData();
            
        }

        public void SetData(DataGridViewRow row) {
            
            txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
            txtCustomerSurname.Text = row.Cells["CustomerSurName"].Value.ToString();
            txtBalance.Text = row.Cells["Balance"].Value.ToString();
            txtDateOfBirth.Text = row.Cells["DateOfBirth"].Value.ToString();
            txtMotherSurname.Text = row.Cells["MotherOSurname"].Value.ToString();
            txtPlaceOfBirth.Text = row.Cells["PlaceOfBirth"].Value.ToString();
            txtTcNO.Text = row.Cells["TcNO"].Value.ToString();
            cmbCustomerType.Text = row.Cells["CustomerType"].Value.ToString();
            CustomerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
        }

        public void GetData() 
        
        {
            OleDbDataAdapter adaptor;
            DataSet verikumesi;
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=C:\\DB\\Database1.accdb");
                adaptor = new OleDbDataAdapter("Select * from CUSTOMER ", baglanti);
                verikumesi = new DataSet();
                baglanti.Open();
                adaptor.Fill(verikumesi, "CUSTOMER");   
                dataGridView1.DataSource = verikumesi.Tables["CUSTOMER"];
                baglanti.Close();
            }
            catch
            {

            }
        }

        public void GetCustomerType()
        {
            OleDbDataAdapter adaptor;
            DataSet verikumesi;
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=C:\\DB\\Database1.accdb");
                adaptor = new OleDbDataAdapter("Select * from PARAMETER S where S.GROUP = 'CUSTOMER_TYPE'", baglanti);
                verikumesi = new DataSet();
                baglanti.Open();
                adaptor.Fill(verikumesi, "PARAMETER");
                baglanti.Close();

                DataTable tbCombo = verikumesi.Tables["PARAMETER"];
                foreach (DataRow item in tbCombo.Rows)
                {
                    cmbCustomerType.Items.Add(item["ParameterName"].ToString());
                    
                }

            }
            catch
            {

            }
        
        }

        public void InsertData() {
            try
            {
                foreach (Control ctl in this.Controls)
                    if (ctl is TextBox)
                    {
                        if (ctl.Text == String.Empty)
                        {
                            throw new Exception("Lütfen Zorunlu Alanları Doldurunuz!");
                           

                        }
                    }
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                OleDbCommand komut = new OleDbCommand
                ("INSERT INTO CUSTOMER (CustomerType,MotherOSurname,TcNO,CustomerName,CustomerSurname,Balance,PlaceOfBirth,DateOfBirth) VALUES ('" + cmbCustomerType.Text + "','" + txtMotherSurname.Text + "','" + txtTcNO.Text + "','" + txtCustomerName.Text + "','" + txtCustomerSurname.Text + "','" + txtBalance.Text + "','" + txtPlaceOfBirth.Text + "','" + txtDateOfBirth.Value.ToShortDateString() + "')", baglanti);
                komut.ExecuteNonQuery();
                dataGridView1.Update();
                baglanti.Close();
                MessageBox.Show("Kayıt Eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateData()
        {
            try
            {
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                OleDbCommand komut = new OleDbCommand
                ("UPDATE CUSTOMER SET CustomerName='" 
                + txtCustomerName.Text 
                + "' ,  CustomerSurname='" 
                + txtCustomerSurname.Text 
                + "', MotherOSurname='" 
                + txtMotherSurname.Text 
                + "' , Balance=" 
                + txtBalance.Text 
                + " , DateOfBirth='" 
                + txtDateOfBirth.Value.ToShortDateString() 
                + "' , PlaceOfBirth='" 
                + txtPlaceOfBirth.Text 
                + "' , TcNO='" + txtTcNO.Text 
                + "' , CustomerType='" 
                + cmbCustomerType.Text 
                + "' WHERE CustomerID = " 
                + CustomerId.ToString(), baglanti);
                komut.ExecuteNonQuery();
                dataGridView1.Update();
                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);

            }
        }

        public void DeleteData()
        {
            try
            {

                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();

                OleDbCommand komut = new OleDbCommand
                ("DELETE FROM CUSTOMER WHERE CustomerID="+ CustomerId.ToString(), baglanti);

                komut.ExecuteNonQuery();
                dataGridView1.Update();
                dataGridView1.Refresh();
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi!");



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);

            }
        
        }
    
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SetData(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
            GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            GetData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Location =new Point (193,12);
            btnDelete.Location =new Point (276,12);
            txtBalance.Clear();
            txtCustomerName.Clear();
            txtCustomerSurname.Clear();
            txtMotherSurname.Clear();
            txtPlaceOfBirth.Clear();
            txtTcNO.Clear();
            cmbCustomerType.Text = "";
            
            

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                if ((baglanti.State == ConnectionState.Closed))
                    baglanti.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter
                    ("SELECT *FROM CUSTOMER WHERE TcNO LIKE '" +
        txtSearch.Text + "%'", baglanti);
                adp.Fill(ds,"CUSTOMER");
                dataGridView1.DataSource = ds.Tables["CUSTOMER"];
               
                
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Location = new Point(110, 12);
            btnDelete.Location = new Point(193, 12);
        }

        

        

        

        

        
        

        

        
        

       

    }
}
