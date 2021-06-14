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
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HMA2FOJ;Initial Catalog=YurtOtomasyonu;Integrated Security=True");

        public string id,ad,soyad,TC,telefon,dogum,bolum,mail,odaNo,veliadsoyad,velitel,adres;

        private void button1_Click(object sender, EventArgs e)
        {
            //OGRENCİ SİLME 
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from Ogrenci where Ogrid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", TxtOgrid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");

            //ODANIN AKTIF OGRENCI SAYISINI AZALTMA 
            baglanti.Open();
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAkif-1 where OdaNo=@oda", baglanti);
            komutoda.Parameters.AddWithValue("@oda", CmbOgrodaNo.Text);
            komutoda.ExecuteNonQuery();
            baglanti.Close();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2,OgrSoyad=@p3,OgrTC=@p4,OgrTelefon=@p5,OgrDogum=@p6,OgrBolum=@p7,OgrMail=@p8,OgrOda=@p9,OgrVeliAdSoyad=@p10,OgrVeliAdres=@p11,OgrVeliTelefon=@p12 where Ogrid=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", TxtOgrid.Text);
                komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p4", MsbOgrTC.Text);
                komut.Parameters.AddWithValue("@p5", MskOgrTelefon.Text);
                komut.Parameters.AddWithValue("@p6", MsbOgrDogumt.Text);
                komut.Parameters.AddWithValue("@p7", CmbOgrBolum.Text);
                komut.Parameters.AddWithValue("@p8", TxtOgrMail.Text);
                komut.Parameters.AddWithValue("@p9", CmbOgrodaNo.Text);
                komut.Parameters.AddWithValue("@p10", TxtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p11", RcbOgrAdres.Text);
                komut.Parameters.AddWithValue("@p12", MskVeliTel.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarıyla Güncellendi");
               
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!! Lütfen Yeniden Deneyin");
            }
        }

        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet7.Odalar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.odalarTableAdapter.Fill(this.yurtOtomasyonuDataSet7.Odalar);
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet6.Bolumler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet6.Bolumler);
            TxtOgrid.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MsbOgrTC.Text = TC;
            MskOgrTelefon.Text = telefon;
            MsbOgrDogumt.Text = dogum;
            CmbOgrBolum.Text = bolum;
            TxtOgrMail.Text = mail;
            CmbOgrodaNo.Text = odaNo;
            TxtVeliAdSoyad.Text = veliadsoyad;
            MskVeliTel.Text = velitel;
            RcbOgrAdres.Text = adres;

            
        }

        private void FrmOgrDuzenle_Click(object sender, EventArgs e)
        {

        }
    }
}