namespace Semesterprojekt.Models
{
    public class Workshop
    {
        public int WorkshopId { get; set; }
        public string Navn { get; set; }
        public int Pris { get; set; }
        public string Lokation { get; set; }
        public string Tid { get; set; }

        public Workshop()
        {
        }

        public Workshop(int workshopId, string navn, int pris, string lokation, string tid)
        {
            WorkshopId = workshopId;
            Navn = navn;
            Pris = pris;
            Lokation = lokation;
            Tid = tid;
        }

    }
}
