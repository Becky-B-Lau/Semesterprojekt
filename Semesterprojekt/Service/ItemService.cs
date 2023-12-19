using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Semesterprojekt.MockData;
using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
	public class ItemService : IItemService
	{
		public List<Ordre> _items { get; set; }
		public static int Id = 1;
		public static int KundeId = 1;
		private JasonFileOrdreService JasonFileOrdreService { get; set; }

		
		public ItemService(JasonFileOrdreService jasonFileOrdreService)
		{
			JasonFileOrdreService = jasonFileOrdreService;
			//_items = MockOrdre.GetMockOrdre();
			_items = JasonFileOrdreService.GetJsonOrdre().ToList();
		}

		public void AddItem(Ordre item)
		{
			_items.Add(item);
            
            item.Kunde.Kundeid = KundeId++;
            item.id = Id++;
			JasonFileOrdreService.SaveJsonOrdre(_items);
		}

		public List<Ordre> GetItems() { return _items; }

		// NameSearch()
		// Metoden bruges for at søge på ordrer i Ordreoversigten (Order.cshtml)
		public IEnumerable<Ordre> NameSearch(string str)
		{
			List<Ordre> nameSearch = new List<Ordre>();
			foreach (Ordre item in _items)
			{
				if (item.id.ToString().Contains(str))
				{
					nameSearch.Add(item);
				}
			}

			return nameSearch;
		}

		public Ordre? GetItem(int kundeid)
		{
			foreach (Ordre ordre in _items)
			{
				if (ordre.id == kundeid)
					return ordre;
			}

			return null;
		}

		//UopdateItem

		//Metoden bruges både af EditOrder og UpdateKunde. Vi bruger en liste items med Kunde Objekter, som vi sløjfer gennem. 
		//Hvis ID på den nuværende objekt er lige med ID på den objekt vi har passed, opdateres properties af den nuværende Kunde/Ordre 
		//med den nye værdi brugeren har indtastet.

		//Kun udvalgte properties vises på de individuelle opdaterings sider - som set i EditOrder.cshtml / UpdateKunde.cshtml

		//Når alle værdier er opdateret, bliver de gemt i en JSON fil.

		public void UpdateItem(Ordre item)
		{
			if (item!= null)
			{
				foreach (Ordre i in _items)
				{
					if (i.Kunde.Kundeid == item.Kunde.Kundeid)
					{
						i.Kunde.Navn = item.Kunde.Navn;
						i.Kunde.Alder = item.Kunde.Alder;
						i.Kunde.Telefonnummer = item.Kunde.Telefonnummer;
						i.Kunde.Email = item.Kunde.Email;
						i.Kunde.Adresse = item.Kunde.Adresse;
						i.Kunde.Type = item.Kunde.Type;
						i.Billeder.Pris = item.Billeder.Pris;
						i.Beskrivelse = item.Beskrivelse;
						i.DateTime = item.DateTime;
					}

				}
				JasonFileOrdreService.SaveJsonOrdre(_items);
			}
		}

		public Ordre DeleteItem(int? itemId)
		{
			Ordre kundeSlettes = null;
			foreach (Ordre i in _items)
			{
				if (i.Kunde.Kundeid == itemId)
				{
					kundeSlettes = i;
					break;
				}
			}
			if (kundeSlettes != null)
			{ _items.Remove(kundeSlettes);
				JasonFileOrdreService.SaveJsonOrdre(_items);
			}			
			return kundeSlettes;
		}
		public IEnumerable<Ordre> KundeidSearch(int? kundeid)
		{
			List<Ordre> kundeidSearch = new List<Ordre>();
			foreach (Ordre i in _items)
			{
				if (i.Kunde.Kundeid.ToString().Contains(kundeid.ToString()))
				{
					kundeidSearch.Add(i);
				}
			}

			return kundeidSearch;
		}
		
	}
}
