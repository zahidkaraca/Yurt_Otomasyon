using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;   /sql verilerimı cekmek ıcın ekledım/

namespace YurtOtomasyonu
{
    public partial class OgrenciForm : System.Windows.Forms.Form
    {
        public OgrenciForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HMA2FOJ;Initial Catalog=YurtOtomasyonu;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            //BÖLÜMLER TABLOSU
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", baglanti); //bolumler tablosundakı BolumAd kısmındakı verılerı cektık.
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbOgrBolum.Items.Add(oku[0].ToString());
            }
            baglanti.Close();
            //ODALAR TABLOSU VERİLERİ COMBOBOX'A ÇEK
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select OdaNo From Odalar where OdaKapasite != OdaAktif", baglanti); //where sorgusu ile boş odaların tespitini yaptık,OdaKapasite ile OdaAktif eşitse oda doludur
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOgrodaNo.Items.Add(oku2[0].ToString());
            }
            baglanti.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void MsbOgrTelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                //Öğrenci bilgilerini kaydettik
                baglanti.Open();
                SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,OgrTC,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOda,OgrVeliAdSoyad,OgrVeliAdres,OgrVeliTelefon) values(@Ad,@Soyad,@TC,@Telefon,@Dogum,@Bolum,@Mail,@Oda,@VeliAdSoyad,@VeliAdres,@VeliTelefon)", baglanti);
                komutkaydet.Parameters.AddWithValue("@Ad", TxtOgrAd.Text);
                komutkaydet.Parameters.AddWithValue("@Soyad", TxtOgrSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@TC", MsbOgrTC.Text);
                komutkaydet.Parameters.AddWithValue("@Telefon", MskOgrTelefon.Text);
                komutkaydet.Parameters.AddWithValue("@Dogum", MsbOgrDogumt.Text);
                komutkaydet.Parameters.AddWithValue("@Bolum", CmbOgrBolum.Text);
                komutkaydet.Parameters.AddWithValue("@Mail", TxtOgrMail.Text);
                komutkaydet.Parameters.AddWithValue("@Oda", CmbOgrodaNo.Text);
                komutkaydet.Parameters.AddWithValue("@VeliAdSoyad", TxtVeliAdSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@VeliAdres", RcbOgrAdres.Text);
                komutkaydet.Parameters.AddWithValue("@VeliTelefon", MskVeliTel.Text);
                komutkaydet.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Gerçekleşmiştir");

                //Öğrenci id yi labele çekme
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select Ogrid from Ogrenci", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while(oku.Read())
                {
                    label6.Text = oku[0].ToString();
                }
                baglanti.Close();


                //Öğrenci borç alanı oluşturma öğrenci kayıt ederkenki bilgilerle öğrenci borç tablosuna da veri çekiyoruz yani tek kayıtla iki işlem
                baglanti.Open();
                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3)", baglanti);
                komutkaydet2.Parameters.AddWithValue("@b1",label6.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                komutkaydet2.ExecuteNonQuery();
                baglanti.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!! Lütfen Tekrar Deneyin");
            }
            //OGRENCI ODA KONTEJANI AZALTMA
            baglanti.Open();
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@Oda1", baglanti);
            komutoda.Parameters.AddWithValue("@Oda1", CmbOgrodaNo.Text);
            komutoda.ExecuteNonQuery();
            baglanti.Close();

        }

        private void CmbOgrBolum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
// Data Source = DESKTOP - HMA2FOJ; Initial Catalog = YurtOtomasyonu; Integrated Security = True