namespace Semesterprojekt.Models
{

    public class Kunde : Person
    {
<<<<<<< HEAD
   //ja
=======
        public bool Erhverv { get; set; }
        public bool Privat { get; set; }
>>>>>>> 5761968fa8067d3dd01bd7f9fd77101b63473544
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
