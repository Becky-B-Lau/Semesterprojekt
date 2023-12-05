namespace Semesterprojekt.Models
{

    public class Kunde : Person
    {
        private static List<Kunde> kunder = new List<Kunde>();

        private int Id { get; set; }
        public Kunde() : base()
        {
        }
        public Kunde(int id, string navn, int alder, int telefonnummer, string adresse, string email) : base(navn, alder, telefonnummer, adresse, email)
        {

            Id = id;
        }
        public static void AddKunde(Kunde kunde)
        {
            kunder.Add(kunde);
        }
        public static void AddKunde( int id, string navn, int alder, int telefonnummer, string adresse, string email)
        {
            kunder.Add(new Kunde(id, navn, alder, telefonnummer, adresse, email));
        }

        public static Kunde? RemoveKundeVedNavn(string navn)
        {
            foreach (Kunde kunde in kunder)
            {
                if (kunde.Navn == navn)
                {
                    kunder.Remove(kunde);
                    return kunde;
                }
            }

            return null;
        }

        public static List<Kunde> GetKunder()
        {
            return kunder;
        }


        public static Kunde? SearchKundeVedNavn(string navn)
        {
            foreach (Kunde kunde in kunder)
            {
                if (kunde.Navn == navn)
                    return kunde;
            }

            return null;
        }
    }
}
