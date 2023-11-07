namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("candidature")]
public class Candidature {
    [Key]
    [Column("id_candidature")]
    public int IdCandidature { get; set; }
    [Column("id_annonce")]
    public int IdAnnonce { get; set; }
    [Column("nom")]
    public string? Nom { get; set; }
    [Column("prenom")]
    public string? Prenom { get; set; }
    [Column("date_de_naissane")]
    public DateTime DateDeNaissance { get; set; }
    [Column("contact")]
    public string? Contact { get; set; }

    [Column("etat")]
    public int Etat { get; set; }

    public Candidature(){}

    public Candidature GetCandidatureById()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Candidature.Where(c => c.IdCandidature == this.IdCandidature).First();
        }
    }
    public List<Candidature> ObtenirListeCandidatureNonValide()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Candidature.
                Where(c => c.Etat == 0)
                .ToList();
        }
    }
    // 1 izy rehefa accepte
    public List<Candidature> ObtenirListeCandidature()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Candidature.
                Where(c => c.Etat == 10)
                .ToList();
        }
    }
    
    // 2 izy en alternance
    public List<Candidature> ObtenirListeAlternance()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Candidature.
                Where(c => c.Etat == 10)
                .ToList();
        }
    }
     // 3 izy voaray
    public List<Candidature> ObtenirListeEmploye()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Candidature.
                Where(c => c.Etat == 30)
                .ToList();
        }
    }
    
    public Candidature ObtenirListeCandidatureById()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Candidature.
                Where(c => c.IdCandidature == this.IdCandidature)
                .First();
        }
    }

    public void InsererCandidature()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            context.Candidature.Add(this);
            context.SaveChanges();
        }
    }
}