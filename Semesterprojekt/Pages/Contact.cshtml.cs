using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Semesterprojekt.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Models.Kunde Kunde { get; set; }
        [BindProperty]
        public Models.Ordre Ordre { get; set; }
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
