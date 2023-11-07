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
    public int IdPoste { get; set; }
    [Required]
    public int IdSuperieur { get; set; }
    // Insertion des donnees 
    public void InsertionEssai(int IdCandidature, int IdContrat, int etat, Boolean isEmp)
    {
        this.IdCandidature = IdCandidature;
        Employe employe = new Employe { IdCandidature = this.IdCandidature, IdSuperieur = this.IdSuperieur};
        DetailsContrat detailsContrat = new DetailsContrat { DateDebut = this.DateDebut, DateFin = this.DateDebut.AddMonths(this.DureeContrat), IdTypeContrat = IdContrat, Matricule = "None" };
        Console.WriteLine("ETO AMBONY INSERTION SALAIRE");
        Salaire salaire = new Salaire
        { DateSalaire = DateTime.Now, Renumeration = this.Renumeration, IdTypeSalaire =  int.Parse(this.TypeSalaire) };
        Console.WriteLine("ETO ");
        List<Horaire> horaires = new List<Horaire>();
        foreach (var VARIABLE in JourDeTravail) { Horaire horaire = new Horaire { Sortie = this.HoraireSortie, Entree = this.HoraireSortie, IdJour = int.Parse(VARIABLE) }; horaires.Add(horaire); }
        List<Avantage> avantages = new List<Avantage>();
        foreach (var VARIABLE in Avantage)
        {
            Avantage avantage = new Avantage { IdAvantage = int.Parse(VARIABLE) }; avantages.Add(avantage);
        }
        using (var context = ApplicationDbContextFactory.Create())
        {
            // verifier si la personne est deja un employe
            List<Employe> objects = context.Employe.Where(e => e.IdCandidature == IdCandidature).ToList();
            if (objects.Count <= 0) // ici non
            {
                context.Employe.Add(employe); 
                context.SaveChanges(); 
            }
            else // ici oui donc on prend ce candidat
            {
                employe = objects[0];
            }
            detailsContrat.IdEmploye = employe.IdEmploye;
            if (isEmp)
            {
                detailsContrat.Matricule = ContratTravail.CompleterString(7, detailsContrat.IdEmploye.ToString());
            }
            context.DetailsContrat.Add(detailsContrat);  // insertion des details du contrat
            context.SaveChanges(); 
            salaire.IdContrat = detailsContrat.IdDetailsContrat; 
            context.Salaire.Add(salaire); // insertion salaire
            context.SaveChanges();
            foreach (var VARIABLE in Avantage) // insertion des differernts avanatages
            {
                Console.WriteLine("Here? ");
                Avantage avantage = new Avantage { IdAvantage = int.Parse(VARIABLE), IdEmploye = employe.IdEmploye };
                Console.WriteLine("YES ");
                context.Avantage.Add(avantage);
                context.SaveChanges();
            }
            foreach (var VARIABLE in JourDeTravail) // insertion des jours de travail
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
            // Transformer le statut du candidat
            Candidature candidature = context.Candidature.Where(c => c.IdCandidature == (this.IdCandidature)).First();
            candidature.Etat = etat;
            context.Candidature.Update(candidature);
            context.SaveChanges();
        }
    }
}
