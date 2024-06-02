using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace E_Okul_Sistemi
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        public int ÖgrId;
        public string ad = "";
        public string soyad = "";
        readonly Sql bgl = new Sql();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmÖgretmen frögretmen = new FrmÖgretmen();
            frögretmen.Show();
            this.Hide();
        }
        private void frmGiris_Load(object sender, EventArgs e)
        {         
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmÖgrenciNotlar frmÖgrNotlar = new frmÖgrenciNotlar();        
            SqlCommand kmt = new SqlCommand("Select * from ÖgrenciKayıt1 where ÖGRID=@p1", bgl.baglantı());
            kmt.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                frmÖgrNotlar.numara = textBox1.Text;
                ad = dr["ÖGRAD"].ToString();
                soyad = dr["ÖGRSOYAD"].ToString();
                frmÖgrNotlar.Show();
            }
            else
            {
                MessageBox.Show("Ögrenci Bulunamadı", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            bgl.baglantı().Close();
        }
    }
}
