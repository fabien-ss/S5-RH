namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("situation_matrimoniale")]
public class SituationMatrimoniale {
    [Key]
    [Column("id_situation_matrimoniale")]
    int IdSituationMatrimoniale { get; set; }
    [Column("details")]
    string? Details { get; set; }
}