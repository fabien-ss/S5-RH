using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.Conge;
[Table("type_conge")]
public class TypeConge{
    [Key]
    [Column("id_type_conge")]
    public int IdTypeConge { get; set; }
    [Column("libelle")]
    public string Libelle { get; set; }    
    public  List<TypeConge> ObtenirTypeConges()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.TypeConges.ToList();
        }
    }
}