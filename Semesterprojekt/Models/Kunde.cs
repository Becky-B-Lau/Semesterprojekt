namespace Semesterprojekt.Models
{

    public class Kunde : Person
    {
 
        public string Type { get; set; }
        public int Kundeid { get; }
        private static int KundeId = 1;
        public Kunde() : base()
        {
            Kundeid = KundeId++;
        }

        public Kunde(string navn, int alder, int telefonnummer, string adresse, string email, string type) : base(navn, alder, telefonnummer, adresse, email)
        {
            Type = type;   
            Kundeid = KundeId++;
        }
    }
}
