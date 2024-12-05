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

namespace Personel_Kayit_Projesi
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3FED8I7\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*) FROM Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader(); // Çalıştır ve Oku
            while(dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();


            //Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM Personel WHERE PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar Personel Sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM Personel WHERE PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarPersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Şehir Toplam Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(DISTINCT(PerSehir)) FROM Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam Maaş 
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("SELECT SUM(PerMaas) FROM Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Ortalama Maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("SELECT AVG(PerMaas) FROM Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while(dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();


        }
    }
}
