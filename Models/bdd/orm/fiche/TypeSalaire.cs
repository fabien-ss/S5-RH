using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("type_salaire")]
public class TypeSalaire{
    [Key]
    [Column("id_type_salaire")]
    public int IdTypeSalaire { get; set; }
    [Column("nom")]
    public string Nom { get; set; }    
    public static List<TypeSalaire> ObtenirSalaire()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.TypeSalaire.ToList();
        }
    }
}