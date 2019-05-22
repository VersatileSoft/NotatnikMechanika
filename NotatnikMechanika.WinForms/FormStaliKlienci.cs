using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormStaliKlienci : Form
    {
        private RadioButton szablonRadioButton;
        private int iloscKlientow;

        public FormStaliKlienci()
        {
            InitializeComponent();

            DodajKlientow("");
        }

        private void BTdodaj_Click(object sender, EventArgs e)
        {
            Program.stalyKlientIndexSet = false;
            foreach (Control control in PstaliKlienci.Controls)
            {
                RadioButton check = (RadioButton)control;

                if (check.Checked)
                {
                    Program.stalyKlientIndexSet = true;

                    Program.stalyKlientIndex = int.Parse(check.Text.Split('.')[0]) - 1;
                }
            }

            Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DodajKlientow(textBox1.Text);
        }

        private void DodajKlientow(string search)
        {
            PstaliKlienci.Controls.Clear();
            iloscKlientow = 0;

            int nrKlienta = 0;

            foreach (Klient klient in Program.dataMenager.staliKlienci)
            {
                nrKlienta++;
                szablonRadioButton = new RadioButton
                {
                    Location = new Point(12, 12 + 26 * iloscKlientow),
                    Size = new Size(450, 21),
                    Font = new Font("Microsoft Sans Serif", 10.25F),
                    Text = nrKlienta + "." + klient.imie + " " + klient.nazwisko + " " + klient.marka + " " + klient.model + " " + klient.rejestracja + " " + klient.silnik + " " + klient.moc + " " + klient.vin
                };

                if (search == "")
                {
                    PstaliKlienci.Controls.Add(szablonRadioButton);

                    iloscKlientow++;
                }
                else
                if (szablonRadioButton.Text.ToLower().Contains(search.ToLower()))
                {
                    PstaliKlienci.Controls.Add(szablonRadioButton);

                    iloscKlientow++;
                }
            }
        }
    }
}