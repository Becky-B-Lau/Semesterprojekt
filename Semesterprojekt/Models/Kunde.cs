namespace Semesterprojekt.Models
{

    public class Kunde : Person
    {
<<<<<<< HEAD
        private int Id { get; set; }
=======
       public bool Erhverv { get; set; }
        public bool Privat { get; set; }
        public int Kundeid { get; }
        private static int KundeId = 1;
>>>>>>> ee1dd6723bad7ee1792d74a743afe8a3c3b9ff1d
        public Kunde() : base()
        {
        }
        public Kunde(string navn, int alder, int telefonnummer, string adresse, string email, bool erhverv, bool privat) : base(navn, alder, telefonnummer, adresse, email)
        {
<<<<<<< HEAD
            Id = id;
=======
            Erhverv = erhverv;
            Privat = privat; 
            Kundeid = KundeId++;
>>>>>>> ee1dd6723bad7ee1792d74a743afe8a3c3b9ff1d
        }
    }
}
