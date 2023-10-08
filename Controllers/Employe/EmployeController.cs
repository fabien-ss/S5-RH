using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Embauche;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Contrat;

public class EmployeController : Controller{

    public IActionResult ListeAdmis()
    {
        List<Models.bdd.orm.Candidature> Candidats = new List<Models.bdd.orm.Candidature>();
        Candidats = new Models.bdd.orm.Candidature().ObtenirListeCandidature();
        ViewData["ListeCandidature"] = Candidats;
        return View();
    }
    public IActionResult ListeCandidat()
    {
        List<Models.bdd.orm.Candidature> Candidats = new List<Models.bdd.orm.Candidature>();
        Candidats = new Models.bdd.orm.Candidature().ObtenirListeCandidatureNonValide();
        ViewData["ListeCandidature"] = Candidats;
        return View();
    }
    public IActionResult ListeAlternance()
    {
        List<Models.bdd.orm.Candidature> Candidats = new List<Models.bdd.orm.Candidature>();
        Candidats = new Models.bdd.orm.Candidature().ObtenirListeAlternance();
        ViewData["ListeEmploye"] = Candidats;
        return View();
    }
    public IActionResult ListeEmploye()
    {
        List<Models.bdd.orm.Candidature> Candidats = new List<Models.bdd.orm.Candidature>();
       // andidats = new Models.bdd.orm.Candidature().ObtenirListeAlternance();
        Candidats = new Models.bdd.orm.Candidature().ObtenirListeEmploye();
        ViewData["ListeEmploye"] = Candidats;
        return View();
    }
}