using System;
using System.Collections.Generic;

namespace NotatnikMechanika.WinForms
{
    [Serializable]
    public class FakturaDane
    {
        public bool paragon;

        public string nazwa;
        public string adres;
        public string kodPocztowy;
        public string miejscowosc;
        public string telefon;
        public string nip;
        public string regon;
        public string bank;
        public string konto;


        public string nazwaNabywaca;
        public string nipNabywca;
        public string adresNabywca;
        public string kodNabywca;
        public string miejscowoscNabywca;

        public List<string[]> listViewItems = new List<string[]>();

        public int nrFaktury;
        public string nrFakturyString;
        public string miejsceWystawienia;
        public string dataWystawienia;

        public string formaPlatnosci;
        public bool zaplacono;
        public string terminPlatnosci;

        public string osobaWystawiajaca;
        public string osobaUpowazniona;

        public string dodatkowe;

        public double sumaNetto;
        public double sumaVat;
        public double sumaBrutto;
    }
}