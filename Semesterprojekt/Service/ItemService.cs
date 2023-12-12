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
        public ItemService()
		{
			_items = MockOrdre.GetMockOrdre();
		}

		public void AddItem(Ordre item)
		{
			_items.Add(item);
            
            item.Kunde.Kundeid = KundeId++;
            item.id = Id++;
        }

		public List<Ordre> GetItems() { return _items; }


		public IEnumerable<Ordre> NameSearch(string str)
		{
			List<Ordre> nameSearch = new List<Ordre>();
			foreach (Ordre item in _items)
			{
				if (item.id.ToString().Contains(str.ToLower()))
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

		public void UpdateOrder(Ordre item)
		{ 
			if (item != null)
			{
				foreach (Ordre? i in _items)
				{
					if (i.id == item.id)
					{
						i.Beskrivelse = item.Beskrivelse;
						i.Billeder.Pris = item.Billeder.Pris;
						i.DateTime = item.DateTime;
					}

					
				}

			}
		
		}

		public void UpdateItem(Ordre kundeid)
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
