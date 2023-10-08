using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Models.back.Embauche;
// modele de liaison
public class ContratEssai
{
    [Required(ErrorMessage = "Candidate.")]
    public int IdCandidature;
    
    [Required(ErrorMessage = "Type salaire requis.")]
    public string TypeSalaire { get; set; } 
    
    [Required(ErrorMessage = "Salaire requis.")]
    public double Renumeration { get; set; }
    
    [Required(ErrorMessage = "Durée requis.")]
    public int DureeContrat { get; set; }
    
    [Required(ErrorMessage = "Date début requis.")]
    public DateTime DateDebut { get; set; }
    
    [Required(ErrorMessage = "Horaire requis.")]
    public string HoraireEntree { get; set; }
    
    [Required(ErrorMessage = "Horaire requis.")]
    public string HoraireSortie { get; set; }

    [Required(ErrorMessage = "Selectionnez les jours de travail.")]
    public string[] JourDeTravail { get; set; }
    [Required(ErrorMessage = "l")]
    public string[] Avantage { get; set; }

    
    public void InsertionEssai(int IdCandidature)
    {
        //Console.WriteLine("The candidature id = " + this.IdCandidature);
        this.IdCandidature = IdCandidature;
        
        Employe employe = new Employe { IdCandidature = this.IdCandidature };
        DetailsContrat detailsContrat = new DetailsContrat { DateDebut = this.DateDebut, DateFin = this.DateDebut.AddMonths(this.DureeContrat), IdTypeContrat = 1, Matricule = "None" };
        Salaire salaire = new Salaire
        { DateSalaire = DateTime.Now, Renumeration = this.Renumeration, IdTypeSalaire =  int.Parse(this.TypeSalaire) };
        List<Horaire> horaires = new List<Horaire>();
        foreach (var VARIABLE in JourDeTravail) { Horaire horaire = new Horaire { Sortie = this.HoraireSortie, Entree = this.HoraireSortie, IdJour = int.Parse(VARIABLE) }; horaires.Add(horaire); }
        List<Avantage> avantages = new List<Avantage>();
        foreach (var VARIABLE in Avantage)
        { Avantage avantage = new Avantage { IdAvantage = int.Parse(VARIABLE) }; avantages.Add(avantage); }
        using (var context = ApplicationDbContextFactory.Create())
        { context.Employe.Add(employe); context.SaveChanges(); detailsContrat.IdEmploye = employe.IdEmploye; context.DetailsContrat.Add(detailsContrat); context.SaveChanges(); salaire.IdContrat = detailsContrat.IdDetailsContrat; context.Salaire.Add(salaire); context.SaveChanges();
            foreach (var VARIABLE in Avantage)
            {
                Avantage avantage = new Avantage { IdAvantage = int.Parse(VARIABLE), IdEmploye = employe.IdEmploye };
                context.Avantage.Add(avantage);
                context.SaveChanges();
            }
            foreach (var VARIABLE in JourDeTravail)
            {
                Horaire horaire = new Horaire
                {
                    IdContrat = detailsContrat.IdDetailsContrat,
                    IdJour = int.Parse(VARIABLE),
                    Entree = HoraireEntree,
                    Sortie = HoraireSortie
                };
                context.Horaire.Add(horaire);
                context.SaveChanges();
            }

            Candidature candidature = context.Candidature.Where(c => c.IdCandidature == (this.IdCandidature)).First();
            candidature.Etat = 2;
            context.Candidature.Update(candidature);
            context.SaveChanges();
        }
    }
}
