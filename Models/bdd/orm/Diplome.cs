namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("diplome")]
public class Diplome {
    [Key]
    [Column("id_diplome")]
    int IdDiplome { get; set;}
    [Column("details")]
    string? Details { get; set;}
}