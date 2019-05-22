using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormPrint : Form
    {
        private Klient klient;

        public FormPrint()
        {
            InitializeComponent();

            LadujDane();
        }

        private void FormPrint_Shown(object sender, EventArgs e)
        {
            PrintControl(panel1);
            Close();
        }

        public void PrintControl(Control control)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

            Bitmap bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));

            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, e) => e.Graphics.DrawImage(bitmap, 0, 0);
            pd.PrintPage += (s, e) => e.Graphics.DrawLine(pen, 60, 155, 300, 155);
            pd.PrintPage += (s, e) => e.Graphics.DrawLine(pen, 565, 155, 800, 155);
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
            //pd.Print();
        }


        private void LadujDane()
        {
            if (Program.zArchiwum)
            {
                klient = Program.dataMenager.archiwum.ElementAt(Program.archiwumIndex);
            }
            else
            {
                Program.dataMenager.klienci.TryGetValue(Program.keyImie + " " + Program.keyNazwisko, out klient);
            }

            LimieKlient.Text = klient.imie;
            LnazwiskoKlient.Text = klient.nazwisko;
            Lmarka.Text = klient.marka;
            Lmodel.Text = klient.model;
            //Lrejestracja.Text = klient.rejestracja;

            Lnazwa.Text = Program.dataMenager.daneFirmy.nazwa;
            //   Lnazwisko.Text = Program.dataMenager.daneFirmy.nazwisko;
            Ladres.Text = Program.dataMenager.daneFirmy.adres;
            LkodPocztowy.Text = Program.dataMenager.daneFirmy.kodPocztowy;
            Lnip.Text = Program.dataMenager.daneFirmy.nip;
            if (Lnip.Text == "")
            {
                LnipText.Visible = false;
            }

            Ldata.Text = DateTime.Now.ToShortDateString();

            int enumerator = 1;
            double uslugiCena = 0;

            if (enumerator < 15)
            {
                foreach (Usluga usluga in klient.uslugi)
                {
                    string[] tabKlient = new string[3];

                    tabKlient[0] = enumerator++.ToString();
                    tabKlient[1] = usluga.nazwa;
                    tabKlient[2] = usluga.cena;
                    try
                    {
                        uslugiCena += double.Parse(usluga.cena);
                    }
                    catch { }
                    LVuslugi.Items.Add(new ListViewItem(tabKlient));
                }
            }

            enumerator = 1;
            double towaryCena = 0;

            if (enumerator < 15)
            {
                foreach (Towar towar in klient.towary)
                {
                    string[] tabKlient = new string[3];

                    tabKlient[0] = enumerator++.ToString();
                    tabKlient[1] = towar.nazwa;
                    tabKlient[2] = towar.cena;
                    try
                    {
                        towaryCena += double.Parse(towar.cena);
                    }
                    catch { }
                    LVtowary.Items.Add(new ListViewItem(tabKlient));
                }
            }

            LuslugiSuma.Text = uslugiCena.ToString();
            LtowarySuma.Text = towaryCena.ToString();
            LuslugiTowarySuma.Text = (uslugiCena + towaryCena).ToString();
        }
    }
}