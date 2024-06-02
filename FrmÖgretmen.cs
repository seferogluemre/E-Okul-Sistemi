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
    public partial class FrmÖgretmen : Form
    {
        public FrmÖgretmen()
        {
            InitializeComponent();
        }

        private void FrmÖgretmen_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulüpİşlemleri frKulpişlem = new FrmKulüpİşlemleri();
            frKulpişlem.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
           
        }

        private void BtnÖgrenc_Click(object sender, EventArgs e)
        {
            FrmÖgrenci frmÖgrenci = new FrmÖgrenci();
            frmÖgrenci.Show();
        }

        private void BtnSınavnot_Click(object sender, EventArgs e)
        {
            FrmSınavnotlar frsnavnot = new FrmSınavnotlar();
            frsnavnot.Show();
            
        }

        private void BtnÖgretmenler_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Alan Yakında Hizmete sunulcaktır", "YES E-Okul Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
