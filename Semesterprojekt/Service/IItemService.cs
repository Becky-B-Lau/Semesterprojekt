using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
	public interface IItemService
	{
		//
		IEnumerable<Ordre> NameSearch(string str);

		List<Ordre> GetItems();
		void AddItem(Ordre item);
		void UpdateItem(Ordre item);
		Ordre GetItem(int id);
		Ordre DeleteItem(int? itemId);
	}
}
}
