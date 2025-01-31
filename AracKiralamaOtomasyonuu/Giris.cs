using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AracKiralamaOtomasyonuu
{
    public partial class Giris : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Giris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection("Data Source=RTX2060\\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*From Kullanici_Bilgi where Kullanici_Adi='" + textBox1.Text + "'And Sifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı, Hoşgeldin!");
                AnaForm anasayfa = new AnaForm();
                anasayfa.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz. Lütfen Tekrar Deneyin...");
            }
            con.Close();
        }
    }
}
