using System;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public static class Program
    {
        public static bool hasloOk;
        public static string keyImie;
        public static string keyNazwisko;
        public static bool edycja;
        public static bool zArchiwum;
        public static int archiwumIndex;

        public static int stalyKlientIndex;
        public static bool stalyKlientIndexSet;

        public static FormPrzywitanie formPrzywitanie = new FormPrzywitanie();
        public static FormFirstSettings formFirstSettings = new FormFirstSettings();
        public static Form1 form1;
        public static FormHasloBaza formHasloBaza;
        public static FormPrintFakturaDane formPrintFaktura;

        public static ListViewItem itemFaktura;

        public static DataMenager dataMenager;

        [STAThread]
        private static void Main()
        {
            dataMenager = new DataMenager();

            dataMenager.OdczytajDane();

            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            Application.EnableVisualStyles();

            formHasloBaza = new FormHasloBaza();

            form1 = new Form1();

            if (dataMenager.firstOpenSettings.firstOpen)
            {
                Application.Run(formPrzywitanie);
            }
            else
            {
                Application.Run(form1);
            }
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            dataMenager.ZapiszDane();
        }

        //---------Funkcje Własne-------------

        internal static double KwotaVatzNetto(double netto, double vat)
        {
            double vatD = vat / 100;

            return Math.Round((netto * vatD), 2);
        }

        internal static double KwotaVatzBrutto(double brutto, double vat)
        {
            double vatD = vat / 100;

            return Math.Round((brutto / (1 + vatD)) * vatD, 2);
        }

        internal static void UstawieniaFabryczne()
        {
            if (MessageBox.Show(
                 "Uwaga po przywróceniu ustawień fabrycznych konieczne jest ponowne wpisanie klucza dostępu. Czy napewno go posiadasz?",
                 "Ustawienia fabryczne",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
                 ) == DialogResult.Yes)
            {

                dataMenager.ResetData();

                MessageBox.Show(
                 "Uruchom program ponownie",
                 "Ustawienia fabryczne",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

                Application.Exit();
            }
        }
    }
}