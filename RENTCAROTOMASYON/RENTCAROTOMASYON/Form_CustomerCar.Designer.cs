namespace RENTCAROTOMASYON
{
    partial class Form_CustomerCar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_listele = new System.Windows.Forms.Button();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.btn_sil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_customer = new System.Windows.Forms.ComboBox();
            this.cmb_car = new System.Windows.Forms.ComboBox();
            this.btn_form_customer = new System.Windows.Forms.Button();
            this.dtp_rent_date = new System.Windows.Forms.DateTimePicker();
            this.dtp_return_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_1 = new System.Windows.Forms.RadioButton();
            this.rd_2 = new System.Windows.Forms.RadioButton();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1466, 201);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_listele
            // 
            this.btn_listele.Location = new System.Drawing.Point(619, 260);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.Size = new System.Drawing.Size(75, 23);
            this.btn_listele.TabIndex = 1;
            this.btn_listele.Text = "LİSTELE";
            this.btn_listele.UseVisualStyleBackColor = true;
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.Location = new System.Drawing.Point(619, 328);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_ekle.TabIndex = 2;
            this.btn_ekle.Text = "EKLE";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.Location = new System.Drawing.Point(619, 392);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(75, 23);
            this.btn_sil.TabIndex = 3;
            this.btn_sil.Text = "SİL";
            this.btn_sil.UseVisualStyleBackColor = true;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "MÜŞTERİ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "ARABA";
            // 
            // cmb_customer
            // 
            this.cmb_customer.FormattingEnabled = true;
            this.cmb_customer.Location = new System.Drawing.Point(255, 252);
            this.cmb_customer.Name = "cmb_customer";
            this.cmb_customer.Size = new System.Drawing.Size(296, 24);
            this.cmb_customer.TabIndex = 6;
            // 
            // cmb_car
            // 
            this.cmb_car.FormattingEnabled = true;
            this.cmb_car.Location = new System.Drawing.Point(255, 327);
            this.cmb_car.Name = "cmb_car";
            this.cmb_car.Size = new System.Drawing.Size(296, 24);
            this.cmb_car.TabIndex = 7;
            // 
            // btn_form_customer
            // 
            this.btn_form_customer.Location = new System.Drawing.Point(635, 493);
            this.btn_form_customer.Name = "btn_form_customer";
            this.btn_form_customer.Size = new System.Drawing.Size(246, 23);
            this.btn_form_customer.TabIndex = 8;
            this.btn_form_customer.Text = "ANA FORM";
            this.btn_form_customer.UseVisualStyleBackColor = true;
            // 
            // dtp_rent_date
            // 
            this.dtp_rent_date.Location = new System.Drawing.Point(266, 407);
            this.dtp_rent_date.Name = "dtp_rent_date";
            this.dtp_rent_date.Size = new System.Drawing.Size(200, 22);
            this.dtp_rent_date.TabIndex = 9;
            // 
            // dtp_return_date
            // 
            this.dtp_return_date.Location = new System.Drawing.Point(266, 469);
            this.dtp_return_date.Name = "dtp_return_date";
            this.dtp_return_date.Size = new System.Drawing.Size(200, 22);
            this.dtp_return_date.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "ALIŞ TARİHİ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "TESLİM TARİHİ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_1);
            this.groupBox1.Controls.Add(this.lbl_2);
            this.groupBox1.Controls.Add(this.rd_2);
            this.groupBox1.Controls.Add(this.rd_1);
            this.groupBox1.Location = new System.Drawing.Point(1004, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 221);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rd_1
            // 
            this.rd_1.AutoSize = true;
            this.rd_1.Location = new System.Drawing.Point(3, 18);
            this.rd_1.Name = "rd_1";
            this.rd_1.Size = new System.Drawing.Size(103, 20);
            this.rd_1.TabIndex = 0;
            this.rd_1.TabStop = true;
            this.rd_1.Text = "radioButton1";
            this.rd_1.UseVisualStyleBackColor = true;
            this.rd_1.CheckedChanged += new System.EventHandler(this.rd_1_CheckedChanged);
            // 
            // rd_2
            // 
            this.rd_2.AutoSize = true;
            this.rd_2.Location = new System.Drawing.Point(6, 88);
            this.rd_2.Name = "rd_2";
            this.rd_2.Size = new System.Drawing.Size(103, 20);
            this.rd_2.TabIndex = 1;
            this.rd_2.TabStop = true;
            this.rd_2.Text = "radioButton2";
            this.rd_2.UseVisualStyleBackColor = true;
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Location = new System.Drawing.Point(135, 18);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(44, 16);
            this.lbl_1.TabIndex = 14;
            this.lbl_1.Text = "label5";
            // 
            // lbl_2
            // 
            this.lbl_2.AutoSize = true;
            this.lbl_2.Location = new System.Drawing.Point(150, 92);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(44, 16);
            this.lbl_2.TabIndex = 15;
            this.lbl_2.Text = "label6";
            // 
            // Form_CustomerCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 746);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_return_date);
            this.Controls.Add(this.dtp_rent_date);
            this.Controls.Add(this.btn_form_customer);
            this.Controls.Add(this.cmb_car);
            this.Controls.Add(this.cmb_customer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.btn_listele);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_CustomerCar";
            this.Text = "Form_CustomerCar";
            this.Load += new System.EventHandler(this.Form_CustomerCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_listele;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_customer;
        private System.Windows.Forms.ComboBox cmb_car;
        private System.Windows.Forms.Button btn_form_customer;
        private System.Windows.Forms.DateTimePicker dtp_rent_date;
        private System.Windows.Forms.DateTimePicker dtp_return_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.RadioButton rd_2;
        private System.Windows.Forms.RadioButton rd_1;
    }
}