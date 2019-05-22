namespace NotatnikMechanika.WinForms
{
    partial class FormPrzywitanie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrzywitanie));
            this.Lnotatnik = new System.Windows.Forms.Label();
            this.TBklucz = new System.Windows.Forms.TextBox();
            this.BTzatwierdz = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BTdemo = new System.Windows.Forms.Button();
            this.BTklucz = new System.Windows.Forms.Button();
            this.Lnieprawidłowy = new System.Windows.Forms.Label();
            this.PBklucze = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PBklucze)).BeginInit();
            this.SuspendLayout();
            // 
            // Lnotatnik
            // 
            this.Lnotatnik.AutoSize = true;
            this.Lnotatnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lnotatnik.Location = new System.Drawing.Point(205, 189);
            this.Lnotatnik.Name = "Lnotatnik";
            this.Lnotatnik.Size = new System.Drawing.Size(371, 46);
            this.Lnotatnik.TabIndex = 2;
            this.Lnotatnik.Text = "Notatnik mechanika";
            // 
            // TBklucz
            // 
            this.TBklucz.Location = new System.Drawing.Point(136, 456);
            this.TBklucz.Name = "TBklucz";
            this.TBklucz.Size = new System.Drawing.Size(204, 20);
            this.TBklucz.TabIndex = 4;
            this.TBklucz.Visible = false;
            // 
            // BTzatwierdz
            // 
            this.BTzatwierdz.Location = new System.Drawing.Point(342, 317);
            this.BTzatwierdz.Name = "BTzatwierdz";
            this.BTzatwierdz.Size = new System.Drawing.Size(100, 35);
            this.BTzatwierdz.TabIndex = 5;
            this.BTzatwierdz.Text = "Dalej";
            this.BTzatwierdz.UseVisualStyleBackColor = true;
            this.BTzatwierdz.Click += new System.EventHandler(this.BTzatwierdz_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(479, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Wypróbuj wersję demo:";
            this.label4.Visible = false;
            // 
            // BTdemo
            // 
            this.BTdemo.Location = new System.Drawing.Point(550, 479);
            this.BTdemo.Name = "BTdemo";
            this.BTdemo.Size = new System.Drawing.Size(86, 29);
            this.BTdemo.TabIndex = 7;
            this.BTdemo.Text = "Dalej";
            this.BTdemo.UseVisualStyleBackColor = true;
            this.BTdemo.Visible = false;
            this.BTdemo.Click += new System.EventHandler(this.BTdemo_Click);
            // 
            // BTklucz
            // 
            this.BTklucz.Location = new System.Drawing.Point(239, 482);
            this.BTklucz.Name = "BTklucz";
            this.BTklucz.Size = new System.Drawing.Size(86, 29);
            this.BTklucz.TabIndex = 8;
            this.BTklucz.Text = "Kup klucz";
            this.BTklucz.UseVisualStyleBackColor = true;
            this.BTklucz.Visible = false;
            this.BTklucz.Click += new System.EventHandler(this.BTklucz_Click);
            // 
            // Lnieprawidłowy
            // 
            this.Lnieprawidłowy.AutoSize = true;
            this.Lnieprawidłowy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Lnieprawidłowy.ForeColor = System.Drawing.Color.DarkRed;
            this.Lnieprawidłowy.Location = new System.Drawing.Point(144, 514);
            this.Lnieprawidłowy.Name = "Lnieprawidłowy";
            this.Lnieprawidłowy.Size = new System.Drawing.Size(188, 17);
            this.Lnieprawidłowy.TabIndex = 9;
            this.Lnieprawidłowy.Text = "Nieprawidłowy klucz dostępu";
            this.Lnieprawidłowy.Visible = false;
            // 
            // PBklucze
            // 
            this.PBklucze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBklucze.Image = global::NotatnikMechanika.WinForms.Properties.Resources.Logo;
            this.PBklucze.Location = new System.Drawing.Point(342, 49);
            this.PBklucze.Name = "PBklucze";
            this.PBklucze.Size = new System.Drawing.Size(100, 100);
            this.PBklucze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBklucze.TabIndex = 1;
            this.PBklucze.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(444, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pełna wersja";
            // 
            // FormPrzywitanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 443);
            this.Controls.Add(this.Lnieprawidłowy);
            this.Controls.Add(this.BTklucz);
            this.Controls.Add(this.BTdemo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BTzatwierdz);
            this.Controls.Add(this.TBklucz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lnotatnik);
            this.Controls.Add(this.PBklucze);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPrzywitanie";
            this.Text = "Notatnik mechanika";
            ((System.ComponentModel.ISupportInitialize)(this.PBklucze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PBklucze;
        private System.Windows.Forms.Label Lnotatnik;
        private System.Windows.Forms.TextBox TBklucz;
        private System.Windows.Forms.Button BTzatwierdz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTdemo;
        private System.Windows.Forms.Button BTklucz;
        private System.Windows.Forms.Label Lnieprawidłowy;
        private System.Windows.Forms.Label label1;
    }
}