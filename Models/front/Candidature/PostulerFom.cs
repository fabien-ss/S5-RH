using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.Front.Candidature;

public class PostulerForm
{
    [Required(ErrorMessage = "Nom not set.")]
    public string Nom{ get; set;}
    [Required(ErrorMessage = "Prenom not set.")]
    public string Prenom{ get; set;}
    [Required(ErrorMessage = "Date de naissance.")]
    public DateTime DateDeNaissace{ get; set;}
    [Required(ErrorMessage = "Telephone.")]
    public string Telephone{ get; set;}
    [Required(ErrorMessage = "Motivation.")]
    public string? Motivation{ get; set;}
    public int IdDiplome{ get; set;}
    public int IdExperience{ get; set;}
    public int IdSexe{ get; set;}
    public int IdSituationMatrimoniale{ get; set;}
    public string Hobies{ get; set;}
    
    
}