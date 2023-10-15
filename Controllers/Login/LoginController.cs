using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.back.Pdf;

namespace S5_RH.Controllers.Pdf;

public class LoginController : Controller
{
 
    // Generer fiche de poste
    public IActionResult Login()
    {
        return View();
    }
}