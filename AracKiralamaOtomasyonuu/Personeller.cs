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

namespace AracKiralamaOtomasyonuu
{
    public partial class Personeller : Form
    {
        public Personeller()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=RTX2060\\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from PersonelTablo";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            KullaniciDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Kulid.Text == "" || Kulisim.Text == "" || Kulsifre.Text == "")
            {
                MessageBox.Show("Kayıp ya da eksik bilgi...");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into PersonelTablo values("+Kulid.Text+",'"+Kulisim.Text+"','"+Kulsifre.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Eklendi!");
                    Con.Close();
                    populate();
                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Personeller_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
