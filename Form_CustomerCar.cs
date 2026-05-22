using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.Entity;


namespace RENTCAROTOMASYON
{
    public partial class Form_CustomerCar : Form
    {
        public Form_CustomerCar()
        {
            InitializeComponent();
        }
        CustomerDbContext db = new CustomerDbContext();


        private void btn_listele_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime bugun = DateTime.Today;
                var list = db.CustomerCars
     .Include(cc => cc.Customer)
     .Include(cc => cc.Car)
     .Select(cc => new
     {
         cc.rental_ıd,
         MÜŞTERİADI = cc.Customer.customer_name,
         MÜŞTERİSOYADI = cc.Customer.customer_surname,
         ARAÇADI = cc.Car.car_name,
         KATEGORİ = cc.Car.Category.category_name,
         PLAKA = cc.Car.car_plate,
         GÜNLÜKÜCRET = cc.Car.car_dailyprice,
         ALIŞTARİHİ = cc.rent_date,
         TESLİMTARİHİ = cc.return_date,
         TOPLAMÜCRET = cc.total_price,
         DURUM = cc.return_date <= bugun ? "TESLİM EDİLDİ" : "KİRADA"
     })
     .ToList();

                dataGridView1.DataSource = list;
                dataGridView1.Columns["MÜŞTERİADI"].HeaderText = "MÜŞTERİ ADI";
                dataGridView1.Columns["MÜŞTERİSOYADI"].HeaderText = "MÜŞTERİ SOYADI";
                dataGridView1.Columns["ARAÇADI"].HeaderText = "ARAÇ ADI";
                dataGridView1.Columns["KATEGORİ"].HeaderText = "KATEGORİ";
                dataGridView1.Columns["PLAKA"].HeaderText = "PLAKA";
                dataGridView1.Columns["GÜNLÜKÜCRET"].HeaderText = "GÜNLÜK ÜCRET";
                dataGridView1.Columns["ALIŞTARİHİ"].HeaderText = "ALIŞ TARİHİ";
                dataGridView1.Columns["TESLİMTARİHİ"].HeaderText = "TESLİM TARİHİ";
                dataGridView1.Columns["TOPLAMÜCRET"].HeaderText = "TOPLAM ÜCRET";
                dataGridView1.Columns["DURUM"].HeaderText = "DURUM";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["rental_ıd"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "DETAYLI HATA\n\n" +
                    "Hata = " + ex.Message +
                    "\n\nDetay = " + ex.InnerException?.Message +
                    "\n\nEn İç Detay = " + ex.InnerException?.InnerException?.Message
                );
            }
        }

        private void Form_CustomerCar_Load(object sender, EventArgs e)
        {

            try
            {
                cmb_customer.DataSource = db.Customers
                    .OrderBy(c => c.customer_name)
                    .Select(c => new
                    {
                        c.customer_ıd,
                        FullName = c.customer_name + " " + c.customer_surname
                    })
                    .ToList();

                cmb_customer.DisplayMember = "FullName";
                cmb_customer.ValueMember = "customer_ıd";

                cmb_car.DataSource = db.Cars
                    .Include(c => c.Category)
                    .OrderBy(c => c.car_name)
                    .Select(c => new
                    {
                        c.car_ıd,
                        CarInfo = c.car_name + " - " + c.car_plate + " - " + c.car_dailyprice + " TL (" + c.Category.category_name + ")"
                    })
                    .ToList();

                cmb_car.DisplayMember = "CarInfo";
                cmb_car.ValueMember = "car_ıd";

                btn_listele.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata = " + ex.Message);
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmb_customer.SelectedValue == null || cmb_car.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen müşteri ve araç seçiniz.");
                    return;
                }

                int selectedCustomerId = Convert.ToInt32(cmb_customer.SelectedValue);
                int selectedCarId = Convert.ToInt32(cmb_car.SelectedValue);

                DateTime rentDate = dtp_rent_date.Value.Date;
                DateTime returnDate = dtp_return_date.Value.Date;

                int gunSayisi = (returnDate - rentDate).Days;

                if (gunSayisi <= 0)
                {
                    MessageBox.Show("Teslim tarihi alış tarihinden sonra olmalıdır.");
                    return;
                }

                bool aracDoluMu = db.CustomerCars.Any(cc =>
                    cc.car_ıd == selectedCarId &&
                    rentDate < cc.return_date &&
                    returnDate > cc.rent_date
                );

                if (aracDoluMu)
                {
                    MessageBox.Show("Seçilen araç bu tarih aralığında zaten kiralanmış.");
                    return;
                }

                Car selectedCar = db.Cars.Find(selectedCarId);

                if (selectedCar == null)
                {
                    MessageBox.Show("Seçilen araç bulunamadı.");
                    return;
                }

                decimal toplamUcret = gunSayisi * selectedCar.car_dailyprice;

                CustomerCar newRecord = new CustomerCar()
                {
                    customer_ıd = selectedCustomerId,
                    car_ıd = selectedCarId,
                    rent_date = rentDate,
                    return_date = returnDate,
                    total_price = toplamUcret
                };

                db.CustomerCars.Add(newRecord);
                db.SaveChanges();

                MessageBox.Show("Kayıt başarıyla eklendi. Toplam ücret: " + toplamUcret + " TL");

                btn_listele.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hata = " + ex.Message +
                    "\n\nDetay = " + ex.InnerException?.Message +
                    "\n\nEn İç Detay = " + ex.InnerException?.InnerException?.Message
                );
            }
        }


        private void btn_sil_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult sonuc = MessageBox.Show(
                    "Silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        int selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["rental_ıd"].Value);

                        var recordToDelete = db.CustomerCars.Find(selectedId);

                        if (recordToDelete != null)
                        {
                            db.CustomerCars.Remove(recordToDelete);
                            db.SaveChanges();

                            MessageBox.Show("Kayıt başarıyla silindi.");
                            btn_listele.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Kayıt bulunamadı.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen silmek için bir kayıt seçiniz.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hata = " + ex.Message +
                    "\n\nDetay = " + ex.InnerException?.Message +
                    "\n\nEn İç Detay = " + ex.InnerException?.InnerException?.Message
                );
            }
        }

        private void rd_1_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (rd_1.Checked)
                {
                    var result = db.CustomerCars
                        .GroupBy(cc => new
                        {
                            cc.Customer.customer_ıd,
                            cc.Customer.customer_name,
                            cc.Customer.customer_surname
                        })
                        .Select(g => new
                        {
                            FullName = g.Key.customer_name + " " + g.Key.customer_surname,
                            TotalCount = g.Count()
                        })
                        .OrderByDescending(x => x.TotalCount)
                        .FirstOrDefault();

                    if (result != null)
                    {
                        lbl_1.Text = $"{result.FullName} {result.TotalCount} araç kiraladı";
                    }
                    else
                    {
                        lbl_1.Text = "Kayıt bulunamadı.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata = " + ex.Message);
            }
        }

        private void rd_2_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (rd_2.Checked)
                {
                    var result = db.CustomerCars
                        .GroupBy(cc => new
                        {
                            cc.Car.car_ıd,
                            cc.Car.car_name,
                            cc.Car.car_plate
                        })
                        .Select(g => new
                        {
                            Arac = g.Key.car_name + " - " + g.Key.car_plate,
                            KiralamaSayisi = g.Count()
                        })
                        .OrderByDescending(x => x.KiralamaSayisi)
                        .FirstOrDefault();

                    if (result != null)
                    {
                        lbl_2.Text = $"{result.Arac} {result.KiralamaSayisi}" +
                          $" kez kiralandı";
                    }
                    else
                    {
                        lbl_2.Text = "Kayıt bulunamadı.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata = " + ex.Message);
            }
        }

        private void btn_form_customer_Click(object sender, EventArgs e)
        {
            Form1 anaForm = new Form1();
            this.Hide();
            anaForm.ShowDialog();
            this.Close();
        }

        private void lbl_2_Click(object sender, EventArgs e)
        {

        }
    }
}
    
    
    
    

