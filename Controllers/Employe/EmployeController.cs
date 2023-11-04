using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.bdd.orm.Conge;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Employe;

public class EmployeController : Controller{

    // Obtenir la liste des candidats admis
    public IActionResult ListeDemandeConge()
    {
        string matricule = "FA0000008";
        DetailsEmploye detailsEmploye = new DetailsEmploye { Matricule = matricule };
        Console.WriteLine("Matricule controller employe = "+detailsEmploye.Matricule);
        detailsEmploye = detailsEmploye.GetEmployeByMatricule();
        Models.bdd.orm.fiche.Employe employe = new Models.bdd.orm.fiche.Employe
            { IdEmploye = detailsEmploye.IdEmploye };
        employe = employe.ObtenirEmployeByIdEmploye();
        // ici on a l'id du superieur
        List<Models.bdd.orm.fiche.Employe> subordonnees = employe.GetEmployeByIdSuperior();
        List<Conge> conges = new Conge().ListeConge(subordonnees);
        ViewData["conges"] = conges;
        return View();
    }
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

    public IActionResult ListeDetailsParEmploye()
    {
        ViewData["employe"] = new DetailsEmploye().ObtenirTousLesEmployes();
        return View();
    }
    
}