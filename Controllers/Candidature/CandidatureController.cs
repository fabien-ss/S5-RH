using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.Front.Candidature;

namespace S5_RH.Controllers.Candidature;

public class CandidatureController : Controller
{
    public IActionResult Postuler(string idAnnonce)
    {
        using (var conte = ApplicationDbContextFactory.Create())
        {
            ViewData["Diplome"] = conte.Diplome.ToList();
            ViewData["Experience"] = conte.Experience.ToList();
            ViewData["Sexe"] = conte.Sexe.ToList();
            ViewData["Situation"] = conte.SituationMatrimoniale.ToList();
        }
        Models.bdd.orm.Annonce annonce = new Models.bdd.orm.Annonce().GetAnnonceById(int.Parse(idAnnonce));
        ViewData["Annonce"] = annonce;
        TempData["Annonce"] = idAnnonce;
        return View();
    }

    public IActionResult TratementCandidature(CandidatureForm candidatureForm)
    {
        if (ModelState.IsValid)
        {
            TempData["candidatureTemp"] = candidatureForm;
            return RedirectToAction("Questionnaire");
        }
        return Postuler(((string)TempData["Annonce"]));
    }
    public IActionResult Questionnaire(CandidatureForm candidatureForm)
    {
        if (ModelState.IsValid)
        {
            Models.bdd.orm.Question question = new Models.bdd.orm.Question
            {
                IdAnnonce = int.Parse((string)TempData["Annonce"]) 
            };
            List<Models.bdd.orm.Question> questionReponses = question.ObtenirQuestions();
            return View(questionReponses);
        }
        return Postuler(((string)TempData["Annonce"]));
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