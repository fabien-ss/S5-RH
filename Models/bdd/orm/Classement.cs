using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm;

[Keyless]
[Table("v_classement")]
public class Classement
{
    [Column("notec")]
    public double Note{ get; set; }
    [Column("nom")]
    public string Nom{ get; set; }
    [Column("id_candidature")]
    public int IdCandidature { get; set; }
    [Column("id_annonce")]
    public int IdAnnonce { get; set; }

    public List<Classement> obtenirClassementParAnnonce()
    {
        using (var c = ApplicationDbContextFactory.Create())
        {
            return c.Classement.Where(c => c.IdAnnonce == this.IdAnnonce).ToList();
        }
    }
}

