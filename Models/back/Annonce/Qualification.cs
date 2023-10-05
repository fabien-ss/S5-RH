using S5_RH.Models.bdd.orm;

namespace S5_RH.Models.back.Annonce;
public class Qualification
{
    public List<Diplome> Diplomes { get; set; }
    public List<Experience> Experiences { get; set; }
    public List<Sexe> Sexe { get; set; }
    public List<SituationMatrimoniale> Situation { get; set; }
    public List<Coefficient> Coefficients { get; set; }

    public Qualification()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.Diplomes = context.Diplome.ToList();
            this.Experiences = context.Experience.ToList();
            this.Sexe = context.Sexe.ToList();
            this.Situation = context.SituationMatrimoniale.ToList();
            this.Coefficients = context.Coefficient.ToList();
        }
    }
}
