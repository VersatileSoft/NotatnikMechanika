namespace NotatnikMechanika.WinForms
{
    partial class FormPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrint));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.GBpodsumowanie = new System.Windows.Forms.GroupBox();
            this.LuslugiTowarySuma = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LtowarySuma = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LuslugiSuma = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LVtowary = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.Lnip = new System.Windows.Forms.Label();
            this.LnipText = new System.Windows.Forms.Label();
            this.LkodPocztowy = new System.Windows.Forms.Label();
            this.Lmodel = new System.Windows.Forms.Label();
            this.Lmarka = new System.Windows.Forms.Label();
            this.Ladres = new System.Windows.Forms.Label();
            this.LnazwiskoKlient = new System.Windows.Forms.Label();
            this.LimieKlient = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ldata = new System.Windows.Forms.Label();
            this.Lnazwa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LVuslugi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hcena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.GBpodsumowanie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.GBpodsumowanie);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LVtowary);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Lnip);
            this.panel1.Controls.Add(this.LnipText);
            this.panel1.Controls.Add(this.LkodPocztowy);
            this.panel1.Controls.Add(this.Lmodel);
            this.panel1.Controls.Add(this.Lmarka);
            this.panel1.Controls.Add(this.Ladres);
            this.panel1.Controls.Add(this.LnazwiskoKlient);
            this.panel1.Controls.Add(this.LimieKlient);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Ldata);
            this.panel1.Controls.Add(this.Lnazwa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LVuslugi);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 1123);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label8.Location = new System.Drawing.Point(338, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 31);
            this.label8.TabIndex = 33;
            this.label8.Text = "Zlecenie";
            // 
            // GBpodsumowanie
            // 
            this.GBpodsumowanie.Controls.Add(this.LuslugiTowarySuma);
            this.GBpodsumowanie.Controls.Add(this.label9);
            this.GBpodsumowanie.Controls.Add(this.LtowarySuma);
            this.GBpodsumowanie.Controls.Add(this.label7);
            this.GBpodsumowanie.Controls.Add(this.LuslugiSuma);
            this.GBpodsumowanie.Controls.Add(this.label6);
            this.GBpodsumowanie.Location = new System.Drawing.Point(64, 950);
            this.GBpodsumowanie.Name = "GBpodsumowanie";
            this.GBpodsumowanie.Size = new System.Drawing.Size(677, 89);
            this.GBpodsumowanie.TabIndex = 32;
            this.GBpodsumowanie.TabStop = false;
            this.GBpodsumowanie.Text = "Podsumowanie";
            // 
            // LuslugiTowarySuma
            // 
            this.LuslugiTowarySuma.AutoSize = true;
            this.LuslugiTowarySuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.LuslugiTowarySuma.Location = new System.Drawing.Point(254, 41);
            this.LuslugiTowarySuma.Name = "LuslugiTowarySuma";
            this.LuslugiTowarySuma.Size = new System.Drawing.Size(27, 29);
            this.LuslugiTowarySuma.TabIndex = 5;
            this.LuslugiTowarySuma.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(232, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Razem:";
            // 
            // LtowarySuma
            // 
            this.LtowarySuma.AutoSize = true;
            this.LtowarySuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.LtowarySuma.Location = new System.Drawing.Point(481, 46);
            this.LtowarySuma.Name = "LtowarySuma";
            this.LtowarySuma.Size = new System.Drawing.Size(27, 29);
            this.LtowarySuma.TabIndex = 3;
            this.LtowarySuma.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cena za towary:";
            // 
            // LuslugiSuma
            // 
            this.LuslugiSuma.AutoSize = true;
            this.LuslugiSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.LuslugiSuma.Location = new System.Drawing.Point(48, 46);
            this.LuslugiSuma.Name = "LuslugiSuma";
            this.LuslugiSuma.Size = new System.Drawing.Size(27, 29);
            this.LuslugiSuma.TabIndex = 1;
            this.LuslugiSuma.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cena za usługi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(60, 629);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Towary:";
            // 
            // LVtowary
            // 
            this.LVtowary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.LVtowary.Location = new System.Drawing.Point(64, 652);
            this.LVtowary.Name = "LVtowary";
            this.LVtowary.Size = new System.Drawing.Size(677, 289);
            this.LVtowary.TabIndex = 20;
            this.LVtowary.UseCompatibleStateImageBehavior = false;
            this.LVtowary.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Lp.";
            this.columnHeader3.Width = 47;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nazwa towaru";
            this.columnHeader4.Width = 390;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cena";
            this.columnHeader5.Width = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(60, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Usługi:";
            // 
            // Lnip
            // 
            this.Lnip.AutoSize = true;
            this.Lnip.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lnip.Location = new System.Drawing.Point(104, 243);
            this.Lnip.Name = "Lnip";
            this.Lnip.Size = new System.Drawing.Size(44, 17);
            this.Lnip.TabIndex = 18;
            this.Lnip.Text = "8736";
            // 
            // LnipText
            // 
            this.LnipText.AutoSize = true;
            this.LnipText.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnipText.Location = new System.Drawing.Point(65, 243);
            this.LnipText.Name = "LnipText";
            this.LnipText.Size = new System.Drawing.Size(33, 17);
            this.LnipText.TabIndex = 17;
            this.LnipText.Text = "NIP";
            // 
            // LkodPocztowy
            // 
            this.LkodPocztowy.AutoSize = true;
            this.LkodPocztowy.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LkodPocztowy.Location = new System.Drawing.Point(65, 215);
            this.LkodPocztowy.Name = "LkodPocztowy";
            this.LkodPocztowy.Size = new System.Drawing.Size(115, 17);
            this.LkodPocztowy.TabIndex = 13;
            this.LkodPocztowy.Text = "Dynów 36-065";
            // 
            // Lmodel
            // 
            this.Lmodel.AutoSize = true;
            this.Lmodel.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lmodel.Location = new System.Drawing.Point(643, 186);
            this.Lmodel.Name = "Lmodel";
            this.Lmodel.Size = new System.Drawing.Size(28, 17);
            this.Lmodel.TabIndex = 12;
            this.Lmodel.Text = "A4";
            // 
            // Lmarka
            // 
            this.Lmarka.AutoSize = true;
            this.Lmarka.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lmarka.Location = new System.Drawing.Point(504, 186);
            this.Lmarka.Name = "Lmarka";
            this.Lmarka.Size = new System.Drawing.Size(44, 17);
            this.Lmarka.TabIndex = 11;
            this.Lmarka.Text = "Audi";
            // 
            // Ladres
            // 
            this.Ladres.AutoSize = true;
            this.Ladres.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ladres.Location = new System.Drawing.Point(65, 186);
            this.Ladres.Name = "Ladres";
            this.Ladres.Size = new System.Drawing.Size(86, 17);
            this.Ladres.TabIndex = 9;
            this.Ladres.Text = "Wyręby 21";
            // 
            // LnazwiskoKlient
            // 
            this.LnazwiskoKlient.AutoSize = true;
            this.LnazwiskoKlient.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnazwiskoKlient.Location = new System.Drawing.Point(643, 157);
            this.LnazwiskoKlient.Name = "LnazwiskoKlient";
            this.LnazwiskoKlient.Size = new System.Drawing.Size(74, 17);
            this.LnazwiskoKlient.TabIndex = 8;
            this.LnazwiskoKlient.Text = "Kowalski";
            // 
            // LimieKlient
            // 
            this.LimieKlient.AutoSize = true;
            this.LimieKlient.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimieKlient.Location = new System.Drawing.Point(504, 157);
            this.LimieKlient.Name = "LimieKlient";
            this.LimieKlient.Size = new System.Drawing.Size(32, 17);
            this.LimieKlient.TabIndex = 7;
            this.LimieKlient.Text = "Jan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(503, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nabywca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(643, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data:";
            // 
            // Ldata
            // 
            this.Ldata.AutoSize = true;
            this.Ldata.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ldata.Location = new System.Drawing.Point(643, 61);
            this.Ldata.Name = "Ldata";
            this.Ldata.Size = new System.Drawing.Size(98, 18);
            this.Ldata.TabIndex = 4;
            this.Ldata.Text = "28.01.2017";
            // 
            // Lnazwa
            // 
            this.Lnazwa.AutoSize = true;
            this.Lnazwa.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lnazwa.Location = new System.Drawing.Point(65, 157);
            this.Lnazwa.Name = "Lnazwa";
            this.Lnazwa.Size = new System.Drawing.Size(72, 17);
            this.Lnazwa.TabIndex = 2;
            this.Lnazwa.Text = "Womech";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(60, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sprzedawca:";
            // 
            // LVuslugi
            // 
            this.LVuslugi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.Hcena});
            this.LVuslugi.Location = new System.Drawing.Point(64, 337);
            this.LVuslugi.Name = "LVuslugi";
            this.LVuslugi.Size = new System.Drawing.Size(677, 289);
            this.LVuslugi.TabIndex = 0;
            this.LVuslugi.UseCompatibleStateImageBehavior = false;
            this.LVuslugi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Lp.";
            this.columnHeader1.Width = 47;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nazwa usługi";
            this.columnHeader2.Width = 390;
            // 
            // Hcena
            // 
            this.Hcena.Text = "Cena";
            this.Hcena.Width = 95;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.ShowIcon = false;
            this.printPreviewDialog1.Visible = false;
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(796, 772);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPrint";
            this.Text = "Form4";
            this.Shown += new System.EventHandler(this.FormPrint_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBpodsumowanie.ResumeLayout(false);
            this.GBpodsumowanie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView LVuslugi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader Hcena;
        private System.Windows.Forms.Label Lnazwa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lnip;
        private System.Windows.Forms.Label LnipText;
        private System.Windows.Forms.Label LkodPocztowy;
        private System.Windows.Forms.Label Lmodel;
        private System.Windows.Forms.Label Lmarka;
        private System.Windows.Forms.Label Ladres;
        private System.Windows.Forms.Label LnazwiskoKlient;
        private System.Windows.Forms.Label LimieKlient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Ldata;
        public System.Windows.Forms.Panel panel1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView LVtowary;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GBpodsumowanie;
        private System.Windows.Forms.Label LuslugiTowarySuma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LtowarySuma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LuslugiSuma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}