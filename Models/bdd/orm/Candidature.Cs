namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("candidature")]
public class Candidature {
    [Key]
    [Column("id_candidature")]
    public int IdCandidature { get; set; }
    [Column("id_annonce")]
    public int IdAnnonce { get; set; }
    [Column("nom")]
    public string? Nom { get; set; }
    [Column("prenom")]
    public string? Prenom { get; set; }
    [Column("date_de_naissance")]
    public DateTime DateDeNaissance { get; set; }
    [Column("contact")]
    public string? Contact { get; set; }
}