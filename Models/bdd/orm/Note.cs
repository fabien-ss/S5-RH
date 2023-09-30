namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("note")]
public class Note {
    [Key]
    [Column("id_candidature")]
    int IdCandidature { get; set;}
    [Column("note")]
    double Valeur { get; set;}
}