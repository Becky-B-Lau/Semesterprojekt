using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Semesterprojekt.MockData;
using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
	public class ItemService : IItemService
	{
		public List<Ordre> _items { get; set; }
		public static int Id { get; set; } //
		public static int nextId = 2; //


		public ItemService()
		{
			_items = MockOrdre.GetMockOrdre();
		}

		public void AddItem(Ordre item)
		{
			_items.Add(item);

			item.id = nextId++; //
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
		{
			if (kundeid != null)
			{
				foreach (Ordre i in _items)
				{
					if (i.Kunde.Kundeid == kundeid.Kunde.Kundeid)
					{
						i.Kunde.Navn = kundeid.Kunde.Navn;
						i.Kunde.Alder = kundeid.Kunde.Alder;
						i.Kunde.Telefonnummer = kundeid.Kunde.Telefonnummer;
						i.Kunde.Email = kundeid.Kunde.Email;
						i.Kunde.Adresse = kundeid.Kunde.Adresse;
						i.Kunde.Type = kundeid.Kunde.Type;
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
	}
}
