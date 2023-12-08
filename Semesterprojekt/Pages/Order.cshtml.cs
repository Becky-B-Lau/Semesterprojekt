using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Semesterprojekt.MockData;
using Semesterprojekt.Service;
using System.Collections.Generic;

namespace Semesterprojekt.Pages
{
	public class OrderModel : PageModel
	{
		[BindProperty]
		public Models.Ordre Ordre { get; set; }
		public Models.Kunde Kunde { get; set; }
		
		//
		[BindProperty] public string SearchString { get; set; }

		private readonly ILogger<OrderModel> _logger;
		private readonly IItemService _itemService;

		public OrderModel(ILogger<OrderModel> logger, IItemService itemService) // Dependency Injection
		{
			_logger = logger;
			_itemService = itemService;
		}

		public List<Models.Ordre>? Items { get; private set; }

		public void OnGet()
		{
			Items = _itemService.GetItems();
		}

		[HttpPost]
		public RedirectToPageResult OnPost()
		{
			// Handle form submission logic here
			// You can redirect to another page if needed
			return RedirectToPage("/Order");
		}

		//
		public IActionResult OnPostNameSearch()
		{
			Items = _itemService.NameSearch(SearchString).ToList();
			return Page();
		}
	}
}
