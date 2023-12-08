using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Models;
using Semesterprojekt.MockData;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Kunder

{
	public class DeleteKundeModel : PageModel
	{
		private IItemService _itemService;

		public DeleteKundeModel(IItemService itemService)
		{
			_itemService = itemService;
		}

		//	[BindProperty]
		//	public Models.Kunde Kunde { get; set; }


		//	public IActionResult OnGet(int id)
		//	{
		//		Kunde = _itemService.Kunde(id);
		//		if (Item == null)
		//			return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

		//		return Page();
		//	}

		//	public IActionResult OnPost()
		//	{
		//		Models.Item deletedItem = _itemService.DeleteItem(Item.Id);
		//		if (deletedItem == null)
		//			return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

		//		return RedirectToPage("GetAllItems");
		//	}
		//}
	}
}
