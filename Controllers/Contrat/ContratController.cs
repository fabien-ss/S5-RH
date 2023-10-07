using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Embauche;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Contrat;

public class ContratController : Controller{
    
    public IActionResult ContratTravail(){
        ViewData["TypeContrat"] = TypeContrat.ObtenirTypeContrat();
        ViewData["Jours"] = Jour.ObtenirListeJour();
        ViewData["Avantages"] = TypeAvantage.ObtenirTypeAvantage();
        return View();
    }
    [HttpGet("/ContratEssai")]
    public IActionResult ContratEssai(){
        ViewData["TypeSalaire"] = TypeSalaire.ObtenirSalaire();
        ViewData["Jours"] = Jour.ObtenirListeJour();
        ViewData["Avantages"] = TypeAvantage.ObtenirTypeAvantage();
        return View();
    }
    public IActionResult Traitement(ContratEssai contratEssai)
    {
        if (ModelState.IsValid)
        {
            contratEssai.InsertionEssai();
            return RedirectToAction("ContratTravail");
        }
        return RedirectToAction("ContratEssai");
    }
}