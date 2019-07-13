using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class Form1 : Form
    {
        private int prawyKlik;
        private readonly List<Form3> forms3;

        public Form1()
        {
            InitializeComponent();

            SprawdzCzyDemo();

            ZmienOkno(0);

            OdswiezZlecenia();

            forms3 = new List<Form3>();
        }


        private void BTnoweZlecenie_Click(object sender, EventArgs e)
        {
            Program.edycja = false;
            Form2 form2 = new Form2();
            form2.ShowDialog();

            OdswiezZlecenia();
        }

        private void BTdrukujMagazyn_Click(object sender, EventArgs e)
        {
            FormPrintInwentaryzacja formPrintInwentaryzacja = new FormPrintInwentaryzacja();

            formPrintInwentaryzacja.Show();
        }

        #region Menu Strip

        private void LVzlecenia_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LVzlecenia.FocusedItem.Bounds.Contains(e.Location))
                {
                    MSzlecenia.Show(Cursor.Position);
                    prawyKlik = 0;
                }
            }
        }

        private void LVstaliKlienci_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LVstaliKlienci.FocusedItem.Bounds.Contains(e.Location))
                {

                    MSstaliKlienci.Show(Cursor.Position);
                    prawyKlik = 1;
                }
            }
        }

        private void LVuslugi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LVuslugi.FocusedItem.Bounds.Contains(e.Location))
                {
                    MSstale.Show(Cursor.Position);
                    prawyKlik = 2;
                }
            }
        }

        private void LVTowary_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LVTowary.FocusedItem.Bounds.Contains(e.Location))
                {
                    MSstale.Show(Cursor.Position);
                    prawyKlik = 3;
                }
            }
        }

        private void LVarchiwum_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LVarchiwum.FocusedItem.Bounds.Contains(e.Location))
                {

                    MSstale.Show(Cursor.Position);
                    prawyKlik = 4;
                }
            }
        }

        private void LVfaktury_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LVfaktury.FocusedItem.Bounds.Contains(e.Location))
                {
                    MSstale.Show(Cursor.Position);
                    prawyKlik = 5;
                }
            }
        }

        private void ZarchiwizujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.dataMenager.firstOpenSettings.demo == false)
            {
                Zarchiwizuj();
            }
        }


        private void UsuńToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (prawyKlik == 0)
            {
                Program.dataMenager.klienci.Remove(LVzlecenia.FocusedItem.SubItems[0].Text + " " + LVzlecenia.FocusedItem.SubItems[1].Text);
                OdswiezZlecenia();
            }

            if (prawyKlik == 1)
            {
                Program.dataMenager.staliKlienci.RemoveAt(LVstaliKlienci.FocusedItem.Index);
                OdswiezStalychKlientow();
            }

            if (prawyKlik == 2)
            {


                Program.dataMenager.uslugi.RemoveAt(LVuslugi.FocusedItem.Index);
                OdswiezUslugi();
            }

            if (prawyKlik == 3)
            {
                Program.dataMenager.towary.RemoveAt(LVTowary.FocusedItem.Index);
                OdswiezTowary();
            }

            if (prawyKlik == 4)
            {
                Program.dataMenager.archiwum.RemoveAt(LVarchiwum.FocusedItem.Index);
                OdswiezArchiwum();
            }

            if (prawyKlik == 5)
            {
                Program.dataMenager.faktury.RemoveAt(LVfaktury.FocusedItem.Index);
                OdswiezFaktury();
            }

        }

        private void EdytujToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (prawyKlik == 2)
            {
                Usluga usluga = Program.dataMenager.uslugi.ElementAt(LVuslugi.FocusedItem.Index);

                TBuslugiNazwa.Text = usluga.nazwa;

                TBuslugiCena.Text = usluga.cena;

                Program.dataMenager.uslugi.RemoveAt(LVuslugi.FocusedItem.Index);

                OdswiezUslugi();
            }

            if (prawyKlik == 3)
            {
                Towar towar = Program.dataMenager.towary.ElementAt(int.Parse(LVTowary.FocusedItem.SubItems[0].Text) - 1);

                TBTowarNazwa.Text = towar.nazwa;

                TBSymbol.Text = towar.symbol;

                TBTowarCena.Text = towar.cena;

                NTowarIlosc.Value = towar.ilosc;

                Program.dataMenager.towary.RemoveAt(int.Parse(LVTowary.FocusedItem.SubItems[0].Text) - 1);
                OdswiezTowary();
            }

            if (prawyKlik == 5)
            {
                Program.formPrintFaktura = new FormPrintFakturaDane(LVfaktury.SelectedItems[0].Index);

                Program.formPrintFaktura.ShowDialog();

                OdswiezFaktury();
            }
        }

        private void HistoriaNaprawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.dataMenager.firstOpenSettings.demo == false)
            {
                ZmienOkno(3);
                TBszukajArchiwum.Text = LVstaliKlienci.SelectedItems[0].SubItems[0].Text + " " + LVstaliKlienci.SelectedItems[0].SubItems[1].Text;
            }
        }
        #endregion

        #region Listview double Click

        private void LVzlecenia_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Program.zArchiwum = false;
            if (e.Button == MouseButtons.Left)
            {
                Program.keyImie = LVzlecenia.SelectedItems[0].SubItems[0].Text;
                Program.keyNazwisko = LVzlecenia.SelectedItems[0].SubItems[1].Text;

                forms3.Add(new Form3());

                //Form3 form3 = new Form3();
                forms3.Last().Show();
            }
        }

        private void LVarchiwum_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Program.zArchiwum = true;

            if (e.Button == MouseButtons.Left)
            {
                Program.archiwumIndex = LVarchiwum.SelectedItems[0].Index;

                Form3 form3 = new Form3();
                form3.Show();
            }
            // Program.zArchiwum = false;
        }

        private void LVfaktury_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            Program.formPrintFaktura = new FormPrintFakturaDane(LVfaktury.SelectedItems[0].Index);

            Program.formPrintFaktura.ShowDialog();

            OdswiezFaktury();
        }

        #endregion

        #region Przełączanie między oknami

        private void BTzlecenia_Click(object sender, EventArgs e)
        {
            ZmienOkno(0);
            OdswiezZlecenia();
        }

        private void BTstaliKlienci_Click(object sender, EventArgs e)
        {
            ZmienOkno(1);
            OdswiezStalychKlientow();
        }

        private void BTuslugiTowary_Click(object sender, EventArgs e)
        {
            ZmienOkno(2);
            OdswiezUslugi();
        }

        private void BTarchiwum_Click(object sender, EventArgs e)
        {
            ZmienOkno(3);
            OdswiezArchiwum();

        }

        private void BTfaktury_Click(object sender, EventArgs e)
        {
            ZmienOkno(4);
            OdswiezFaktury();
        }

        private void BTMagazyn_Click(object sender, EventArgs e)
        {
            ZmienOkno(5);
            OdswiezTowary();
        }

        #endregion

        #region Ustawienia

        private void BTustawienia_Click(object sender, EventArgs e)
        {
            FormUstawienia formUstawienia = new FormUstawienia();

            formUstawienia.ShowDialog();

            OdswiezTowary();
        }
        #endregion

        #region Zdarzenia buttonów dodawania

        private void BTnowaFaktura_Click(object sender, EventArgs e)
        {
            Program.formPrintFaktura = new FormPrintFakturaDane(true, false);
            Program.formPrintFaktura.ShowDialog();
            OdswiezFaktury();
        }

        private void BTNowyParagon_Click(object sender, EventArgs e)
        {

            Program.formPrintFaktura = new FormPrintFakturaDane(true, true);
            Program.formPrintFaktura.ShowDialog();
            OdswiezFaktury();

        }

        private void BTNowyKlient_Click(object sender, EventArgs e)
        {
            FormStalyKlientDodaj formStalyKlientDodaj = new FormStalyKlientDodaj(true, null);

            formStalyKlientDodaj.ShowDialog();

            OdswiezStalychKlientow();

        }

        private void LVstaliKlienci_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            ListViewItem item = LVstaliKlienci.Items[LVstaliKlienci.SelectedIndices[0]];

            Klient szablonKlient = new Klient
            {
                imie = item.SubItems[0].Text,
                nazwisko = item.SubItems[1].Text,
                nazwaFirmy = item.SubItems[2].Text,
                nip = item.SubItems[3].Text,
                marka = item.SubItems[4].Text,
                model = item.SubItems[5].Text,


                rejestracja = item.SubItems[6].Text,
                silnik = item.SubItems[7].Text,
                moc = item.SubItems[8].Text,
                vin = item.SubItems[9].Text,

                telefon = item.SubItems[10].Text,
                adres = item.SubItems[11].Text,
                przebieg = item.SubItems[12].Text,
                rokProdukcji = item.SubItems[13].Text
            };

            Program.dataMenager.staliKlienci.RemoveAt(LVstaliKlienci.SelectedIndices[0]);

            OdswiezStalychKlientow();

            FormStalyKlientDodaj formStalyKlientDodaj = new FormStalyKlientDodaj(true, szablonKlient);

            formStalyKlientDodaj.ShowDialog();

            OdswiezStalychKlientow();

        }

        private void BTUslugiDodaj_Click(object sender, EventArgs e)
        {

            Program.dataMenager.uslugi.Add(
               new Usluga()
               {
                   nazwa = TBuslugiNazwa.Text,
                   cena = TBuslugiCena.Text,
               });

            OdswiezUslugi();

            TBuslugiNazwa.Text = "";
            TBuslugiCena.Text = "";


        }

        private void BTTowarDodaj_Click(object sender, EventArgs e)
        {
            Program.dataMenager.towary.Add(
                 new Towar()
                 {
                     nazwa = TBTowarNazwa.Text,
                     symbol = TBSymbol.Text,
                     cena = TBTowarCena.Text,
                     ilosc = (int)NTowarIlosc.Value
                 });

            OdswiezTowary();

            TBTowarNazwa.Text = "";
            TBTowarCena.Text = "";
            TBSymbol.Text = "";
            NTowarIlosc.Value = 0;
        }

        #endregion

        #region hasło
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Program.dataMenager.firstOpenSettings.demo == false)
            {
                if (Program.dataMenager.firstOpenSettings.isPassword)
                {
                    Visible = false;
                    Program.formHasloBaza.ShowDialog();
                    if (Program.hasloOk)
                    {
                        Visible = true;
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }
        #endregion

        #region pełna wersja

        private void BTpelnaWersja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                  "Uwaga! Dane zapisane w wersji demo po przejściu na pęną wersje zostaną usunięte. Czy napewno chcesz to zrobić?",
                  "Pełna wersja",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Asterisk
                  ) == DialogResult.Yes)
            {
                Program.UstawieniaFabryczne();
            }
        }

        #endregion

        #region szukaj archiwum

        private void TBszukajArchiwum_TextChanged(object sender, EventArgs e)
        {
            OdswiezArchiwum(TBszukajArchiwum.Text);
        }

        #endregion

        #region funkcje własne

        public void Zarchiwizuj()
        {
            if (prawyKlik == 0)
            {
                Program.dataMenager.klienci.TryGetValue(LVzlecenia.FocusedItem.SubItems[0].Text + " " + LVzlecenia.FocusedItem.SubItems[1].Text, out Klient selectKlient);

                Program.dataMenager.archiwum.Add(selectKlient);
                Program.dataMenager.klienci.Remove(LVzlecenia.FocusedItem.SubItems[0].Text + " " + LVzlecenia.FocusedItem.SubItems[1].Text);
                ZmienOkno(3);
                OdswiezArchiwum();
            }
        }

        public void Zarchiwizuj(string key)
        {
            Program.dataMenager.klienci.TryGetValue(key, out Klient selectKlient);

            Program.dataMenager.archiwum.Add(selectKlient);
            Program.dataMenager.klienci.Remove(key);

            ZmienOkno(3);
            OdswiezArchiwum();
        }

        private void SprawdzCzyDemo()
        {
            if (Program.dataMenager.firstOpenSettings.demo)
            {
                BTarchiwum.Enabled = false;
                BTustawienia.Enabled = false;
                //  BTstaliKlienciDodaj.Enabled = false;
                BTUslugiDodaj.Enabled = false;
                BTfaktury.Enabled = false;
                BTMagazyn.Enabled = false;
            }
            else
            {

                BTpelnaWersja.Visible = false;
            }

        }

        public void ZmienOkno(int nrOkna)
        {
            GBzlecenia.Visible = false;
            GBstaliKlienci.Visible = false;
            GBuslugi.Visible = false;
            GBarchiwum.Visible = false;
            GBfaktury.Visible = false;
            GBMagazyn.Visible = false;

            switch (nrOkna)
            {
                case 0:
                    GBzlecenia.Visible = true;
                    break;
                case 1:
                    GBstaliKlienci.Visible = true;
                    break;
                case 2:
                    GBuslugi.Visible = true;
                    break;
                case 3:
                    GBarchiwum.Visible = true;
                    break;
                case 4:
                    GBfaktury.Visible = true;
                    break;
                case 5:
                    GBMagazyn.Visible = true;
                    break;
            }
        }

        public void OdswiezZlecenia()
        {
            LVzlecenia.Items.Clear();

            foreach (KeyValuePair<string, Klient> klient in Program.dataMenager.klienci)
            {
                string[] tabKlient = new string[16];

                tabKlient[0] = klient.Value.imie;
                tabKlient[1] = klient.Value.nazwisko;
                tabKlient[2] = klient.Value.nazwaFirmy;
                tabKlient[3] = klient.Value.nip;


                tabKlient[4] = klient.Value.marka;
                tabKlient[5] = klient.Value.model;

                tabKlient[6] = klient.Value.rejestracja;
                tabKlient[7] = klient.Value.silnik;
                tabKlient[8] = klient.Value.moc;
                tabKlient[9] = klient.Value.vin;

                tabKlient[10] = klient.Value.telefon;
                tabKlient[11] = klient.Value.adres;
                tabKlient[12] = klient.Value.przebieg;
                tabKlient[13] = klient.Value.rokProdukcji;

                tabKlient[14] = klient.Value.dataPrzyjecia;
                tabKlient[15] = klient.Value.dataWykonania;

                LVzlecenia.Items.Add(new ListViewItem(tabKlient));

            }
        }

        public void OdswiezStalychKlientow()
        {
            LVstaliKlienci.Items.Clear();
            foreach (Klient stalyKlient in Program.dataMenager.staliKlienci)
            {
                LVstaliKlienci.Items.Add(new ListViewItem(new string[14]
                {
                   stalyKlient.imie,
                   stalyKlient.nazwisko,
                   stalyKlient.nazwaFirmy,
                   stalyKlient.nip,

                   stalyKlient.marka,
                   stalyKlient.model,

                   stalyKlient.rejestracja ,
                   stalyKlient.silnik,
                   stalyKlient.moc,
                   stalyKlient.vin,

                   stalyKlient.telefon ,
                   stalyKlient.adres,
                   stalyKlient.przebieg,
                   stalyKlient.rokProdukcji
                }));
            }
        }

        public void OdswiezUslugi()
        {
            LVuslugi.Items.Clear();
            foreach (Usluga usluga in Program.dataMenager.uslugi)
            {
                LVuslugi.Items.Add(new ListViewItem(new string[2]
                {
                   usluga.nazwa,
                   usluga.cena,

                }));
            }
        }

        public void OdswiezTowary()
        {
            LVTowary.Items.Clear();

            if (Program.dataMenager.daneFirmy.magazyn)
            {
                if (LVTowary.Columns.Count == 4)
                {
                    ColumnHeader column = new ColumnHeader
                    {
                        Text = "Ilość",
                        Width = 100
                    };

                    LVTowary.Columns.Add(column);

                }
            }
            else
            if (LVTowary.Columns.Count == 5)
            {
                LVTowary.Columns.RemoveAt(4);
            }

            int nrTowaru = 0;

            foreach (Towar towar in Program.dataMenager.towary)
            {
                nrTowaru++;

                if (TBTowarSzukajNazwa.Text != "" || TBTowarSzukajSymbol.Text != "")
                {
                    if (TBTowarSzukajNazwa.Text != "" && TBTowarSzukajSymbol.Text != "")
                    {
                        if (towar.nazwa.ToLower().Contains(TBTowarSzukajNazwa.Text.ToLower()) && towar.symbol.ToLower().Contains(TBTowarSzukajSymbol.Text.ToLower()))
                        {
                            DodajTowarDoLVTowary(towar, nrTowaru);
                        }
                    }
                    else
                    {
                        if ((towar.nazwa.ToLower().Contains(TBTowarSzukajNazwa.Text.ToLower()) && TBTowarSzukajNazwa.Text != "") || (towar.symbol.ToLower().Contains(TBTowarSzukajSymbol.Text.ToLower()) && TBTowarSzukajSymbol.Text != ""))
                        {
                            DodajTowarDoLVTowary(towar, nrTowaru);
                        }
                    }
                }
                else
                {
                    DodajTowarDoLVTowary(towar, nrTowaru);
                }
            }
        }

        private void DodajTowarDoLVTowary(Towar towar, int nrTowaru)
        {
            string[] item = new string[5];

            item[0] = nrTowaru.ToString();
            item[1] = towar.nazwa;
            item[2] = towar.symbol;
            item[3] = towar.cena;

            if (Program.dataMenager.daneFirmy.magazyn)
            {
                item[4] = towar.ilosc.ToString();
            }

            LVTowary.Items.Add(new ListViewItem(item));
        }

        public void OdswiezArchiwum()
        {
            LVarchiwum.Items.Clear();

            foreach (Klient klientArchiwum in Program.dataMenager.archiwum)
            {
                string[] tabKlient = new string[14];

                tabKlient[0] = klientArchiwum.imie;
                tabKlient[1] = klientArchiwum.nazwisko;
                tabKlient[2] = klientArchiwum.marka;
                tabKlient[3] = klientArchiwum.model;

                tabKlient[4] = klientArchiwum.rejestracja;
                tabKlient[5] = klientArchiwum.silnik;
                tabKlient[6] = klientArchiwum.moc;
                tabKlient[7] = klientArchiwum.vin;

                tabKlient[8] = klientArchiwum.telefon;
                tabKlient[9] = klientArchiwum.adres;
                tabKlient[10] = klientArchiwum.przebieg;
                tabKlient[11] = klientArchiwum.rokProdukcji;

                tabKlient[12] = klientArchiwum.dataPrzyjecia;
                tabKlient[13] = klientArchiwum.dataWykonania;

                LVarchiwum.Items.Add(new ListViewItem(tabKlient));
            }
        }

        public void OdswiezArchiwum(string search)
        {
            LVarchiwum.Items.Clear();


            foreach (Klient klientArchiwum in Program.dataMenager.archiwum)
            {
                try
                {
                    string[] tabKlient = new string[14];

                    tabKlient[0] = klientArchiwum.imie;
                    tabKlient[1] = klientArchiwum.nazwisko;
                    tabKlient[2] = klientArchiwum.marka;
                    tabKlient[3] = klientArchiwum.model;

                    tabKlient[4] = klientArchiwum.rejestracja;
                    tabKlient[5] = klientArchiwum.silnik;
                    tabKlient[6] = klientArchiwum.moc;
                    tabKlient[7] = klientArchiwum.vin;

                    tabKlient[8] = klientArchiwum.telefon;
                    tabKlient[9] = klientArchiwum.przebieg;
                    tabKlient[10] = klientArchiwum.adres;
                    tabKlient[11] = klientArchiwum.rokProdukcji;

                    tabKlient[12] = klientArchiwum.dataPrzyjecia;
                    tabKlient[13] = klientArchiwum.dataWykonania;



                    if ((tabKlient[0] + " " + tabKlient[1]).ToLower().Contains(search.ToLower()))
                    {
                        LVarchiwum.Items.Add(new ListViewItem(tabKlient));
                    }
                }
                catch { }
            }
        }

        private void OdswiezFaktury()
        {
            LVfaktury.Items.Clear();

            foreach (FakturaDane faktura in Program.dataMenager.faktury)
            {
                LVfaktury.Items.Add(new ListViewItem(new string[9]
                {
                    faktura.nrFakturyString,
                    faktura.paragon ? "Paragon" : "Faktura",
                    faktura.dataWystawienia,
                    faktura.nazwaNabywaca,
                    faktura.formaPlatnosci,
                    faktura.zaplacono ? "TAK" : "NIE",
                    faktura.sumaNetto.ToString(),
                    faktura.sumaVat.ToString(),
                    faktura.sumaBrutto.ToString()
                }));

            }
        }
        #endregion

        private void TBTowarSzukajNazwa_TextChanged(object sender, EventArgs e)
        {
            OdswiezTowary();
        }

        private void TBTowarSzukajSymbol_TextChanged(object sender, EventArgs e)
        {
            OdswiezTowary();
        }
    }
}