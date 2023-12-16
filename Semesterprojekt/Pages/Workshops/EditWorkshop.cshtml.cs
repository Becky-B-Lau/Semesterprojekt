using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Workshops
{
    public class EditWorkshopModel : PageModel
    {
        private IWorkshopService _workshopService;
        public EditWorkshopModel(IWorkshopService workshopService) 
        {
            _workshopService = workshopService;
        }
        [BindProperty]
        public Models.Workshop Workshop { get; set; }

        public IActionResult OnGet(int Id)                      
        {
            Workshop = _workshopService.GetWorkshop(Id);
            if (Workshop == null)  
            { 
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }
            _workshopService.UpdateWorkshop(Workshop);
            return RedirectToPage("Kalender");
        }
    }
}
