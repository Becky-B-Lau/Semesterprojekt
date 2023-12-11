using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

		[BindProperty] 
		public Models.Ordre Ordre { get; set; }

		public IActionResult OnGet(int kundeid)
		{
			Ordre = _itemService.GetItem(kundeid) ;
			if (Ordre == null)
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return Page();
		}

		public IActionResult OnPost(int kundeid)
		{
			Ordre = _itemService.GetItem(kundeid);
			Models.Ordre deletedItem = _itemService.DeleteItem(Ordre.Kunde.Kundeid);
			if (deletedItem == null)
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return RedirectToPage("GetAllKunder");
		}
	}
}
