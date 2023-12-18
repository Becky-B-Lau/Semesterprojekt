using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Semesterprojekt.Pages.Login
{
    public class LogUdModel : PageModel
    {


        //async den kan gør det i baggrund og ikke blokere hovedtråden (det er den som er ansvarlig for at køre vores applikations logik).
        //hvis vi gør uden async kan hovedtråden bliver inaktiv indtil den er færdig hvilket gør at programmet kan virke frosset eller ikke reagerer fordi den venter på at den er færdig.

        //Task<IActionResult> går ude på at Task viser at den skal returnerer en opgave af type IActionResult.
        public async Task<IActionResult> OnGet()
        {
            LogIndModel.LoggedInUser = null; //LoggedInUser bliver sat til null.

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); //HttpContext.SignOutAsync: den logger en ude ved at slette authentication cookie. og CookieAuthenticationDefaults.AuthenticationScheme: fortæller hvad der er brugt til at godkende hvilket er cookie-baseret
            return RedirectToPage("/index"); //Gør at når man logget ind vil man blive sendt hen til forside.
        }
    }
}
