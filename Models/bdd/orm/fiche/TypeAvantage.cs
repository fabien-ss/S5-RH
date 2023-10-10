using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("type_avantage")]
public class TypeAvantage
{
    [Key]
    [Column("id_avantage")]
    public int IdAvantage { get; set; }
    [Column("nom")]
    public string Nom { get; set; }

    public static List<TypeAvantage> ObtenirTypeAvantage()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.TypeAvantage.ToList();
        }
    }
}