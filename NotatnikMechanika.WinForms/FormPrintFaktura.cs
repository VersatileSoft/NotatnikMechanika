using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormPrintFaktura : Form
    {
        private readonly FakturaDane szablonFaktura;
        private readonly bool OryginalKopia;
        private readonly bool paragon;

        public FormPrintFaktura(int index, bool paragon, bool OryginalKopia)
        {
            InitializeComponent();

            this.OryginalKopia = OryginalKopia;

            this.paragon = paragon;

            szablonFaktura = Program.dataMenager.faktury[index];

            LadujDane();

            DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DGV.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            DGV.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            DGVsuma.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            DGVsuma.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void FormPrintFaktura_Shown(object sender, EventArgs e)
        {
            PrintControl(panel1);
            Close();
        }

        public void PrintControl(Control control)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, e) =>
            {
                Bitmap bitmap = new Bitmap(control.Width, control.Height);

                control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));

                e.PageSettings.PaperSize = new PaperSize("A4", panel1.Width, panel1.Height);

                e.Graphics.DrawImage(bitmap, 0, 0);

                if (OryginalKopia && LKopiaOryginal.Text != "Kopia")
                {
                    LKopiaOryginal.Text = "Kopia";

                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;

                    LadujDane();
                }

            };
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
            //pd.Print();
        }

        private void LadujDane()
        {
            LKopiaOryginal.Text = "Oryginał";

            UstawUslugiTowary(szablonFaktura);

            if (paragon)
            {
                LnrFaktury.Text = "Paragon nr " + szablonFaktura.nrFakturyString;

                LmiejsceWystawienia.Visible = false;

                LterminPlatnosci.Visible = false;

                LterminPlatnosci.Visible = false;

                LformaPlatnosci.Visible = false;

                LnipNabywca.Visible = false;

                LkodMiejscowoscNabywca.Visible = false;
                LadresNabywca.Visible = false;
                LnazwaNabywca.Visible = false;
                LosobaUpowazniona.Visible = false;
                LosobaWystawiajaca.Visible = false;
                label43.Visible = false;
                LnipText.Visible = false;
                label5.Visible = false;
                label17.Visible = false;
                label15.Visible = false;

                label2.Visible = false;
                label4.Visible = false;
            }
            else
            {
                LnrFaktury.Text = "Faktura nr " + szablonFaktura.nrFakturyString;

                LmiejsceWystawienia.Text = szablonFaktura.miejsceWystawienia;

                try
                {
                    LterminPlatnosci.Text = szablonFaktura.terminPlatnosci.Split(',').ElementAt(1);
                }
                catch
                {
                    LterminPlatnosci.Text = szablonFaktura.terminPlatnosci;
                }

                LformaPlatnosci.Text = szablonFaktura.formaPlatnosci;
                LnipNabywca.Text = szablonFaktura.nipNabywca;
                LnipText.Visible = szablonFaktura.nipNabywca != "" ? true : false;
                LkodMiejscowoscNabywca.Text = szablonFaktura.kodNabywca + " " + szablonFaktura.miejscowoscNabywca;
                LadresNabywca.Text = szablonFaktura.adresNabywca;
                LnazwaNabywca.Text = szablonFaktura.nazwaNabywaca;
                LosobaUpowazniona.Text = szablonFaktura.osobaUpowazniona;
                LosobaWystawiajaca.Text = szablonFaktura.osobaWystawiajaca;
            }

            try
            {
                LdataWystawienia.Text = szablonFaktura.dataWystawienia.Split(',').ElementAt(1);
            }
            catch
            {

                LdataWystawienia.Text = szablonFaktura.dataWystawienia;
            }

            Lnazwa.Text = szablonFaktura.nazwa;
            Ladres.Text = szablonFaktura.adres;
            LkodMiejscowosc.Text = szablonFaktura.kodPocztowy + " " + szablonFaktura.miejscowosc;
            Lnip.Text = szablonFaktura.nip;
            Lregon.Text = szablonFaktura.regon;
            Lbank.Text = szablonFaktura.bank;
            Lkonto.Text = szablonFaktura.konto;
            Ltelefon.Text = szablonFaktura.telefon;

            Ldodatkowe.Text = szablonFaktura.dodatkowe;

            if (Ldodatkowe.Text == "")
            {
                LDodatkoweText.Visible = false;
            }
            else
            {
                LDodatkoweText.Visible = true;
            }

            LdoZaplaty.Text = "Do zapłaty: " + szablonFaktura.sumaBrutto + " zł";
        }

        private void UstawUslugiTowary(FakturaDane faktura)
        {
            DGVsuma.Rows.Clear();
            DGV.Rows.Clear();

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

            DGVsuma.Rows.Add(szablonFaktura.sumaNetto, "-", szablonFaktura.sumaVat, szablonFaktura.sumaBrutto);
        }

        public void DodajUslugeTowar(string nazwa, double cena, double sztuk, string JM, double vat)
        {
            _ = vat / 100;

            double cenaNetto = cena - Program.KwotaVatzBrutto(cena, vat);

            if (DGV.Rows.Count < 28)
            {

                DGV.Rows.Add(
                        (DGV.Rows.Count + 1).ToString(),
                        nazwa,
                        cena.ToString(),
                        sztuk.ToString(),
                        JM,
                        (cenaNetto * sztuk).ToString(),
                        vat + "%",
                        (Program.KwotaVatzBrutto(cena, vat) * sztuk).ToString(),
                        (cena * sztuk).ToString()
                    );
            }
        }

        public void DodajUslugeTowarZw(string nazwa, double cena, double sztuk, string JM)
        {
            LZw.Visible = true;

            double cenaNetto = cena - Program.KwotaVatzBrutto(cena, 0);

            if (DGV.Rows.Count < 28)
            {

                DGV.Rows.Add(
                        (DGV.Rows.Count + 1).ToString(),
                        nazwa,
                        cena.ToString(),
                        sztuk.ToString(),
                        JM,
                        (cenaNetto * sztuk).ToString(),
                        "zw",
                        (Program.KwotaVatzBrutto(cena, 0) * sztuk).ToString(),
                        (cena * sztuk).ToString()
                    );
            }
        }
    }
}