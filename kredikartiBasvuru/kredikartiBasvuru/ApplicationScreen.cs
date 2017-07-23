using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kredikartiBasvuru
{
    public partial class ApplicationScreen : Form
    {
        public bool isUpdate = false;
        

        public ApplicationScreen()
        {
            InitializeComponent();
        }

        public ApplicationScreen(DataGridViewRow set)
        {
            isUpdate = true;
            InitializeComponent();
            SetData(set);
        }

        OleDbConnection baglanti = null;

        int CustomerId = 0;

        public bool dolu = false;
      
        private void ApplicationScreen_Load(object sender, EventArgs e)
        {
           
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            GetData();
            txtName.Focus();

            if (isUpdate)
            {

                label4.Text = "Müşteri Kaydını Güncelle";
                btnUpdate.Location = new Point(654,447);
                btnNew.Location = new Point(560,447);
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                isUpdate = true;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnAdd.Location = new Point(654, 447);
                btnNew.Location = new Point(560, 447);
                isUpdate = false;

            }
            
 
        }

        public void GetData()
        {
            OleDbDataAdapter adaptor;
            DataSet verikumesi;
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=C:\\DB\\Database1.accdb");
                adaptor = new OleDbDataAdapter("Select * from APPLICATION", baglanti);
                verikumesi = new DataSet();
                baglanti.Open();
                adaptor.Fill(verikumesi, "APPLICATION");
                
                baglanti.Close();
            }
            catch
            {

            }
        }

        public void InsertData()
        {
            try
            {
                if (SelectTC(txtTcNo.Text))
                {
                    throw new Exception("Bu T.C. Kimlik Numarasına Ait Başvuru Mevcuttur.");
                }
                else
                {
                    
                        foreach (Control ctl in this.Controls)
                            if (ctl is TextBox)
                            {
                                if (ctl.Text == String.Empty)
                                {
                                    throw new Exception("Lütfen Zorunlu alanları doldurunuz!");
                                    
                                }
                            }
                    
                        DataSet ds = new DataSet();
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        ds.Clear();
                        OleDbCommand komut = new OleDbCommand
                        ("INSERT INTO APPLICATION (Address,TelephoneNumber,MaritalStatus,YourHome,EducationStatus,EmailAddress,Name,Surname,TcNo) VALUES ('" + txtAddress.Text + "','" + txtTelephoneNumber.Text + "','" + cmbMaritalStatus.Text + "','" + cmbYourHome.Text + "','" + cmbEducationStatus.Text + "','" + txtEmailAddress.Text + "','" + txtName.Text + "','" + txtSurname.Text + "','" + txtTcNo.Text + "')", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kayıt Eklendi.");
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Cleaner()
        {
            txtAddress.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtTcNo.Clear();
            txtTelephoneNumber.Clear();
            txtEmailAddress.Clear();
            txtAddress.Clear();
            cmbEducationStatus.Text = "";
            cmbMaritalStatus.Text = "";
            cmbYourHome.Text = "";
            
        }

        public void InsertCustomerData()
        {
            try
            {
                
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                OleDbCommand komut = new OleDbCommand
                ("INSERT INTO CUSTOMER (CustomerType,MotherOSurname,TcNO,CustomerName,CustomerSurname) VALUES ('POTENTIAL','','" + 
                txtTcNo.Text + "','" + 
                txtName.Text + "','" + 
                txtSurname.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Müşteri Tablosuna Potansiyel Müşteri Eklenmiştir.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }
      
        public bool SelectTC(string tc)
        {
               bool isCount = false;
               baglanti.Open();
               baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=C:\\DB\\Database1.accdb");
               OleDbDataAdapter adaptor = new OleDbDataAdapter("Select * From APPLICATION where  TcNO='" + tc + "'", baglanti);
               DataSet verikumesi = new DataSet();
               baglanti.Open();
               adaptor.Fill(verikumesi, "APPLICATION");
               if (verikumesi.Tables.Count > 0 && verikumesi.Tables[0].Rows.Count > 0)
               {
                   isCount = true;
               }
               baglanti.Close();
               return isCount;
        }
        
        public void UpdateData()
        {
            try
            {
                
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();

                OleDbCommand komut = new OleDbCommand
                ("UPDATE APPLICATION SET Address='" + txtAddress.Text + "' ,Name='" + txtName.Text + "',Surname='" + txtSurname.Text + "' ,TcNo='" + txtTcNo.Text +"', TelephoneNumber='" + txtTelephoneNumber.Text + "', MaritalStatus='" + cmbMaritalStatus.Text + "', EducationStatus='" + cmbEducationStatus.Text + "' , EmailAddress='" + txtEmailAddress.Text + "' , YourHome='" + cmbYourHome.Text + "' WHERE CustomerID = " + CustomerId.ToString(), baglanti);
                komut.ExecuteNonQuery();
                
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
                ("DELETE FROM APPLICATION WHERE CustomerID=" + CustomerId.ToString(), baglanti);

                komut.ExecuteNonQuery();
                
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi!");



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);

            }

        }

        public void SetData(DataGridViewRow set)
        {
            
            this.txtEmailAddress.Text = set.Cells[9].Value.ToString();
            this.cmbEducationStatus.Text = set.Cells[8].Value.ToString();
            this.cmbYourHome.Text = set.Cells[7].Value.ToString();
            this.cmbMaritalStatus.Text = set.Cells[6].Value.ToString();
            this.txtTelephoneNumber.Text = set.Cells[5].Value.ToString();
            this.txtAddress.Text = set.Cells[4].Value.ToString();
            this.txtName.Text=set.Cells[2].Value.ToString();
            this.txtSurname.Text=set.Cells[3].Value.ToString();
            this.txtTcNo.Text=set.Cells[1].Value.ToString();
            CustomerId = (int)set.Cells[0].Value;
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
               
             InsertData();

              if (GetIsCustomer(txtTcNo.Text)==false)
             {
              InsertCustomerData();
             }
              GetData();
              Cleaner();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private bool GetIsCustomer(string tckn)
        {
            bool isCustomer = false;
            try
            {
                DataSet ds = new DataSet();
                if ((baglanti.State == ConnectionState.Closed))
                    baglanti.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter
                    ("SELECT * FROM CUSTOMER WHERE TcNO = '" + tckn + "'", baglanti);
                adp.Fill(ds, "CUSTOMER");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        isCustomer = true;
                    }
                    else
                    {
                        isCustomer = false;
                    }
                }
                else
                {
                    isCustomer = false;
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
            return isCustomer;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            
            UpdateData();
            GetData();
            Cleaner();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            GetData();
            Cleaner();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Cleaner();
        }

        

        
    }
}