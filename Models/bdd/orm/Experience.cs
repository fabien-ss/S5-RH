namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("experience")]
public class Experience {
    [Key]
    [Column("id_experience")]
    public int IdExperience { get; set;}
    [Column("details")]
    public string? Details { get; set;}
}