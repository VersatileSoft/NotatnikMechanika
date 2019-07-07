using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NotatnikMechanika.WinForms
{
    public class DataMenager
    {
        private readonly BinaryFormatter binaryFormatter;
        private FileStream filestream;

        public Dictionary<string, Klient> klienci = new Dictionary<string, Klient>();

        public List<Klient> staliKlienci = new List<Klient>();
        public List<Usluga> uslugi = new List<Usluga>();
        public List<Towar> towary = new List<Towar>();
        public List<Klient> archiwum = new List<Klient>();
        public List<FakturaDane> faktury = new List<FakturaDane>();

        public Update update = new Update();
        public DaneFirmy daneFirmy = new DaneFirmy();
        public FirstOpenSettings firstOpenSettings = new FirstOpenSettings();
        private readonly string klienciSciezka = @"Dane/klienci.binary";
        private readonly string staliKlienciSciezka = @"Dane/stali_klienci.binary";
        private readonly string uslugiSciezka = @"Dane/uslugi.binary";
        private readonly string towarySciezka = @"Dane/towary.binary";
        private readonly string archiwumSciezka = @"Dane/archiwum.binary";
        private readonly string updateSciezka = @"Dane/update.binary";
        private readonly string daneFirmySciezka = @"Dane/dane_firmy.binary";
        private readonly string firstOpenSettingsSciezka = @"Dane/first_Open_Settings.binary";
        private readonly string fakturySciezka = @"Dane/faktury.binary";

        public DataMenager()
        {
            binaryFormatter = new BinaryFormatter();
        }

        public void ResetData()
        {
            klienci.Clear();
            staliKlienci.Clear();
            uslugi.Clear();
            towary.Clear();
            archiwum.Clear();
            faktury.Clear();
            daneFirmy = new DaneFirmy();
            firstOpenSettings.columns.Clear();
            firstOpenSettings.demo = true;
            firstOpenSettings.isPassword = false;
            firstOpenSettings.password = null;

            firstOpenSettings.firstOpen = true;
        }


        public void ZapiszDane()
        {
            if (!Directory.Exists(@"Dane"))
            {
                _ = Directory.CreateDirectory(@"Dane");
            }

            binaryFormatter.Serialize(File.Open(klienciSciezka, FileMode.OpenOrCreate), klienci);
            binaryFormatter.Serialize(File.Open(staliKlienciSciezka, FileMode.OpenOrCreate), staliKlienci);
            binaryFormatter.Serialize(File.Open(uslugiSciezka, FileMode.OpenOrCreate), uslugi);
            binaryFormatter.Serialize(File.Open(towarySciezka, FileMode.OpenOrCreate), towary);
            binaryFormatter.Serialize(File.Open(archiwumSciezka, FileMode.OpenOrCreate), archiwum);
            binaryFormatter.Serialize(File.Open(updateSciezka, FileMode.OpenOrCreate), update);
            binaryFormatter.Serialize(File.Open(daneFirmySciezka, FileMode.OpenOrCreate), daneFirmy);
            binaryFormatter.Serialize(File.Open(firstOpenSettingsSciezka, FileMode.OpenOrCreate), firstOpenSettings);
            binaryFormatter.Serialize(File.Open(fakturySciezka, FileMode.OpenOrCreate), faktury);
        }

        public void OdczytajDane()
        {
            try
            {
                filestream = File.Open(klienciSciezka, FileMode.Open);
                klienci = (Dictionary<string, Klient>)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }

            try
            {
                filestream = File.Open(staliKlienciSciezka, FileMode.Open);
                staliKlienci = (List<Klient>)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }

            try
            {
                filestream = File.Open(uslugiSciezka, FileMode.Open);
                uslugi = (List<Usluga>)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }

            try
            {
                filestream = File.Open(towarySciezka, FileMode.Open);
                towary = (List<Towar>)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }

            try
            {
                filestream = File.Open(archiwumSciezka, FileMode.Open);
                archiwum = (List<Klient>)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }

            try
            {
                filestream = File.Open(updateSciezka, FileMode.Open);
                update = (Update)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }

            try
            {
                filestream = File.Open(daneFirmySciezka, FileMode.Open);
                daneFirmy = (DaneFirmy)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }

            try
            {
                filestream = File.Open(firstOpenSettingsSciezka, FileMode.Open);
                firstOpenSettings = (FirstOpenSettings)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }

            try
            {
                filestream = File.Open(fakturySciezka, FileMode.Open);
                faktury = (List<FakturaDane>)binaryFormatter.Deserialize(filestream);
                filestream.Close();
            }
            catch { }
        }
    }
}