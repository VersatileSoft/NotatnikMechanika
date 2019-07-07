using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class Form3 : Form
    {
        private bool zlecenieGotowe = true;
        private Klient klient;
        private double uslugiSuma = 0;
        private double towarySuma = 0;
        private double uslugiTowarySuma = 0;
        private int indexCheck = 0;

        public Form3()
        {
            InitializeComponent();

            if (Program.dataMenager.firstOpenSettings.demo)
            {

                BTdrukuj.Enabled = false;
            }

            LadujDane();

            if (Program.zArchiwum)
            {
                BTedytuj.Enabled = false;
            }


        }

        #region drukowanie

        private void BTdrukuj_Click(object sender, EventArgs e)
        {
            Program.keyImie = klient.imie;
            Program.keyNazwisko = klient.nazwisko;

            FormPrint formPrint = new FormPrint();
            formPrint.ShowDialog();
        }

        private void BTdrukujFakture_Click(object sender, EventArgs e)
        {
            Program.formPrintFaktura = new FormPrintFakturaDane(false, false);

            Program.keyImie = klient.imie;
            Program.keyNazwisko = klient.nazwisko;

            Program.formPrintFaktura.ShowDialog();
        }

        private void BTParagon_Click(object sender, EventArgs e)
        {
            Program.formPrintFaktura = new FormPrintFakturaDane(false, true);

            Program.keyImie = klient.imie;
            Program.keyNazwisko = klient.nazwisko;

            Program.formPrintFaktura.ShowDialog();
        }

        #endregion

        #region CheckBoxy
        private void CheckUsluga_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Puslugi.Controls.Count / 2; i++)
            {
                CheckBox check = (CheckBox)Puslugi.Controls[i * 2];
                klient.uslugi.ElementAt(i).gotowe = check.Checked;
            }

            SprawdzCzyGotowe();
        }


        private void CheckTowar_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Ptowary.Controls.Count / 2; i++)
            {
                CheckBox check = (CheckBox)Ptowary.Controls[i * 2];
                klient.towary.ElementAt(i).gotowe = check.Checked;
            }

            SprawdzCzyGotowe();
        }

        #endregion

        #region edycja
        private void BTedytuj_Click(object sender, EventArgs e)
        {
            Program.edycja = true;
            Program.keyImie = klient.imie;
            Program.keyNazwisko = klient.nazwisko;
            Form2 form2 = new Form2();
            form2.ShowDialog();

            LadujDane();
            Program.form1.OdswiezZlecenia();
        }

        #endregion

        #region funkcje własne
        private void SprawdzCzyGotowe()
        {
            zlecenieGotowe = true;

            foreach (Usluga usluga in klient.uslugi)
            {
                if (usluga.gotowe == false)
                {
                    zlecenieGotowe = false;
                    break;
                }
            }

            foreach (Towar towar in klient.towary)
            {
                if (towar.gotowe == false)
                {
                    zlecenieGotowe = false;
                    break;
                }
            }

            if (zlecenieGotowe == true)
            {

                if (MessageBox.Show(
                  "Zlecenie zostało ukończone. Czy chcesz przenieść je do archiwum?",
                  "Zlecenie Ukończone",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
                  ) == DialogResult.Yes)
                {

                    Program.form1.Zarchiwizuj(klient.imie + " " + klient.nazwisko);
                    Close();
                }
            }
        }

        private void LadujDane()
        {
            uslugiSuma = 0;
            towarySuma = 0;
            if (Program.zArchiwum)
            {
                klient = Program.dataMenager.archiwum.ElementAt(Program.archiwumIndex);
            }
            else
            {
                Program.dataMenager.klienci.TryGetValue(Program.keyImie + " " + Program.keyNazwisko, out klient);
            }

            Lnazwisko.Text = klient.imie + " " + klient.nazwisko;
            Lmodel.Text = klient.marka + " " + klient.model;

            Lrejestracja.Text = klient.rejestracja;
            Lsilnik.Text = klient.silnik;
            Lmoc.Text = klient.moc;
            Lvin.Text = klient.vin;

            Ltelefon.Text = klient.telefon;
            Ladres.Text = klient.adres;
            Lprzebieg.Text = klient.przebieg;
            LrokProdukcji.Text = klient.rokProdukcji;

            try
            {
                Lprzyjecie.Text = klient.dataPrzyjecia.Split(',').ElementAt(1);

            }
            catch
            {
                Lprzyjecie.Text = klient.dataPrzyjecia;
            }

            try
            {
                Lwykonanie.Text = klient.dataWykonania.Split(',').ElementAt(1);
            }
            catch
            {
                Lwykonanie.Text = klient.dataWykonania;
            }

            Ldodatkowe.Text = klient.dodatkowe;

            Puslugi.Controls.Clear();
            Ptowary.Controls.Clear();
            indexCheck = 0;

            foreach (Usluga usluga in klient.uslugi)
            {
                CheckBox checkUsluga = new CheckBox();
                Label label = new Label();

                checkUsluga.Location = new Point(12, 12 + (28 * indexCheck));
                checkUsluga.Size = new Size(185, 21);
                checkUsluga.Font = new Font("Microsoft Sans Serif", 10.25F);
                checkUsluga.Text = usluga.nazwa;
                checkUsluga.Checked = usluga.gotowe;
                checkUsluga.CheckedChanged += new EventHandler(CheckUsluga_CheckedChanged);
                if (Program.zArchiwum)
                {
                    checkUsluga.Enabled = false;
                }

                label.Location = new Point(215, 12 + (28 * indexCheck));
                label.Size = new Size(50, 20);
                label.Font = new Font("Microsoft Sans Serif", 10.25F);
                label.Text = usluga.cena;
                try
                {
                    uslugiSuma += double.Parse(usluga.cena);
                }
                catch { }

                Puslugi.Controls.Add(checkUsluga);
                Puslugi.Controls.Add(label);

                indexCheck++;
            }

            indexCheck = 0;

            foreach (Towar towar in klient.towary)
            {
                CheckBox checkTowar = new CheckBox();
                Label label = new Label();

                checkTowar.Location = new Point(12, 12 + (28 * indexCheck));
                checkTowar.Size = new Size(185, 21);
                checkTowar.Font = new Font("Microsoft Sans Serif", 10.25F);
                checkTowar.Text = towar.nazwa;
                checkTowar.Checked = towar.gotowe;
                checkTowar.CheckedChanged += new EventHandler(CheckTowar_CheckedChanged);
                if (Program.zArchiwum)
                {
                    checkTowar.Enabled = false;
                }


                label.Location = new Point(215, 12 + (28 * indexCheck));
                label.Size = new Size(50, 20);
                label.Font = new Font("Microsoft Sans Serif", 10.25F);
                label.Text = towar.cena;
                try
                {
                    towarySuma += double.Parse(towar.cena);
                }
                catch { }


                Ptowary.Controls.Add(checkTowar);
                Ptowary.Controls.Add(label);

                indexCheck++;
            }
            try
            {
                uslugiTowarySuma = uslugiSuma + towarySuma;
            }
            catch { }


            LuslugiSuma.Text = uslugiSuma.ToString();
            LtowarySuma.Text = towarySuma.ToString();
            LuslugiTowarySuma.Text = uslugiTowarySuma.ToString();
        }

        #endregion

        //private void BTdodaj_Click(object sender, EventArgs e)
        //{

        //    //helpTab[0] = TBimie.Text;
        //    //helpTab[1] = TBnazwisko.Text;
        //    //helpTab[2] = TBwaga.Text;
        //    //helpTab[3] = TBplatony.Text;
        //    //helpTab[4] = Lmaliny.Text;
        //    //helpTab[5] = Lwyplata.Text;
        //    //helpTab[6] = checkBox1.Checked ? "Tak" : "Nie";
        //    //Lerr.Visible = false;

        //    //if ((helpTab[0] != "") & (helpTab[1] != "") & (helpTab[2] != "") & (helpTab[3] != "") & (helpTab[4] != "") & (helpTab[5] != ""))
        //    //{
        //    //    if (Program.GetCzlowiek(helpTab[0] + " " + helpTab[1]) == null)
        //    //    {
        //    //        Program.GetBaza().Add(helpTab[0] + " " + helpTab[1], new Czlowiek());

        //    //        Program.GetCzlowiek(helpTab[0] + " " + helpTab[1]).imie = helpTab[0];
        //    //        Program.GetCzlowiek(helpTab[0] + " " + helpTab[1]).nazwisko = helpTab[1];

        //    //    }




        //    //    Program.GetCzlowiek(helpTab[0] + " " + helpTab[1]).daty.Add(Program.data, new Dane
        //    //    {
        //    //        WgWszystko = float.Parse(helpTab[2]),
        //    //        WgPlatony = float.Parse(helpTab[3]),
        //    //        WgMaliny = float.Parse(helpTab[4]),
        //    //        Cena = Program.cena,
        //    //        Wyplata = float.Parse(helpTab[5]),
        //    //        NaKonto = checkBox1.Checked

        //    //    });


        //    //    listView1.Items.Add(new ListViewItem(helpTab));



        //    //    TBimie.Text = "";
        //    //    TBnazwisko.Text = "";
        //    //    TBwaga.Clear();
        //    //    TBplatony.Clear();
        //    //    Lmaliny.Text = "0";
        //    //    Lwyplata.Text = "0";

        //    //}
        //    //else Lerr.Visible = true;

        //}

        //private void TBwaga_TextChanged(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    Lmaliny.Text = Convert.ToString(float.Parse(TBwaga.Text) - float.Parse(TBplatony.Text));
        //    //    Lwyplata.Text = Convert.ToString(float.Parse(Lmaliny.Text) * Program.cena);
        //    //}
        //    //catch { }      
        //}

        //private void TBplatony_TextChanged(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    Lmaliny.Text = Convert.ToString(float.Parse(TBwaga.Text) - float.Parse(TBplatony.Text));
        //    //    Lwyplata.Text = Convert.ToString(float.Parse(Lmaliny.Text) * Program.cena);
        //    //}
        //    //catch { }           
        //}

        //private void listView1_DoubleClick(object sender, EventArgs e)
        //{
        //   // ListViewItem item;
        //   // string[] str=new string[7];
        //   // int i = 0;
        //   //item = listView1.FocusedItem;


        //   // foreach (ListViewItem.ListViewSubItem item2 in item.SubItems)
        //   // {
        //   //     str[i] = item2.Text;
        //   //     i++;
        //   // }

        //   //  TBimie.Text=str[0];
        //   //  TBnazwisko.Text= str[1];
        //   // TBwaga.Text= str[2];
        //   // TBplatony.Text= str[3];
        //   //  Lmaliny.Text= str[4];
        //   // Lwyplata.Text= str[5];
        //   // if (str[6] == "Tak")
        //   // {
        //   //     checkBox1.Checked = true;
        //   // }
        //   // else checkBox1.Checked = false;

        //   // Program.GetCzlowiek(str[0] + " " + str[1]).daty.Remove( Program.data);


        //   // listView1.FocusedItem.Remove();


        //}

        //private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //listView1.Items.Clear();
        //}

        //private void Form3_Load(object sender, EventArgs e)
        //{
        //    //Lnazwisko.Text = Program.data.Split(',')[1];
        //    //Lcena.Text = Program.cena.ToString();

        //    //bool isset = false;

        //    //foreach (var item in Program.GetBaza())
        //    //{

        //    //    isset = false;

        //    //    foreach (var item2 in TBimie.Items)
        //    //    {

        //    //        if (item.Value.imie == item2.ToString()) isset = true;


        //    //    }

        //    //    if (isset == false)
        //    //        TBimie.Items.Add(item.Value.imie);

        //    //    isset = false;

        //    //    foreach (var item2 in TBnazwisko.Items)
        //    //    {

        //    //        if (item.Value.nazwisko == item2.ToString()) isset = true;


        //    //    }

        //    //    if (isset == false)
        //    //        TBnazwisko.Items.Add(item.Value.nazwisko);
        //    //}


        //    //if (Program.istnieje)
        //    //{

        //    //    foreach (var item in Program.GetBaza())
        //    //    {



        //    //        foreach (var item2 in item.Value.daty)
        //    //        {

        //    //            if (Program.data == item2.Key)
        //    //            {
        //    //                helpTab[0] = item.Value.imie;
        //    //                helpTab[1] = item.Value.nazwisko;
        //    //                helpTab[2] = item2.Value.WgWszystko.ToString();
        //    //                helpTab[3] = item2.Value.WgPlatony.ToString();
        //    //                helpTab[4] = item2.Value.WgMaliny.ToString();
        //    //                helpTab[5] = item2.Value.Wyplata.ToString();
        //    //                helpTab[6] = item2.Value.NaKonto ? "Tak" : "Nie";

        //    //                listView1.Items.Add(new ListViewItem(helpTab));

        //    //            }


        //    //        }
        //    //    }
        //    //}
        //}

        //private void TBimie_TextUpdate(object sender, EventArgs e)
        //{
        //    IsInBase();
        //}

        //private void TBnazwisko_TextUpdate(object sender, EventArgs e)
        //{
        //    IsInBase();
        //}

        //private void TBimie_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    IsInBase();
        //}

        //private void TBnazwisko_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    IsInBase();
        //}




        //private void IsInBase()
        //{
        //    //if (Program.GetCzlowiek(TBimie.Text + " " + TBnazwisko.Text) == null)
        //    //{
        //    //    Linfo.ForeColor = Color.Red;
        //    //    Linfo.Text = "Brak w bazie";
        //    //}
        //    //else
        //    //{
        //    //    Linfo.ForeColor = Color.Green;
        //    //    Linfo.Text = "Znaleziono w bazie";

        //    //}
        //}
    }
}