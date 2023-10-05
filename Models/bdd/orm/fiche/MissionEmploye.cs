using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("mission_emplye")]
public class MissionEmploye{
    [Key]
    [Column("id_fiche_de_poste")]
    int IdFicheDePoste;
    [Column("id_mission")]
    int IdSubordonnee;
}