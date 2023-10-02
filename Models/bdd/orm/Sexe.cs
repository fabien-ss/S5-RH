namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("sexe")]
public class Sexe {
    [Key]
    [Column("id_sexe")]
    public int IdSexe { get; set;}
    [Column("details")]
    public string? Details { get; set;}
}