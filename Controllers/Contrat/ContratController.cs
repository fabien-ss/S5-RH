using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Embauche;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Contrat;

public class ContratController : Controller{
    
    public IActionResult ContratTravail(){
        ViewData["TypeContrat"] = TypeContrat.ObtenirTypeContrat();
       //
        ViewData["Jours"] = Jour.ObtenirListeJour();
        ViewData["Avantages"] = TypeAvantage.ObtenirTypeAvantage();
        return View();
    }
    public IActionResult ContratEssai(int id)
    {
        ViewData["TypeSalaire"] = TypeSalaire.ObtenirSalaire();
        ViewData["Jours"] = Jour.ObtenirListeJour();
        ViewData["Avantages"] = TypeAvantage.ObtenirTypeAvantage();
        ViewData["TypeContrat"] = TypeContrat.ObtenirTypeContrat();

        ViewData["Candidat"] = new Models.bdd.orm.Candidature
        {
            IdCandidature = id
        }.ObtenirListeCandidatureById();
        TempData["IdCandidat"] = id;
        return View();
    }
    public IActionResult Traitement(ContratEssai contratEssai)
    {
        if (ModelState.IsValid)
        {
            object? currentId = TempData["IdCandidat"];
            contratEssai.InsertionEssai((int)currentId);
            return RedirectToAction("ContratTravail");
        }
        return RedirectToAction("ContratEssai");
    }
}