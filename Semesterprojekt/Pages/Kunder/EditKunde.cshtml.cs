using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Models;
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

			public IActionResult OnGet(int Id)
			{
				Ordre = _itemService.GetItem(Id);
				if (Ordre == null)
					return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

				return Page();
			}

		public int GetKundeid()
		{
			return Ordre.Kunde.Kundeid;
		}

		public IActionResult OnPost()

			{
            if (!ModelState.IsValid)
			{
				return Page();
			}
			_itemService.UpdateItem(Ordre);
			return RedirectToPage("GetAllKunder");

	}
}
