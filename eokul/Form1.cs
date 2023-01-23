using System.Data.SqlClient;

namespace eokul
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int hesap;
            hesap = (Convert.ToInt32(mvize.Text) + Convert.ToInt32(mfinal.Text)) / 2;
            ort.Text=hesap.ToString();
            SqlConnection baglan;
            baglan = new SqlConnection("Data Source=SEMIH;Initial Catalog=eokul;Integrated Security=True; TrustServerCertificate=True");
            baglan.Open();
            SqlCommand c1 = new SqlCommand("insert into sistem values(@id,@ad,@soyad,@vize,@final,@ort,@durum)", baglan);
            c1.Parameters.AddWithValue("@id", int.Parse(no.Text));
            c1.Parameters.AddWithValue("@ad", (ad.Text));
            c1.Parameters.AddWithValue("@soyad", (soyad.Text));
            c1.Parameters.AddWithValue("@vize", int.Parse(mvize.Text));
            c1.Parameters.AddWithValue("@final", int.Parse(mfinal.Text));
            c1.Parameters.AddWithValue("@ort", int.Parse(ort.Text));
            c1.Parameters.AddWithValue("@durum",(durum.Text));
            if (hesap < 50)
            {
                durum.Text = "ff";
            }
            else if(hesap >= 50 && hesap <60) 
            {
                durum.Text = "DD";
            }
            else if (hesap >= 60 && hesap < 70)
            {
                durum.Text = "DC";
            }
            else if (hesap >= 70 && hesap < 80)
            {
                durum.Text = "CC";
            }
            else if (hesap >= 80 && hesap < 90)
            {
                durum.Text = "BB";
            }
            else if (hesap >= 90 && hesap <= 100)
            {
                durum.Text = "AA";
            }

            baglan.Close();
            MessageBox.Show("Notlar baþarýyla girildi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglan;
            baglan = new SqlConnection("Data Source=SEMIH;Initial Catalog=eokul;Integrated Security=True; TrustServerCertificate=True");
            baglan.Open();
            SqlCommand c1 = new SqlCommand("select ogr_id,ogr_ad,ogr_soyad,vize,final,ortalama,durum from sistem", baglan);
            SqlDataReader dr1 = c1.ExecuteReader();
            while (dr1.Read())
            {
                int ogr_id = (int)dr1[0];
                string ogr_ad = dr1[1].ToString();
                string ogr_soyad = dr1[2].ToString();
                string vize = dr1[3].ToString();
                string final =dr1[4].ToString();
                int ortalama = (int)dr1[5];
                string durum = dr1[6].ToString();   

                richTextBox1.Text = richTextBox1.Text + ogr_id + " " + ogr_ad + " " + ogr_soyad + " " + vize + " " + final + " " + ortalama+ "\n";
                ad.Text = ogr_ad;
                soyad.Text = ogr_soyad;
                mvize.Text = vize;
                mfinal.Text = final;


            }
            
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int hesap;
            hesap = (Convert.ToInt32(mvize.Text) + Convert.ToInt32(mfinal.Text)) / 2;
            ort.Text = hesap.ToString();
            SqlConnection baglan;
            baglan = new SqlConnection("Data Source=SEMIH;Initial Catalog=eokul;Integrated Security=True; TrustServerCertificate=True");
            baglan.Open();
            SqlCommand c1 = new SqlCommand("update sistem set ogr_id=@id, ogr_ad=@ad, @ogr=soyad, vize=@vize,final=@final,ortalama=@ortalama where ogr_id=@id ", baglan);
            c1.Parameters.AddWithValue("@id", int.Parse(no.Text));
            c1.Parameters.AddWithValue("@ad", (ad.Text));
            c1.Parameters.AddWithValue("@soyad",(soyad.Text));
            c1.Parameters.AddWithValue("@vize", int.Parse(mvize.Text));
            c1.Parameters.AddWithValue("@final", int.Parse(mfinal.Text));
            c1.Parameters.AddWithValue("@ortalama", int.Parse(ort.Text));
            c1.ExecuteNonQuery();
            baglan.Close();
        }

        private void vize_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int hesap;
            hesap = (Convert.ToInt32(mvize.Text) + Convert.ToInt32(mfinal.Text)) / 2;
            ort.Text = hesap.ToString();
            SqlConnection baglan;
            baglan = new SqlConnection("Data Source=SEMIH;Initial Catalog=eokul;Integrated Security=True; TrustServerCertificate=True");
            baglan.Open();
            SqlCommand c1 = new SqlCommand("select ogr_ad,ogr_soyad,vize,final from sistem where ogr_id=@id");
            c1.Parameters.AddWithValue("@id", no.Text);
            SqlDataReader s1=c1.ExecuteReader();
            string ogr_ad = s1[0].ToString();
            string ogr_soyad = s1[1].ToString(); 
            string vize = s1[2].ToString();
            string final = s1[3].ToString();
            ad.Text = ogr_ad;
            soyad.Text= ogr_soyad;
            mvize.Text = ogr_ad;    
            mfinal.Text = ogr_soyad;

            baglan.Close();
        }
    }
}