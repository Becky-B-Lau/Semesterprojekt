namespace Semesterprojekt.Models
{

    public class Kunde : Person
    {
        private int Id { get; set; }
        public Kunde() : base()
        {
        }
        public Kunde(int id, string navn, int alder, int telefonnummer, string adresse, string email) : base(navn, alder, telefonnummer, adresse, email)
        {
            Id = id;
        }
    }
}
