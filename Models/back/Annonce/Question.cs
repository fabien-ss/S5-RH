using S5_RH.Models.bdd.orm;

namespace S5_RH.Models.back.Annonce;
public class Question
{
    public string? Quest { get; set; }
    public string[]? Reponses { get; set; }
    public string[]? Valeur { get; set; }

    public void TraitementInsertionQuestion()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            bdd.orm.Question question = new bdd.orm.Question
            {
                IdAnnonce = 1,
                Fanontaniana = this.Quest
            };
            context.Add(question);
            context.SaveChanges();
            Console.WriteLine("id=" + question.IdQuestion);
            var reponses = this.Reponses;
            if (reponses != null)
                for (int i = 0; i < reponses.Length; i++)
                {
                    Reponse reponse = new Reponse
                    {
                        IdQuestion = question.IdQuestion,
                        Valimpanontaniana = reponses[i],
                        Verite = int.Parse(this.Valeur[i])
                    };
                    context.Add(reponse);
                }

            context.SaveChanges();
        }
    }
}