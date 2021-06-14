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
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HMA2FOJ;Initial Catalog=YurtOtomasyonu;Integrated Security=True");
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from admin where yoneticiad=@p1 and yoneticisifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATALI GİRİŞ TEKRAR DENEYİNİZ!!");
                TxtKullaniciAd.Clear();
                TxtSifre.Clear();
                TxtKullaniciAd.Focus();
            }
            baglanti.Close();
                    
            baglanti.Close();

        }
    }
}