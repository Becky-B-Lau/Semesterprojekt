using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Kunder
{
    public class EditKundeModel : PageModel
    {
			private IItemService _itemService;

			public EditKundeModel(IItemService itemService)
			{
				_itemService = itemService;
			}

			[BindProperty]
			public Models.Ordre Ordre { get; set; }

			public IActionResult OnGet(int kundeid)
			{
				Ordre = _itemService.GetItem(kundeid);
				if (Ordre == null)
					return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

				return Page();
			}

			public IActionResult OnPost()
			{
			if (!ModelState.IsValid)
				{
					return Page();
				}

				_itemService.UpdateItem(Ordre.Kunde.Kundeid);
				return RedirectToPage("GetAllItems");
			}
	}
}
