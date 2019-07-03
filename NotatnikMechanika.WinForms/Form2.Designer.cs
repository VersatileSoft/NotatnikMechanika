namespace NotatnikMechanika.WinForms
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.DTprzyjecie = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BTdodajZlecenie = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DTwykonanie = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTstaliKlienciZapisz = new System.Windows.Forms.Button();
            this.LdaneKlienta = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTdodajDoUslug = new System.Windows.Forms.Button();
            this.BTusun = new System.Windows.Forms.Button();
            this.BTuslugi = new System.Windows.Forms.Button();
            this.BTdodajUsluga = new System.Windows.Forms.Button();
            this.CBwszystkoUslugi = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BTdodajDoTowarow = new System.Windows.Forms.Button();
            this.BTusunTowary = new System.Windows.Forms.Button();
            this.BTtowary = new System.Windows.Forms.Button();
            this.CBwszystkoTowary = new System.Windows.Forms.CheckBox();
            this.BTdodajTowar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TBdodatkowe = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DTprzyjecie
            // 
            this.DTprzyjecie.Location = new System.Drawing.Point(14, 28);
            this.DTprzyjecie.Name = "DTprzyjecie";
            this.DTprzyjecie.Size = new System.Drawing.Size(207, 20);
            this.DTprzyjecie.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data przyjęcia zlecenia:";
            // 
            // BTdodajZlecenie
            // 
            this.BTdodajZlecenie.Location = new System.Drawing.Point(214, 499);
            this.BTdodajZlecenie.Name = "BTdodajZlecenie";
            this.BTdodajZlecenie.Size = new System.Drawing.Size(105, 40);
            this.BTdodajZlecenie.TabIndex = 4;
            this.BTdodajZlecenie.Text = "Dodaj zlecenie";
            this.BTdodajZlecenie.UseVisualStyleBackColor = true;
            this.BTdodajZlecenie.Click += new System.EventHandler(this.BTdodajZlecenie_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(313, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data wykonania zlecenia:";
            // 
            // DTwykonanie
            // 
            this.DTwykonanie.Location = new System.Drawing.Point(316, 28);
            this.DTwykonanie.Name = "DTwykonanie";
            this.DTwykonanie.Size = new System.Drawing.Size(207, 20);
            this.DTwykonanie.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTstaliKlienciZapisz);
            this.groupBox1.Controls.Add(this.LdaneKlienta);
            this.groupBox1.Location = new System.Drawing.Point(14, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 106);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dane klienta";
            // 
            // BTstaliKlienciZapisz
            // 
            this.BTstaliKlienciZapisz.Location = new System.Drawing.Point(200, 64);
            this.BTstaliKlienciZapisz.Name = "BTstaliKlienciZapisz";
            this.BTstaliKlienciZapisz.Size = new System.Drawing.Size(105, 36);
            this.BTstaliKlienciZapisz.TabIndex = 40;
            this.BTstaliKlienciZapisz.Text = "Edytuj";
            this.BTstaliKlienciZapisz.UseVisualStyleBackColor = true;
            this.BTstaliKlienciZapisz.Click += new System.EventHandler(this.BTstaliKlienciZapisz_Click);
            // 
            // LdaneKlienta
            // 
            this.LdaneKlienta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LdaneKlienta.Location = new System.Drawing.Point(2, 16);
            this.LdaneKlienta.Name = "LdaneKlienta";
            this.LdaneKlienta.Size = new System.Drawing.Size(507, 44);
            this.LdaneKlienta.TabIndex = 24;
            this.LdaneKlienta.Text = "Kliknij edytuj aby dodać dane klienta";
            this.LdaneKlienta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTdodajDoUslug);
            this.groupBox2.Controls.Add(this.BTusun);
            this.groupBox2.Controls.Add(this.BTuslugi);
            this.groupBox2.Controls.Add(this.BTdodajUsluga);
            this.groupBox2.Controls.Add(this.CBwszystkoUslugi);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(14, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 246);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usługi";
            // 
            // BTdodajDoUslug
            // 
            this.BTdodajDoUslug.Location = new System.Drawing.Point(131, 217);
            this.BTdodajDoUslug.Name = "BTdodajDoUslug";
            this.BTdodajDoUslug.Size = new System.Drawing.Size(115, 23);
            this.BTdodajDoUslug.TabIndex = 27;
            this.BTdodajDoUslug.Text = "Dodaj do usług";
            this.BTdodajDoUslug.UseVisualStyleBackColor = true;
            this.BTdodajDoUslug.Click += new System.EventHandler(this.BTdodajDoUslug_Click);
            // 
            // BTusun
            // 
            this.BTusun.Location = new System.Drawing.Point(6, 217);
            this.BTusun.Name = "BTusun";
            this.BTusun.Size = new System.Drawing.Size(115, 23);
            this.BTusun.TabIndex = 26;
            this.BTusun.Text = "Usuń";
            this.BTusun.UseVisualStyleBackColor = true;
            this.BTusun.Click += new System.EventHandler(this.BTusun_Click);
            // 
            // BTuslugi
            // 
            this.BTuslugi.Location = new System.Drawing.Point(131, 188);
            this.BTuslugi.Name = "BTuslugi";
            this.BTuslugi.Size = new System.Drawing.Size(115, 23);
            this.BTuslugi.TabIndex = 25;
            this.BTuslugi.Text = "Usługi";
            this.BTuslugi.UseVisualStyleBackColor = true;
            this.BTuslugi.Click += new System.EventHandler(this.BTuslugi_Click);
            // 
            // BTdodajUsluga
            // 
            this.BTdodajUsluga.Location = new System.Drawing.Point(6, 188);
            this.BTdodajUsluga.Name = "BTdodajUsluga";
            this.BTdodajUsluga.Size = new System.Drawing.Size(115, 23);
            this.BTdodajUsluga.TabIndex = 24;
            this.BTdodajUsluga.Text = "Dodaj ";
            this.BTdodajUsluga.UseVisualStyleBackColor = true;
            this.BTdodajUsluga.Click += new System.EventHandler(this.BTdodajUsluga_Click);
            // 
            // CBwszystkoUslugi
            // 
            this.CBwszystkoUslugi.AutoSize = true;
            this.CBwszystkoUslugi.Location = new System.Drawing.Point(9, 27);
            this.CBwszystkoUslugi.Name = "CBwszystkoUslugi";
            this.CBwszystkoUslugi.Size = new System.Drawing.Size(15, 14);
            this.CBwszystkoUslugi.TabIndex = 22;
            this.CBwszystkoUslugi.UseVisualStyleBackColor = true;
            this.CBwszystkoUslugi.CheckedChanged += new System.EventHandler(this.CBwszystkoUslugi_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(4, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 138);
            this.panel1.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label8.Location = new System.Drawing.Point(155, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Cena:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label7.Location = new System.Drawing.Point(30, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Usługa:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BTdodajDoTowarow);
            this.groupBox3.Controls.Add(this.BTusunTowary);
            this.groupBox3.Controls.Add(this.BTtowary);
            this.groupBox3.Controls.Add(this.CBwszystkoTowary);
            this.groupBox3.Controls.Add(this.BTdodajTowar);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(272, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 246);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Towary";
            // 
            // BTdodajDoTowarow
            // 
            this.BTdodajDoTowarow.Location = new System.Drawing.Point(131, 217);
            this.BTdodajDoTowarow.Name = "BTdodajDoTowarow";
            this.BTdodajDoTowarow.Size = new System.Drawing.Size(115, 23);
            this.BTdodajDoTowarow.TabIndex = 41;
            this.BTdodajDoTowarow.Text = "Dodaj do towarów";
            this.BTdodajDoTowarow.UseVisualStyleBackColor = true;
            this.BTdodajDoTowarow.Click += new System.EventHandler(this.BTdodajDoTowarow_Click);
            // 
            // BTusunTowary
            // 
            this.BTusunTowary.Location = new System.Drawing.Point(9, 217);
            this.BTusunTowary.Name = "BTusunTowary";
            this.BTusunTowary.Size = new System.Drawing.Size(115, 23);
            this.BTusunTowary.TabIndex = 40;
            this.BTusunTowary.Text = "Usuń";
            this.BTusunTowary.UseVisualStyleBackColor = true;
            this.BTusunTowary.Click += new System.EventHandler(this.BTusunTowary_Click);
            // 
            // BTtowary
            // 
            this.BTtowary.Location = new System.Drawing.Point(131, 188);
            this.BTtowary.Name = "BTtowary";
            this.BTtowary.Size = new System.Drawing.Size(115, 23);
            this.BTtowary.TabIndex = 37;
            this.BTtowary.Text = "Towary";
            this.BTtowary.UseVisualStyleBackColor = true;
            this.BTtowary.Click += new System.EventHandler(this.BTtowary_Click);
            // 
            // CBwszystkoTowary
            // 
            this.CBwszystkoTowary.AutoSize = true;
            this.CBwszystkoTowary.Location = new System.Drawing.Point(12, 27);
            this.CBwszystkoTowary.Name = "CBwszystkoTowary";
            this.CBwszystkoTowary.Size = new System.Drawing.Size(15, 14);
            this.CBwszystkoTowary.TabIndex = 38;
            this.CBwszystkoTowary.UseVisualStyleBackColor = true;
            this.CBwszystkoTowary.CheckedChanged += new System.EventHandler(this.CBwszystkoTowary_CheckedChanged);
            // 
            // BTdodajTowar
            // 
            this.BTdodajTowar.Location = new System.Drawing.Point(9, 188);
            this.BTdodajTowar.Name = "BTdodajTowar";
            this.BTdodajTowar.Size = new System.Drawing.Size(115, 23);
            this.BTdodajTowar.TabIndex = 36;
            this.BTdodajTowar.Text = "Dodaj ";
            this.BTdodajTowar.UseVisualStyleBackColor = true;
            this.BTdodajTowar.Click += new System.EventHandler(this.BTdodajTowar_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Location = new System.Drawing.Point(6, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 138);
            this.panel2.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label9.Location = new System.Drawing.Point(130, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Cena:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label10.Location = new System.Drawing.Point(33, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Towar:";
            // 
            // TBdodatkowe
            // 
            this.TBdodatkowe.Location = new System.Drawing.Point(14, 434);
            this.TBdodatkowe.Name = "TBdodatkowe";
            this.TBdodatkowe.Size = new System.Drawing.Size(509, 59);
            this.TBdodatkowe.TabIndex = 17;
            this.TBdodatkowe.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label11.Location = new System.Drawing.Point(11, 415);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Dodatkowe uwagi:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(535, 548);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TBdodatkowe);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DTwykonanie);
            this.Controls.Add(this.BTdodajZlecenie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTprzyjecie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodawanie zlecenia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTprzyjecie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTdodajZlecenie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTwykonanie;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox TBdodatkowe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BTdodajTowar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTtowary;
        private System.Windows.Forms.CheckBox CBwszystkoUslugi;
        private System.Windows.Forms.CheckBox CBwszystkoTowary;
        private System.Windows.Forms.Button BTdodajDoUslug;
        private System.Windows.Forms.Button BTusun;
        private System.Windows.Forms.Button BTuslugi;
        private System.Windows.Forms.Button BTdodajUsluga;
        private System.Windows.Forms.Button BTdodajDoTowarow;
        private System.Windows.Forms.Button BTusunTowary;
        private System.Windows.Forms.Label LdaneKlienta;
        private System.Windows.Forms.Button BTstaliKlienciZapisz;
    }
}