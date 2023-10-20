using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [Column("date_retour")]
    public DateTime DateRetour { get; set; } 
    [Column("details")]
    public string Details { get; set; }
    [Column("id_type_conge")]
    public int IdTypeConge { get; set; }

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
            Conge c = context.Conge.Where(c => c.Matricule == this.Matricule & c.DateFin == null).First();
            c.DateFin = this.DateFin;
            c.update();
            context.SaveChanges();
        }
    }
}