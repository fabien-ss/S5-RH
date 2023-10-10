using System.ComponentModel.DataAnnotations;

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

    // public void Sauvegarde(Models.bdd.orm.Qualification Qualification)
    // {
    //     using (var context = ApplicationDbContextFactory.Create())
    //     {
    //         bdd.orm.Annonce annonce = new bdd.orm.Annonce
    //         {
    //             IdService = this.IdServices,
    //             Debut = this.Debut,
    //             Fin = this.Fin,
    //             Details = this.Description
    //         };
    //         context.Annonce.Add(annonce);
    //         context.SaveChanges();
    //         Qualification.IdAnnonce = annonce.IdAnnoce;
    //         context.Qualification.Add(Qualification);
    //         context.SaveChanges();
    //     }
    // }
    
}