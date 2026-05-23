using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RENTCAROTOMASYON
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
         
            string kullaniciAdi = txt_kullanici_adi.Text.Trim();
            string sifre = txt_sifre.Text.Trim();

            if (kullaniciAdi == "Berna Aldemir" && sifre == "3434")
            {
                Form1 anaForm = new Form1();
                this.Hide();
                anaForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }
    }
    }




