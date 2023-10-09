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
    [NotMapped]
    public List<Reponse> Reponses { get; set; }
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