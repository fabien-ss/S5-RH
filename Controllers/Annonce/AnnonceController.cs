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

    public IActionResult ListeAnnonce()
    {
        List<Models.bdd.orm.Annonce> annonce = new List<Models.bdd.orm.Annonce>();
        annonce = new Models.bdd.orm.Annonce().ObetnirAnnonce();
        ViewData["Listes"] = annonce;
        return View();
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
            TempData["Qualification"] = JsonSerializer.Serialize(qualif);
            NouvelleAnnonce annonce =
                JsonSerializer.Deserialize<NouvelleAnnonce>((string)TempData["NouvelleAnnonce"]);
            return RedirectToAction("Questionnaire");
        }
        return RedirectToAction("NouvelleAnnonce");
    }
    
    public IActionResult NouvelleAnnonce()
    {
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
    public IActionResult ListeQualification()
    {
        ViewData["qualif"] = new S5_RH.Models.bdd.orm.Qualification().ListAll();
        ViewData["Score"] = new S5_RH.Models.bdd.orm.Qualification().GetScore(1);
        return View();
    }
}
