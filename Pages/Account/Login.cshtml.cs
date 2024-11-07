using Autenticacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Autenticacion.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        /*public void OnPost() 
        {
			Console.WriteLine("User: " + User.Email + " Password: " + User.Password);
		}*/
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (User.Email == "Correo@gmail.com" && User.Password == "Andres")
            { 
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
