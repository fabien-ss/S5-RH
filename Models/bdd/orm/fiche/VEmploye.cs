using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("v_employe")]
public class VEmploye
{
    [Key]
    [Column("id_employe")]
    public int IdEmploye { get; set; }
    [Column("id_candidature")]
    public int IdCandidature { get; set; }
   
    [Column("id_superieur")] 
    public int? IdSuperieur { get; set; }
    [Column("nom")]
    public string Nom { get; set; }
    [Column("prenom")]
    public string Prenom { get; set; }
    [Column("details")]
    public string Poste { get; set; }
    [Column("etat")]
    public int Etat { get; set; }

    public List<VEmploye> ObtenirListeEmploye()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.VEmploye.ToList();
        }
    }
    
    public List<VEmploye> ObtenirListeAlternance()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.VEmploye.ToList();
        }
    }
   // andidats = new Models.bdd.orm.Candidature().ObtenirListeAlternance();
   // Candidats = new Models.bdd.orm.Candidature().ObtenirListeEmploye();
}