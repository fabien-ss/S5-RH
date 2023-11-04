using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("employe")]
public class Employe
{
    [Key]
    [Column("id_employe")]
    
    public int IdEmploye { get; set; }
    [Column("id_candidature")]
    public int IdCandidature { get; set; }
   
    [Column("id_superieur")] 
    public int? IdSuperieur { get; set; }
    [NotMapped] 
    public string Matricule { get; set; }

    public List<Employe> GetEmployeByIdSuperior()
    {
        using (var ctx = ApplicationDbContextFactory.Create())
        {
            List<Employe> emps = ctx.Employe.Where(e => e.IdSuperieur == this.IdEmploye).ToList();
            Console.WriteLine(emps.Count+" trouvés");
            foreach (var e in emps)
            {
                Console.WriteLine("Id emp = "+e.IdEmploye);
                e.setMatricule();
            }
            return emps;
        }
    }
    public Employe ObtenirEmployeByIdEmploye()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Employe.Where(e => e.IdEmploye == this.IdEmploye).First();
        }
    }
    public Employe ObtenirEmployeParId()
    {
        using var context = ApplicationDbContextFactory.Create();
        Console.WriteLine(this.IdCandidature);
        return context.Employe.First(e => e.IdCandidature == this.IdCandidature);
    }

    public void setMatricule()
    {
        using (var ctx = ApplicationDbContextFactory.Create())
        {
            try
            {
                this.Matricule = ctx.DetailsEmploye.Where(de => de.IdEmploye == this.IdEmploye).First().Matricule;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}