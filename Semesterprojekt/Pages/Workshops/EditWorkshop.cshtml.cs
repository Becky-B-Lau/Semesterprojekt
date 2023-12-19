using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Workshops
{
    public class EditWorkshopModel : PageModel
    {
        //Constructor der modtager en IWorkshopService som parameter
        private IWorkshopService _workshopService; //Et instansfild.
        public EditWorkshopModel(IWorkshopService workshopService) //Depndency ijektion //En constuctor.
        {
            _workshopService = workshopService;
        }
        [BindProperty] //Hænger sammen med linjen under og binder de enskaber vi har i Models.Workshop til siden.
        public Models.Workshop Workshop { get; set; }

        public IActionResult OnGet(int Id) //Henter data                      
        {
            Workshop = _workshopService.GetWorkshop(Id); //Henter workshop fra workshopService baseret på det givne id.
            if (Workshop == null) //Sikkre sig at der er et id der matcher
            { 
                return RedirectToPage("/NotFound"); //Hvis den er null, omdirigeres brugeren til siden "NotFound"  
            }
            return Page(); //Ellers bliver brugeren omdirigeres til opdater workshop siden
        }
        public IActionResult OnPost() //Bekræfter en handling, og giver data vidre
        {
            if (!ModelState.IsValid) //Sikkre sig at alle data'er er udfylde
            {
                return Page(); //Omdirigere brugeren til opdater workshop siden
            }
            _workshopService.UpdateWorkshop(Workshop); //Kalder på metoden UpdateWorkshop(Workshop), som den så går igennem før den fortsætter
            return RedirectToPage("Kalender"); //Og omdirigere brugeren tilbage til "Kalender" siden
        }
    }
}
