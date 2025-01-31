using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaOtomasyonuu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void yuzde_Click(object sender, EventArgs e)
        {

        }
        int baslangicdeger = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            baslangicdeger += 1;
            surecbari.Value = baslangicdeger;
            yuzde.Text = "" + baslangicdeger;
            if (baslangicdeger == 100)
            {
                surecbari.Value = 0;
                timer1.Stop();
                Giris gir = new Giris();
                gir.Show();
                this.Hide();
            }
        }


    }
}
