using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;
using Semesterprojekt.MockData;

namespace Semesterprojekt.Pages.Kunder
{
	public class GetAllKunderModel : PageModel
	{

		private IItemService _itemService;

		public GetAllKunderModel(IItemService itemService) // Dependency Injection
		{
			_itemService = itemService;
		}

		public List<Models.Ordre>? Items { get; private set; }

		public void OnGet()
		{
			Items = _itemService.GetItems();
		}
	}
}
