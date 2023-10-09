namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("v_classement")]
public class Classement
{
  [Key]
  [Column("id_candidature")]
  public int IdCandidature { get; set; }
  [Column("id_annonce")]
  public int IdAnnonce { get; set; }
  [Column("nom")]
  public String Nom { get; set; }
  [Column("prenom")]
  public String Prenom { get; set; }
  [Column("note")]
  public double Note { get; set; }
  [Column("contact")]
  public String Contact { get; set; }

  public List<Classement> ObtenirClassementParIdAnnonce()
  {
   using(var Context=ApplicationDbContextFactory.Create())
   {
       return Context.Classement.
           Where(c => c.IdAnnonce == this.IdAnnonce).ToList();
   }  
  }
}