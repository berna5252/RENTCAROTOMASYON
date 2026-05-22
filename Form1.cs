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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CustomerDbContext db = new CustomerDbContext();


    /*    private void btn_listele_Click(object sender, EventArgs e)
        {
            try
            {
                var customers = db.Customers.ToList();
                dataGridView1.DataSource = customers;

                dataGridView1.Columns["customer_ıd"].HeaderText = "ID";
                dataGridView1.Columns["customer_name"].HeaderText = "İSİM";
                dataGridView1.Columns["customer_surname"].HeaderText = "SOYİSİM";
                dataGridView1.Columns["customer_email"].HeaderText = "E-POSTA";
                dataGridView1.Columns["customer_telephone"].HeaderText = "TELEFON";

                dataGridView1.Columns["customer_ıd"].Visible = false;
            
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    */
                private void btn_listele_Click(object sender, EventArgs e)
        {
            try
            {
                var list = db.Customers
                    .Select(c => new
                    {
                        c.customer_ıd,
                        İSİM = c.customer_name,
                        SOYİSİM = c.customer_surname,
                        EPOSTA = c.customer_email,
                        TELEFON = c.customer_telephone
                    })
                    .ToList();

                dataGridView1.DataSource = list;

                dataGridView1.Columns["customer_ıd"].Visible = false;
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
                Customer newCustomer = new Customer()
                {
                    customer_name = txt_isim.Text,
                    customer_surname = txt_soyisim.Text,
                    customer_email = txt_email.Text,
                    customer_telephone = txt_telefon.Text
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();

                MessageBox.Show("Yeni Müşteri Eklendi!");
                btn_listele.PerformClick();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata = {ex.Message}");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                txt_isim.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_name"].Value.ToString();
                txt_soyisim.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_surname"].Value.ToString();
                txt_email.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_email"].Value.ToString();
                txt_telefon.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_telephone"].Value.ToString();
            }

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["customer_ıd"].Value);
                    Customer customer = db.Customers.Find(selectedId);
                    if (customer != null)
                    {
                        customer.customer_name = txt_isim.Text;
                        customer.customer_surname = txt_soyisim.Text;
                        customer.customer_email = txt_email.Text;
                        customer.customer_telephone = txt_telefon.Text;

                        db.SaveChanges();
                        MessageBox.Show("Müşteri güncellendi!");
                        btn_listele.PerformClick();


                    }

                }
                {

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata = {ex.Message}");
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
                        int selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["customer_ıd"].Value);
                        Customer customer = db.Customers.Find(selectedId);
                        if (customer != null)
                        {
                            db.Customers.Remove(customer);
                            db.SaveChanges();
                            MessageBox.Show("Müşteri Silindi!");
                            btn_listele.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show($"Hata = {ex.Message}"); }
        }

        private void btn_form_cc_Click(object sender, EventArgs e)
        {
            Form_CustomerCar form_cc = new Form_CustomerCar();
            this.Hide();
            form_cc.ShowDialog();
            this.Close();
        }

        private void btn_form_car_Click(object sender, EventArgs e)
        {
            Form_Car formCar = new Form_Car();
            formCar.Show();
        }

        private void btn_çıkış_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show(
        "Sistemden çıkmak istediğinize emin misiniz?",
        "Çıkış Onayı",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_rapor_Click(object sender, EventArgs e)
        {
            RAPORLAR RAPORLAR = new RAPORLAR();
            RAPORLAR.Show();
        }
    }
}

  


  