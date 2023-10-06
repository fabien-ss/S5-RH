using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("type_avantage")]
public class TypeAvantage
{
    [Column("id_avantage")]
    public int IdAvantage { get; set; }
    [Column("nom")]
    public string Nom { get; set; }
}