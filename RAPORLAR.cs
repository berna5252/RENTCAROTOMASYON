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
    public partial class RAPORLAR : Form
    {
        CustomerDbContext db = new CustomerDbContext();
        public RAPORLAR()
        {
            InitializeComponent();
        }

        private void btn_raporlari_getir_Click(object sender, EventArgs e)
        {
         
            try
            {
                DateTime bugun = DateTime.Today;
                int ay = bugun.Month;
                int yil = bugun.Year;

                decimal gunlukGelir = db.CustomerCars
                    .Where(x => x.rent_date == bugun)
                    .Sum(x => (decimal?)x.total_price) ?? 0;

                decimal aylikGelir = db.CustomerCars
                    .Where(x => x.rent_date.Month == ay && x.rent_date.Year == yil)
                    .Sum(x => (decimal?)x.total_price) ?? 0;

                int gunlukKiralama = db.CustomerCars
                    .Count(x => x.rent_date == bugun);

                int aylikKiralama = db.CustomerCars
                    .Count(x => x.rent_date.Month == ay && x.rent_date.Year == yil);

                var enCokArac = db.CustomerCars
                    .GroupBy(x => new
                    {
                        x.Car.car_name,
                        x.Car.car_plate
                    })
                    .Select(g => new
                    {
                        Arac = g.Key.car_name + " - " + g.Key.car_plate,
                        Sayi = g.Count()
                    })
                    .OrderByDescending(x => x.Sayi)
                    .FirstOrDefault();

                label1.Text = gunlukGelir + " TL";
                label_3.Text = aylikGelir + " TL";
                label2.Text = gunlukKiralama.ToString();
                lbl_4.Text = aylikKiralama.ToString();

                label_5.Text = enCokArac != null
                    ? enCokArac.Arac + " - " + enCokArac.Sayi + " kiralama"
                    : "Kayıt yok";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata = " + ex.Message);
            }
        }

        private void lbl_gunluk_kiralama_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 anaForm = new Form1();
            this.Hide();
            anaForm.ShowDialog();
            this.Close();
        }
    }
    }




