using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.Front.Candidature;

namespace S5_RH.Controllers.Candidature;

public class CandidatureController : Controller
{
    public IActionResult Postuler()
    {
        return View();
    }

    public IActionResult Questionnaire()
    {
        Models.bdd.orm.Question question = new Models.bdd.orm.Question
        {
            IdAnnonce = 1
        };
        List<Models.bdd.orm.Question> questionReponses = question.ObtenirQuestions(); 
        return View(questionReponses);
    }

    public IActionResult TraitementCandidature(CandidatureForm candidature)
    {
        if (ModelState.IsValid)
        {
            Models.bdd.orm.Candidature candidat = new Models.bdd.orm.Candidature();
            Models.bdd.orm.CandidatCv cv = new Models.bdd.orm.CandidatCv();

            // attention mbola tsy misy id_annonce ilay qualif
            candidat.Sauvegarde(candidat);
            TempData.Clear();
        }

        ModelState.AddModelError("Tsy mety e", "Tsy mety eh");
        return RedirectToAction("NouvelleAnnonce");
    }
    
}