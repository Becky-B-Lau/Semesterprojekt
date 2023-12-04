namespace Semesterprojekt.Models
{
	public class Ordre
	{
		private int Id { get; set; }
		private DateTime DateTime { get; set; }
		public Kunde Kunde { get; set; }
		private string Beskrivelse { get; set; }
		private double Pakke { get; set; }
		private bool Godkendt { get; set; }

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

