using Autenticacion.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Autenticacion.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

       /* public void OnPost() 
        {
			Console.WriteLine("User: " + User.Email + " Password: " + User.Password);
		}*/
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page(); 

            if (User.Email == "Correo@gmail.com" && User.Password == "Andres")
            { 
                // Creacion de Claims, Datos a almacenar en las Cookies
                var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name,"admin"),
                    new Claim (ClaimTypes.Email,User.Email),
                };
                //Se asocian los Claims a una Cookie
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                //Se agreaga la identidad a la Claimprincipal de la aplicacion
                ClaimsPrincipal claimsPrincipal= new ClaimsPrincipal(identity);
                // se registra bien y se crea la Cookie en el navegador
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
