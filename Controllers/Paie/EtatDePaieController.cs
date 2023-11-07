using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Paie;
using S5_RH.Models.front.HeureSup;

namespace S5_RH.Controllers.Paie;

public class EtatDePaieController : Controller
{
    public IActionResult EtatDePaie(HeureSup heureSup)
    {
        EtatDePaie etatDePaie = new EtatDePaie();
        DateTime dateJour = DateTime.Now;
        if (ModelState.IsValid)
        {
            dateJour = heureSup.DateEtat;
        }
        etatDePaie.Date = dateJour;
        List<EtatDePaie> etat = etatDePaie.GetEtatDePaie();
        foreach (var VARIABLE in etat)
        {
            VARIABLE.Date = etatDePaie.Date;
        }
        ViewData["etat_de_paie"] = etat;
        return View();
    }
}