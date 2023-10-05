namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("qualification")]
public class Qualification {
    [Key]
    [Column("id_qualification")]
    public int IdQualification { get; set;}
    [Column("id_annonce")]
    public int IdAnnonce { get; set; }
    [Column("dimplome")]
    public string? Diplome { get; set;}
    [Column("experience")]
    public string? Experience { get; set;}
    [Column("sexe")]
    public string? Sexe { get; set;}
    [Column("situation_matrimoniale")]
    public string? SituationMatrimoniale { get; set;}
}