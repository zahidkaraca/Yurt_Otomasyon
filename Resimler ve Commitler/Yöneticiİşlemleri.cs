using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace YurtOtomasyonu
{
    public partial class FrmYoneticiDuzenle : Form
    {
        public FrmYoneticiDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HMA2FOJ;Initial Catalog=YurtOtomasyonu;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmYoneticiDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet10.Admin' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet10.Admin);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Admin (YoneticiAd,YoneticiSifre) values (@p1,@p2)", baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSifre.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yönetici Eklendi");
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet10.Admin);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, sifre;
            secilen = dataGridView1.SelectedCells[0].RowIndex;

            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtYoneticiid.Text = id;
            TxtKullaniciAdi.Text = ad;
            TxtSifre.Text = sifre;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Admin where Yoneticiid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtYoneticiid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Gerçekleşti");
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet10.Admin);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update Admin set YoneticiAd=@p2,YoneticiSifre=@p3 where Yoneticiid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtYoneticiid.Text);
            komut3.Parameters.AddWithValue("@p2", TxtKullaniciAdi.Text);
            komut3.Parameters.AddWithValue("@p3", TxtSifre.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Gerçekleşti");
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet10.Admin);
        }
    }
}