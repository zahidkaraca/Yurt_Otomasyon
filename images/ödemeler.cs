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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HMA2FOJ;Initial Catalog=YurtOtomasyonu;Integrated Security=True");
        

        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet4.Borclar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borclarTableAdapter1.Fill(this.yurtOtomasyonuDataSet4.Borclar);
            //// TODO: Bu kod satırı 'yurtOtomasyonuDataSet3.Borclar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borclarTableAdapter.Fill(this.yurtOtomasyonuDataSet3.Borclar);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cell Click in amacı tek tıkla basıldığı zaman datagriddeki bilgileri tabloya aktarır.
           
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            TxtAd.Text = ad;
            TxtSoyad.Text = soyad;
            TxtKalan.Text = kalan;
            TxtOgridd.Text = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //ödenen tutarı kalan tutardan çıkarma
            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt16(TxtOdenen.Text);
            kalan = Convert.ToInt16(TxtKalan.Text);
            yeniborc = kalan - odenen;
            TxtKalan.Text = yeniborc.ToString();

            //yeni tutarı veri tabanına kaydetme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Borclar set ogrkalanborc=@p1 where Ogrid=@p2", baglanti);
            komut.Parameters.AddWithValue("@p2", TxtOgridd.Text);
            komut.Parameters.AddWithValue("@p1", TxtKalan.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Borç Ödendi");
            this.borclarTableAdapter.Fill(this.yurtOtomasyonuDataSet3.Borclar);
            this.borclarTableAdapter1.Fill(this.yurtOtomasyonuDataSet4.Borclar);

            //Kasa Bilgileri
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktar) values (@k1,@k2)", baglanti);
            komut2.Parameters.AddWithValue("@k1",TxtOdenenAy.Text);
            komut2.Parameters.AddWithValue("@k2", TxtOdenen.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}