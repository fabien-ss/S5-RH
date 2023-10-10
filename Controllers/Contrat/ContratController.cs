using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Embauche;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Contrat;

public class ContratController : Controller{
    
    public IActionResult ContratTravail(string? IdCandidature)
    {
        ViewData["TypeContrat"] = TypeContrat.ObtenirTypeContrat();
        ViewData["Jours"] = Jour.ObtenirListeJour();
        ViewData["Avantages"] = TypeAvantage.ObtenirTypeAvantage();
        TempData["IdCandidature"] = IdCandidature;
        ViewData["TypeSalaire"] = TypeSalaire.ObtenirSalaire();
        return View();
    }

    public IActionResult TraitementRenouvellement(ContratTravail contratTravail)
    {
        if (ModelState.IsValid)
        {
            int IdCandidature = int.Parse((string)TempData["IdCandidature"]);
            contratTravail.UpdateContrat(IdCandidature);
            Console.WriteLine(contratTravail.DureeContrat);   
        }
        return RedirectToAction("ContratTravail");
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
            contratEssai.InsertionEssai((int)currentId, 1, 2);
            return RedirectToAction("ContratTravail");
        }
        return RedirectToAction("ContratEssai");
    }
}