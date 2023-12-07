using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Workshops
{
    public class CreateWorkshopModel : PageModel
    {
        private IWorkshopService _workshopService;


        public CreateWorkshopModel(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        [BindProperty]
        public Models.Workshop Workshop { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _workshopService.AddWorkshop(Workshop);
            return RedirectToPage("Kalender");
        }
    }
}
