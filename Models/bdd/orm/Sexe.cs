namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("sexe")]
public class Sexe {
    [Key]
    [Column("id_sexe")]
    int IdSexe { get; set;}
    [Column("details")]
    string? Details { get; set;}
}