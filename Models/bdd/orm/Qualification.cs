namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("qualification")]
public class Qualification {
    [Key]
    [Column("id_qualification")]
    int IdQualification { get; set;}
    [Column("id_annonce")]
    int IdAnnonce { get; set; }
    [Column("dimplome")]
    string? Diplome { get; set;}
    [Column("experience")]
    string? Experience { get; set;}
    [Column("sexe")]
    string? Sexe { get; set;}
    [Column("situation_matrimoniale")]
    string? SituationMatrimoniale { get; set;}
}