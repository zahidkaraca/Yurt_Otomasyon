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
    public partial class FrmGiderGüncelle : Form
    {
        public FrmGiderGüncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HMA2FOJ;Initial Catalog=YurtOtomasyonu;Integrated Security=True");


        public string elektrik, su, dogalgaz, internet, gida, personel, diger,id;

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p2,Su=@p3,Dogalgaz=@p4,internet=@p5,Gıda=@p6,Personel=@p7,Diger=@p8 where Odemeid=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", TxtGiderid.Text);
                komut.Parameters.AddWithValue("@p2", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p3", TxtSu.Text);
                komut.Parameters.AddWithValue("@p4", TxtDogalGaz.Text);
                komut.Parameters.AddWithValue("@p5", TxtInternet.Text);
                komut.Parameters.AddWithValue("@p6", TxtGıda.Text);
                komut.Parameters.AddWithValue("@p7", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p8", TxtDiger.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarıyla Güncellendi");
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!! Lütfen Yeniden Deneyin");
            }
        }

        private void FrmGiderGüncelle_Load(object sender, EventArgs e)
        {
            TxtGiderid.Text = id;
            TxtElektrik.Text = elektrik;
            TxtSu.Text = su;
            TxtDogalGaz.Text = dogalgaz;
            TxtInternet.Text = internet;
            TxtGıda.Text = gida;
            TxtPersonel.Text = personel;
            TxtDiger.Text = diger;
        }
    }
}