using System.ComponentModel.DataAnnotations;

namespace Semesterprojekt.Models
{
	public class Ordre
	{
		private int Id { get; set; }
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

		public Ordre(int id, DateTime datetime, Kunde kunde, string beskrivelse, double pakke, bool godkendt)
		{
			Id = id++;
			DateTime = datetime;
			Kunde = kunde;
			Beskrivelse = beskrivelse;
			Pakke = pakke;
			Godkendt = godkendt;
		}

		//UpdateOrdre

		//DeleteOrdre
	}


}

