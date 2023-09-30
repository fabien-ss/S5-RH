namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("candidat_cv")]
public class CandidatCv {
    [Key]
    [Column("id_candidat_cv")]
    int IdCandidatCv { get; set; }
    [Column("id_candidature")]
    int IdCandidature { get; set; }
    [Column("id_diplome")]
    int IdDiplome { get; set; }
    [Column("id_sexe")]
    int IdSexe { get; set; }
    [Column("id_situation_matrimoniale")]
    int IdSituationMatrimoniale { get; set; }
}