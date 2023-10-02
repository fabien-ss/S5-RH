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

public class QualificationContainer
{
    public string[] DiplomeId { get; set; }
    public string[] CoefficientDiplome { get; set; }
    public string[] ExperienceId { get; set; }
    public string[] CoefficientExperience { get; set; }
    public string[] SexeId { get; set; }
    public string[] CoefficientSexe { get; set; }
    public string[] SituationId { get; set; }
    public string[] CoefficientSituation { get; set; }
    
    public S5_RH.Models.bdd.orm.Qualification ValidateQualification()
    {
        string coefficientExperience = "";
        string coefficientSexe = "";
        string coefficientSituation = "";
        string coefficientDiplome = "";
        for (int i = 0; i < this.DiplomeId.Length; i++)
        {
            coefficientDiplome = coefficientDiplome + this.DiplomeId[i] + "=" + this.CoefficientDiplome[i] + ";"; 
        }
        for (int i = 0; i < this.SituationId.Length; i++)
        {
            coefficientSituation = coefficientSituation + this.SituationId[i] + "=" + this.CoefficientSituation[i] + ";"; 
        }
        for (int i = 0; i < this.ExperienceId.Length; i++)
        {
            coefficientExperience = coefficientExperience +  this.ExperienceId[i] + "=" + this.CoefficientExperience[i] + ";"; 
        }
        for (int i = 0; i < this.SexeId.Length; i++)
        {
            coefficientSexe = coefficientSexe + this.SexeId[i] + "=" + this.CoefficientSexe[i] + ";";
        }

        S5_RH.Models.bdd.orm.Qualification CritereDeSelection = new bdd.orm.Qualification
        {
            Diplome = coefficientDiplome,
            Experience = coefficientExperience,
            Sexe = coefficientSexe,
            SituationMatrimoniale = coefficientSituation
        };
        return CritereDeSelection;
    }
}