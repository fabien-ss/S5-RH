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
        Console.WriteLine("498");
        DetailsEmploye detailsEmploye = new DetailsEmploye { Matricule = this.Matricule };
        detailsEmploye = detailsEmploye.GetEmployeByMatricule();
        Console.WriteLine(51);
        DateTime dateDebut = detailsEmploye.DateDebut.AddDays(365);
        Console.WriteLine("Date debut ="+dateDebut);
        DateTime dateDuJour = DateTime.Now;
        TimeSpan reste = dateDuJour - dateDebut;
        // 30 jours par an ny congé
        
        double nombreJourDeTravail = reste.Days;
        Console.WriteLine("Jour total naha mpiasa = "+nombreJourDeTravail + " Timetamp = "+reste + " Date du jour = "+dateDuJour);
        Console.WriteLine(dateDuJour - dateDebut);
        double congeParJour = 0.0833333333333333333333;
        double totalConge = congeParJour * nombreJourDeTravail;
        Console.WriteLine(59);
        double totalCongePris = this.SumOfLastLeave();
        Console.WriteLine(61);
        Console.WriteLine("Total Conge "+totalConge);
        Console.WriteLine("Total Conge Pris "+totalCongePris);
        if (totalCongePris > totalConge) throw new CongeAnneeInvalide("Congé epuisé");
        Console.WriteLine(63);
    }

    public double SumOfLastLeave()
    {
        List<Conge> conges = this.getCongeByMatriculeEmp();
        double date = 0;
        foreach (Conge c in conges)
        {
            if (c.DateFin == null) throw new CongeAnneeInvalide("Cette personne est déjà en congé");
            date += (c.DateDebut - c.DateFin).Value.TotalDays;
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
            Console.WriteLine("Matricule = "+this.Matricule);
            Conge c = context.Conge.FromSqlRaw(sql).ToList().First();
            c.DateFin = this.DateFin;
            Console.WriteLine("Date fin = "+this.DateFin);
            context.Update(c);
            context.SaveChanges();
        }
    }
}