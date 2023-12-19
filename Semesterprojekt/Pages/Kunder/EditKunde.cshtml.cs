using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Models;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Kunder
{
    public class EditKundeModel : PageModel
    {
			private IItemService _itemService;

        //Constructor. IItemService, parameter. itemservice, instance field.
        public EditKundeModel(IItemService itemService)
			{
				_itemService = itemService;
			}
        //public Property "Ordre" af Klassen ordre

        [BindProperty]
			public Models.Ordre Ordre { get; set; }

			//int kundeid = parameter
			//Kalder metoden GetItem i _itemservice med kundeid og returnerer tilbage til siden
			//hvis kundeid'et er null, returnerer den en notfound side
			public IActionResult OnGet(int kundeid)
			{
				Ordre = _itemService.GetItem(kundeid);
				if (Ordre == null)
					return RedirectToPage("/NotFound");

				return Page();
			}

		//Metoden GetKundeid finder kundeid propertien inde i kunden inde i ordren
		public int GetKundeid()
		{
			return Ordre.Kunde.Kundeid;
		}

		//Onpost metoden bruges til at opdatere kunden. Hvis kravene ikke er opfyldt, returnerer den til siden
		//	Hvis kravene er opfyldt, går den videre hen i UpdateItem i itemservice og laver foreach loop, gemmer 
		//	oplysningerne i Json filen, og går tilbage til siden med listen af kunder
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
}
