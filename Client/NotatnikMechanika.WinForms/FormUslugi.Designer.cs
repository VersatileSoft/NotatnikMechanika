namespace NotatnikMechanika.WinForms
{
    partial class FormUslugi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUslugi));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBszukaj = new System.Windows.Forms.TextBox();
            this.Puslugi = new System.Windows.Forms.Panel();
            this.BTdodaj = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TBszukaj);
            this.groupBox1.Controls.Add(this.Puslugi);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dostępne usługi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(193, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nazwa";
            // 
            // TBszukaj
            // 
            this.TBszukaj.Location = new System.Drawing.Point(258, 236);
            this.TBszukaj.Name = "TBszukaj";
            this.TBszukaj.Size = new System.Drawing.Size(144, 20);
            this.TBszukaj.TabIndex = 4;
            this.TBszukaj.TextChanged += new System.EventHandler(this.TBszukaj_TextChanged);
            // 
            // Puslugi
            // 
            this.Puslugi.AutoScroll = true;
            this.Puslugi.Location = new System.Drawing.Point(7, 20);
            this.Puslugi.Name = "Puslugi";
            this.Puslugi.Size = new System.Drawing.Size(604, 210);
            this.Puslugi.TabIndex = 0;
            // 
            // BTdodaj
            // 
            this.BTdodaj.Location = new System.Drawing.Point(267, 286);
            this.BTdodaj.Name = "BTdodaj";
            this.BTdodaj.Size = new System.Drawing.Size(100, 30);
            this.BTdodaj.TabIndex = 1;
            this.BTdodaj.Text = "Dodaj";
            this.BTdodaj.UseVisualStyleBackColor = true;
            this.BTdodaj.Click += new System.EventHandler(this.BTdodaj_Click);
            // 
            // FormUslugi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 325);
            this.Controls.Add(this.BTdodaj);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormUslugi";
            this.Text = "Usługi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel Puslugi;
        private System.Windows.Forms.Button BTdodaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBszukaj;
    }
}