using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("type_avantage")]
public class TypeAvantage
{
    [Column("id_avantage")]
    private int IdAvantage { get; set; }
    [Column("nom")]
    private string Nom { get; set; }
}