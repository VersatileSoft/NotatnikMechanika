namespace NotatnikMechanika.WinForms
{
    partial class FormTowary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTowary));
            this.BTdodaj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBSymbol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBNazwa = new System.Windows.Forms.TextBox();
            this.Ptowary = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTdodaj
            // 
            this.BTdodaj.Location = new System.Drawing.Point(294, 405);
            this.BTdodaj.Name = "BTdodaj";
            this.BTdodaj.Size = new System.Drawing.Size(100, 30);
            this.BTdodaj.TabIndex = 3;
            this.BTdodaj.Text = "Dodaj";
            this.BTdodaj.UseVisualStyleBackColor = true;
            this.BTdodaj.Click += new System.EventHandler(this.BTdodaj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBSymbol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TBNazwa);
            this.groupBox1.Controls.Add(this.Ptowary);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 387);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dostępne towary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(337, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Symbol";
            // 
            // TBSymbol
            // 
            this.TBSymbol.Location = new System.Drawing.Point(403, 350);
            this.TBSymbol.Name = "TBSymbol";
            this.TBSymbol.Size = new System.Drawing.Size(144, 20);
            this.TBSymbol.TabIndex = 8;
            this.TBSymbol.TextChanged += new System.EventHandler(this.TBSymbol_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(123, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nazwa";
            // 
            // TBNazwa
            // 
            this.TBNazwa.Location = new System.Drawing.Point(185, 350);
            this.TBNazwa.Name = "TBNazwa";
            this.TBNazwa.Size = new System.Drawing.Size(144, 20);
            this.TBNazwa.TabIndex = 6;
            this.TBNazwa.TextChanged += new System.EventHandler(this.TBNazwa_TextChanged);
            // 
            // Ptowary
            // 
            this.Ptowary.AutoScroll = true;
            this.Ptowary.Location = new System.Drawing.Point(7, 20);
            this.Ptowary.Name = "Ptowary";
            this.Ptowary.Size = new System.Drawing.Size(656, 314);
            this.Ptowary.TabIndex = 0;
            // 
            // FormTowary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 447);
            this.Controls.Add(this.BTdodaj);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTowary";
            this.Text = "Towary";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTdodaj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel Ptowary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBNazwa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBSymbol;
    }
}