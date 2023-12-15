using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Models;
using Semesterprojekt.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System.Data.Common;
using System.Xml.Linq;
using System.Diagnostics;
using System;

namespace Semesterprojekt.Pages.Kunder
{
	public class DeleteKundeModel : PageModel
	{
		private IItemService _itemService;

		//Constructor. IItemService, parameter. itemservice, instance field.
		public DeleteKundeModel(IItemService itemService)
		{
			_itemService = itemService;
		}

		//public Property "Ordre" af typen models.Ordre
		[BindProperty]
		public Models.Ordre Ordre { get; set; }

		//Onget metoden returnerer en kunde, hvis parametret kundeid findes.
		//Hvis det ikke findes, redirecter den til en "NotFound" side.
				public IActionResult OnGet(int kundeid)
		{
			Ordre = _itemService.GetItem(kundeid) ;
			if (Ordre == null)
				return RedirectToPage("/NotFound");
			return Page();
		}

		//OnPost metoden sletter en kunde med det specifikke ID,
		//og den håndtere, hvis kunden ikke kan slettes.
		public IActionResult OnPost(int kundeid)
		{
			Ordre = _itemService.GetItem(kundeid);
			Models.Ordre deleteItem = _itemService.DeleteItem(Ordre.Kunde.Kundeid);
			if (deleteItem == null)
				return RedirectToPage("/NotFound");

			return RedirectToPage("GetAllKunder");
		}
	}
}
