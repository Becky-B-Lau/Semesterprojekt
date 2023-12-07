namespace Semesterprojekt.Models
{

    public class Kunde : Person
    {
   //ja
        public int Kundeid { get; }
        private static int KundeId = 1;
        public Kunde() : base()
        {
        }

        public Kunde(string navn, int alder, int telefonnummer, string adresse, string email, bool erhverv, bool privat) : base(navn, alder, telefonnummer, adresse, email)
        {
            Erhverv = erhverv;
            Privat = privat; 
            Kundeid = KundeId++;
        }
    }
}
