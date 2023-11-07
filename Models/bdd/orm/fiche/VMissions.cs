using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm.fiche;
using System.ComponentModel.DataAnnotations.Schema;

[Keyless]
[Table("v_missions")]
public class VMissions
{
    [Column("nom")]
    public string Nom { get; set; }
    [Column("id_fiche_de_poste")]
    public int IdFicheDePoste { get; set; }
    [Column("id_mission")]
    public int IdMission { get; set; }
}
