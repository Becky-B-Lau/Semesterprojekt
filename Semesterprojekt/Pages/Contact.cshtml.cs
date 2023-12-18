using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Semesterprojekt.Models;
using Semesterprojekt.Service;
using System.Runtime.ConstrainedExecution;

namespace Semesterprojekt.Pages
{
    public class ContactModel : PageModel
    {

		//instance field:

		private readonly IItemService _itemService;
        private readonly ILogger<ContactModel> _logger;

		//Property som vi binder til (pga. [BindProperty]) UI'en (html-siden). Det g�r vi for at data kan overf�res fra
		//inputfields i UI'en til Ordre-properties.
		[BindProperty]
        public Models.Ordre Ordre { get; set; }

        

		//Constructor indeholder parameterne itemService og logger af typen IItemService og ILogger<ContactModel>. 
		public ContactModel(ILogger<ContactModel> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
         
        }

		//OnGet metoden: return til siden
		public IActionResult OnGet()
        {

            return Page();
           
        }

        //OnPost metoden: hvis man ikke har indsat i forhold til kravene s� vil man return til siden
        //igen ellers vil den g�r inden i itemservice og tilf�jet objekte til Json derefter vil
        //man return til index siden (forsiden)
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid) 
            { return Page(); }
            _itemService.AddItem(Ordre);
            return RedirectToPage("Index");
        
        }

    }
}
