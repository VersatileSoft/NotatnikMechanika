using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormPrintFakturaDane : Form
    {
        private Klient klient;
        private readonly FakturaDane faktura;
        private int index;
        private readonly bool paragon;
        private double calkowityKoszt;
        private double sumaNetto;
        private double sumaVAT;


        public FormPrintFakturaDane(bool empty, bool paragon)
        {
            InitializeComponent();

            this.paragon = paragon;

            SprawdzCzyPusty(empty);

            UstawDaneFirmy();

            SprawdzCzyDemo();

            if (paragon)
            {
                ZmnienKontrolkiNaParagon();
            }

            TBnumerFaktury.Text = "";

            for (int i = Program.dataMenager.faktury.Count - 1; i >= 0; i--)
            {

                if (paragon)
                {
                    if (Program.dataMenager.faktury[i].paragon)
                    {
                        string[] nrFaktura = Program.dataMenager.faktury[i].nrFakturyString.Split('/');

                        if (nrFaktura[1] == DateTime.Now.Year.ToString())
                        {
                            TBnumerFaktury.Text = (int.Parse(nrFaktura[0]) + 1).ToString() + "/" + DateTime.Now.Year;
                            break;
                        }
                    }
                }
                else
                if (!Program.dataMenager.faktury[i].paragon)
                {

                    string[] nrFaktura = Program.dataMenager.faktury[i].nrFakturyString.Split('/');

                    if (nrFaktura[1] == DateTime.Now.Year.ToString())
                    {
                        TBnumerFaktury.Text = (int.Parse(nrFaktura[0]) + 1).ToString() + "/" + DateTime.Now.Year;
                        break;
                    }
                }
            }

            if (TBnumerFaktury.Text == "")
            {
                TBnumerFaktury.Text = "1" + "/" + DateTime.Now.Year;
            }
        }



        public FormPrintFakturaDane(int index)
        {
            InitializeComponent();

            paragon = Program.dataMenager.faktury[index].paragon;

            this.index = index;

            if (paragon)
            {
                ZmnienKontrolkiNaParagon();
            }

            faktura = Program.dataMenager.faktury[index];

            UstawDaneFirmy(faktura);

            if (!paragon)
            {
                UstawDaneKlienta(faktura);
            }


            UstawUslugiTowary(faktura);

            UstawDaneFaktury();

            LCalkowityKoszt.Text = calkowityKoszt.ToString() + " zł";
        }

        #region obsługa tabelki

        private void BTdodaj_Click(object sender, EventArgs e)
        {

            Program.itemFaktura = null;

            FormUslugaTowarFaktura formUslugaTowarFaktura = new FormUslugaTowarFaktura();

            formUslugaTowarFaktura.ShowDialog();

        }

        private void BTusun_Click(object sender, EventArgs e)
        {
            try
            {
                calkowityKoszt -= double.Parse(LVuslugiTowary.SelectedItems[0].SubItems[8].Text);
                sumaNetto -= double.Parse(LVuslugiTowary.SelectedItems[0].SubItems[5].Text);
                sumaVAT -= double.Parse(LVuslugiTowary.SelectedItems[0].SubItems[6].Text.Replace("%", ""));

                int i = 0;
                LVuslugiTowary.Items.Remove(LVuslugiTowary.SelectedItems[0]);

                foreach (ListViewItem item in LVuslugiTowary.Items)
                {
                    i++;
                    item.SubItems[0].Text = i.ToString();
                }
            }
            catch { }
            LCalkowityKoszt.Text = calkowityKoszt.ToString() + " zł";
        }

        private void BTedytuj_Click(object sender, EventArgs e)
        {

            try
            {

                calkowityKoszt -= double.Parse(LVuslugiTowary.SelectedItems[0].SubItems[8].Text);
                sumaNetto -= double.Parse(LVuslugiTowary.SelectedItems[0].SubItems[5].Text);

                if (LVuslugiTowary.SelectedItems[0].SubItems[6].Text != "zw")
                {
                    sumaVAT -= double.Parse(LVuslugiTowary.SelectedItems[0].SubItems[6].Text.Replace("%", ""));
                }

                FormUslugaTowarFaktura formUslugaTowarFaktura = new FormUslugaTowarFaktura(LVuslugiTowary.SelectedItems[0]);

                formUslugaTowarFaktura.ShowDialog();

                LVuslugiTowary.Items[LVuslugiTowary.SelectedItems[0].Index] = Program.itemFaktura;

                calkowityKoszt += double.Parse(LVuslugiTowary.Items[LVuslugiTowary.SelectedItems[0].Index].SubItems[8].Text);

            }
            catch { };


            LCalkowityKoszt.Text = calkowityKoszt.ToString() + " zł";

        }

        #endregion

        #region buttony zapisz drukuj anuluj
        private void BTzapisz_Click(object sender, EventArgs e)
        {

            bool nrFakturyIstnieje = false;

            if (faktura != null)
            {

                ZapiszFakture(index);
                Close();

            }
            else
            {

                foreach (FakturaDane fak in Program.dataMenager.faktury)
                {
                    if (paragon && fak.paragon && fak.nrFakturyString == TBnumerFaktury.Text)
                    {

                        nrFakturyIstnieje = true;
                    }

                    if (!paragon && !fak.paragon && fak.nrFakturyString == TBnumerFaktury.Text)
                    {

                        nrFakturyIstnieje = true;
                    }
                }

                if (nrFakturyIstnieje)
                {
                    string message;

                    if (paragon)
                    {
                        message = "Istnieje już paragon z takim numerem.";
                    }
                    else
                    {
                        message = "Istnieje już faktura z takim numerem.";
                    }

                    MessageBox.Show(
                 message,
                 "Faktura/Paragon",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error
                 );

                }
                else
                {
                    ZapiszFakture();

                    string message;

                    if (paragon)
                    {
                        message = "Paragon został zapisany";
                    }
                    else
                    {
                        message = "Faktura została zapisana";
                    }

                    MessageBox.Show(
                     message,
                     "Faktura/Paragon",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                     );


                    if (klient == null)
                    {
                        Close();
                    }
                }
            }
        }

        private void BTdrukuj_Click(object sender, EventArgs e)
        {

            bool nrFakturyIstnieje = false;

            if (faktura != null)
            {

                ZapiszFakture(index);
                FormPrintFaktura formPrintFaktura = new FormPrintFaktura(index, paragon, CBOryginalKopia.Checked);
                formPrintFaktura.ShowDialog();

            }
            else
            {

                index = 0;

                foreach (FakturaDane fak in Program.dataMenager.faktury)
                {
                    if (fak.nrFakturyString == TBnumerFaktury.Text)
                    {
                        nrFakturyIstnieje = true;
                        break;
                    }
                    index++;
                }

                if (nrFakturyIstnieje)
                {
                    ZapiszFakture(index);

                    FormPrintFaktura formPrintFaktura = new FormPrintFaktura(index, paragon, CBOryginalKopia.Checked);
                    formPrintFaktura.ShowDialog();
                }
                else
                {
                    ZapiszFakture();

                    string message;

                    if (paragon)
                    {
                        message = "Paragon został zapisany";
                    }
                    else
                    {
                        message = "Faktura została zapisana";
                    }

                    MessageBox.Show(
                     message,
                     "Faktura/Paragon",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                     );

                    FormPrintFaktura formPrintFaktura = new FormPrintFaktura(Program.dataMenager.faktury.Count - 1, paragon, CBOryginalKopia.Checked);
                    formPrintFaktura.ShowDialog();

                    if (klient == null)
                    {
                        Close();
                    }
                }
            }
        }

        private void BTanuluj_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region inne

        private void CBzaplacono_CheckedChanged(object sender, EventArgs e)
        {
            DTPterminPlatnosci.Enabled = !CBzaplacono.Checked;
        }

        private void BTstaliKlienci_Click(object sender, EventArgs e)
        {
            FormStaliKlienci formStaliKlienci = new FormStaliKlienci();

            formStaliKlienci.ShowDialog();

            if (Program.stalyKlientIndexSet)
            {
                Klient klient = Program.dataMenager.staliKlienci.ElementAt(Program.stalyKlientIndex);

                if (klient.nip == null)
                {
                    Console.WriteLine(klient.imie + " " + klient.nazwisko);

                    TBnazwaNabywca.Text = klient.imie + " " + klient.nazwisko;

                    TBadresNabywca.Text = klient.adres;
                }
                else
                {
                    TBnazwaNabywca.Text = klient.nazwaFirmy;
                    TBadresNabywca.Text = klient.adres;
                    TBnipNabywca.Text = klient.nip;
                }
            }
        }

        #endregion

        #region funkcje własne 

        private void ZmnienKontrolkiNaParagon()
        {
            Text = "Paragon";

            foreach (Control control in groupBox2.Controls)
            {
                control.Enabled = false;
            }

            foreach (Control control in groupBox4.Controls)
            {
                control.Enabled = false;
            }

            TBmiejsceWystawienia.Enabled = false;

            TBosobaUpowaznionaDoOdbioru.Enabled = false;
            TBosobaWystawiajacaDokument.Enabled = false;
        }


        private void SprawdzCzyDemo()
        {
            if (Program.dataMenager.firstOpenSettings.demo)
            {
                BTzapisz.Enabled = false;
                BTdrukuj.Enabled = false;
            }
        }

        private void UstawDaneFaktury()
        {
            TBnumerFaktury.Text = faktura.nrFakturyString;
            DTPdataWystawienia.Text = faktura.dataWystawienia;

            RTBDodatkowe.Text = faktura.dodatkowe;

            if (!paragon)
            {

                TBmiejsceWystawienia.Text = faktura.miejsceWystawienia;

                CBformaPlatnosci.Text = faktura.formaPlatnosci;
                CBzaplacono.Checked = faktura.zaplacono;
                try
                {
                    DTPterminPlatnosci.Text = faktura.terminPlatnosci;
                }
                catch { }
                TBosobaWystawiajacaDokument.Text = faktura.osobaWystawiajaca;
                TBosobaUpowaznionaDoOdbioru.Text = faktura.osobaUpowazniona;
            }
        }

        private void UstawUslugiTowary()
        {
            Console.WriteLine("ustawUslugiTowary");
            foreach (Usluga usluga in klient.uslugi)
            {

                try
                {
                    if (Program.dataMenager.daneFirmy.DeaflutVAT == "zw")
                    {
                        DodajUslugeTowarZw(usluga.nazwa, usluga.cena != "" ? double.Parse(usluga.cena) : 0, 1, "Szt.");
                    }
                    else
                    {
                        DodajUslugeTowar(usluga.nazwa, usluga.cena != "" ? double.Parse(usluga.cena) : 0, 1, "Szt.", int.Parse(Program.dataMenager.daneFirmy.DeaflutVAT));
                    }
                }
                catch { }
            }

            foreach (Towar towar in klient.towary)
            {

                try
                {
                    if (Program.dataMenager.daneFirmy.DeaflutVAT == "zw")
                    {
                        DodajUslugeTowarZw(towar.nazwa, towar.cena != "" ? double.Parse(towar.cena) : 0, 1, "Szt.");
                    }
                    else
                    {
                        DodajUslugeTowar(towar.nazwa, towar.cena != "" ? double.Parse(towar.cena) : 0, 1, "Szt.", int.Parse(Program.dataMenager.daneFirmy.DeaflutVAT));
                    }
                }
                catch { }
            }
        }

        private void UstawUslugiTowary(FakturaDane faktura)
        {
            foreach (string[] uslugaTowar in faktura.listViewItems)
            {

                if (uslugaTowar[6] == "zw")
                {
                    DodajUslugeTowarZw(uslugaTowar[1], double.Parse(uslugaTowar[2]), double.Parse(uslugaTowar[3]), uslugaTowar[4]);
                }
                else
                {
                    DodajUslugeTowar(uslugaTowar[1], double.Parse(uslugaTowar[2]), double.Parse(uslugaTowar[3]), uslugaTowar[4], double.Parse(uslugaTowar[6].Replace("%", "")));
                }
            }
        }

        public void DodajUslugeTowar(string nazwa, double cena, double sztuk, string JM, double vat)
        {
            _ = vat / 100;

            double cenaNetto = cena - Program.KwotaVatzBrutto(cena, vat);

            LVuslugiTowary.Items.Add(new ListViewItem(new string[9]
             {
                    (LVuslugiTowary.Items.Count+1).ToString(),
                    nazwa,
                    cena.ToString(),
                    sztuk.ToString(),
                    JM,
                    (cenaNetto * sztuk).ToString(),
                    vat+"%",
                    (Program.KwotaVatzBrutto(cena, vat)* sztuk).ToString(),
                    (cena * sztuk).ToString()
             }));
            calkowityKoszt += cena * sztuk;
            sumaNetto += cenaNetto * sztuk;
            sumaVAT += Program.KwotaVatzBrutto(cena, vat) * sztuk;


            LCalkowityKoszt.Text = calkowityKoszt.ToString() + " zł";
        }

        public void DodajUslugeTowarZw(string nazwa, double cena, double sztuk, string JM)
        {
            double cenaNetto = cena - Program.KwotaVatzBrutto(cena, 0);

            LVuslugiTowary.Items.Add(new ListViewItem(new string[9]
             {
                    (LVuslugiTowary.Items.Count+1).ToString(),
                    nazwa,
                    cena.ToString(),
                    sztuk.ToString(),
                    JM,
                    (cenaNetto * sztuk).ToString(),
                    "zw",
                    (Program.KwotaVatzBrutto(cena, 0)* sztuk).ToString(),
                    (cena * sztuk).ToString()
             }));
            calkowityKoszt += cena * sztuk;
            sumaNetto += cenaNetto * sztuk;
            sumaVAT += Program.KwotaVatzBrutto(cena, 0) * sztuk;


            LCalkowityKoszt.Text = calkowityKoszt.ToString() + " zł";
        }

        private void UstawDaneKlienta()
        {
            Console.WriteLine("NIP: " + klient.nip);

            if (klient.nip == "")
            {
                TBnazwaNabywca.Text = klient.imie + " " + klient.nazwisko;
                TBadresNabywca.Text = klient.adres;
            }
            else
            {
                TBnazwaNabywca.Text = klient.nazwaFirmy;
                TBadresNabywca.Text = klient.adres;
                TBnipNabywca.Text = klient.nip;
            }
        }

        private void UstawDaneKlienta(FakturaDane faktura)
        {
            TBnazwaNabywca.Text = faktura.nazwaNabywaca;
            TBnipNabywca.Text = faktura.nipNabywca;
            TBadresNabywca.Text = faktura.adresNabywca;
            TBkodPocztowyNabywca.Text = faktura.kodNabywca;
            TBmiejscowoscNabywca.Text = faktura.miejscowoscNabywca;
        }

        private void UstawDaneFirmy()
        {
            TBnazwaFirmy.Text = Program.dataMenager.daneFirmy.nazwa;
            TBadres.Text = Program.dataMenager.daneFirmy.adres;
            TBkodPocztowy.Text = Program.dataMenager.daneFirmy.kodPocztowy;
            TBmiejscowosc.Text = Program.dataMenager.daneFirmy.miejscowosc;
            TBtelefon.Text = Program.dataMenager.daneFirmy.telefon;
            TBnip.Text = Program.dataMenager.daneFirmy.nip;
            TBregon.Text = Program.dataMenager.daneFirmy.regon;
            TBbank.Text = Program.dataMenager.daneFirmy.bank;
            TBkonto.Text = Program.dataMenager.daneFirmy.konto;
        }

        private void UstawDaneFirmy(FakturaDane faktura)
        {
            TBnazwaFirmy.Text = faktura.nazwa;
            TBadres.Text = faktura.adres;
            TBkodPocztowy.Text = faktura.kodPocztowy;
            TBmiejscowosc.Text = faktura.miejscowosc;
            TBtelefon.Text = faktura.telefon;
            TBnip.Text = faktura.nip;
            TBregon.Text = faktura.regon;
            TBbank.Text = faktura.bank;
            TBkonto.Text = faktura.konto;
        }

        private void ZapiszFakture()
        {
            List<string[]> listViewItemsHelper = new List<string[]>();

            foreach (ListViewItem item in LVuslugiTowary.Items)
            {
                listViewItemsHelper.Add(new string[9]
                {
                     item.SubItems[0].Text,
                     item.SubItems[1].Text,
                     item.SubItems[2].Text,
                     item.SubItems[3].Text,
                     item.SubItems[4].Text,
                     item.SubItems[5].Text,
                     item.SubItems[6].Text,
                     item.SubItems[7].Text,
                     item.SubItems[8].Text,
                });
            }

            if (Program.dataMenager.daneFirmy.magazyn)
            {
                string textToShow = "";

                foreach (string[] item in listViewItemsHelper)
                {
                    Towar towar = IsInTowary(item[1]);

                    if (towar != null)
                    {
                        if ((towar.ilosc - int.Parse(item[3])) < 0)
                        {
                            textToShow += towar.nazwa + ": " + towar.ilosc + "-" + item[3] + "=" + 0 + "\r\n";
                            towar.ilosc = 0;
                        }
                        else
                        {
                            textToShow += towar.nazwa + ": " + towar.ilosc + "-" + item[3] + "=" + (towar.ilosc - int.Parse(item[3])) + "\r\n";
                            towar.ilosc -= int.Parse(item[3]);
                        }
                    }
                }

                if (listViewItemsHelper.Count > 0)
                {
                    MessageBox.Show(textToShow, "Podsumowanie magazynu", MessageBoxButtons.OK);
                }
            }


            Program.dataMenager.faktury.Add(new FakturaDane
            {
                paragon = paragon,
                nazwa = TBnazwaFirmy.Text,
                adres = TBadres.Text,
                kodPocztowy = TBkodPocztowy.Text,
                miejscowosc = TBmiejscowosc.Text,
                telefon = TBtelefon.Text,
                nip = TBnip.Text,
                regon = TBregon.Text,
                bank = TBbank.Text,
                konto = TBkonto.Text,


                nazwaNabywaca = TBnazwaNabywca.Text,
                nipNabywca = TBnipNabywca.Text,
                adresNabywca = TBadresNabywca.Text,
                kodNabywca = TBkodPocztowyNabywca.Text,
                miejscowoscNabywca = TBmiejscowoscNabywca.Text,

                listViewItems = listViewItemsHelper,

                nrFaktury = Program.dataMenager.faktury.Count + 1,
                nrFakturyString = TBnumerFaktury.Text,
                miejsceWystawienia = TBmiejsceWystawienia.Text,
                dataWystawienia = DTPdataWystawienia.Text,

                formaPlatnosci = CBformaPlatnosci.Text,
                zaplacono = CBzaplacono.Checked,
                terminPlatnosci = DTPterminPlatnosci.Text,

                osobaWystawiajaca = TBosobaWystawiajacaDokument.Text,
                osobaUpowazniona = TBosobaUpowaznionaDoOdbioru.Text,

                dodatkowe = RTBDodatkowe.Text,

                sumaNetto = sumaNetto,
                sumaBrutto = calkowityKoszt,
                sumaVat = sumaVAT

            });
        }

        private Towar IsInTowary(string checkedTowar)
        {
            foreach (Towar towar in Program.dataMenager.towary)
            {
                if (towar.nazwa == checkedTowar)
                {
                    return towar;
                }
            }

            return null;
        }

        private void ZapiszFakture(int index)
        {
            List<string[]> listViewItemsHelper = new List<string[]>();

            foreach (ListViewItem item in LVuslugiTowary.Items)
            {
                listViewItemsHelper.Add(new string[9]
                    {
                        item.SubItems[0].Text,
                        item.SubItems[1].Text,
                        item.SubItems[2].Text,
                        item.SubItems[3].Text,
                        item.SubItems[4].Text,
                        item.SubItems[5].Text,
                        item.SubItems[6].Text,
                        item.SubItems[7].Text,
                        item.SubItems[8].Text,
                    });
            }


            Program.dataMenager.faktury[index] = new FakturaDane
            {
                paragon = paragon,
                nazwa = TBnazwaFirmy.Text,
                adres = TBadres.Text,
                kodPocztowy = TBkodPocztowy.Text,
                miejscowosc = TBmiejscowosc.Text,
                telefon = TBtelefon.Text,
                nip = TBnip.Text,
                regon = TBregon.Text,
                bank = TBbank.Text,
                konto = TBkonto.Text,


                nazwaNabywaca = TBnazwaNabywca.Text,
                nipNabywca = TBnipNabywca.Text,
                adresNabywca = TBadresNabywca.Text,
                kodNabywca = TBkodPocztowyNabywca.Text,
                miejscowoscNabywca = TBmiejscowoscNabywca.Text,

                listViewItems = listViewItemsHelper,

                nrFaktury = Program.dataMenager.faktury.Count + 1,
                nrFakturyString = TBnumerFaktury.Text,
                miejsceWystawienia = TBmiejsceWystawienia.Text,
                dataWystawienia = DTPdataWystawienia.Text,

                formaPlatnosci = CBformaPlatnosci.Text,
                zaplacono = CBzaplacono.Checked,
                terminPlatnosci = CBzaplacono.Checked ? "Zapłacono" : DTPterminPlatnosci.Text,

                osobaWystawiajaca = TBosobaWystawiajacaDokument.Text,
                osobaUpowazniona = TBosobaUpowaznionaDoOdbioru.Text,

                dodatkowe = RTBDodatkowe.Text,

                sumaNetto = sumaNetto,
                sumaBrutto = calkowityKoszt,
                sumaVat = sumaVAT
            };
        }

        private void SprawdzCzyPusty(bool empty)
        {
            if (empty)
            {
                LCalkowityKoszt.Text = 0.00 + " zł";
            }
            else
            {
                if (Program.zArchiwum)
                {
                    klient = Program.dataMenager.archiwum.ElementAt(Program.archiwumIndex);
                }
                else
                {
                    Program.dataMenager.klienci.TryGetValue(Program.keyImie + " " + Program.keyNazwisko, out klient);

                }

                if (!paragon)
                {
                    UstawDaneKlienta();
                }

                UstawUslugiTowary();

                LCalkowityKoszt.Text = calkowityKoszt.ToString() + " zł";
            }
        }
        #endregion
    }
}