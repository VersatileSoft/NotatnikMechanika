using System;

namespace NotatnikMechanika.WinForms
{
    [Serializable]
    public class Towar
    {
        public string nazwa;
        public string symbol;
        public string cena;
        public bool gotowe;
        public bool dodajDoZlecenia;
        public int ilosc;
    }
}