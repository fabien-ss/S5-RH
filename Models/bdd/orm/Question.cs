using iTextSharp.text;
using S5_RH.Models.Front.Candidature;

namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 [Table("question")]
public class Question {
    [Key]
    [Column("id_question")]
    public int IdQuestion { get; set;}
    [Column("question")]
    public string? Fanontaniana { get; set;}
    [Column("id_annonce")]
    public int IdAnnonce { get; set; }
    [Column("point")]
    public int Point { get; set;}
    [NotMapped]
    public List<Reponse> Reponses { get; set; }

    // ajouter les reponses de l'utilisateur
    public void setUsersResponse(HttpContext context)
    {
        foreach (var r in this.Reponses)
        {
            r.setUserReponse(context);
        }
    }

    public Boolean isRightAnswer()
    {
        foreach (var V in this.Reponses)
        {
            if (V.Verite != V.UserReponse)
            {
                return false;
            }
        }
        return true;
    }
    // fonction pour valider la note
    public double Note(List<Question> questions)
    {
        double note = 0;
        foreach (var q in questions)
        {
            Boolean isRight = q.isRightAnswer();
            if (isRight)
            {
                note += q.Point;
            }
        }
        return note;
    }
    public List<Question> ObtenirQuestions()
    {
        List<Question> questions;
        using (var context = ApplicationDbContextFactory.Create())
        {
            questions = context.Question
                .Where(q => q.IdAnnonce == this.IdAnnonce).ToList();
            foreach (var q in questions)
            {
                Reponse rep = new Reponse { IdQuestion = q.IdQuestion };
                q.Reponses = rep.GetReponseByIdQuestion();
            }
        }
        return questions;
    }

    public Dictionary<Question, List<Reponse>> ObtenirQuestionAvecReponse()
    {
        Dictionary<Question, List<Reponse>> QuestionReponse = new Dictionary<Question, List<Reponse>>();
        using (var context = ApplicationDbContextFactory.Create())
        {
            List<Question> questions = context.Question
                .Where(q => q.IdAnnonce == this.IdAnnonce).ToList();
            foreach (var q in questions)
            {
                Reponse rep = new Reponse { IdQuestion = q.IdQuestion };
                QuestionReponse.Add(q, context.Reponse.Where(r => r.IdQuestion == rep.IdQuestion).ToList());
               // q.Reponses = rep.GetReponseByIdQuestion();
            }
        }
        return QuestionReponse;
    }
}