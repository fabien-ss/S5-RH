using System.ComponentModel.DataAnnotations.Schema;

[Table("type_contrat")]
public class TypeContrat
{
    [Column("id_contrat")]
    private int IdContrat { get; set; }
    [Column("nom")]
    private string Nom { get; set; }
}