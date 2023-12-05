using System.ComponentModel.DataAnnotations;

namespace Semesterprojekt.Models
{
	public class Ordre
	{
		public int id {get;} 
		private static int Id = 1;

        [Display(Name = "Dato")]
        [Required(ErrorMessage = "Du skal angive en dato")]
        public DateTime? DateTime { get; set; }
		public Kunde Kunde { get; set; }
        [Display(Name = "Beskrivelse")]
        [Required(ErrorMessage = "Du skal angive en beskrivelse")]
        public string? Beskrivelse { get; set; }
		public double Pakke { get; set; }
		public bool Godkendt { get; set; }


		public Ordre() { }

		public Ordre(DateTime dateTime, Kunde kunde, string beskrivelse)
		{
			id = Id++;
			DateTime = dateTime;
			Kunde = kunde; //hvordan henter jeg kunde.navn osv?
			Beskrivelse = beskrivelse;
			//Pakke = pakke;
			//Godkendt = godkendt;
		}

		//UpdateOrdre

		//DeleteOrdre
	}


}

