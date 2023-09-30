namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("candidature")]
public class Candidature {
    [Key]
    [Column("id_candidature")]
    int IdCandidature { get; set; }
    [Column("id_annonce")]
    int IdAnnonce { get; set; }
    [Column("nom")]
    string? Nom { get; set; }
    [Column("prenom")]
    string? Prenom { get; set; }
    [Column("date_de_naissance")]
    TimestampAttribute? DateDeNaissance { get; set; }
    [Column("contact")]
    string? Contact { get; set; }
}