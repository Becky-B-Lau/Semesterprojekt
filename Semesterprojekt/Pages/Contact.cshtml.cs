using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages
{
    public class ContactModel : PageModel
    {
        private IItemService _itemService;

        [BindProperty]
        public Models.Kunde Kunde { get; set; }
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
