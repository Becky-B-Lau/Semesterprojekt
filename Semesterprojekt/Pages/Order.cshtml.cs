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
		// Her instanteres en Ordre og en Kunde Klasse. Med hjælp af [BindProperty] attribute mapper vi værdier 
		// fra HTTP request som en PageModel property. I dette tilfælde sker det, når en ordre oprettes.
		[BindProperty]
		public Models.Ordre Ordre { get; set; }
		public Models.Kunde Kunde { get; set; }
		
		
		//Her mappes værdien som indtastes i Søgefunktionen på vores Ordreoversigt Side (Order.cshtml)
		[BindProperty] public string SearchString { get; set; }

		//_logger er en slags tool som bruges for at logge beskeder. Logging behavior er konfiguret i Program.cs
		//_itemService er en instans af vores Interface IItemService.cs. Instansen bruges længere ned til at anvende metoder relateret til Ordrer
		//fx. for at hente data, opdater ordre informationer eller søge på ordrer
		private readonly ILogger<OrderModel> _logger;
		private readonly IItemService _itemService;


		//Konstruktøren er brugt for Dependency Injection, dvs. at når vi opretter en instans af OrderModel Klassen,
		//tillader parameterne logger og itemService os at bruge metoder som er defineret i IItemService.cs /  ILogger Service
		//Ved at bruge dependency injection behøver ikke at lave ændringer direkte her i OrderModel Klassen. På den måde overholder vi Separation of Concerns.
		public OrderModel(ILogger<OrderModel> logger, IItemService itemService) 
		{
			_logger = logger;
			_itemService = itemService;
		}

		//Vi instansierer en read-only liste kaldt Items
		//Når OnGet() metoden kaldes (som er defineret i ItemService.cs), returnerer vi en liste med ordrer og gemmer dem i Items
		public List<Models.Ordre>? Items { get; private set; }

		public void OnGet()
		{
			Items = _itemService.GetItems();
		}

		//Binding Property gør at OnPost() metoden håndterer HTTP post requests
		//Når den kaldes, bliver brugeren omdirigeret til /Order siden (vores Ordre Oversigt)
		[HttpPost]
		public RedirectToPageResult OnPost()
		{
			return RedirectToPage("/Order");
		}

		//Metoden bruges decideret til at søge på Ordre
		//OnPost prefix gør at metoden håndterer HTTP post requests når man klikker på "Search" i Søgefunktionen
		//I starten kaldte vi metoden for NameSearch men vi søger faktisk på Ordre ID ikke Kundens Navn
		
		public IActionResult OnPostNameSearch()
		{
			Items = _itemService.NameSearch(SearchString).ToList(); //vores returnerede object fra IItemService skal laves om til en liste 
			return Page(); // nødvendig at returnere siden vi er på for at opdater den så vores søgeresultet vises
		}

		
		
	}
}
