using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Okul_Sistemi
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        private static readonly DataSet1TableAdapters.Dersler1TableAdapter dersler1TableAdapter = new DataSet1TableAdapters.Dersler1TableAdapter();
        DataSet1TableAdapters.Dersler1TableAdapter ds = dersler1TableAdapter;
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult tepki = new DialogResult();
            tepki = MessageBox.Show("Uygulamadan Ayrılıyorsunuz?", "YES E-Okul Uygulaması", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tepki == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(textbxDersad.Text);
            MessageBox.Show("Yeni Ders Eklendi","Başarılı İşlem",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void buttonListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void ButtonSil_Click(object sender, EventArgs e)
        {
            ds.Dersil(byte.Parse(textbxDersıd.Text));
            MessageBox.Show("Ders listeden silindi", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void buttonGüncelle_Click(object sender, EventArgs e)
        {
            ds.DersGUNCELLE(textbxDersad.Text, byte.Parse(textbxDersıd.Text));
            MessageBox.Show("Ders Listesi Güncellendi", "E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textbxDersıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textbxDersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
