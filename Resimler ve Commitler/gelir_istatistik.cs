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
    public partial class FrmGelirİstatistikleri : Form
    {
        public FrmGelirİstatistikleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HMA2FOJ;Initial Catalog=YurtOtomasyonu;Integrated Security=True");

        private void FrmGelirİstatistikleri_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet9.Kasa' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kasaTableAdapter.Fill(this.yurtOtomasyonuDataSet9.Kasa);

            //Kasadki Toplam Miktarı Hesaplama ve Kaydetme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Sum (OdemeMiktar) from Kasa", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblPara.Text = oku[0].ToString() + "₺";
            }
            baglanti.Close();

            //Tekrarsız Olarak Ayları Listeleme distinc
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy) from Kasa", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbAy.Items.Add(oku2[0].ToString());
            }
            baglanti.Close();


            //GRAFİKLERE VERİ TABANINDAN VERİ CEKME (CHART)
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select sum(OdemeMiktar) from kasa group by OdemeAy", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                this.chart1.Series["AYLIK"].Points.AddXY(oku3[0],oku3[1]);

            }
            baglanti.Close();

        }

        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Sum (OdemeMiktar) from Kasa where OdemeAy=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblAyKazanc.Text= oku[0].ToString() + "₺";
            }
            baglanti.Close();
        }
    }
}