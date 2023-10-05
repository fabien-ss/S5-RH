namespace S5_RH.Models.bdd.orm.fiche;
using System.ComponentModel.DataAnnotations.Schema;

[Table("v_missions")]
public class VMissions
{
    [Column("nom")]
    private string Nom { get; set; }
    [Column("id_fiche_de_poste")]
    private int IdFicheDePoste { get; set; }
    [Column("id_mission")]
    private int IdMission { get; set; }
}
