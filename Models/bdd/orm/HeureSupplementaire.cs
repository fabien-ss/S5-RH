using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iTextSharp.text;

namespace S5_RH.Models.bdd.orm;

[Table(("heure_supplementaire"))]
public class HeureSupplementaire
{
    [Column("matricule")]
    public string Matricule{ get;set;}
    [Column("datedebut")]
    public DateTime DateDebut{ get;set;}
    [Column("datefin")]
    public DateTime DateFin{ get;set;}
    [Column("mois")]
    public int Mois{ get;set;}
    [Column("annee")]
    public int Annee{ get;set;}
    [Key]
    [Column("id_heure_supplementaire")]
    public int IdHeureSup{ get;set;}
    [NotMapped]
    public float TotalHours { get; set; }

    public void insertHeureSup()
    {
        this.Mois = this.DateDebut.Month;
        this.Annee = this.DateDebut.Year;
        using (var ctx = ApplicationDbContextFactory.Create())
        {
            ctx.HeureSupplementaires.Add(this);
            ctx.SaveChanges();
        }
    }

    public double getTotalHours()
    {
        float retour = 0;
        List<HeureSupplementaire> heureSupplementaires = this.getAllSuplementHours();
        foreach (var hs in heureSupplementaires)
        {
            Console.WriteLine("Duration :  " + (hs.DateFin - hs.DateDebut).Hours+ "Date debut"+hs.DateDebut + " for "+hs.Matricule );
            retour += (hs.DateFin - hs.DateDebut).Hours;
        }
        Console.WriteLine("Total "+retour);
        return retour;
    }

    public List<HeureSupplementaire> getAllSuplementHours()
    {
        List<HeureSupplementaire> heureSupplementaires;
        using (var ctx = ApplicationDbContextFactory.Create())
        {
            heureSupplementaires = ctx.HeureSupplementaires.Where(
                hs => hs.Mois == this.Mois &
                      hs.Annee == this.Annee & hs.Matricule == this.Matricule
            ).ToList();
        }
        Console.WriteLine("Emp "+this.Matricule+" ");
        return heureSupplementaires;
    }
}