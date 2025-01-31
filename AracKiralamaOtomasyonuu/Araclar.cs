using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AracKiralamaOtomasyonuu
{
    public partial class Araclar : Form
    {
        public Araclar()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=RTX2060\\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from AracTablo";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AracDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (KayitnoTb.Text == "" || MarkaTb.Text == "" || ModelTb.Text == "" || FiyatTb.Text == "")
            {
                MessageBox.Show("Kayıp ya da eksik bilgi...");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AracTablo values(" + KayitnoTb.Text + ",'" + MarkaTb.Text + "','" + ModelTb.Text + "','" + FiyatTb.Text + "','" +DurumCbox.SelectedItem.ToString()+ "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araç Başarıyla Eklendi!");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Araclar_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
