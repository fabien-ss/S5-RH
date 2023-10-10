namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("poste")]
public class Poste {
    [Key]
    [Column("id_poste")]
    public int IdPoste { get; set;}
    [Column("id_service")]
    public int IdService { get; set;}
    [Column("details")]
    public string? Details { get; set;}
    [NotMapped]
    public List<S5_RH.Models.bdd.orm.fiche.Mission> Missions { get; set; }

    public void setMission()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.Missions = context.Mission.Where(m => m.IdPoste == this.IdPoste).ToList();
        }
    }
}