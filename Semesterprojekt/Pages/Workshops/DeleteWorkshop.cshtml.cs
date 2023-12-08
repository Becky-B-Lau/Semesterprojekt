using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Workshops
{
    public class DeleteWorkshopModel : PageModel

    {
        private IWorkshopService _workshopService;
        public DeleteWorkshopModel(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }
        [BindProperty]
        public Models.Workshop Workshop { get; set; }

        public IActionResult OnGet(int id) 
        {
            Workshop = _workshopService.GetWorkshop(id);
            if(Workshop == null) 
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id) 
        {
            Workshop = _workshopService.GetWorkshop(id);
            Models.Workshop deletedWorkshop = _workshopService.DeleteWorkshop(Workshop.WorkshopId);
            if (deletedWorkshop == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("Kalender");
        }
    }
}
