using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Semesterprojekt.MockData;
using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
	public class ItemService : IItemService
	{
		private List<Ordre> _items {  get; set; }

		public ItemService()
		{
			_items = MockOrdre.GetMockOrdre();
		}

		public void AddItem(Ordre item)
		{
			_items.Add(item);
		}

		public List<Ordre> GetItems() { return _items; }
	}
}
