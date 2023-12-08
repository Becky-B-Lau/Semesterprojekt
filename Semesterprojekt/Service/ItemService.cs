using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Semesterprojekt.MockData;
using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
	public class ItemService : IItemService
	{
		public List<Ordre> _items { get; set; }

		public ItemService()
		{
			_items = MockOrdre.GetMockOrdre();
		}

		public void AddItem(Ordre item)
		{
			_items.Add(item);
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

		public Ordre GetItem(int kundeid)
		{
			foreach (Ordre ordre in _items)
			{
				if (ordre.Kunde.Kundeid == kundeid)
					return ordre;
			}

			return null;
		}

		public void UpdateItem(Ordre item)
		{
			if (item != null)
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
					}
				}
			}
		}

		public Ordre DeleteItem(int? itemId)
		{
			foreach (Ordre i in _items)
			{
				if (i.Kunde.Kundeid == itemId)
				{
					_items.Remove(i);
					return i;
				}
			}
			return null;
		}
	}
}
