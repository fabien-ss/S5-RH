using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("type_salaire")]
public class TypeSalaire{
    [Key]
    [Column("id_type_salaire")]
    private int IdTypeSalaire { get; set; }
    [Column("nom")]
    private string Nom { get; set; }    
}