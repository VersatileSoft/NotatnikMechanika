using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormUslugi : Form
    {
        private CheckBox szablonCheckBox;
        private int iloscUslug;

        public FormUslugi()
        {
            InitializeComponent();

            DodajUslugi("");
        }

        private void BTdodaj_Click(object sender, EventArgs e)
        {
            foreach (Control control in Puslugi.Controls)
            {
                CheckBox check = (CheckBox)control;

                if (check.Checked)
                {
                    int index = int.Parse(check.Text.Split('.')[0]) - 1;

                    Program.dataMenager.uslugi.ElementAt(index).dodajDoZlecenia = check.Checked;
                }
            }
            Close();
        }

        private void TBszukaj_TextChanged(object sender, EventArgs e)
        {
            DodajUslugi(TBszukaj.Text);
        }

        private void DodajUslugi(string search)
        {
            Puslugi.Controls.Clear();
            iloscUslug = 0;

            int nrTowaru = 0;

            foreach (Usluga usluga in Program.dataMenager.uslugi)
            {
                nrTowaru++;

                szablonCheckBox = new CheckBox
                {
                    Location = new Point(6, 6 + 26 * iloscUslug),
                    Size = new Size(234, 21),
                    Font = new Font("Microsoft Sans Serif", 10.25F),
                    Text = nrTowaru + ". " + usluga.nazwa
                };


                if (search == "")
                {
                    Puslugi.Controls.Add(szablonCheckBox);

                    iloscUslug++;
                }
                else

                if (usluga.nazwa.ToLower().Contains(search.ToLower()))
                {
                    Puslugi.Controls.Add(szablonCheckBox);

                    iloscUslug++;
                }
            }
        }
    }
}