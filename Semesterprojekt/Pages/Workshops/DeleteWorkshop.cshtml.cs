using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Workshops
{
    public class DeleteWorkshopModel : PageModel

    {
        // Constructor modtager en IWorkshopService som parameter
        private IWorkshopService _workshopService; //instansfild
        public DeleteWorkshopModel(IWorkshopService workshopService) //Depndency ijektion //constuctor
        {
            _workshopService = workshopService;
        }
        /// <summary>
        /// dependency injektion = designmønstre som bruges til at håndtere forskellige afhængiheder mellem klasser
        /// dependensy injektion referer til en teknik hvor objekter for deres afhængiheder udefra istedet som fx fra IWorkshopService i dette tilfælde
        /// </summary>
        [BindProperty] //binder de eenskaber som vi har defineret inde i Models.workshoper attaced med lindjen uder bindsproperty //property
        public Models.Workshop Workshop { get; set; }

        public IActionResult OnGet(int id)  // OnGet-metoden, der håndterer HTTP GET-anmodningen
        {
            Workshop = _workshopService.GetWorkshop(id); // Henter workshop fra workshopService baseret på det givne id
            if (Workshop == null) 
            {
                return RedirectToPage("/NotFound"); // Hvis den ønskede workshop ikke findes, omdirigeres brugeren til NotFound-siden
            }
            return Page(); // Hvis alt går godt, returnerer den siden for sletning af workshop
        }
        /// <summary>
        ///  ført angiver vi hvad det er vi skal lave hvilket er en OnGet metode hvor vi skal bruge workshoppens id
        ///  da vi går igang henter vi først workshppen fra GetWorkshop som ligger i WorkshopService
        ///  hvis workshoppen ikke kan findes aka hvis den er null kommer vi til "notfound"(tilbage til siden)
        ///  hvis den bliver fundet kommer vi til vores "vil du slette" siden
        /// </summary>

        public IActionResult OnPost(int id) // OnPost-metoden, der håndterer HTTP POST-anmodningen (når brugeren bekræfter sletning)
        {
            Workshop = _workshopService.GetWorkshop(id); // Henter workshop fra workshopService baseret på det givne id
            Models.Workshop deletedWorkshop = _workshopService.DeleteWorkshop(Workshop.WorkshopId); // Sletter workshop fra workshopService og gemmer den slettede workshop i en variabel

            if (deletedWorkshop == null)
            {
                return RedirectToPage("/NotFound"); // Hvis den slettede workshop ikke findes, omdirigeres brugeren til NotFound-siden
            }
            return RedirectToPage("Kalender"); // Hvis sletningen lykkes, omdirigeres brugeren til Kalender-siden
        }
        /// <summary>
        /// først angiver vi at det er en OnPost metode hvilket betyder at der skal foretages en action/handling, 
        /// i dette tilfælde at workshoppen skal slettet, som OnPost skal forsøge at gøre via det givende id
        /// Workshop henter den workshop på id'et som skal slettet nede fra GetWorkshop i workshopservice
        /// og der efter sletter den givene workshop og gmmer den som variable for at tjekke at den eksistere som vi tjekker i vores (if)
        /// hvis den slettede workshop ikke findes kommer vi til "notfound" og hvis den bliver slettet succesfully kommer vi tilbage til kaldender
        /// </summary>
    }
}
