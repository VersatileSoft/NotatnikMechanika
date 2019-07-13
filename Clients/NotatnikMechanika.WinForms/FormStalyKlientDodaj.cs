using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormStalyKlientDodaj : Form
    {
        private Klient klient;
        private readonly bool fromLuncher;

        public FormStalyKlientDodaj(bool fromLuncher, Klient szblonKlient)
        {
            InitializeComponent();

            this.fromLuncher = fromLuncher;

            SprawdzCzyDemo();

            if (fromLuncher)
            {
                BTstaliKlienciZapisz.Visible = false;
                BTstaliKlieci.Visible = false;
                BTdodajDoStalych.Location = new Point(216, 276);
            }

            if (szblonKlient != null)
            {
                UzupelnijDane(szblonKlient);
            }
        }

        private void UzupelnijDane(Klient szblonKlient)
        {
            TBstaliKlienciImie.Text = szblonKlient.imie;
            TBstaliKlienciNazwisko.Text = szblonKlient.nazwisko;
            TBstaliKlienciMarka.Text = szblonKlient.marka;
            TBstaliKlienciModel.Text = szblonKlient.model;

            TBstaliKlienciRejestracja.Text = szblonKlient.rejestracja;
            TBstaliKlienciSilnik.Text = szblonKlient.silnik;
            TBstaliKlienciMoc.Text = szblonKlient.moc;
            TBstaliKlienciVin.Text = szblonKlient.vin;

            TBstaliKlienciTelefon.Text = szblonKlient.telefon;
            TBstaliKlienciAdres.Text = szblonKlient.adres;
            TBstaliKlienciPrzebieg.Text = szblonKlient.przebieg;
            TBstaliKlienciRokProdukcji.Text = szblonKlient.rokProdukcji;

            TBNazwaFirmy.Text = szblonKlient.nazwaFirmy;
            TBNip.Text = szblonKlient.nip;
        }

        public Klient ShowAndGetData()
        {
            ShowDialog();

            return klient;
        }

        private void BTstaliKlieci_Click(object sender, EventArgs e)
        {
            FormStaliKlienci formStaliKlienci = new FormStaliKlienci();

            formStaliKlienci.ShowDialog();

            if (Program.stalyKlientIndexSet)
            {

                Klient klient = Program.dataMenager.staliKlienci.ElementAt(Program.stalyKlientIndex);

                TBstaliKlienciImie.Text = klient.imie;
                TBstaliKlienciNazwisko.Text = klient.nazwisko;
                TBstaliKlienciMarka.Text = klient.marka;
                TBstaliKlienciModel.Text = klient.model;

                TBstaliKlienciRejestracja.Text = klient.rejestracja;
                TBstaliKlienciSilnik.Text = klient.silnik;
                TBstaliKlienciMoc.Text = klient.moc;
                TBstaliKlienciVin.Text = klient.vin;

                TBstaliKlienciTelefon.Text = klient.telefon;
                TBstaliKlienciAdres.Text = klient.adres;
                TBstaliKlienciPrzebieg.Text = klient.przebieg;
                TBstaliKlienciRokProdukcji.Text = klient.rokProdukcji;

                TBNazwaFirmy.Text = klient.nazwaFirmy;
                TBNip.Text = klient.nip;
            }
        }

        private void BTstaliKlienciZapisz_Click(object sender, EventArgs e)
        {

            klient = new Klient
            {
                imie = TBstaliKlienciImie.Text,
                nazwisko = TBstaliKlienciNazwisko.Text,
                marka = TBstaliKlienciMarka.Text,
                model = TBstaliKlienciModel.Text,

                rejestracja = TBstaliKlienciRejestracja.Text,
                silnik = TBstaliKlienciSilnik.Text,
                moc = TBstaliKlienciMoc.Text,
                vin = TBstaliKlienciVin.Text,

                telefon = TBstaliKlienciTelefon.Text,
                adres = TBstaliKlienciAdres.Text,
                przebieg = TBstaliKlienciPrzebieg.Text,
                rokProdukcji = TBstaliKlienciRokProdukcji.Text,

                nazwaFirmy = TBNazwaFirmy.Text,
                nip = TBNip.Text
            };

            Close();
        }

        private void BTdodajDoStalych_Click(object sender, EventArgs e)
        {
            if (TBstaliKlienciImie.Text != "" & TBstaliKlienciNazwisko.Text != "")
            {
                DodajDoStalych();

                if (!fromLuncher)
                {
                    MessageBox.Show(
                          "Klient został dodany do bazy danych",
                          "Klient",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(
                   "Pola Imię i Nazwisko nie mogą być puste",
                   "Klient",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
        }

        private void DodajDoStalych()
        {
            Program.dataMenager.staliKlienci.Add(
                new Klient()
                {
                    imie = TBstaliKlienciImie.Text,
                    nazwisko = TBstaliKlienciNazwisko.Text,
                    marka = TBstaliKlienciMarka.Text,
                    model = TBstaliKlienciModel.Text,

                    rejestracja = TBstaliKlienciRejestracja.Text,
                    silnik = TBstaliKlienciSilnik.Text,
                    moc = TBstaliKlienciMoc.Text,
                    vin = TBstaliKlienciVin.Text,

                    telefon = TBstaliKlienciTelefon.Text,
                    adres = TBstaliKlienciAdres.Text,
                    przebieg = TBstaliKlienciPrzebieg.Text,
                    rokProdukcji = TBstaliKlienciRokProdukcji.Text,

                    nazwaFirmy = TBNazwaFirmy.Text,
                    nip = TBNip.Text
                });

            if (fromLuncher)
            {
                Close();
            }
        }

        private void SprawdzCzyDemo()
        {
            if (Program.dataMenager.firstOpenSettings.demo)
            {
                BTstaliKlieci.Enabled = false;

                BTdodajDoStalych.Enabled = false;
            }
        }
    }
}