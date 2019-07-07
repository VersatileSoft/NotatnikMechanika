using System;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormFirstSettings : Form
    {
        private int otwarteOkno;

        public FormFirstSettings()
        {
            InitializeComponent();

            ZmienOkno(1);
            BTdalej.Enabled = false;
        }

        #region okno1
        private void RBuzywajHasla_CheckedChanged(object sender, EventArgs e)
        {
            if (RBuzywajHasla.Checked)
            {
                label6.Enabled = true;
                label7.Enabled = true;
                TBhaslo.Enabled = true;
                TBpowtorzHaslo.Enabled = true;
                if (TBhaslo.Text == "")
                {
                    BTdalej.Enabled = false;
                }
                else
                {
                    BTdalej.Enabled = true;
                }
            }
            else
            {
                label6.Enabled = false;
                label7.Enabled = false;
                TBhaslo.Enabled = false;
                TBpowtorzHaslo.Enabled = false;
                LrozneHasla.Visible = false;
                BTdalej.Enabled = true;
            }
        }

        private void TBhaslo_TextChanged(object sender, EventArgs e)
        {
            if (RBuzywajHasla.Checked)
            {
                if (TBhaslo.Text == "")
                {
                    BTdalej.Enabled = false;
                }
                else
                {
                    BTdalej.Enabled = true;
                }
            }
        }
        #endregion

        private void BTdalej_Click(object sender, EventArgs e)
        {
            if (otwarteOkno == 0)
            {
                //  zapiszDaneKolumn();
                BTdalej.Enabled = false;
            }

            if (otwarteOkno == 1)
            {
                if (TBhaslo.Text != TBpowtorzHaslo.Text)
                {
                    otwarteOkno -= 1;
                    LrozneHasla.Visible = true;
                }
                else
                {
                    ZapiszHaslo();
                }

                Program.dataMenager.firstOpenSettings.isPassword = RBuzywajHasla.Checked;
            }

            if (otwarteOkno == 2)
            {
                ZapiszDaneFirmy();

                MessageBox.Show("Konfiguracja zakończona, uruchom program ponownie",
                    "Notatnik mechanika",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Program.dataMenager.firstOpenSettings.demo = false;
                Program.dataMenager.firstOpenSettings.firstOpen = false;

                Application.Exit();
            }
            ZmienOkno(otwarteOkno + 1);
        }

        private void ZapiszDaneFirmy()
        {
            Program.dataMenager.daneFirmy.nazwa = TBnazwa.Text;
            Program.dataMenager.daneFirmy.adres = TBadres.Text;
            Program.dataMenager.daneFirmy.kodPocztowy = TBkodPocztowy.Text;
            Program.dataMenager.daneFirmy.miejscowosc = TBmiejscowosc.Text;
            Program.dataMenager.daneFirmy.telefon = TBtelefon.Text;
            Program.dataMenager.daneFirmy.nip = TBnip.Text;
            Program.dataMenager.daneFirmy.regon = TBregon.Text;
            Program.dataMenager.daneFirmy.bank = TBbank.Text;
            Program.dataMenager.daneFirmy.konto = TBkonto.Text;
        }

        #region funkcje własne
        private void ZapiszHaslo()
        {
            Program.dataMenager.firstOpenSettings.password = TBhaslo.Text;
        }

        private void ZmienOkno(int nrOkna)
        {
            //  GBdaneKlienta.Visible = false;
            GBszyfrowanieDanych.Visible = false;
            GBdaneFirmy.Visible = false;

            switch (nrOkna)
            {
                case 0:
                    //  GBdaneKlienta.Visible = true;
                    //  otwarteOkno = 0;
                    break;
                case 1:
                    GBszyfrowanieDanych.Visible = true;
                    otwarteOkno = 1;
                    break;
                case 2:
                    GBdaneFirmy.Visible = true;
                    otwarteOkno = 2;
                    break;
            }
        }
        #endregion
    }
}