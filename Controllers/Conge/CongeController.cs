using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.Front.Candidature;

namespace S5_RH.Controllers.Candidature;

public class CongeController : Controller
{
    public IActionResult AfficheEmploye()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
    public IActionResult InsertionConge()
    {
        return View();
    }

    public IActionResult ListePersonneConge()
    {
        return View();
    }

    public IActionResult RechercheEmploye()
    {
        return View();
    }
    public IActionResult Validation()
    {
        return View();
    }
    /*public IActionResult TraitementCandidature(CandidatureForm candidature)
    {
        if (ModelState.IsValid)
        {
            Models.bdd.orm.Candidature candidat = new Models.bdd.orm.Candidature();
            Models.bdd.orm.CandidatCv cv = new Models.bdd.orm.CandidatCv();

            // attention mbola tsy misy id_annonce ilay qualif
         //   candidat.Sauvegarde(candidat);
            TempData.Clear();
        }

        ModelState.AddModelError("Tsy mety e", "Tsy mety eh");
        return RedirectToAction("NouvelleAnnonce");
    }*/
    
}