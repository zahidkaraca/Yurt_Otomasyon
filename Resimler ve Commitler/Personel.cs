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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HMA2FOJ;Initial Catalog=YurtOtomasyonu;Integrated Security=True");

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet12.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter1.Fill(this.yurtOtomasyonuDataSet12.Personel);
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet11.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDataSet11.Personel);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtPersoneliAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtGorev.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
            this.personelTableAdapter1.Fill(this.yurtOtomasyonuDataSet12.Personel);
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDataSet11.Personel);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("delete from Personel where Personelid=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtPersonelid.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Gerçekleşti");
            this.personelTableAdapter1.Fill(this.yurtOtomasyonuDataSet12.Personel);
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDataSet11.Personel);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, gorev;
            secilen = dataGridView1.SelectedCells[0].RowIndex;

            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            gorev = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtPersonelid.Text = id;
            TxtPersoneliAdi.Text = ad;
            TxtGorev.Text = gorev;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update Personel set PersonelAdSoyad=@p2,PersonelDepartman=@p3 where Personelid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtPersonelid.Text);
            komut3.Parameters.AddWithValue("@p2", TxtPersoneliAdi.Text);
            komut3.Parameters.AddWithValue("@p3", TxtGorev.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Gerçekleşti");
            this.personelTableAdapter1.Fill(this.yurtOtomasyonuDataSet12.Personel);
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDataSet11.Personel);
        }
    }
}