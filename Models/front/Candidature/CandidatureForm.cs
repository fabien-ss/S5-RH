using System.ComponentModel.DataAnnotations;
using S5_RH.Models.bdd.orm;

namespace S5_RH.Models.Front.Candidature;
public class CandidatureForm
{
    [Required(ErrorMessage = "Nom not set.")]
    private string Nom { get; set; }
    [Required(ErrorMessage = "Prenom not set.")]
    private string Prenom { get; set; }
    [Required(ErrorMessage = "Birth date not set.")]
    private DateTime DateDeNaissance { get; set; }
    [Required(ErrorMessage = "Phone not set.")]
    private string Telephone { get; set; }
    [Required(ErrorMessage = "Motivation letter not set.")]
    private string Motivation { get; set; }
    [Required(ErrorMessage = "Diplome not set.")]
    public string IdDiplome { get; set; }
    [Required(ErrorMessage = "Experience not set.")]
    private string IdExperience { get; set; }
    [Required(ErrorMessage = "Sex not set.")]
    private string IdSexe { get; set; }
    [Required(ErrorMessage = "Matrimonial Situation not set.")]
    private string IdSituationMatrimoniale { get; set; }
    [Required(ErrorMessage = "Hobbies not set.")]
    private string Hobies { get; set; }

    public CandidatureForm(string nom, string prenom, DateTime dateDeNaissance, string telephone, string motivation, string idDiplome, string idExperience, string idSexe, string idSituationMatrimoniale, string hobies) 
    {
        this.Nom = nom;
        this.Prenom = prenom;
        this.DateDeNaissance = dateDeNaissance;
        this.Telephone = telephone;
        this.Motivation = motivation;
        this.IdDiplome = idDiplome;
        this.IdExperience = idExperience;
        this.IdSexe = idSexe;
        this.IdSituationMatrimoniale = idSituationMatrimoniale;
        this.Hobies = hobies;

    }
    public void Sauvegarde()
    {
        /*using (var context = ApplicationDbContextFactory.Create())
        {
            S5_RH.Models.bdd.orm.Candidature candidature = new S5_RH.Models.bdd.orm.Candidature
            {
                Nom = this.Nom,
                Prenom = this.Prenom,
                DateDeNaissance = this.DateDeNaissance,
                
            };
            S5_RH.Models.bdd.orm.CandidatCv cv = new S5_RH.Models.bdd.orm.CandidatCv
            {

            };

            context.Annonce.Add(annonce);
            context.SaveChanges();
            Qualification.IdAnnonce = annonce.IdAnnoce;
            context.Qualification.Add(Qualification);
            context.SaveChanges();
        }*/
    }
    
}