using System.ComponentModel.DataAnnotations;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Models.back.Embauche;

// modele de liaison
public class ContratTravail : ContratEssai
{
    
    [Required]
    public int IdTypeContrat{ get; set;}
    public void UpdateContrat(int IdCandidature)
    {
        Employe employe = new Employe { IdCandidature = IdCandidature };
        DetailsContrat dc = new DetailsContrat();
        // mise a jour de tous les contrats precedent
        using (var context = ApplicationDbContextFactory.Create())
        {
            employe = context.Employe.Where(e => e.IdCandidature == IdCandidature).First();
            List<DetailsContrat> dts = context.DetailsContrat.Where(d => d.IdEmploye == employe.IdEmploye).ToList();
            foreach (var d in dts)
            {
                d.IdValide = 1;
                d.Matricule = DateDebut.Date + CompleterString(7,d.IdEmploye+""); 
                context.SaveChanges();
            }
           // dc = context.DetailsContrat.Where(d => d.IdEmploye == employe.IdEmploye).First();
           // dc.IdValide = 1;
            //context.SaveChanges();
        }
        // Insertion des details du nouveau contrat
        this.InsertionEssai(IdCandidature, this.IdTypeContrat, 3);
    }

    public static string CompleterString(int TailleFinale, string texte)
    {
        int reste = TailleFinale - texte.Length;
        string zero = "FA";
        for (int i = 0; i < reste; i++)
        {
            zero += "0";
        }
        return zero + texte;
    }
}
