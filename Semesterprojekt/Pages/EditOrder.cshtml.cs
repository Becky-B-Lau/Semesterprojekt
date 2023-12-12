using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Service;

namespace Semesterprojekt.Pages
{
    public class EditOrderModel : PageModel
    {
        private IItemService _itemService;

        public EditOrderModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        [BindProperty]
        public Models.Ordre Item { get; set; }

        public IActionResult OnGet(int id)
        {
            Item = _itemService.GetItem(id);
            if (Item == null)
                return RedirectToPage("/NotFound");

            return Page();

        }

        public IActionResult OnPost() 
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _itemService.UpdateItem(Item);
            return RedirectToPage("Order");
        
        }
    }
}
