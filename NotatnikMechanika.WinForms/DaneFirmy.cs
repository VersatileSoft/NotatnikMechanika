using System;

namespace NotatnikMechanika.WinForms
{
    [Serializable]
    public class DaneFirmy
    {
        public string nazwa;

        public string adres;
        public string kodPocztowy;
        public string miejscowosc;
        public string telefon;

        public string nip;
        public string regon;
        public string bank;
        public string konto;

        public string DeaflutVAT = "23";

        public bool magazyn;
    }
}