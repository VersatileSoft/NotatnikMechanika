using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormTowary : Form
    {
        private CheckBox szablonCheckBox;
        private int iloscTowarow;

        public FormTowary()
        {
            InitializeComponent();

            DodajTowary("", "");
        }

        private void BTdodaj_Click(object sender, EventArgs e)
        {
            foreach (Control control in Ptowary.Controls)
            {
                CheckBox check = (CheckBox)control;

                if (check.Checked)
                {
                    int index = int.Parse(check.Text.Split('.')[0]) - 1;

                    Program.dataMenager.towary.ElementAt(index).dodajDoZlecenia = check.Checked;
                }
            }
            Close();
        }

        private void TBNazwa_TextChanged(object sender, EventArgs e)
        {
            DodajTowary(TBNazwa.Text, TBSymbol.Text);
        }

        private void TBSymbol_TextChanged(object sender, EventArgs e)
        {
            DodajTowary(TBNazwa.Text, TBSymbol.Text);
        }

        private void DodajTowary(string nazwa, string symbol)
        {

            Ptowary.Controls.Clear();
            iloscTowarow = 0;

            int nrTowaru = 0;

            foreach (Towar towar in Program.dataMenager.towary)
            {
                nrTowaru++;

                szablonCheckBox = new CheckBox
                {
                    Location = new Point(6, 6 + 26 * iloscTowarow),
                    Size = new Size(630, 21),
                    Font = new Font("Microsoft Sans Serif", 10.25F)
                };

                if (Program.dataMenager.daneFirmy.magazyn)
                {
                    szablonCheckBox.Text = nrTowaru + ". " + towar.nazwa + " " + towar.symbol + " x" + towar.ilosc;
                }

                if (!Program.dataMenager.daneFirmy.magazyn)
                {
                    szablonCheckBox.Text = nrTowaru + ". " + towar.nazwa + " " + towar.symbol;
                }

                if (nazwa == "" && symbol == "")
                {
                    Ptowary.Controls.Add(szablonCheckBox);

                    iloscTowarow++;
                }
                else
                if (nazwa != "" && symbol == "")
                {
                    if (towar.nazwa.ToLower().Contains(nazwa.ToLower()))
                    {
                        Ptowary.Controls.Add(szablonCheckBox);

                        iloscTowarow++;
                    }
                }
                else
                if (nazwa == "" && symbol != "")
                {
                    if (towar.symbol.ToLower().Contains(symbol.ToLower()))
                    {
                        Ptowary.Controls.Add(szablonCheckBox);

                        iloscTowarow++;
                    }
                }
                else
                if (nazwa != "" && symbol != "")
                {
                    if (towar.nazwa.ToLower().Contains(nazwa.ToLower()) && towar.symbol.ToLower().Contains(symbol.ToLower()))
                    {
                        Ptowary.Controls.Add(szablonCheckBox);

                        iloscTowarow++;
                    }
                }
            }
        }
    }
}