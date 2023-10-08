using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("mission")]
public class Mission
{
    [Key]
    [Column("id_mission")]
    public int IdMission{ get;set;}
    [Column("nom")]
    public string Libelle{ get;set;}
    [Column("id_poste")]
    public int IdPoste{ get;set;}

    [NotMapped] 
    public List<Tache> Taches { get; set; }

    public Mission()
    {
    }

    public void setTaches()
    {
        Taches = new Tache().ObtenirTacheByIdMission(this.IdMission);
    }
}
