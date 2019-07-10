using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class Form2 : Form
    {
        private Klient szablonKlient;
        private int iloscUslug = 0;
        private int iloscTowarow = 0;
        private readonly List<CTBusluga> uslugi;
        private readonly List<CTBtowar> towary;
        private CTBusluga szablonUsluga;
        private CTBtowar szablonTowar;
        private CheckBox szablonCheckBox;
        public Form2()
        {
            InitializeComponent();

            SprawdzCzyDemo();

            uslugi = new List<CTBusluga>();
            towary = new List<CTBtowar>();

            CheckForEdit();
        }

        #region Dodawanie usług i towarów

        private void BTdodajUsluga_Click(object sender, EventArgs e)
        {
            DodajUsluge(null);
        }

        private void BTdodajTowar_Click(object sender, EventArgs e)
        {
            DodajTowar(null);
        }

        private void BTuslugi_Click(object sender, EventArgs e)
        {
            FormUslugi formUslugi = new FormUslugi();

            formUslugi.ShowDialog();

            foreach (Usluga usluga in Program.dataMenager.uslugi)
            {
                if (usluga.dodajDoZlecenia)
                {
                    DodajUsluge(usluga);

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
                    DodajTowar(towar);

                }
                towar.dodajDoZlecenia = false;
            }
        }
        #endregion

        #region Button dodaj zlecenie
        private void BTdodajZlecenie_Click(object sender, EventArgs e)
        {
            bool klientIstnieje = false;

            if (szablonKlient.imie != "" & szablonKlient.nazwisko != "")
            {
                if (Program.edycja == false)
                {
                    foreach (Klient klient in Program.dataMenager.klienci.Values)
                    {
                        if (klient.imie == szablonKlient.imie & klient.nazwisko == szablonKlient.nazwisko)
                        {
                            klientIstnieje = true;
                        }
                    }
                }

                if (klientIstnieje)
                {
                    MessageBox.Show(
                  "W zleceniach jest  już klient z tym Imieniem i Nazwiskiem",
                  "Klient",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                }
                else
                {
                    szablonKlient.uslugi.Clear();
                    szablonKlient.towary.Clear();

                    foreach (CTBusluga us in uslugi)
                    {
                        if (us.TBusluga.Text != "")
                        {
                            szablonKlient.uslugi.Add(new Usluga() { nazwa = us.TBusluga.Text, cena = us.TBuslugaCena.Text, gotowe = false });
                        }

                    }

                    foreach (CTBtowar us in towary)
                    {
                        if (us.TBtowar.Text != "")
                        {
                            szablonKlient.towary.Add(new Towar() { nazwa = us.TBtowar.Text, cena = us.TBtowarCena.Text, gotowe = false });
                        }

                    }

                    szablonKlient.dataPrzyjecia = DTprzyjecie.Text;
                    szablonKlient.dataWykonania = DTwykonanie.Text;

                    szablonKlient.dodatkowe = TBdodatkowe.Text;



                    if (Program.edycja == false)
                    {
                        Program.dataMenager.klienci.Add(szablonKlient.imie + " " + szablonKlient.nazwisko, szablonKlient);
                    }

                    Close();

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
        #endregion

        #region obsługa checkboxów
        private void CBwszystkoUslugi_CheckedChanged(object sender, EventArgs e)
        {
            ZaznaczWszystko(true);
        }

        private void CBwszystkoTowary_CheckedChanged(object sender, EventArgs e)
        {
            ZaznaczWszystko(false);
        }


        private void BTusun_Click(object sender, EventArgs e)
        {
            UsunZaznaczone(panel1, true);

        }

        private void BTusunTowary_Click(object sender, EventArgs e)
        {
            UsunZaznaczone(panel2, false);
        }

        private void BTdodajDoUslug_Click(object sender, EventArgs e)
        {
            DodajDoStalych(panel1, true);
        }

        private void BTdodajDoTowarow_Click(object sender, EventArgs e)
        {
            DodajDoStalych(panel2, false);
        }
        #endregion

        #region stali klienci
        private void BTstaliKlienciZapisz_Click(object sender, EventArgs e)
        {
            FormStalyKlientDodaj formStalyKlientDodaj = new FormStalyKlientDodaj(false, szablonKlient);

            Klient klient = formStalyKlientDodaj.ShowAndGetData();

            if (klient != null)
            {

                LdaneKlienta.Text = klient.imie + " " + klient.nazwisko + " " + klient.marka + " " + klient.model;

                szablonKlient.imie = klient.imie;
                szablonKlient.nazwisko = klient.nazwisko;
                szablonKlient.marka = klient.marka;
                szablonKlient.model = klient.model;


                szablonKlient.rejestracja = klient.rejestracja;
                szablonKlient.silnik = klient.silnik;
                szablonKlient.moc = klient.moc;
                szablonKlient.vin = klient.vin;

                szablonKlient.telefon = klient.telefon;
                szablonKlient.adres = klient.adres;
                szablonKlient.przebieg = klient.przebieg;
                szablonKlient.rokProdukcji = klient.rokProdukcji;

                szablonKlient.nazwaFirmy = klient.nazwaFirmy;
                szablonKlient.nip = klient.nip;
            }
        }
        #endregion

        #region funkcje własne
        private void DodajDoStalych(Panel panel, bool usluga)
        {

            bool zaznaczone = false;
            int i = 0;
            foreach (Control control in panel.Controls)
            {
                if (i % 3 == 0)
                {
                    CheckBox check = (CheckBox)control;
                    if (check.Checked)
                    {
                        if (usluga)
                        {
                            Program.dataMenager.uslugi.Add(new Usluga
                            {
                                nazwa = panel.Controls[i + 1].Text,
                                cena = panel.Controls[i + 2].Text,
                            });

                        }
                        else
                        {
                            Program.dataMenager.towary.Add(new Towar
                            {
                                nazwa = panel.Controls[i + 1].Text,
                                symbol = "",
                                cena = panel.Controls[i + 2].Text,
                                ilosc = 1
                            });
                        }
                        zaznaczone = true;
                    }
                }
                i++;
            }
            if (zaznaczone)
            {
                if (usluga)
                {
                    MessageBox.Show(
                    "Usługi zostały dodane",
                    "Usługi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                    "Towary zostały dodane",
                    "Towary",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
            else
            {
                if (usluga)
                {
                    MessageBox.Show(
                    "Musisz zanaczyć co najmniej jedną usługę",
                    "Usługi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                    "Musiusz zanaczyć co najmniej jeden towar",
                    "Towary",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        private void SprawdzCzyDemo()
        {
            if (Program.dataMenager.firstOpenSettings.demo)
            {
                BTdodajDoUslug.Enabled = false;
                BTdodajDoTowarow.Enabled = false;

                BTuslugi.Enabled = false;
                BTtowary.Enabled = false;
            }
        }

        private void ZaznaczWszystko(bool czyUslugi)
        {
            Panel panel;

            if (czyUslugi)
            {
                panel = panel1;
            }
            else
            {
                panel = panel2;
            }

            int i = 1;

            foreach (Control control in panel.Controls)
            {
                if (i % 3 == 1)
                {
                    CheckBox check = (CheckBox)control;

                    if (czyUslugi)
                    {
                        check.Checked = CBwszystkoUslugi.Checked;
                    }
                    else
                    {
                        check.Checked = CBwszystkoTowary.Checked;
                    }
                }
                i++;
            }
        }

        private void UsunZaznaczone(Panel panel, bool czyUslugi)
        {
            int i = 1;
            int ileUsun = 0;

            foreach (Control control in panel.Controls)
            {
                if (i % 3 == 1)
                {
                    CheckBox check = (CheckBox)control;
                    if (check.Checked)
                    {
                        ileUsun++;
                    }
                }

                i++;
            }

            if (czyUslugi)
            {
                iloscUslug -= ileUsun;
            }
            else
            {
                iloscTowarow -= ileUsun;
            }

            int index = 0;

            while (ileUsun-- > 0)
            {
                i = 1;
                foreach (Control control in panel.Controls)
                {
                    if (i % 3 == 1)
                    {
                        CheckBox check = (CheckBox)control;
                        if (check.Checked)
                        {
                            index = i - 1;
                            break;
                        }
                    }

                    i++;
                }

                panel.Controls.RemoveAt(index + 2);
                panel.Controls.RemoveAt(index + 1);
                panel.Controls.RemoveAt(index);

                if (czyUslugi)
                {
                    uslugi.RemoveAt(index / 3);
                }
                else
                {
                    towary.RemoveAt(index / 3);
                }

                for (int k = index; k < panel.Controls.Count; k += 3)
                {
                    if (k == 0)
                    {
                        panel.Controls[k].Location = new Point(5, 6);
                        panel.Controls[k + 1].Location = new Point(26, 6);
                        panel.Controls[k + 2].Location = new Point(150, 6);

                    }
                    else
                    {
                        panel.Controls[k].Location = new Point(5, panel.Controls[k - 3].Location.Y + 26);
                        panel.Controls[k + 1].Location = new Point(26, panel.Controls[k - 2].Location.Y + 26);
                        panel.Controls[k + 2].Location = new Point(150, panel.Controls[k - 1].Location.Y + 26);
                    }
                }
            }
        }

        private void DodajUsluge(Usluga usluga)
        {

            szablonUsluga = new CTBusluga();
            szablonCheckBox = new CheckBox();
            szablonUsluga.Init();


            if (iloscUslug == 0)
            {
                szablonCheckBox.Location = new Point(5, 6);
            }
            else
            {
                szablonCheckBox.Location = new Point(5, panel1.Controls[panel1.Controls.Count - 3].Location.Y + 26);
            }

            szablonCheckBox.Size = new Size(15, 20);
            szablonCheckBox.Text = "";



            if (iloscUslug == 0)
            {
                szablonUsluga.TBusluga.Location = new Point(26, 6);
            }
            else
            {
                szablonUsluga.TBusluga.Location = new Point(26, panel1.Controls[panel1.Controls.Count - 2].Location.Y + 26);
            }

            szablonUsluga.TBusluga.Size = new Size(118, 20);
            if (usluga != null)
            {
                szablonUsluga.TBusluga.Text = usluga.nazwa;
            }



            if (iloscUslug == 0)
            {
                szablonUsluga.TBuslugaCena.Location = new Point(150, 6);
            }
            else
            {
                szablonUsluga.TBuslugaCena.Location = new Point(150, panel1.Controls[panel1.Controls.Count - 1].Location.Y + 26);
            }

            szablonUsluga.TBuslugaCena.Size = new Size(65, 20);
            if (usluga != null)
            {
                szablonUsluga.TBuslugaCena.Text = usluga.cena;
            }

            panel1.Controls.Add(szablonCheckBox);
            panel1.Controls.Add(szablonUsluga.TBusluga);
            panel1.Controls.Add(szablonUsluga.TBuslugaCena);

            uslugi.Add(szablonUsluga);

            iloscUslug++;
        }

        private void DodajTowar(Towar towar)
        {
            szablonTowar = new CTBtowar();
            szablonCheckBox = new CheckBox();
            szablonTowar.Init();

            if (iloscTowarow == 0)
            {
                szablonCheckBox.Location = new Point(5, 6);
            }
            else
            {
                szablonCheckBox.Location = new Point(5, panel2.Controls[panel2.Controls.Count - 3].Location.Y + 26);
            }

            szablonCheckBox.Size = new Size(15, 20);
            szablonCheckBox.Text = "";


            if (iloscTowarow == 0)
            {
                szablonTowar.TBtowar.Location = new Point(26, 6);
            }
            else
            {
                szablonTowar.TBtowar.Location = new Point(26, panel2.Controls[panel2.Controls.Count - 2].Location.Y + 26);
            }

            szablonTowar.TBtowar.Size = new Size(118, 20);
            if (towar != null)
            {
                szablonTowar.TBtowar.Text = towar.nazwa;
            }

            if (iloscTowarow == 0)
            {
                szablonTowar.TBtowarCena.Location = new Point(150, 6);
            }
            else
            {
                szablonTowar.TBtowarCena.Location = new Point(150, panel2.Controls[panel2.Controls.Count - 1].Location.Y + 26);
            }

            szablonTowar.TBtowarCena.Size = new Size(65, 20);
            if (towar != null)
            {
                szablonTowar.TBtowarCena.Text = towar.cena;
            }

            panel2.Controls.Add(szablonCheckBox);
            panel2.Controls.Add(szablonTowar.TBtowar);
            panel2.Controls.Add(szablonTowar.TBtowarCena);

            towary.Add(szablonTowar);

            iloscTowarow++;
        }

        private void CheckForEdit()
        {
            if (Program.edycja == false)
            {
                szablonKlient = new Klient();
            }

            if (Program.edycja == true)
            {
                Program.dataMenager.klienci.TryGetValue(Program.keyImie + " " + Program.keyNazwisko, out szablonKlient);

                DTprzyjecie.Text = szablonKlient.dataPrzyjecia;
                DTwykonanie.Text = szablonKlient.dataWykonania;

                LdaneKlienta.Text = szablonKlient.imie + " " + szablonKlient.nazwisko + " " + szablonKlient.marka + " " + szablonKlient.model;



                TBdodatkowe.Text = szablonKlient.dodatkowe;

                foreach (Usluga usluga in szablonKlient.uslugi)
                {
                    DodajUsluge(usluga);
                }

                foreach (Towar towar in szablonKlient.towary)
                {
                    DodajTowar(towar);
                }

                Text = "Edytuj zlecenie";
                BTdodajZlecenie.Text = "Edytuj zlecenie";
            }
        }
        #endregion
    }
}