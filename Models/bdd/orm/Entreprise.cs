using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm;
[Table("entreprise")]
public class Entreprise
{
    [Key]
    [Column("nom")]
    public string nom { get; set; }
    [Column("date_de_creation")]
    public DateTime DateDeCreation { get; set; }
    [Column("siege")]
    public string Siege { get; set; }
    [Column("numero_fiscal")]
    public string Fiscale { get; set; }
    [Column("logo")]
    public string Logo { get; set; }
    [Column("description")]
    public string Description { get; set; }
    public Entreprise ObtenirEntreprise()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Entreprise.First();
        }
    }
}

