using System.Diagnostics;
using System.Text.Json;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.Front.Candidature;

namespace S5_RH.Controllers.Candidature;

public class CandidatureController : Controller
{
    public IActionResult DetailsAnnonce(int idAnnonce)
    {
        Models.bdd.orm.Annonce annonce = new Models.bdd.orm.Annonce { IdAnnoce = idAnnonce };
        annonce = annonce.GetAnnonceById();
        ViewData["Annonce"] = annonce;
        return View();
    }
    public IActionResult Postuler(string idAnnonce)
    {
        
        Models.bdd.orm.Annonce annonce = new Models.bdd.orm.Annonce{ IdAnnoce = int.Parse(idAnnonce)}.GetAnnonceById();
        ViewData["Annonce"] = annonce;
        TempData["idAnnonce"] = idAnnonce;
        using (var conte = ApplicationDbContextFactory.Create())
        {
            ViewData["Diplome"] = conte.Diplome.ToList();
            ViewData["Experience"] = conte.Experience.ToList();
            ViewData["Sexe"] = conte.Sexe.ToList();
            ViewData["Situation"] = conte.SituationMatrimoniale.ToList();
            ViewData["Poste"] = conte.Poste.Where(p => p.IdService == annonce.IdService).ToList();
        }
        return View();
    }

    public IActionResult TratementCandidature(CandidatureForm candidatureForm)
    {
        if (ModelState.IsValid)
        {
            TempData["candidatureTemp"] = (candidatureForm);
            return RedirectToAction("Questionnaire");
        }
        return Postuler(((string)TempData["idAnnonce"]));
    }

    public IActionResult Validation()
    {
        PostulerForm postulerForm = JsonSerializer.Deserialize<PostulerForm>((string)TempData["PostulerDetails"]);
        Console.WriteLine("Id annonce = "+postulerForm.IdAnnonce);
        Models.bdd.orm.Question question = new Models.bdd.orm.Question
        {
            IdAnnonce = int.Parse(postulerForm.IdAnnonce) 
        };
        List<Models.bdd.orm.Question> questionReponses = question.ObtenirQuestions();
        foreach (var q in questionReponses)
        {
            q.setUsersResponse(HttpContext);
        }
        double noteqcm = question.Note(questionReponses); 
        double notecv = postulerForm.NoteCv();
        
        postulerForm.insertionCandidature(noteqcm);
        ViewData["Message"] = "Votre candidature a été reçue ! QCM" + noteqcm + ", CV "+notecv;
        return View();
    }
    public IActionResult Questionnaire(PostulerForm postulerForm)
    {
        if (postulerForm.Equals(null))
        {
            postulerForm = JsonSerializer.Deserialize<PostulerForm>((string)TempData["PostulerDetails"]);
        }
        if (ModelState.IsValid)
        {
            TempData["PostulerDetails"] = JsonSerializer.Serialize(postulerForm);
            Console.WriteLine("Id annonce = "+(string)TempData["idAnnonce"]);
            Models.bdd.orm.Question question = new Models.bdd.orm.Question
            {
                IdAnnonce = int.Parse((string)TempData["idAnnonce"]) 
            };
            List<Models.bdd.orm.Question> questionReponses = question.ObtenirQuestions();
            return View(questionReponses);
        }
        return Postuler(((string)TempData["Annonce"]));
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}