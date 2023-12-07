using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Semesterprojekt.Models;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IItemService _itemService;
      
        [BindProperty]
        public Models.Ordre Ordre { get; set; }
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
         
        }

        
        public IActionResult OnGet()
        {

            return Page();
           
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid) 
            { return Page(); }
            _itemService.AddItem(Ordre);
            return RedirectToPage("Order");
        
        }

    }
}
