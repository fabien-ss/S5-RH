using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.back.Embauche;

// modele de liaison
public class ContratTravail
{
    [Required(ErrorMessage = "Salary not set.")]
    public double Salaire {get; set;}
    [Required(ErrorMessage = "")]
    public string TypeSalaire {get; set;}
    public string TypeContrat {get; set;}
    public string[] Avantages {get; set;}
}
