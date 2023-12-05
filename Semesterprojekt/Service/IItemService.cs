using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
	public interface IItemService
	{
		List<Ordre> GetItems();
		void AddItem(Ordre item);
	}
}
