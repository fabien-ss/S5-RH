using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models;
using S5_RH.Models.back.Annonce;
//using Newtonsoft.Json;  
using System.Text.Json;

namespace S5_RH.Controllers.Annonce;

public class AnnonceController : Controller
{
    private readonly ILogger<AnnonceController> _logger;

    public AnnonceController(ILogger<AnnonceController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult TraitementAnnonce(NouvelleAnnonce nouvelleAnnonce)
    {
        if (ModelState.IsValid)
        {
            TempData["NouvelleAnnonce"] = JsonSerializer.Serialize(nouvelleAnnonce);
            return RedirectToAction("Qualification", "Annonce");
        } 
        return RedirectToAction("NouvelleAnnonce");
    }

    public IActionResult TraitementQualification(QualificationContainer qualification)
    {
        if (ModelState.IsValid)
        {
            Models.bdd.orm.Qualification qualif = qualification.ValidateQualification();
            NouvelleAnnonce annonce =
                JsonSerializer.Deserialize<NouvelleAnnonce>((string)TempData["NouvelleAnnonce"]);
            // attention mbola tsy misy id_annonce ilay qualif
            annonce.Sauvegarde(qualif);
            TempData.Clear();
        }

        ModelState.AddModelError("Tsy mety e", "Tsy mety eh");
        return RedirectToAction("NouvelleAnnonce");
    }
    
    public IActionResult NouvelleAnnonce()
    {
        
        // listes des services
        ViewData["students"] = "Nouvelle Annonce";
        NouvelleAnnonce nouvelleAnnonce = new NouvelleAnnonce();
        ViewData["services"] = nouvelleAnnonce.Services;
        return View();
    }
    
    public IActionResult Qualification()
    {
        Models.back.Annonce.Qualification qualification = new Qualification();
        return View(qualification);
    }
    
    public IActionResult Questionnaire()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
