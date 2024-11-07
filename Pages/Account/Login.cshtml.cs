using Autenticacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Autenticacion.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public void onGet()
        {
            Console.WriteLine("User: " + User.Email + "Password: " + User.Password);
        }
    }
}
