using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using Question = S5_RH.Models.back.Annonce.Question;
using Diplome = S5_RH.Models.bdd.orm.Diplome;
using Qualification = S5_RH.Models.bdd.orm.Qualification;

namespace S5_RH.Controllers.Annonce;

    public class QuestionnaireController : Controller
    {
        [HttpPost]
        public ActionResult InsertionQuestionnaire()
        {
            
            // id_annonce
            List<Question> questions = new List<Question>();
            var nombreDeQuestion = int.Parse(HttpContext.Request.Form["nombreDeQuestion"]);
            for (int i = 1; i <= nombreDeQuestion; i++)
            {
                var nomQuestion = $"question{i}_question";
                var question = HttpContext.Request.Form[nomQuestion];
                var nomResponse = $"question{i}_reponse[]";
                var responses = HttpContext.Request.Form[nomResponse];
                var validation = $"question{i}_reponse_validation[]";
                var validity = HttpContext.Request.Form[validation];
               
                Question question1 = new Question
                {
                    Quest = question,
                    Reponses = responses,
                    Valeur = validity
                };
                questions.Add(question1);
            }

            NouvelleAnnonce nouvelleAnnonce = JsonSerializer.Deserialize<NouvelleAnnonce>((string)TempData["NouvelleAnnonce"]);
            Qualification qualification = JsonSerializer.Deserialize<Qualification>((string)TempData["Qualification"]);
            nouvelleAnnonce.Sauvegarde(qualification, questions);
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Index()
        { 
            return RedirectToAction("Index", "Home");
        }
    }
