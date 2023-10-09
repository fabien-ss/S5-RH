using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models;
//using Newtonsoft.Json;  
using System.Text.Json;

namespace S5_RH.Controllers.Classement;

public class ClassementController : Controller
{
    private readonly ILogger<ClassementController> _logger;

    public ClassementController(ILogger<ClassementController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult TraitementClassement()
    {
        if (ModelState.IsValid)
        {
            
        } 
        return RedirectToAction();
    }
  
    public IActionResult Classement(String IdAnnonce)
    {
        int idAnnonce = int.Parse(IdAnnonce);
        Models.bdd.orm.Classement classement = new Models.bdd.orm.Classement
        {
            IdAnnonce = idAnnonce
        };
        List < Models.bdd.orm.Classement > classements = classement.ObtenirClassementParIdAnnonce();
        ViewData["classements"] = classements;
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult ListeAnnonce()
    {
        List<Models.bdd.orm.Annonce> listeAnnonces =Models.bdd.orm.Annonce.ObtenirTous();
        ViewData["listeannonces"] = listeAnnonces;
        return View();
    }
}
