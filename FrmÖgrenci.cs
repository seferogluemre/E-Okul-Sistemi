using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace E_Okul_Sistemi
{
    public partial class FrmÖgrenci : Form
    {
        public FrmÖgrenci()
        {
            InitializeComponent();
        }
        //DataSet üzerinden ilişkili ögrenci ve kulüpler tablosunu referanslama
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        //SQL Database Baglantısı
        SqlConnection baglantı = new SqlConnection("Data Source=EMRE_SEFEROGLU\\SQLEXPRESS;Initial Catalog=eokulsistem;Integrated Security=True;Encrypt=False");

        //Ögrenci cinsiyet degişkeni
        string OgrCins = "";
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult tepki = new DialogResult();
            tepki = MessageBox.Show("Uygulamadan Ayrılıyorsunuz?", "YES E-Okul Uygulaması", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tepki == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void FrmÖgrenci_Load(object sender, EventArgs e)
        {
            //CRUD İşlem Butonlarını Manuel olarak Çerçeve renk ayarları
            //Listele Butonu
            buttonListele.FlatStyle = FlatStyle.Flat;
            buttonListele.FlatAppearance.BorderSize = 0;       
            //Güncelle Butonu
            buttonGüncelle.FlatStyle = FlatStyle.Flat;
            buttonGüncelle.FlatAppearance.BorderSize = 0;
            buttonGüncelle.BackColor = System.Drawing.Color.Blue;
            //Ekle Butonu
            buttonEkle.FlatStyle = FlatStyle.Flat;
            buttonEkle.FlatAppearance.BorderSize = 0;
            buttonEkle.BackColor = System.Drawing.Color.Green;
            //Sil butonu
            ButtonSil.FlatStyle = FlatStyle.Flat;
            ButtonSil.FlatAppearance.BorderSize = 0;
            ButtonSil.BackColor = System.Drawing.Color.MediumTurquoise;
            dataGridView1.DataSource = ds.OgrencilerListesi();
            baglantı.Open();
            SqlCommand Kmt = new SqlCommand("Select * from Kulüpler1", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(Kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbBxKulüp.DisplayMember = "KULÜPAD";
            CmbBxKulüp.ValueMember = "KULÜPID";
            CmbBxKulüp.DataSource = dt;
            baglantı.Close();
        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {                
            if (textbxÖGRAD.Text == "" || textbxÖGRSOYAD.Text == "")
            {
                MessageBox.Show("Ögrenci Eklenirken Hata Oluştu Daha sonra tekrar deneyin", "YES E-Okul Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textbxÖGRAD.Text != "" && textbxÖGRSOYAD.Text != "")
            {
                ds.ÖgrenciEkleme(textbxÖGRAD.Text, textbxÖGRSOYAD.Text, OgrCins, byte.Parse(CmbBxKulüp.SelectedValue.ToString()));
                MessageBox.Show("Ögrenci Ekleme İşlemi Başarılı", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dataGridView1.DataSource = ds.OgrencilerListesi();
            }
        }    
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secılen_row = dataGridView1.SelectedCells[0].RowIndex;
            textbxÖGRID.Text = dataGridView1.Rows[secılen_row].Cells[0].Value.ToString();
            textbxÖGRAD.Text = dataGridView1.Rows[secılen_row].Cells[1].Value.ToString();
            textbxÖGRSOYAD.Text = dataGridView1.Rows[secılen_row].Cells[2].Value.ToString();      
        }
        private void ButtonSil_Click(object sender, EventArgs e)
        {
            if (textbxÖGRID.Text=="")
            {
                MessageBox.Show("Listeden Silincek Ögrenci Bulunamadı", "YES E-Okul sistemi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            if (textbxÖGRID.Text!="")
            {
                baglantı.Open();
                SqlCommand kmt = new SqlCommand("Delete from ÖgrenciKayıt1 where ÖGRID='"+textbxÖGRID.Text+"'", baglantı);

                kmt.ExecuteNonQuery();
                MessageBox.Show("Seçilen Ögrenci Listeden silindi", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dataGridView1.DataSource = ds.OgrencilerListesi();
                textbxÖGRID.Text = "";
                textbxÖGRAD.Text = "";
                textbxÖGRSOYAD.Text = "";
                CmbBxKulüp.Text = "";
            }
            baglantı.Close();
        }
        private void buttonListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrencilerListesi();
        }
        private void buttonGüncelle_Click(object sender, EventArgs e)
        {
            ds.ÖgrenciGüncelleme(textbxÖGRAD.Text, textbxÖGRSOYAD.Text, byte.Parse(CmbBxKulüp.SelectedValue.ToString()), OgrCins, byte.Parse(textbxÖGRID.Text));
            MessageBox.Show("Ögrenci Bilgileri güncellendi", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.OgrencilerListesi();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                OgrCins = "Erkek";
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                OgrCins = "Bayan";
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxÖgrSorgu.Text == "")
                {
                    MessageBox.Show("Hatalı deger girişi");
                }
                if (textBoxÖgrSorgu.Text != "")
                {
                    MessageBox.Show("Sorgu başarılı Kayıt bulundu", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = ds.ÖgrenciSorgu(textBoxÖgrSorgu.Text);
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }
    }
}