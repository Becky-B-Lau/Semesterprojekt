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
		// Her instanteres en Ordre og en Kunde Klasse. Med hj�lp af [BindProperty] attribute mapper vi v�rdier 
		// fra HTTP request som en PageModel property. I dette tilf�lde sker det, n�r en ordre oprettes.
		[BindProperty]
		public Models.Ordre Ordre { get; set; }
		public Models.Kunde Kunde { get; set; }
		
		
		//Her mappes v�rdien som indtastes i S�gefunktionen p� vores Ordreoversigt Side (Order.cshtml)
		[BindProperty] public string SearchString { get; set; }

		//_logger er en slags tool som bruges for at logge beskeder. Logging behavior er konfiguret i Program.cs
		//_itemService er en instans af vores Interface IItemService.cs. Instansen bruges l�ngere ned til at anvende metoder relateret til Ordrer
		//fx. for at hente data, opdater ordre informationer eller s�ge p� ordrer
		private readonly ILogger<OrderModel> _logger;
		private readonly IItemService _itemService;


		//Konstrukt�ren er brugt for Dependency Injection, dvs. at n�r vi opretter en instans af OrderModel Klassen,
		//tillader parameterne logger og itemService os at bruge metoder som er defineret i IItemService.cs /  ILogger Service
		//Ved at bruge dependency injection beh�ver ikke at lave �ndringer direkte her i OrderModel Klassen. P� den m�de overholder vi Separation of Concerns.
		public OrderModel(ILogger<OrderModel> logger, IItemService itemService) 
		{
			_logger = logger;
			_itemService = itemService;
		}

		//Vi instansierer en read-only liste kaldt Items
		//N�r OnGet() metoden kaldes (som er defineret i ItemService.cs), returnerer vi en liste med ordrer og gemmer dem i Items
		public List<Models.Ordre>? Items { get; private set; }

		public void OnGet()
		{
			Items = _itemService.GetItems();
		}

		//Binding Property g�r at OnPost() metoden h�ndterer HTTP post requests
		//N�r den kaldes, bliver brugeren omdirigeret til /Order siden (vores Ordre Oversigt)
		[HttpPost]
		public RedirectToPageResult OnPost()
		{
			return RedirectToPage("/Order");
		}

		//Metoden bruges decideret til at s�ge p� Ordre
		//OnPost prefix g�r at metoden h�ndterer HTTP post requests n�r man klikker p� "Search" i S�gefunktionen
		//I starten kaldte vi metoden for NameSearch men vi s�ger faktisk p� Ordre ID ikke Kundens Navn
		
		public IActionResult OnPostNameSearch()
		{
			Items = _itemService.NameSearch(SearchString).ToList(); //vores returnerede object fra IItemService skal laves om til en liste 
			return Page(); // n�dvendig at returnere siden vi er p� for at opdater den s� vores s�geresultet vises
		}

		
		
	}
}
