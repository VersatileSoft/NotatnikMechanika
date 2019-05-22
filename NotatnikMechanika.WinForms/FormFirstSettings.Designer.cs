namespace NotatnikMechanika.WinForms
{
    partial class FormFirstSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFirstSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.BTdalej = new System.Windows.Forms.Button();
            this.GBszyfrowanieDanych = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.LrozneHasla = new System.Windows.Forms.Label();
            this.RBnieUzywajHasla = new System.Windows.Forms.RadioButton();
            this.RBuzywajHasla = new System.Windows.Forms.RadioButton();
            this.TBpowtorzHaslo = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBhaslo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GBdaneFirmy = new System.Windows.Forms.GroupBox();
            this.TBkonto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TBbank = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TBregon = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TBtelefon = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TBmiejscowosc = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TBadres = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TBnazwa = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TBkodPocztowy = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TBnip = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GBszyfrowanieDanych.SuspendLayout();
            this.GBdaneFirmy.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(61, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Przed uruchomieniem programu musisz skonfigurować parę rzeczy. To zajmie tylko ch" +
    "wilkę.";
            // 
            // BTdalej
            // 
            this.BTdalej.Location = new System.Drawing.Point(315, 412);
            this.BTdalej.Name = "BTdalej";
            this.BTdalej.Size = new System.Drawing.Size(130, 40);
            this.BTdalej.TabIndex = 2;
            this.BTdalej.Text = "Dalej";
            this.BTdalej.UseVisualStyleBackColor = true;
            this.BTdalej.Click += new System.EventHandler(this.BTdalej_Click);
            // 
            // GBszyfrowanieDanych
            // 
            this.GBszyfrowanieDanych.Controls.Add(this.label16);
            this.GBszyfrowanieDanych.Controls.Add(this.LrozneHasla);
            this.GBszyfrowanieDanych.Controls.Add(this.RBnieUzywajHasla);
            this.GBszyfrowanieDanych.Controls.Add(this.RBuzywajHasla);
            this.GBszyfrowanieDanych.Controls.Add(this.TBpowtorzHaslo);
            this.GBszyfrowanieDanych.Controls.Add(this.label7);
            this.GBszyfrowanieDanych.Controls.Add(this.TBhaslo);
            this.GBszyfrowanieDanych.Controls.Add(this.label6);
            this.GBszyfrowanieDanych.Controls.Add(this.label5);
            this.GBszyfrowanieDanych.Controls.Add(this.label4);
            this.GBszyfrowanieDanych.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.GBszyfrowanieDanych.Location = new System.Drawing.Point(12, 58);
            this.GBszyfrowanieDanych.Name = "GBszyfrowanieDanych";
            this.GBszyfrowanieDanych.Size = new System.Drawing.Size(730, 348);
            this.GBszyfrowanieDanych.TabIndex = 3;
            this.GBszyfrowanieDanych.TabStop = false;
            this.GBszyfrowanieDanych.Text = "Szyfrowanie danych";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(6, 259);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(638, 18);
            this.label16.TabIndex = 12;
            this.label16.Text = "Uwaga! Zapamiętaj hasło ponieważ jeśli je zapomnisz stracisz dane zapisane w prog" +
    "ramie.";
            // 
            // LrozneHasla
            // 
            this.LrozneHasla.AutoSize = true;
            this.LrozneHasla.ForeColor = System.Drawing.Color.Maroon;
            this.LrozneHasla.Location = new System.Drawing.Point(142, 177);
            this.LrozneHasla.Name = "LrozneHasla";
            this.LrozneHasla.Size = new System.Drawing.Size(103, 17);
            this.LrozneHasla.TabIndex = 11;
            this.LrozneHasla.Text = "Hasła są różne";
            this.LrozneHasla.Visible = false;
            // 
            // RBnieUzywajHasla
            // 
            this.RBnieUzywajHasla.AutoSize = true;
            this.RBnieUzywajHasla.Location = new System.Drawing.Point(410, 73);
            this.RBnieUzywajHasla.Name = "RBnieUzywajHasla";
            this.RBnieUzywajHasla.Size = new System.Drawing.Size(201, 21);
            this.RBnieUzywajHasla.TabIndex = 10;
            this.RBnieUzywajHasla.Text = "Nie używaj hasła do danych";
            this.RBnieUzywajHasla.UseVisualStyleBackColor = true;
            // 
            // RBuzywajHasla
            // 
            this.RBuzywajHasla.AutoSize = true;
            this.RBuzywajHasla.Checked = true;
            this.RBuzywajHasla.Location = new System.Drawing.Point(39, 73);
            this.RBuzywajHasla.Name = "RBuzywajHasla";
            this.RBuzywajHasla.Size = new System.Drawing.Size(178, 21);
            this.RBuzywajHasla.TabIndex = 9;
            this.RBuzywajHasla.TabStop = true;
            this.RBuzywajHasla.Text = "Używaj hasła do danych";
            this.RBuzywajHasla.UseVisualStyleBackColor = true;
            this.RBuzywajHasla.CheckedChanged += new System.EventHandler(this.RBuzywajHasla_CheckedChanged);
            // 
            // TBpowtorzHaslo
            // 
            this.TBpowtorzHaslo.Location = new System.Drawing.Point(142, 148);
            this.TBpowtorzHaslo.Name = "TBpowtorzHaslo";
            this.TBpowtorzHaslo.Size = new System.Drawing.Size(100, 23);
            this.TBpowtorzHaslo.TabIndex = 8;
            this.TBpowtorzHaslo.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Powtórz hasło:";
            // 
            // TBhaslo
            // 
            this.TBhaslo.Location = new System.Drawing.Point(142, 119);
            this.TBhaslo.Name = "TBhaslo";
            this.TBhaslo.Size = new System.Drawing.Size(100, 23);
            this.TBhaslo.TabIndex = 6;
            this.TBhaslo.UseSystemPasswordChar = true;
            this.TBhaslo.TextChanged += new System.EventHandler(this.TBhaslo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hasło:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(6, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(392, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hasło można zmienić później w ustawieniach programu.";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(630, 42);
            this.label4.TabIndex = 1;
            this.label4.Text = "W programie dla bezpieczeństwa danych jest możliwość zaszyfrowania bazy stałych k" +
    "lientów, zleceń oraz archiwum. Czy chcesz ustawić hasło dla tych danych? ";
            // 
            // GBdaneFirmy
            // 
            this.GBdaneFirmy.Controls.Add(this.TBkonto);
            this.GBdaneFirmy.Controls.Add(this.label9);
            this.GBdaneFirmy.Controls.Add(this.TBbank);
            this.GBdaneFirmy.Controls.Add(this.label17);
            this.GBdaneFirmy.Controls.Add(this.TBregon);
            this.GBdaneFirmy.Controls.Add(this.label18);
            this.GBdaneFirmy.Controls.Add(this.TBtelefon);
            this.GBdaneFirmy.Controls.Add(this.label19);
            this.GBdaneFirmy.Controls.Add(this.TBmiejscowosc);
            this.GBdaneFirmy.Controls.Add(this.label20);
            this.GBdaneFirmy.Controls.Add(this.label10);
            this.GBdaneFirmy.Controls.Add(this.TBadres);
            this.GBdaneFirmy.Controls.Add(this.label14);
            this.GBdaneFirmy.Controls.Add(this.TBnazwa);
            this.GBdaneFirmy.Controls.Add(this.label13);
            this.GBdaneFirmy.Controls.Add(this.TBkodPocztowy);
            this.GBdaneFirmy.Controls.Add(this.label12);
            this.GBdaneFirmy.Controls.Add(this.TBnip);
            this.GBdaneFirmy.Controls.Add(this.label11);
            this.GBdaneFirmy.Controls.Add(this.label8);
            this.GBdaneFirmy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.GBdaneFirmy.Location = new System.Drawing.Point(12, 58);
            this.GBdaneFirmy.Name = "GBdaneFirmy";
            this.GBdaneFirmy.Size = new System.Drawing.Size(730, 348);
            this.GBdaneFirmy.TabIndex = 3;
            this.GBdaneFirmy.TabStop = false;
            this.GBdaneFirmy.Text = "Dane firmy";
            // 
            // TBkonto
            // 
            this.TBkonto.Location = new System.Drawing.Point(410, 156);
            this.TBkonto.Name = "TBkonto";
            this.TBkonto.Size = new System.Drawing.Size(153, 23);
            this.TBkonto.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label9.Location = new System.Drawing.Point(315, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Numer konta";
            // 
            // TBbank
            // 
            this.TBbank.Location = new System.Drawing.Point(410, 127);
            this.TBbank.Name = "TBbank";
            this.TBbank.Size = new System.Drawing.Size(153, 23);
            this.TBbank.TabIndex = 35;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label17.Location = new System.Drawing.Point(364, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 17);
            this.label17.TabIndex = 34;
            this.label17.Text = "Bank";
            // 
            // TBregon
            // 
            this.TBregon.Location = new System.Drawing.Point(410, 96);
            this.TBregon.Name = "TBregon";
            this.TBregon.Size = new System.Drawing.Size(153, 23);
            this.TBregon.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label18.Location = new System.Drawing.Point(345, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 17);
            this.label18.TabIndex = 32;
            this.label18.Text = "REGON";
            // 
            // TBtelefon
            // 
            this.TBtelefon.Location = new System.Drawing.Point(126, 183);
            this.TBtelefon.Name = "TBtelefon";
            this.TBtelefon.Size = new System.Drawing.Size(153, 23);
            this.TBtelefon.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label19.Location = new System.Drawing.Point(64, 183);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 17);
            this.label19.TabIndex = 30;
            this.label19.Text = "Telefon";
            // 
            // TBmiejscowosc
            // 
            this.TBmiejscowosc.Location = new System.Drawing.Point(126, 154);
            this.TBmiejscowosc.Name = "TBmiejscowosc";
            this.TBmiejscowosc.Size = new System.Drawing.Size(153, 23);
            this.TBmiejscowosc.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label20.Location = new System.Drawing.Point(34, 154);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 17);
            this.label20.TabIndex = 28;
            this.label20.Text = "Miejscowość";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(25, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(446, 18);
            this.label10.TabIndex = 14;
            this.label10.Text = "Te ustawienia można zmienić później w ustawieniach programu.";
            // 
            // TBadres
            // 
            this.TBadres.Location = new System.Drawing.Point(126, 96);
            this.TBadres.Name = "TBadres";
            this.TBadres.Size = new System.Drawing.Size(153, 23);
            this.TBadres.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label14.Location = new System.Drawing.Point(75, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "Adres";
            // 
            // TBnazwa
            // 
            this.TBnazwa.Location = new System.Drawing.Point(126, 67);
            this.TBnazwa.Name = "TBnazwa";
            this.TBnazwa.Size = new System.Drawing.Size(153, 23);
            this.TBnazwa.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label13.Location = new System.Drawing.Point(36, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Nazwa firmy";
            // 
            // TBkodPocztowy
            // 
            this.TBkodPocztowy.Location = new System.Drawing.Point(126, 125);
            this.TBkodPocztowy.Name = "TBkodPocztowy";
            this.TBkodPocztowy.Size = new System.Drawing.Size(61, 23);
            this.TBkodPocztowy.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label12.Location = new System.Drawing.Point(25, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "Kod pocztowy";
            // 
            // TBnip
            // 
            this.TBnip.Location = new System.Drawing.Point(410, 67);
            this.TBnip.Name = "TBnip";
            this.TBnip.Size = new System.Drawing.Size(153, 23);
            this.TBnip.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label11.Location = new System.Drawing.Point(374, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "NIP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(575, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Podaj dane swojej firmy. Będą one widoczne na wydruku zlecenia oraz na fakturze.";
            // 
            // FormFirstSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 464);
            this.Controls.Add(this.BTdalej);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GBdaneFirmy);
            this.Controls.Add(this.GBszyfrowanieDanych);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormFirstSettings";
            this.Text = "Ustawienia";
            this.GBszyfrowanieDanych.ResumeLayout(false);
            this.GBszyfrowanieDanych.PerformLayout();
            this.GBdaneFirmy.ResumeLayout(false);
            this.GBdaneFirmy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTdalej;
        private System.Windows.Forms.GroupBox GBszyfrowanieDanych;
        private System.Windows.Forms.MaskedTextBox TBpowtorzHaslo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox TBhaslo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RBnieUzywajHasla;
        private System.Windows.Forms.RadioButton RBuzywajHasla;
        private System.Windows.Forms.GroupBox GBdaneFirmy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBadres;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TBnazwa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TBkodPocztowy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TBnip;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LrozneHasla;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TBkonto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBbank;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TBregon;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TBtelefon;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TBmiejscowosc;
        private System.Windows.Forms.Label label20;
    }
}