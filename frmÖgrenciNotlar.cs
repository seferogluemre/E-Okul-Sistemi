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

namespace E_Okul_Sistemi
{
    public partial class frmÖgrenciNotlar : Form
    {
        public frmÖgrenciNotlar()
        {
            InitializeComponent();
        }
        Sql bgl = new Sql();
        public string numara;
        private void frmÖgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Select DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM From Notlar1 INNER JOIN Dersler1 ON Notlar1.DERSID=Dersler1.DERSID where ÖGRID=@p1", bgl.baglantı());
            kmt.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter dr = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            TxtÖgrId.Text = numara.ToString();


            //Girilen Id göre ögrenci adını çekme
            SqlCommand ÖgrSorgu = new SqlCommand("Select ÖGRAD,ÖGRSOYAD From ÖgrenciKayıt1 where ÖGRID=@ÖgrId", bgl.baglantı());
            ÖgrSorgu.Parameters.AddWithValue("@ÖgrId", TxtÖgrId.Text);
            SqlDataReader ÖgrData = ÖgrSorgu.ExecuteReader();
            while (ÖgrData.Read())
            {
                textBox2.Text = ÖgrData["ÖGRAD"].ToString();
                textBox3.Text = ÖgrData["ÖGRSOYAD"].ToString();
            }
            bgl.baglantı().Close();
        }
    }
}
