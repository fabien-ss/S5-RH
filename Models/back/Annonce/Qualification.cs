using S5_RH.Models.bdd.orm;

namespace S5_RH.Models.back.Annonce;
public class Qualification
{
    public List<Diplome> Diplomes { get; set; }
    public List<Experience> Experiences { get; set; }
    public List<Sexe> Sexe { get; set; }
    public List<SituationMatrimoniale> Situation { get; set; }
    public List<string> Coefficient { get; set; }

    public Qualification()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.Diplomes = context.Diplome.ToList();
            this.Experiences = context.Experience.ToList();
            this.Sexe = context.Sexe.ToList();
            this.Situation = context.SituationMatrimoniale.ToList();
        }
        
    }
}

public class QualificationContainer
{
    private string[] DiplomeId { get; set; }
    private string[] CoefficientDiplome { get; set; }
    private string[] ExperienceId { get; set; }
    private string[] CoefficientExperience { get; set; }
    private string[] SexeId { get; set; }
    private string[] SituationId { get; set; }
    private string[] CoefficientSituation { get; set; }

    public void ValidateQualification()
    {
        
    }
}