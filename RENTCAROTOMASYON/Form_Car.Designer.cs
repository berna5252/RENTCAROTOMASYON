namespace RENTCAROTOMASYON
{
    partial class Form_Car
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_car_name = new System.Windows.Forms.TextBox();
            this.txt_car_plate = new System.Windows.Forms.TextBox();
            this.txt_daily_price = new System.Windows.Forms.TextBox();
            this.cmb_category = new System.Windows.Forms.ComboBox();
            this.btn_listele = new System.Windows.Forms.Button();
            this.btn_sil = new System.Windows.Forms.Button();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1505, 261);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ARAÇ ADI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(25, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "PLAKA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(25, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "GÜNLÜK ÜCRET";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(25, 566);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "KATEGORİ";
            // 
            // txt_car_name
            // 
            this.txt_car_name.Location = new System.Drawing.Point(214, 339);
            this.txt_car_name.Name = "txt_car_name";
            this.txt_car_name.Size = new System.Drawing.Size(167, 22);
            this.txt_car_name.TabIndex = 5;
            // 
            // txt_car_plate
            // 
            this.txt_car_plate.Location = new System.Drawing.Point(214, 409);
            this.txt_car_plate.Name = "txt_car_plate";
            this.txt_car_plate.Size = new System.Drawing.Size(167, 22);
            this.txt_car_plate.TabIndex = 6;
            // 
            // txt_daily_price
            // 
            this.txt_daily_price.Location = new System.Drawing.Point(214, 483);
            this.txt_daily_price.Name = "txt_daily_price";
            this.txt_daily_price.Size = new System.Drawing.Size(167, 22);
            this.txt_daily_price.TabIndex = 7;
            // 
            // cmb_category
            // 
            this.cmb_category.FormattingEnabled = true;
            this.cmb_category.Location = new System.Drawing.Point(214, 562);
            this.cmb_category.Name = "cmb_category";
            this.cmb_category.Size = new System.Drawing.Size(167, 24);
            this.cmb_category.TabIndex = 8;
            // 
            // btn_listele
            // 
            this.btn_listele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_listele.Location = new System.Drawing.Point(687, 339);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.Size = new System.Drawing.Size(138, 33);
            this.btn_listele.TabIndex = 9;
            this.btn_listele.Text = "LİSTELE";
            this.btn_listele.UseVisualStyleBackColor = true;
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_sil.Location = new System.Drawing.Point(687, 586);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(138, 35);
            this.btn_sil.TabIndex = 10;
            this.btn_sil.Text = "SİL";
            this.btn_sil.UseVisualStyleBackColor = true;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ekle.Location = new System.Drawing.Point(687, 423);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(138, 32);
            this.btn_ekle.TabIndex = 11;
            this.btn_ekle.Text = "EKLE";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_guncelle.Location = new System.Drawing.Point(687, 510);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(138, 29);
            this.btn_guncelle.TabIndex = 12;
            this.btn_guncelle.Text = "GÜNCELLE";
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 683);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 43);
            this.button1.TabIndex = 13;
            this.button1.Text = "ANA FORM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Car
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1613, 838);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_listele);
            this.Controls.Add(this.cmb_category);
            this.Controls.Add(this.txt_daily_price);
            this.Controls.Add(this.txt_car_plate);
            this.Controls.Add(this.txt_car_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_Car";
            this.Text = "Form_Car";
            this.Load += new System.EventHandler(this.Form_Car_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_car_name;
        private System.Windows.Forms.TextBox txt_car_plate;
        private System.Windows.Forms.TextBox txt_daily_price;
        private System.Windows.Forms.ComboBox cmb_category;
        private System.Windows.Forms.Button btn_listele;
        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Button btn_guncelle;
        private System.Windows.Forms.Button button1;
    }
}