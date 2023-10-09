using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models;
using S5_RH.Models.back.Annonce;
//using Newtonsoft.Json;  
using System.Text.Json;

namespace S5_RH.Controllers.Annonce;

/**
 * [author] 01kingMaker
 */
public class AnnonceController : Controller
{
    private readonly ILogger<AnnonceController> _logger;

    public AnnonceController(ILogger<AnnonceController> logger)
    {
        _logger = logger;
    }

    public IActionResult AnnulerAnnonce()
    {
        TempData.Clear();
        return NouvelleAnnonce();
    }
    [HttpPost]
    public IActionResult NouvelleAnnonce(NouvelleAnnonce nouvelleAnnonce)
    {
        if (ModelState.IsValid)
        {
            TempData["NouvelleAnnonce"] = JsonSerializer.Serialize(nouvelleAnnonce);
            return RedirectToAction("Qualification", "Annonce");
        }
        ViewData["services"] = nouvelleAnnonce.Services;
        return View(nouvelleAnnonce);
        //return RedirectToAction("NouvelleAnnonce");
    }

    public IActionResult TraitementQualification(QualificationContainer qualification)
    {
        if (ModelState.IsValid)
        {
            Models.bdd.orm.Qualification qualif = 
                qualification.ValidateQualification();
            TempData["Qualification"] = JsonSerializer.Serialize(qualif);
            return RedirectToAction("Questionnaire");
        }
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
