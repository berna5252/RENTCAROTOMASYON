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
                var list = db.CustomerCars
     .Include(cc => cc.Customer)
     .Include(cc => cc.Car)
     .Select(cc => new
     {
         cc.rental_ıd,
         MÜŞTERİADI = cc.Customer.customer_name,
         MÜŞTERİSOYADI = cc.Customer.customer_surname,
         ARAÇADI= cc.Car.car_name,
         KATEGORİ = cc.Car.Category.category_name,
         PLAKA= cc.Car.car_plate,
         GÜNLÜKÜCRET = cc.Car.car_dailyprice,
         ALIŞTARİHİ = cc.rent_date,
         TESLİMTARİHİ = cc.return_date,
         TOPLAMÜCRET= cc.total_price
     })
     .ToList();

                dataGridView1.DataSource = list;
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
                            cc.Customer.customer_ıd,
                            cc.Customer.customer_name,
                            cc.Customer.customer_surname
                        })
                        .Select(g => new
                        {
                            FullName = g.Key.customer_name + " " + g.Key.customer_surname,
                            TotalPrice = g.Sum(cc => cc.total_price)
                        })
                        .OrderByDescending(x => x.TotalPrice)
                        .FirstOrDefault();

                    if (result != null)
                    {
                        lbl_2.Text = $"{result.FullName} toplam {result.TotalPrice} TL ödeme yaptı";
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

    }
    }
    
    
    
    

