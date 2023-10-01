using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models;

namespace S5_RH.Controllers.Annonce;

public class AnnonceController : Controller
{
    private readonly ILogger<AnnonceController> _logger;

    public AnnonceController(ILogger<AnnonceController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult NouvelleAnnonce()
    {
        ViewData["students"] = "Nouvelle Annonce";
        return View();
    }
    
    public IActionResult Qualification()
    {
        return View();
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
