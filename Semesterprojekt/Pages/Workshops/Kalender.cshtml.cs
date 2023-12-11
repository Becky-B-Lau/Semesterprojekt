using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages.Workshops
{
    public class KalenderModel : PageModel
    {
        private IWorkshopService _workshopService;

        public KalenderModel(IWorkshopService workshopService) //Dependency Injection
        {
            _workshopService = workshopService;
        }

        public List<Models.Workshop> Workshops { get; private set; }

        public void OnGet()
        {
            Workshops = _workshopService.GetWorkshops(); ;
        }

        [BindProperty] public string SearchString { get; set; }
        [BindProperty]
        public int MinPrice { get; set; }

        [BindProperty]
        public int MaxPrice { get; set; }
        public IActionResult OnPostNameSearch()
        {
            Workshops = _workshopService.NameSearch(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostPriceFilter()
        {
            Workshops = _workshopService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }

    }
}
