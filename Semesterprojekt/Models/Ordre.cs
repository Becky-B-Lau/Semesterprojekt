﻿using System.ComponentModel.DataAnnotations;

namespace Semesterprojekt.Models
{
	public class Ordre
	{
		public int id { get; set; } 
		private static int Id = 1;

        [Display(Name = "Dato")]
        [Required(ErrorMessage = "Du skal angive en dato")]
        public DateTime? DateTime { get; set; }
		public Kunde Kunde { get; set; }
        [Display(Name = "Beskrivelse")]
        [Required(ErrorMessage = "Du skal angive en beskrivelse")]
        public string? Beskrivelse { get; set; }
		public Billeder Billeder { get; set; }

      

		public Ordre() {  }

		public Ordre(DateTime dateTime, Kunde kunde, string beskrivelse, Billeder billeder)
		{
			id = Id++;
			DateTime = dateTime;
			Kunde = kunde;
			Beskrivelse = beskrivelse;
			Billeder = billeder;
            
        }

	
	}


}

