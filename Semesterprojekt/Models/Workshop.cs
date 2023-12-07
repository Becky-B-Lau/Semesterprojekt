using System.ComponentModel.DataAnnotations;

namespace Semesterprojekt.Models
{
    public class Workshop
    {
        [Display(Name = "Workshop ID")]
        [Required(ErrorMessage = "Der skal angives et ID til Item")]
        [Range(typeof(int), minimum: "0", maximum: "10000", ErrorMessage = "ID skal være mellem {1} og {2}")]
        public int WorkshopId { get; set; }
        [Display(Name = "Workshop Navn")]
        [Required(ErrorMessage = "Workshopen skal have et navn"), MaxLength(50)]
        public string Navn { get; set; }
        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Der skal angives en pris")]
        [Range(typeof(double), minimum: "0", maximum: "100000", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public int Pris { get; set; }
        [Display(Name = "Der skal angives en lokation")]
        [Required(ErrorMessage = "Workshopen skal have en lokation"), MaxLength(100)]
        public string Lokation { get; set; }
        [Display(Name = "Der skal angives en dato og tid")]
        [Required(ErrorMessage = "Workshopen skal have en dato og tid"), MaxLength(70)]
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
