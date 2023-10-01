using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
namespace S5_RH.Controllers.Annonce;

    public class QuestionnaireController : Controller
    {
        [HttpPost]
        public ActionResult InsertionQuestionnaire()
        {
            int nombreDeQuestion = int.Parse(HttpContext.Request.Form["nombreDeQuestion"]);
            for (int i = 1; i <= nombreDeQuestion; i++)
            {
                string NomQuestion = $"question{i}_question";
                string question = HttpContext.Request.Form[NomQuestion];
                string NomReponse = $"question{i}_reponse[]"; 
                string[] reponses = HttpContext.Request.Form[NomReponse];
                string Validation = $"question{i}_reponse_validation[]";
                string[] validite = HttpContext.Request.Form[Validation];
               
                Question Question = new Question
                {
                    Quest = question,
                    Reponses = reponses,
                    Valeur = validite
                };
                Console.WriteLine(Question.Quest);
                Console.WriteLine(Question.Reponses.Length);
                Console.WriteLine(Question.Valeur.Length);
            }
            return RedirectToAction("Index", "Home");
        }
    }
