@@ -0,0 +1,144 @@
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtOtomasyonu
{
    public partial class FrmAnaForm : Form
    {
        

        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void giderAlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void FrmAnaForm_Load_1(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet2.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter1.Fill(this.yurtOtomasyonuDataSet2.Ogrenci);
            timer3.Start();
      
        }

       

        private void timer3_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //ANA MENUDEN TIKLANINCA YONLENDIRILEN YERLERIN BAGLANMASI
        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        { 
            System.Diagnostics.Process.Start("Calc.exe");   //HESAP MAKINASI
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MsPaint.exe");  //PAINT
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
             axWindowsMediaPlayer1.URL="http://cast1.taksim.fm:8000";  //RADYOO
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OgrenciForm fr = new OgrenciForm();  //OGR FORM
            fr.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmOgrListe fr = new FrmOgrListe();
            fr.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FrmOgrListe fr = new FrmOgrListe();
            fr.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }
        private void bölümListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            FrmOdemeler fr = new FrmOdemeler();
            fr.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGider fr = new FrmGider();
            fr.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            FrmGiderListesi fr = new FrmGiderListesi();
            fr.Show();

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            FrmGelirİstatistikleri fr = new FrmGelirİstatistikleri();
            fr.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            FrmYoneticiDuzenle fr = new FrmYoneticiDuzenle();
            fr.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            FrmPersonel fr = new FrmPersonel();
            fr.Show();
        }

        

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotEkle fr = new FrmNotEkle();
            fr.Show();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Otomasyon Proje Yönetimi Ödevine Ait Olup Büşra ve Zahid Tarafından Yapılmıştır.", "Öğrenci Yurt Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
    }
}