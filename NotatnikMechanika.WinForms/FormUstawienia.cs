using System;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormUstawienia : Form
    {
        public FormUstawienia()
        {
            InitializeComponent();

            SprawdzCzyHaslo();

            UstawDaneFirmy();
        }
        #region zapisz dane firmy
        private void BTzapisz_Click(object sender, EventArgs e)
        {
            ZapiszDaneFirmy();

            Close();
        }
        #endregion

        #region ustawienia hasla
        private void BTzmienHaslo_Click(object sender, EventArgs e)
        {
            if (Program.dataMenager.firstOpenSettings.isPassword)
            {
                if (TBhaslo.Text == Program.dataMenager.firstOpenSettings.password)
                {
                    UstawHaslo();
                }
                else
                {
                    MessageBox.Show(
                  "Niepoprawne hasło",
                  "Hasło",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                  );
                }

            }
            else
            {
                UstawHaslo();

            }
        }

        private void BTusunHaslo_Click(object sender, EventArgs e)
        {
            if (TBhaslo.Text == Program.dataMenager.firstOpenSettings.password)
            {
                Program.dataMenager.firstOpenSettings.password = null;
                Program.dataMenager.firstOpenSettings.isPassword = false;
                TBhaslo.Enabled = false;
                BTusunHaslo.Enabled = false;

                TBhaslo.Text = "";
                TBnoweHaslo.Text = "";
                TBpowtorzHaslo.Text = "";
                LrozneHasla.Visible = false;

                MessageBox.Show(
                "Hasło zostało usunięte",
                "Hasło",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
               "Niepoprawne hasło",
               "Hasło",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ustawienia fabryczne
        private void BTustawieniaFabryczne_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                 "Uwaga! Przywracając ustawienia fabryczne stracisz wszystkie dane. Czy napewno chcesz to zrobić?",
                 "Ustawienia fabryczne",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Asterisk
                 ) == DialogResult.Yes)
            {
                Program.UstawieniaFabryczne();
            }
        }
        #endregion

        #region funkcje własne

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
            Program.dataMenager.daneFirmy.DeaflutVAT = CBDeaflutVAT.Text;
            Program.dataMenager.daneFirmy.magazyn = CHMagazyn.Checked;

        }

        private void SprawdzCzyHaslo()
        {
            if (Program.dataMenager.firstOpenSettings.isPassword)
            {
                TBhaslo.Enabled = true;
                BTusunHaslo.Enabled = true;
            }
            else
            {
                TBhaslo.Enabled = false;
                BTusunHaslo.Enabled = false;
            }
        }

        private void UstawDaneFirmy()
        {
            TBnazwa.Text = Program.dataMenager.daneFirmy.nazwa;
            TBadres.Text = Program.dataMenager.daneFirmy.adres;
            TBkodPocztowy.Text = Program.dataMenager.daneFirmy.kodPocztowy;
            TBmiejscowosc.Text = Program.dataMenager.daneFirmy.miejscowosc;
            TBtelefon.Text = Program.dataMenager.daneFirmy.telefon;
            TBnip.Text = Program.dataMenager.daneFirmy.nip;
            TBregon.Text = Program.dataMenager.daneFirmy.regon;
            TBbank.Text = Program.dataMenager.daneFirmy.bank;
            TBkonto.Text = Program.dataMenager.daneFirmy.konto;
            CBDeaflutVAT.Text = Program.dataMenager.daneFirmy.DeaflutVAT;
            CHMagazyn.Checked = Program.dataMenager.daneFirmy.magazyn;
        }

        private void UstawHaslo()
        {
            if (TBnoweHaslo.Text != "")
            {
                if (TBnoweHaslo.Text == TBpowtorzHaslo.Text)
                {
                    Program.dataMenager.firstOpenSettings.isPassword = true;
                    Program.dataMenager.firstOpenSettings.password = TBnoweHaslo.Text;

                    TBhaslo.Enabled = true;
                    BTusunHaslo.Enabled = true;

                    TBhaslo.Text = "";
                    TBnoweHaslo.Text = "";
                    TBpowtorzHaslo.Text = "";
                    LrozneHasla.Visible = false;

                    MessageBox.Show(
                    "Hasło zostało zapisane",
                    "Hasło",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                    );

                }
                else
                {
                    LrozneHasla.Visible = true;
                }
            }
            else
            {
                MessageBox.Show(
                  "Pole nowe hasło nie może być puste",
                  "Hasło",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                  );
            }
        }
        #endregion
    }
}