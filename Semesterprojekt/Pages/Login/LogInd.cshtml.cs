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
        public static User LoggedInUser { get; set; } = null;
   
        private UserService _userService;


        [BindProperty]
        public string UserName { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public LogIndModel(UserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {

        List<User> users = _userService.users;
            foreach (User user in users)
            {
               
                if (UserName == user.UserName && Password == user.Password)
                {

                    LoggedInUser = user;

                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName) };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Index");

                }

            }


            return Page();
        }
    }
}
