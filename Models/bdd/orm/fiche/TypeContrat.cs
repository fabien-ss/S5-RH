using System.ComponentModel.DataAnnotations.Schema;
namespace S5_RH.Models.bdd.orm.fiche;
[Table("type_contrat")]
public class TypeContrat
{
    [Column("id_contrat")]
    public int IdContrat { get; set; }
    [Column("nom")]
    public string Nom { get; set; }
}