using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.bdd.orm.Conge;
using S5_RH.Models.bdd.orm.fiche;

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
    // Update Base
    public DbSet<DetailsContrat> DetailsContrat { get; set; }
    public DbSet<Employe> Employe { get; set; }
    public DbSet<Horaire> Horaire { get; set; }
    public DbSet<TypeAvantage> TypeAvantage { get; set; }
    public DbSet<TypeContrat> TypeContrat { get; set; }
    public DbSet<VAvantages> VAvantages { get; set; }
    public DbSet<VMissions> VMissions { get; set; }
    public DbSet<Salaire> Salaire { get; set; }
    public DbSet<Jour> Jour { get; set; }
    public DbSet<TypeSalaire> TypeSalaire { get; set; }
    public DbSet<Avantage> Avantage { get; set; }
    public DbSet<Mission> Mission { get; set; }
    public DbSet<VEmploye> VEmploye { get; set; }
    public DbSet<DetailsEmploye> DetailsEmploye { get; set; }
    public DbSet<VHorraire> VHorraires { get; set; }
    public DbSet<Tache> Taches { get; set; }
    public DbSet<Entreprise> Entreprise { get; set; }
    public DbSet<TypeConge> TypeConges { get; set; }
    public DbSet<Conge> Conge { get; set; }
    public DbSet<Classement> Classement { get; set; }
    public DbSet<ListePersonneConge> ListePersonneConges { get; set; }
    public DbSet<EmployeService> EmployeServices { get; set; }
}