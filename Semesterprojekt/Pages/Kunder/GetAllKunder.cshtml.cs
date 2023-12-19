using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;
using Semesterprojekt.MockData;
using Semesterprojekt.Models;
using System.Dynamic;

namespace Semesterprojekt.Pages.Kunder
{
	public class GetAllKunderModel : PageModel
	{

		private IItemService _itemService;

		//Constructor. IItemService, parameter. itemservice, instance field.
		public GetAllKunderModel(IItemService itemService) // Dependency Injection
		{
			_itemService = itemService;
		}
		//Liste af ordrer = Items
		public List<Models.Ordre>? Items { get; private set; }

		//OnGet metoden henter data fra GetItems metoden i _itemservice
		public void OnGet()
		{
			Items = _itemService.GetItems();
		}

		[BindProperty] public int KundeidSearch { get; set; }

		//Onpost metoder gør, så man kan søge efter en kunde med kundeid
		public IActionResult OnPostKundeidSearch()
		{
			Items = _itemService.KundeidSearch(KundeidSearch).ToList();
			return Page();
		}
	}
}
