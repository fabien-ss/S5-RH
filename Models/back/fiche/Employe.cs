using System.ComponentModel.DataAnnotations.Schema;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Models.back.fiche;

public class Employe : bdd.orm.fiche.Employe
{
    public Employe Superieur { get; set; }
    public List<bdd.orm.fiche.Employe> Subordonnees { get; set; }
    //public VMissions[] Missions { get; set; }
    [NotMapped]
    public List<VAvantages> Avantages { get; set; }
    [NotMapped]
    public DetailsContrat DetailsContrat { get; set; }

    public void Initializer()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.Superieur = (Employe) context.Employe.First(p => p.IdEmploye == this.IdSuperieur);
            this.Subordonnees = context.Employe.Where(p => p.IdSuperieur == this.IdEmploye).ToList();
            this.Avantages = context.VAvantages.Where(a => a.IdEmploye == this.IdEmploye).ToList();
            this.DetailsContrat =
                context.DetailsContrat.Where(d => d.IdEmploye == this.IdEmploye).First();
            this.DetailsContrat.Initializer();
        }
    }

    public static void Main(string[] args)
    {
        Employe emp = new Employe();
        emp.IdEmploye = 1;
        emp.Initializer();
        Console.WriteLine(emp);
    }
}
