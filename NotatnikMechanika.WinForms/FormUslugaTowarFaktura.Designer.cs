namespace NotatnikMechanika.WinForms
{
    partial class FormUslugaTowarFaktura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUslugaTowarFaktura));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBnazwa = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBjm = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CBvat = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBbrutto = new System.Windows.Forms.TextBox();
            this.TBnetto = new System.Windows.Forms.TextBox();
            this.TBilosc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTuslugi = new System.Windows.Forms.Button();
            this.BTtowary = new System.Windows.Forms.Button();
            this.BTdodaj = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBnazwa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dane usługi lub towaru";
            // 
            // TBnazwa
            // 
            this.TBnazwa.Location = new System.Drawing.Point(27, 47);
            this.TBnazwa.Name = "TBnazwa";
            this.TBnazwa.Size = new System.Drawing.Size(195, 56);
            this.TBnazwa.TabIndex = 1;
            this.TBnazwa.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa usługi lub towaru";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CBjm);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CBvat);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TBbrutto);
            this.groupBox2.Controls.Add(this.TBnetto);
            this.groupBox2.Controls.Add(this.TBilosc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 173);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametry sprzedaży";
            // 
            // CBjm
            // 
            this.CBjm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBjm.FormattingEnabled = true;
            this.CBjm.Items.AddRange(new object[] {
            "szt.",
            "kpl.",
            "op.",
            "km",
            "kg",
            "l",
            "h"});
            this.CBjm.Location = new System.Drawing.Point(102, 133);
            this.CBjm.Name = "CBjm";
            this.CBjm.Size = new System.Drawing.Size(100, 21);
            this.CBjm.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Jednostka miary";
            // 
            // CBvat
            // 
            this.CBvat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBvat.Items.AddRange(new object[] {
            "23",
            "8",
            "7",
            "6",
            "5",
            "0",
            "zw"});
            this.CBvat.Location = new System.Drawing.Point(102, 106);
            this.CBvat.Name = "CBvat";
            this.CBvat.Size = new System.Drawing.Size(100, 21);
            this.CBvat.TabIndex = 2;
            this.CBvat.SelectedIndexChanged += new System.EventHandler(this.CBvat_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "VAT[%]";
            // 
            // TBbrutto
            // 
            this.TBbrutto.Location = new System.Drawing.Point(102, 80);
            this.TBbrutto.Name = "TBbrutto";
            this.TBbrutto.Size = new System.Drawing.Size(100, 20);
            this.TBbrutto.TabIndex = 5;
            this.TBbrutto.TextChanged += new System.EventHandler(this.TBbrutto_TextChanged);
            // 
            // TBnetto
            // 
            this.TBnetto.Location = new System.Drawing.Point(102, 54);
            this.TBnetto.Name = "TBnetto";
            this.TBnetto.Size = new System.Drawing.Size(100, 20);
            this.TBnetto.TabIndex = 4;
            this.TBnetto.TextChanged += new System.EventHandler(this.TBnetto_TextChanged);
            // 
            // TBilosc
            // 
            this.TBilosc.Location = new System.Drawing.Point(102, 28);
            this.TBilosc.Name = "TBilosc";
            this.TBilosc.Size = new System.Drawing.Size(100, 20);
            this.TBilosc.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cena brutto[zł]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cena netto[zł]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ilość";
            // 
            // BTuslugi
            // 
            this.BTuslugi.Location = new System.Drawing.Point(13, 326);
            this.BTuslugi.Name = "BTuslugi";
            this.BTuslugi.Size = new System.Drawing.Size(75, 23);
            this.BTuslugi.TabIndex = 2;
            this.BTuslugi.Text = "Usługi";
            this.BTuslugi.UseVisualStyleBackColor = true;
            this.BTuslugi.Click += new System.EventHandler(this.BTuslugi_Click);
            // 
            // BTtowary
            // 
            this.BTtowary.Location = new System.Drawing.Point(12, 355);
            this.BTtowary.Name = "BTtowary";
            this.BTtowary.Size = new System.Drawing.Size(75, 23);
            this.BTtowary.TabIndex = 3;
            this.BTtowary.Text = "Towary";
            this.BTtowary.UseVisualStyleBackColor = true;
            this.BTtowary.Click += new System.EventHandler(this.BTtowary_Click);
            // 
            // BTdodaj
            // 
            this.BTdodaj.Location = new System.Drawing.Point(166, 326);
            this.BTdodaj.Name = "BTdodaj";
            this.BTdodaj.Size = new System.Drawing.Size(100, 52);
            this.BTdodaj.TabIndex = 13;
            this.BTdodaj.Text = "Dodaj";
            this.BTdodaj.UseVisualStyleBackColor = true;
            this.BTdodaj.Click += new System.EventHandler(this.BTdodaj_Click);
            // 
            // FormUslugaTowarFaktura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 390);
            this.Controls.Add(this.BTdodaj);
            this.Controls.Add(this.BTtowary);
            this.Controls.Add(this.BTuslugi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUslugaTowarFaktura";
            this.Text = "Dodaj usługę/towar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox TBnazwa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBbrutto;
        private System.Windows.Forms.TextBox TBnetto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTuslugi;
        private System.Windows.Forms.Button BTtowary;
        private System.Windows.Forms.Button BTdodaj;
        private System.Windows.Forms.ComboBox CBjm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CBvat;
        private System.Windows.Forms.TextBox TBilosc;
    }
}