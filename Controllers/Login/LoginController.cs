using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.Authentification;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.back.Pdf;

namespace S5_RH.Controllers.Pdf;

public class LoginController : Controller
{
 
    // Generer fiche de poste
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult TraitementLogin()
    {
        string email = HttpContext.Request.Form["email"];
        string password = HttpContext.Request.Form["password"];
        Boolean isAuth = Authentification.checkUser(email, password);
        if (isAuth.Equals(true))
        {
            return RedirectToAction("Index","Home");
        }
        return RedirectToAction("Login");
    }
}