using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Embauche;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Contrat;

public class EmployeController : Controller{

    // Obtenir la liste des candidats admis
    public IActionResult ListeAdmis()
    {
        List<Models.bdd.orm.Candidature> Candidats = new List<Models.bdd.orm.Candidature>();
        Candidats = new Models.bdd.orm.Candidature().ObtenirListeCandidature();
        ViewData["ListeCandidature"] = Candidats;
        return View();
    }
    // Obtenir la liste des candidats
    public IActionResult ListeCandidat()
    {
        List<Models.bdd.orm.Candidature> Candidats = new List<Models.bdd.orm.Candidature>();
        Candidats = new Models.bdd.orm.Candidature().ObtenirListeCandidatureNonValide();
        ViewData["ListeCandidature"] = Candidats;
        return View();
    }
    // Obtenir la liste des personnes en aternance
    public IActionResult ListeAlternance()
    {
        List<Models.bdd.orm.Candidature> Candidats = new List<Models.bdd.orm.Candidature>();
        Candidats = new Models.bdd.orm.Candidature().ObtenirListeAlternance();
        ViewData["ListeEmploye"] = Candidats;
        return View();
    }
    // Obtenir la liste des employes
    public IActionResult ListeEmploye()
    {
        List<Models.bdd.orm.Candidature> Candidats = new List<Models.bdd.orm.Candidature>();
        Candidats = new Models.bdd.orm.Candidature().ObtenirListeEmploye();
        ViewData["ListeEmploye"] = Candidats;
        return View();
    }
}