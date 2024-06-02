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
    public partial class FrmSınavnotlar : Form
    {
        public FrmSınavnotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Notlar1TableAdapter ds = new DataSet1TableAdapters.Notlar1TableAdapter();
        //SQL Database Baglantısı
        SqlConnection baglantı = new SqlConnection("Data Source=EMRE_SEFEROGLU\\SQLEXPRESS;Initial Catalog=eokulsistem;Integrated Security=True;Encrypt=False");
        int sınav1, sınav2, sınav3, proje;
        void AracTemizle()
        {
            textbxÖGRID.Text = "";
            CmbBxDERS.SelectedIndex = -1;
            textbxsınav1.Text = "";
            textbxsınav2.Text = "";
            textbxSınav3.Text = "";
            textBoxpROJE.Text = "";
            TEXTboxORTALAM.Text = "";
            textbxDurum.Text = "";
        }    
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Mesaj Kutusu aracılıgıyla kullanıcıyı diyaloga sokma ve Çıkış yaptırma
            DialogResult tepki = new DialogResult();
            tepki = MessageBox.Show("Uygulamadan Ayrılıyorsunuz?", "YES E-Okul Uygulaması", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tepki == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void FrmSınavnotlar_Load(object sender, EventArgs e)
        {
            //Comboboxa Dersler tablosundan Dersleri aktarma
            baglantı.Open();
            SqlCommand Kmt = new SqlCommand("Select * from Dersler1", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(Kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbBxDERS.DisplayMember = "DERSAD";
            CmbBxDERS.ValueMember = "DERSID";
            CmbBxDERS.DataSource = dt;
            baglantı.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //DataSet Üzerinden datagride Ögrenci listesi aktarma
            if (textbxÖGRID.Text!="")
            {
                dataGridView1.DataSource = ds.NotListesi(int.Parse(textbxÖGRID.Text));
            }
            else
            {
                MessageBox.Show("Ögrenci Bulunamadı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Datagridde herhangi hücre tıklamasında tıkladıgı satıra ait tüm bilgileri araçlara taşıma
            textbxÖGRID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textbxsınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textbxsınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textbxSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxpROJE.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TEXTboxORTALAM.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textbxDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            AracTemizle();
        }
        double ortalama;
        private void buttonHesapla_Click(object sender, EventArgs e)
        {               
            sınav1 = Convert.ToInt16(textbxsınav1.Text);
            sınav2 = Convert.ToInt16(textbxsınav2.Text);
            sınav3=Convert.ToInt16(textbxSınav3.Text);
            proje = Convert.ToInt16(textBoxpROJE.Text);
            ortalama = (sınav1 + sınav2 + sınav3 + proje) / 4;
            TEXTboxORTALAM.Text = ortalama.ToString();
            if (ortalama>=50)
            {
                textbxDurum.Text = "True";
            }
            else
            {
                textbxDurum.Text = "False";
            }
        }
        private void buttonGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                ds.NotGüncelleme(byte.Parse(CmbBxDERS.SelectedValue.ToString()), int.Parse(textbxÖGRID.Text), byte.Parse(textbxsınav1.Text), byte.Parse(textbxsınav2.Text), byte.Parse(textbxSınav3.Text), byte.Parse(textBoxpROJE.Text), decimal.Parse(TEXTboxORTALAM.Text), bool.Parse(textbxDurum.Text), int.Parse(textbxÖGRID.Text));
            }
            catch (Exception hataMesaj)
            {
                MessageBox.Show("Sistemde Güncelleme Yaparken Hata tespit edildi"+hataMesaj.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);        
            }
        }
    }
}
