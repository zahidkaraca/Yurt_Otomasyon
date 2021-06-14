using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace YurtOtomasyonu
{
    public partial class FrmNotEkle : Form
    {
        public FrmNotEkle()
        {
            InitializeComponent();
        }

        private void btnKAydet_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Kayıt Yeri Seçin";
            saveFileDialog1.Filter = "Metin Dosyası | *.txt";
            saveFileDialog1.InitialDirectory = "c://Notlar";
            saveFileDialog1.ShowDialog();
            StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);
            kaydet.WriteLine(richTextBox1.Text);
            kaydet.Close();
            MessageBox.Show("Kayıt Başarılı");  


        }
    }
}