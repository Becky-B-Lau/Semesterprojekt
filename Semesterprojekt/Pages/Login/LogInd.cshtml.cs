using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semesterprojekt.Models;
using Semesterprojekt.Service;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Semesterprojekt.Pages.Login
{
    public class LogIndModel : PageModel
    {
        //En static property som referere til en User der er logget ind
        public static User LoggedInUser { get; set; } = null;

        //instance field:
        private UserService _userService;

        //[BindProperty] bliver brugt når vi skal binde egenskab noget til data under modelbinding. og DataType(DataType.Password) bliver brugt når vi skal binde til et bestemt egenskab
        //som i dette tilfælde er adgangskoden.
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }


        //Constructor indeholder parameterne itemService af typen IItemService.
        public LogIndModel(UserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        //async den kan gør det i baggrund og ikke blokere hovedtråden (det er den som er ansvarlig for at køre vores applikations logik).
        //hvis vi gør uden async kan hovedtråden bliver inaktiv indtil den er færdig hvilket gør at programmet kan virke frosset eller ikke reagerer fordi den venter på at den er færdig.

        //Task<IActionResult> går ude på at Task viser at den skal returnerer en opgave af type IActionResult.
        public async Task<IActionResult> OnPost()
        {

            List<User> users = _userService.users; //Opretter en list af bruger som henter listen af bruger i _userService.users
            foreach (User user in users) //foreach loop som går i gennem den liste af bruger 
            {

                if (UserName == user.UserName && Password == user.Password) //Hvis brugernavnet (angivet af kunde) og er det sammen som brugernavet i listen + adgangskode (angivet af kunde) som er det sammen som adgangskode i listen.
                {

                    LoggedInUser = user; //hvis den finder et match i loopet gennems bruger i LoggedInUser.

                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName) }; 

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    //fra var claims (l.54) til new ClaimsPrincipal(claimsIdentity)); (l. 57): Programmet oprette en brugeridentitet og udføre autentificering.
                    return RedirectToPage("/Index"); //Gør at når man logget ind vil man blive sendt hen til forside.

                }

            }

            return Page(); //Ellers vil man return til siden igen hvis programmet ikke kan finde en bruger i listen.
        }
    }
}
    
