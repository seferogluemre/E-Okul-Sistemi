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
    public partial class FrmKulüpİşlemleri : Form
    {
        public FrmKulüpİşlemleri()
        {
            InitializeComponent();
        }
        //Sql Connection Baglantısı
        Sql bgl = new Sql();
        void Listele()
        {
            //Kulüpler tablosunu listeleme
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kulüpler1", bgl.baglantı());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void Ekleme()
        {
            try
            {
                if (textbxKulüpad.Text!="")
                {
                    if (textbxKulüpad.Text.Length>3)
                    {
                        //Eger Ad alanı boş degilse ve karakter uzunlugu 3 den büyükse Ekleme yapma
                        SqlCommand kmt = new SqlCommand("insert into Kulüpler1 (KULÜPAD) values (@p1) ", bgl.baglantı());
                        kmt.Parameters.AddWithValue("@p1", textbxKulüpad.Text);
                        kmt.ExecuteNonQuery();
                        MessageBox.Show("Kulüp Listeye Eklendi", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bgl.baglantı().Close();
                        Listele();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Deger Girişi Alanları Dogru Doldurun", "E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız!!!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString()); 
            }
            bgl.baglantı().Close();
        }
        void Güncelleme()
        {
            try
            {
                if (textbxKulüpad.Text!="")
                {
                    SqlCommand kmt = new SqlCommand("Update Kulüpler1 set KULÜPAD=@p1 where KULÜPID=@p2", bgl.baglantı());
                    kmt.Parameters.AddWithValue("@p1", textbxKulüpad.Text);
                    kmt.Parameters.AddWithValue("@p2", textbxkulüpıd.Text);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Kulüp Listesi Güncellendi", "E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    bgl.baglantı().Close();
                    Listele();
                    textbxkulüpıd.Clear();
                    textbxKulüpad.Clear();
                }
                else
                {
                    MessageBox.Show("Hatalı Deger girişi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        void Silme()
        {
            try
            {
                if (textbxkulüpıd.Text != "")
                {
                    SqlCommand slkmt = new SqlCommand("Delete From Kulüpler1 where KULÜPID=@p1", bgl.baglantı());
                    slkmt.Parameters.AddWithValue("@p1", textbxkulüpıd.Text);
                    slkmt.ExecuteNonQuery();
                    MessageBox.Show("Kulüp listeden silindi", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Listele();
                    textbxkulüpıd.Clear();
                    textbxKulüpad.Clear();
                }
                else
                {
                    MessageBox.Show("Hatalı Deger girişi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                      bgl.baglantı().Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }
        private void FrmKulüpİşlemleri_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            Ekleme();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textbxkulüpıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textbxKulüpad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult tepki = new DialogResult();
            tepki = MessageBox.Show("Uygulamadan Ayrılıyorsunuz?", "YES E-Okul Uygulaması", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tepki==DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightYellow;
        }
        private void ButtonSil_Click(object sender, EventArgs e)
        {
            Silme();
        }
        private void buttonGüncelle_Click(object sender, EventArgs e)
        {
            Güncelleme();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
