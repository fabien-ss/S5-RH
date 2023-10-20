namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("annonce")]
public class Annonce {
    [Key]
    [Column("id_annonce")]
    public int IdAnnoce { get; set; }
    [Column("id_service")]
    public int IdService { get; set; }
    [Column("debut")]
    public DateTime? Debut { get; set; }
    [Column("fin")]
    public DateTime? Fin { get; set;}
    [Column("details")]
    public string? Details { get; set; }

    public Annonce GetAnnonceById()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            Annonce retour = context.Annonce.Where(a => a.IdAnnoce == this.IdAnnoce).First();
            return retour; //context.Annonce.Where(a => a.IdAnnoce == this.IdAnnoce).First();
        }
    }

    public List<Annonce> ObetnirAnnonce()
    {
        using (var conte = ApplicationDbContextFactory.Create())
        {
            return conte.Annonce.ToList();
        }
    }
}