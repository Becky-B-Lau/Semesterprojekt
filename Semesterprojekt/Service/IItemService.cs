using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
	public interface IItemService
	{
		//
		IEnumerable<Ordre> NameSearch(string str);

		List<Ordre> GetItems();
		void AddItem(Ordre item);
		void UpdateItem(Ordre kundeid);

		void UpdateOrder(Ordre kundeid);
		public Ordre? GetItem(int kundeid);
		public Ordre DeleteItem(int? itemId);
	}
}
