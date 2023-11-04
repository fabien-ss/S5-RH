using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.Authentification;
using S5_RH.Models.bdd.orm.fiche;
using S5_RH.Models.Login;

namespace S5_RH.Controllers.Login;

public class LoginController : Controller
{
 
    // Generer fiche de poste
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult TraitementLogin()
    {
        string? email = HttpContext.Request.Form["email"];
        string? password = HttpContext.Request.Form["password"];
        Boolean isAuth = Authentification.checkUser(email, password);
        if (isAuth.Equals(true))
        {
            return RedirectToAction("Index","Home");
        }
        return RedirectToAction("Login");
    }

    public IActionResult LoginForPersonnal(LoginForPersonal loginForPersonal)
    {
        if (ModelState.IsValid)
        {
            DetailsEmploye de = new DetailsEmploye { Matricule = loginForPersonal.matricule };
            Console.WriteLine("Matricule = "+de.Matricule);
            de = de.GetEmployeByMatricule();
            if(!de.Equals(null)) return RedirectToAction("ListeDemandeConge","Employe");   
        }
        return View();
    }
}