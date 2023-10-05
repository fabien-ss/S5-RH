using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using S5_RH.Models.bdd.orm;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Test> Test { get; set; }
    public DbSet<Annonce> Annonce { get; set; }
    public DbSet<Diplome> Diplome { get; set; }
    public DbSet<Experience> Experience { get; set; }
    public DbSet<Poste> Poste { get; set; }
    public DbSet<Qualification> Qualification { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Reponse> Reponse { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<Sexe> Sexe { get; set; }
    public DbSet<SituationMatrimoniale> SituationMatrimoniale { get; set; }
    public DbSet<Note> Note { get; set; }
    public DbSet<CandidatCv> CandidatCv { get; set; }
    public DbSet<Candidature> Candidature { get; set; }
    public DbSet<Coefficient> Coefficient { get; set; }
    // ...
}