using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Semesterprojekt.Pages.Login
{
    public class LogUdModel : PageModel
    {


        //async den kan g�r det i baggrund og ikke blokere hovedtr�den (det er den som er ansvarlig for at k�re vores applikations logik).
        //hvis vi g�r uden async kan hovedtr�den bliver inaktiv indtil den er f�rdig hvilket g�r at programmet kan virke frosset eller ikke reagerer fordi den venter p� at den er f�rdig.

        //Task<IActionResult> g�r ude p� at Task viser at den skal returnerer en opgave af type IActionResult.
        public async Task<IActionResult> OnGet()
        {
            LogIndModel.LoggedInUser = null; //LoggedInUser bliver sat til null.

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); //HttpContext.SignOutAsync: den logger en ude ved at slette authentication cookie. og CookieAuthenticationDefaults.AuthenticationScheme: fort�ller hvad der er brugt til at godkende hvilket er cookie-baseret
            return RedirectToPage("/index"); //G�r at n�r man logget ind vil man blive sendt hen til forside.
        }
    }
}
