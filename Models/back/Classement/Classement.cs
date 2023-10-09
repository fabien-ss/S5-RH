namespace S5_RH.Models.back.Annonce.Classement;

public class Classement
{
    public List<bdd.orm.Annonce> ListeAnnonce { get; set; }
    public List<Models.bdd.orm.Classement> ListeClassements { get; set; }

    public Classement()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            ListeAnnonce = context.Annonce.ToList();
            ListeClassements = new List<bdd.orm.Classement>();
        }
    }
}