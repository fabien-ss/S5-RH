using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.bdd.orm;

namespace S5_RH.Controllers.Candidature;

public class CandidatureController : Controller
{
    public IActionResult Postuler()
    {
        return View();
    }

    public IActionResult Questionnaire()
    {
        Question question = new Question
        {
            IdAnnonce = 1
        };
        List<Question> questionReponses = question.ObtenirQuestions(); 
        return View(questionReponses);
    }
}