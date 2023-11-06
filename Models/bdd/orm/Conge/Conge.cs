using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using S5_RH.Models.bdd.orm.fiche;
using S5_RH.Models.Exception;

namespace S5_RH.Models.bdd.orm.Conge;

[Table("conge")]
public class Conge{
    
    [Column("matricule")]
    [Required(ErrorMessage = "Matricul requis.")]
    public string Matricule { get; set; }
    [Column("date_debut")]
    [Required(ErrorMessage = "Date debut requis")]
    public DateTime DateDebut { get; set; }    
    [Column("date_declaration")]
    public DateTime DateDeclaration { get; set; }    
    [Column("date_fin")]
    public DateTime? DateFin { get; set; } 
    [Column("details")]
    [Required(ErrorMessage = "Details requis")]
    public string? Details { get; set; }
    [Column("id_type_conge")]
    public int IdTypeConge { get; set; }
    [Column("validation")]
    public int Validation { get; set; }
    [Key]
    [Column("id_conge")]
    public int IdConge { get; set; }

    public void insererHeureSup()
    {
        
    }
    public void ValiderConge()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            Conge c = context.Conge.Where(c => c.IdConge == this.IdConge & c.DateFin == null).First();
            c.Validation = 10;
            context.Update(c);
            context.SaveChanges();
        }   
    }
    public List<Conge> ListeConge(List<Employe> emps)
    {
        Console.WriteLine("Ce type a "+emps.Count+" subordonnees");
        using (var ctx = ApplicationDbContextFactory.Create())
        {
            List<Conge> retour = new List<Conge>();
            foreach (var e in emps)
            {
                try
                {
                    Conge c = ctx.Conge.Where(c => c.Matricule == e.Matricule & c.DateFin == null & c.Validation == 0).First();
                    retour.Add(c);
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception);
                }
            }
            return retour;
        }
    }
    public void TraitementValidationConge()
    {
        Console.WriteLine("matricule = "+this.Matricule);
        this.CheckIfCongeOk();
        this.CheckIfThereIsRestLeave();
    }
    public void CheckIfCongeOk()
    {
        DetailsEmploye detailsEmploye = new DetailsEmploye { Matricule = this.Matricule };
        detailsEmploye = detailsEmploye.GetEmployeByMatricule();
        DateTime dateDebut = detailsEmploye.DateDebut;
        TimeSpan difference = DateTime.Now - dateDebut;
        if (difference.TotalDays < 365) throw new CongeAnneeInvalide("Contrat trop récent");
    }

    public void CheckIfThereIsRestLeave()
    {
        DetailsEmploye detailsEmploye = new DetailsEmploye { Matricule = this.Matricule };
        detailsEmploye = detailsEmploye.GetEmployeByMatricule();
        DateTime dateDebut = detailsEmploye.DateDebut.AddDays(365);
        DateTime dateDuJour = DateTime.Now;
        TimeSpan reste = dateDuJour - dateDebut;
        double nombreJourDeTravail = reste.Days;
        double congeParJour = 0.0833333333333333333333;
        double totalConge = congeParJour * nombreJourDeTravail;
        double totalCongePris = this.SumOfLastLeave();
        if (totalCongePris > totalConge) throw new CongeAnneeInvalide("Congé epuisé");
    }

    public double SumOfLastLeave()
    {
        List<Conge> conges = this.getCongeByMatriculeEmp();
        double date = 0;
        foreach (Conge c in conges)
        {
            if (c.DateFin == null) throw new CongeAnneeInvalide("Cette personne est déjà en congé");
            if (c.IdTypeConge.Equals(4))
            {
                date += (c.DateDebut - c.DateFin).Value.TotalDays;
            }
        }
        return date;
    }

    public List<Conge> getCongeByMatriculeEmp()
    {
        using (var ctx = ApplicationDbContextFactory.Create())
        {
            return ctx.Conge.Where(c => c.Matricule == this.Matricule).ToList();
        }
    }
    
    public void insertion()
    {
        this.TraitementValidationConge();
        this.DateFin = null;
        Console.WriteLine("Details du conge "+this.Details);
        using (var context = ApplicationDbContextFactory.Create())
        {
            context.Conge.Add(this);
            context.SaveChanges();
        }
    }

    public void update()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            var sql = $"SELECT * FROM Conge WHERE matricule = '{this.Matricule}' AND date_fin is null";
            Conge c = context.Conge.FromSqlRaw(sql).ToList().First();
            c.DateFin = DateTime.Now;
            context.Update(c);
            context.SaveChanges();
        }
    }
}