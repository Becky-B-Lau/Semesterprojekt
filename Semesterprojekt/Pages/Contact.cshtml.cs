using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            
            //PickPrice(Ordre.Pakke);
            return Page();
            
        }

        public IActionResult OnPost() 
        {
           
            if (!ModelState.IsValid) 
            { return Page(); }
            //PickPrice(Ordre.Pakke);
            _itemService.AddItem(Ordre);
            return RedirectToPage("Order");
        
        }






        //public void PickPrice(double pakke)
        //{
        //    switch (Ordre.Pakke)
        //    {
        //        case 1:
        //            Ordre.Billeder.Price = 4000;
        //            break;
        //        case 2:
        //            Ordre.Billeder.Price = 6000;
        //            break;
        //        case 3:
        //            Ordre.Billeder.Price = 2500;
        //            break;
        //        case 4:
        //            Ordre.Billeder.Price = 5000;
        //            break;
        //        case 5:
        //            Ordre.Billeder.Price = 7500;
        //            break;
        //        case 6:
        //            Ordre.Billeder.Price = 20000;
        //            break;
        //    }
        //}


    }
}
