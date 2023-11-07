using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("tache")]
public class Tache
{
    [Key]
    [Column("id_tache")]
    public int IdTache { get; set; }
    [Column("nom")]
    public string Details { get; set; }
    [Column("id_mission")]
    public int IdMission { get; set; }

    public List<Tache> ObtenirTacheByIdMission(int IdMission)
    {
        using (var ctx = ApplicationDbContextFactory.Create())
        {
            return ctx.Taches.Where(t => t.IdMission == IdMission).ToList();
        }
    }
}

