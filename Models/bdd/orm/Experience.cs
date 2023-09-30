namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("experience")]
public class Experience {
    [Key]
    [Column("id_experience")]
    int IdExperience { get; set;}
    [Column("details")]
    string? Details { get; set;}
}