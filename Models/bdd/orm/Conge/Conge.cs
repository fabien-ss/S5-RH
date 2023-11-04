using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace S5_RH.Models.bdd.orm.Conge;
[Table("conge")]
public class Conge{
    [Required(ErrorMessage = "Matricul requis.")]
    [Key]
    [Column("matricule")]
    public string Matricule { get; set; }
    [Column("date_debut")]
    public DateTime DateDebut { get; set; }    
    [Column("date_declaration")]
    public DateTime DateDeclaration { get; set; }    
    [Column("date_fin")]
    public DateTime DateFin { get; set; } 
    
    [Column("details")]
    public string Details { get; set; }
    [Column("id_type_conge")]
    public int IdTypeConge { get; set; }

    public Boolean CheckIfCongeOk()
    {
        
        return false;
    }
    public void insertion()
    {
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
            var sql = $"SELECT * FROM Conge WHERE matricule = '{this.Matricule}' AND date_fin = '-infinity'";
            Console.WriteLine("Matricule = "+this.Matricule);
            Conge c = context.Conge.FromSqlRaw(sql).ToList().First();
            c.DateFin = this.DateFin;
            Console.WriteLine("Date fin = "+this.DateFin);
            context.Update(c);
            context.SaveChanges();
        }
    }
}