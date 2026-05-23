using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace RENTCAROTOMASYON
{
    public partial class Form_Car : Form
    {
        CustomerDbContext db = new CustomerDbContext();
        public Form_Car()
        {
            InitializeComponent();
        }

        private void Form_Car_Load(object sender, EventArgs e)
        {

            cmb_category.DataSource = db.Categories
                .OrderBy(c => c.category_name)
                .ToList();

            cmb_category.DisplayMember = "category_name";
            cmb_category.ValueMember = "category_ıd";

          
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
         
            try
            {
                var list = db.Cars
                    .Include(c => c.Category)
                    .Select(c => new
                    {
                        CarId = c.car_ıd,
                        AracAdi = c.car_name,
                        Plaka = c.car_plate,
                        GunlukUcret = c.car_dailyprice,
                        Kategori = c.Category.category_name
                    })
                    .ToList();

                dataGridView1.DataSource = list;

                dataGridView1.Columns["CarId"].Visible = false;
                dataGridView1.Columns["AracAdi"].HeaderText = "ARAÇ ADI";
                dataGridView1.Columns["Plaka"].HeaderText = "PLAKA";
                dataGridView1.Columns["GunlukUcret"].HeaderText = "GÜNLÜK ÜCRET";
                dataGridView1.Columns["Kategori"].HeaderText = "KATEGORİ";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                if (string.IsNullOrWhiteSpace(txt_car_name.Text) ||
                    string.IsNullOrWhiteSpace(txt_car_plate.Text) ||
                    string.IsNullOrWhiteSpace(txt_daily_price.Text) ||
                    cmb_category.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                    return;
                }

                if (!decimal.TryParse(txt_daily_price.Text, out decimal gunlukUcret))
                {
                    MessageBox.Show("Günlük ücret alanına sadece sayı giriniz.");
                    return;
                }

                Car newCar = new Car()
                {
                    car_name = txt_car_name.Text.Trim(),
                    car_plate = txt_car_plate.Text.Trim(),
                    car_dailyprice = gunlukUcret,
                    category_ıd = Convert.ToInt32(cmb_category.SelectedValue)
                };

                db.Cars.Add(newCar);
                db.SaveChanges();

                MessageBox.Show("Araç başarıyla eklendi.");

                txt_car_name.Clear();
                txt_car_plate.Clear();
                txt_daily_price.Clear();

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
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen silmek için bir araç seçiniz.");
                    return;
                }

                int selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CarId"].Value);

                bool aracKullanilmisMi = db.CustomerCars.Any(cc => cc.car_ıd == selectedId);

                if (aracKullanilmisMi)
                {
                    MessageBox.Show("Bu araç kiralama kayıtlarında kullanıldığı için silinemez.");
                    return;
                }

                DialogResult sonuc = MessageBox.Show(
                    "Seçili aracı silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    Car car = db.Cars.Find(selectedId);

                    if (car != null)
                    {
                        db.Cars.Remove(car);
                        db.SaveChanges();

                        MessageBox.Show("Araç başarıyla silindi.");

                        txt_car_name.Clear();
                        txt_car_plate.Clear();
                        txt_daily_price.Clear();

                        btn_listele.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Araç bulunamadı.");
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

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen güncellemek için bir araç seçiniz.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_car_name.Text) ||
                    string.IsNullOrWhiteSpace(txt_car_plate.Text) ||
                    string.IsNullOrWhiteSpace(txt_daily_price.Text) ||
                    cmb_category.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                    return;
                }

                int selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CarId"].Value);

                Car car = db.Cars.Find(selectedId);

                if (car != null)
                {
                    car.car_name = txt_car_name.Text.Trim();
                    car.car_plate = txt_car_plate.Text.Trim();
                    if (!decimal.TryParse(txt_daily_price.Text, out decimal gunlukUcret))
                    {
                        MessageBox.Show("Günlük ücret alanına sadece sayı giriniz.");
                        return;
                    }

                    car.car_dailyprice = gunlukUcret;
                    car.category_ıd = Convert.ToInt32(cmb_category.SelectedValue);

                    db.SaveChanges();

                    MessageBox.Show("Araç başarıyla güncellendi.");

                    txt_car_name.Clear();
                    txt_car_plate.Clear();
                    txt_daily_price.Clear();

                    btn_listele.PerformClick();
                }
                else
                {
                    MessageBox.Show("Araç bulunamadı.");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_car_name.Text = dataGridView1.Rows[e.RowIndex].Cells["AracAdi"].Value.ToString();
                txt_car_plate.Text = dataGridView1.Rows[e.RowIndex].Cells["Plaka"].Value.ToString();
                txt_daily_price.Text = dataGridView1.Rows[e.RowIndex].Cells["GunlukUcret"].Value.ToString();
            }
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
    
    





