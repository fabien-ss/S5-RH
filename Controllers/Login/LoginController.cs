using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.Authentification;
using S5_RH.Models.bdd.orm.fiche;
using S5_RH.Models.Login;

namespace S5_RH.Controllers.Login;

public class LoginController : Controller
{
 
    // Generer fiche de poste
    public IActionResult Login(Models.Login.LoginForm loginForm)
    {
        if (ModelState.IsValid)
        {
            Boolean isAuth = Authentification.checkUser(loginForm.Email, loginForm.Password);
            if (isAuth.Equals(true))
            {
                return RedirectToAction("Index", "Home");
            }
        }
        return View();
    }

    public IActionResult LoginForPersonnal(LoginForPersonalForm loginForPersonalForm)
    {
        if (ModelState.IsValid)
        {
            DetailsEmploye de = new DetailsEmploye { Matricule = loginForPersonalForm.matricule };
            de = de.GetEmployeByMatricule();
            TempData["matricule"] = de.Matricule;
            if(!de.Equals(null)) return RedirectToAction("ListeDemandeConge","Employe");   
        }
        return View();
    }
}