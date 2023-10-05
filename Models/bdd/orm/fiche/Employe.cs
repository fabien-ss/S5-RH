using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("employe")]
public class Employe
{
    [Column("id_employe")]
    private int IdEmploye { get; set; }
    [Column("id_candidature")]
    private int IdCandidature { get; set; }
    [Column("id_details_contrat")]
    private int IdDetailsContrat { get; set; }
    [Column("id_poste")]
    private int IdPoste { get; set; }
    [Column("id_fiche_de_poste")]
    private int IdFicheDePoste { get; set; }
    [Column("id_horaire")]
    private int IdHoraire { get; set; }
    [Column("id_avantage")]
    private int IdAvantage { get; set; }
}