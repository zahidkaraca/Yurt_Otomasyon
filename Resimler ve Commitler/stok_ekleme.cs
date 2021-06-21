baglanti.Open();
                SqlCommand komutkaydet = new SqlCommand("insert into A_Blok_Stok (yatak,masa,sandalye,dolap,komodin,Ablok_id) values(@k1,@k2,@k3,@k4,@k5,k6)", baglanti);
                komutkaydet.Parameters.AddWithValue("@k1", TxtYatakSayisi.Text);
                komutkaydet.Parameters.AddWithValue("@k2", TxtMasaSayisi.Text);
                komutkaydet.Parameters.AddWithValue("@k3", TxtSandalyeSayisi.Text);
                komutkaydet.Parameters.AddWithValue("@k4", TxtDolapSayisi.Text);
                komutkaydet.Parameters.AddWithValue("@k5", TxtKomodinSayisi.Text);
                komutkaydet.Parameters.AddWithValue("@k6", TxtAblokid.Text);
                
                komutkaydet.ExecuteNonQuery();
                baglanti.Close();