using System;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormUslugaTowarFaktura : Form
    {
        public FormUslugaTowarFaktura()
        {
            InitializeComponent();

            BTdodaj.Text = "Dodaj";

            Text = "Dodaj";

            CBvat.Text = Program.dataMenager.daneFirmy.DeaflutVAT;

            CBjm.SelectedIndex = 0;
        }

        public FormUslugaTowarFaktura(ListViewItem item)
        {
            InitializeComponent();

            BTdodaj.Text = "Edytuj";
            Text = "Edytuj";

            //  CBvat.SelectedIndex = 0;
            CBjm.SelectedIndex = 0;

            TBnazwa.Text = item.SubItems[1].Text;
            TBbrutto.Text = item.SubItems[2].Text;

            if (item.SubItems[6].Text == "zw")
            {
                CBvat.Text = "zw";
            }
            else
            {
                CBvat.Text = item.SubItems[6].Text.Replace("%", "");
            }

            LiczNetto();

            TBilosc.Text = item.SubItems[3].Text;
            CBjm.Text = item.SubItems[4].Text;

            Program.itemFaktura = item;
        }

        private void BTdodaj_Click(object sender, EventArgs e)
        {
            if (TBilosc.Text == "")
            {
                TBilosc.Text = "1";
            }

            if (Program.itemFaktura != null)
            {
                try
                {
                    Program.itemFaktura.SubItems[1].Text = TBnazwa.Text;
                    Program.itemFaktura.SubItems[2].Text = TBbrutto.Text;
                    Program.itemFaktura.SubItems[3].Text = TBilosc.Text;
                    Program.itemFaktura.SubItems[4].Text = CBjm.Text;
                    Program.itemFaktura.SubItems[5].Text = (double.Parse(TBnetto.Text) * double.Parse(TBilosc.Text)).ToString();

                    if (CBvat.Text == "zw")
                    {
                        Program.itemFaktura.SubItems[6].Text = "zw";
                        Program.itemFaktura.SubItems[7].Text = (Program.KwotaVatzNetto(double.Parse(TBnetto.Text), 0 * double.Parse(TBilosc.Text)).ToString());
                    }
                    else
                    {
                        Program.itemFaktura.SubItems[6].Text = CBvat.Text + "%";
                        Program.itemFaktura.SubItems[7].Text = (Program.KwotaVatzNetto(double.Parse(TBnetto.Text), double.Parse(CBvat.Text)) * double.Parse(TBilosc.Text)).ToString();
                    }

                    Program.itemFaktura.SubItems[8].Text = (double.Parse(TBbrutto.Text) * double.Parse(TBilosc.Text)).ToString();
                    Close();
                }
                catch
                {
                    Close();
                }
            }
            else
            {
                try
                {

                    if (Program.dataMenager.daneFirmy.DeaflutVAT == "zw")
                    {
                        Program.formPrintFaktura.DodajUslugeTowar(TBnazwa.Text, double.Parse(TBbrutto.Text), double.Parse(TBilosc.Text), CBjm.Text, 0);
                    }
                    else
                    {
                        Program.formPrintFaktura.DodajUslugeTowar(TBnazwa.Text, double.Parse(TBbrutto.Text), double.Parse(TBilosc.Text), CBjm.Text, double.Parse(Program.dataMenager.daneFirmy.DeaflutVAT));
                    }

                    Close();
                }
                catch
                {
                    MessageBox.Show(
                   "Błąd. Uzupęnij wszystkie pola",
                   "Błąd",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        #region obliczanie cen
        private void TBnetto_TextChanged(object sender, EventArgs e)
        {
            if (TBnetto.Focused)
            {
                if (TBnetto.Text == "")
                {
                    TBbrutto.Text = "";

                }
                else
                {
                    LiczBrutto();
                }
            }
        }
        private void TBbrutto_TextChanged(object sender, EventArgs e)
        {

            if (TBbrutto.Focused)
            {
                if (TBbrutto.Text == "")
                {
                    TBnetto.Text = "";

                }
                else
                {

                    LiczNetto();

                }
            }
        }

        private void CBvat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TBnetto.Text != "")
            {
                try
                {
                    TBbrutto.Text = (Program.KwotaVatzNetto(double.Parse(TBnetto.Text), (CBvat.Text != "zw" ? double.Parse(CBvat.Text) : 0)) + double.Parse(TBnetto.Text)).ToString();
                }
                catch { }

            }
            else
            {
                if (TBnetto.Text != "")
                {
                    try
                    {
                        TBnetto.Text = (double.Parse(TBbrutto.Text) - Program.KwotaVatzBrutto(double.Parse(TBbrutto.Text), (CBvat.Text != "zw" ? double.Parse(CBvat.Text) : 0))).ToString();
                    }
                    catch { }
                }
            }
        }
        #endregion

        private void BTuslugi_Click(object sender, EventArgs e)
        {
            FormUslugi formUslugi = new FormUslugi();

            formUslugi.ShowDialog();

            foreach (Usluga usluga in Program.dataMenager.uslugi)
            {
                if (usluga.dodajDoZlecenia)
                {
                    TBnazwa.Text = usluga.nazwa;
                    TBbrutto.Text = usluga.cena;
                }
                usluga.dodajDoZlecenia = false;
            }
        }

        private void BTtowary_Click(object sender, EventArgs e)
        {
            FormTowary formTowary = new FormTowary();

            formTowary.ShowDialog();

            foreach (Towar towar in Program.dataMenager.towary)
            {
                if (towar.dodajDoZlecenia)
                {
                    TBnazwa.Text = towar.nazwa;
                    TBbrutto.Text = towar.cena;
                }
                towar.dodajDoZlecenia = false;
            }

            LiczNetto();
        }

        private void LiczNetto()
        {
            try
            {
                TBnetto.Text = (double.Parse(TBbrutto.Text) -
                    Program.KwotaVatzBrutto(
                        double.Parse(TBbrutto.Text),
                        (CBvat.Text != "zw" ? double.Parse(CBvat.Text) : 0))
                        ).ToString();
            }
            catch { }
        }

        private void LiczBrutto()
        {
            try
            {
                TBbrutto.Text = (Program.KwotaVatzNetto(
                    double.Parse(TBnetto.Text),
                    (CBvat.Text != "zw" ? double.Parse(CBvat.Text) : 0))
                    + double.Parse(TBnetto.Text)).ToString();
            }
            catch { }
        }
    }
}