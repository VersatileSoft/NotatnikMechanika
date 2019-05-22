using System;
using System.Collections.Generic;

namespace NotatnikMechanika.WinForms
{
    [Serializable]
    public class Klient
    {
        public string imie;
        public string nazwisko;
        public string marka;
        public string model;
        public string rejestracja;
        public string silnik;
        public string moc;
        public string vin;
        public string telefon;
        public string adres;
        public string przebieg;
        public string rokProdukcji;
        public string nazwaFirmy;
        public string nip;
        public string dataPrzyjecia;
        public string dataWykonania;
        public string dodatkowe;

        public List<Usluga> uslugi = new List<Usluga>();
        public List<Towar> towary = new List<Towar>();
    }
}