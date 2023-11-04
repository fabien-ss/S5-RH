using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Paie;

namespace S5_RH.Controllers.Paie;

public class EtatDePaieController : Controller
{
    public IActionResult EtatDePaie()
    {
        List<EtatDePaie> etat = new EtatDePaie().GetEtatDePaie();
        ViewData["etat_de_paie"] = etat;
        return View();
    }
}