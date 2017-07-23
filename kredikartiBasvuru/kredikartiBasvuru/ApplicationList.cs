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
    public partial class ApplicationList : Form
    {
        //global bağlantı nesnesi. bu classstaki butun methodlarda yeni instance ile birlikte kullanılabilir.
        OleDbConnection baglanti = null;

        //class ın constructor'u. class initalise edildiğinde ilk bu method çalışır. bu class için dışardan parametre alacaksa bu methot üzerinden yönetilebilir.
        public ApplicationList()
        {
            InitializeComponent();
        }
        
        //
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            ApplicationScreen appS = new ApplicationScreen();
           appS.Show();
           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //aşağıda bu class içindeki setdata methodu çağrılır.
            //set data methodu DataGridViewRow türünden bir nesne alır.
            SetData(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);
            
        }

        private void ApplicationList_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            GetData();
           
            
        }

        
        public void GetData()
        {
            OleDbDataAdapter adaptor;
            DataSet verikumesi;
            try
            {   //bu nesneye connctionstringimizi veriyoruz.
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=C:\\DB\\Database1.accdb");
                //bu nesnede belirttiğimiz sorguyu tanımlıyoruz. bsğlsntı nesnesine bağlıyoruz.
                adaptor = new OleDbDataAdapter("Select * from APPLICATION", baglanti);
                verikumesi = new DataSet();
                baglanti.Open();
                //burada adaptor nesnesiyle sorguyu çalıştırıp dönen sonucu verikumesi adlı datasete dolduruyoruz.
                adaptor.Fill(verikumesi, "APPLICATION");
                //doldurduğumuz dataset içindeki datatable içindeki verileri şu şekilde gride bağlıyoruz.
                dataGridView1.DataSource = verikumesi.Tables["APPLICATION"];
                baglanti.Close();
            }
            catch
            {

            }
        }

        public void SetData(DataGridViewRow row)
        {
            //ApplicationScreen formunun instance sini oluşturuyoruz.
            //Bu form un consructoru DataGridViewRow türünden bir nesne alıyor ve bu nesneyi burada gönderiyoruz.
            ApplicationScreen appscreen = new ApplicationScreen(row);
            //burada ApplicationScreen formunun FormClosing eventine yeni oluşturduğumuz appscreen_FormClosing methodunu bağladık. Form kapatıldığında bu method çalışacak.
            appscreen.FormClosing += appscreen_FormClosing;
            appscreen.Show();
        }

        void appscreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            GetData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SetData(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            GetData();
        }

        public void DeleteData()
        {
            try
            {
                DataSet ds = new DataSet();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();

                OleDbCommand komut = new OleDbCommand
                ("DELETE FROM APPLICATION WHERE CustomerID=" +dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(), baglanti);

                komut.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Kayıt Silindi!");



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);

            }

        }
        
        
    }
}
