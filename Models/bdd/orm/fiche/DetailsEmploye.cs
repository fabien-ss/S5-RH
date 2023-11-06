using System.ComponentModel.DataAnnotations.Schema;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm.fiche;

[Keyless]
[Table("v_details_employe")]
public class DetailsEmploye
{
    [Column("nom")]
    public string? Nom{ get; set;}
    [Column("prenom")]
    public string? Prenom{ get; set;}
    [Column("date_de_naissance")]
    public DateTime? DateDeNaissance{ get; set;}
    [Column("contact")]
    public string? Contact{ get; set;}
    [Column("details")]
    public string? Poste{ get; set;}
    [Column("id_poste")]
    public int IdPoste{ get; set;}
    [Column("date_debut")]
    public DateTime DateDebut{ get; set;}
    [Column("date_fin")]
    public DateTime DateFin{ get; set;}
    
    [Column("libelle_contrat")]
    public string? LibelleContrat{ get; set;}
    [Column("id_employe")]
    public int IdEmploye{ get; set;}

    [Column("renumeration")]
    public double? Salaire { get; set; }
    [Column("typesalaire")]
    public string? TypeSalaire { get; set; }
    [Column("service")] 
    public string? Service { get; set; }
    [Column("valide")]
    public int IsValide { get; set; }
    [Column("sexe")]
    public int IdSexe{ get;set;}
    [Column("genre")]
    public string Genre{ get;set;}
    [Column("capacite_exercice")]
    public double CapaciteExercice{ get;set;}
    [Column("anciennete")]
    public double Anciennete{ get;set;}
    [Column("matricule")]
    public string Matricule { get; set; }
    [Column("id_candidature")]
    public int IdCandidature { get; set; }
    [NotMapped]
    public List<VAvantages> VAvantages{ get; set;}
    [NotMapped]
    public List<Mission> Missions{ get; set;}

    [NotMapped]
    public List<VHorraire> VHorraires{ get; set;}
    
    [NotMapped]
    public DetailsEmploye Superieur { get; set; }
    [NotMapped] 
    public float _heureSupplementaire { get; set; }
    public void setAvantages()
    {
        this.VAvantages = new VAvantages().ListAvantageByEmp(this.IdEmploye);
    }
    public void setHorraire()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.VHorraires = context.VHorraires.Where(
                h => h.IdEmploye == this.IdEmploye
            ).ToList();
        }
    }
    public void setMission()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.Missions = context.Mission.Where(m => m.IdPoste == this.IdPoste).ToList();
            foreach (var m in this.Missions)
            {
                m.setTaches();
            }
        }
        //this.Missions = new Mission().ObtenirMissionParIdPoste(this.IdPoste);
    }

    public void AjoutSuperieur()
    {
        Employe employe = new Employe { IdEmploye = this.IdEmploye };
        employe = employe.ObtenirEmployeByIdEmploye();
        if (employe.IdSuperieur.Equals(null)) employe.IdSuperieur = IdEmploye;
        DetailsEmploye e = new DetailsEmploye { IdEmploye = (int) employe.IdSuperieur };
        Console.WriteLine($"id superieur = {e.IdEmploye}");
        this.Superieur = e.ObtenirDetailsEmployeParId();
        //this.Superieur = e;
        Console.WriteLine("Nom superieur ="+this.Superieur.Nom);
    }
    public DetailsEmploye ObtenirDetailsEmployeParId()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.DetailsEmploye.Where(d => d.IdEmploye == this.IdEmploye ).First();
        }
    }

    public DetailsEmploye ObtenirDetailsEmployeAlternanceParId()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.DetailsEmploye.Where(d => d.IdEmploye == this.IdEmploye & d.IsValide == 0).First();
        }
    }

    public List<DetailsEmploye> ObtenirTousLesEmployes()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            List<DetailsEmploye> detailsEmployes = context.DetailsEmploye.ToList();
          //  SetHeureSup(detailsEmployes, DateTime.Now);
            return detailsEmployes;
        }
    }
    
    public List<DetailsEmploye> ObtenirTousLesEmployes(DateTime dateDuJour)
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            List<DetailsEmploye> detailsEmployes = context.DetailsEmploye.ToList();
            detailsEmployes = SetHeureSup(detailsEmployes, dateDuJour);
            return detailsEmployes;
        }
    }

    public List<DetailsEmploye> SetHeureSup(List<DetailsEmploye> detailsEmployes, DateTime dateDuJour)
    {
        foreach (var de in detailsEmployes)
        {
            HeureSupplementaire heureSupplementaire = new HeureSupplementaire();
            heureSupplementaire.Matricule = de.Matricule;
            heureSupplementaire.Mois = dateDuJour.Month;
            heureSupplementaire.Annee = dateDuJour.Year;
          //  heureSupplementaire.TotalHours = (float)heureSupplementaire.getTotalHours();
            de._heureSupplementaire = (float)heureSupplementaire.getTotalHours();
        }
        return detailsEmployes;
    }

    public double CalculateAnciennete(){
        DateTime now = DateTime.Now;
        TimeSpan res = now.Subtract((DateTime)this.DateDebut);
        return Math.Round(res.TotalDays);
    }

    public DetailsEmploye GetEmployeByMatricule()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            Console.WriteLine("Matricule = "+this.Matricule);
            DetailsEmploye de = context.DetailsEmploye.Where(d => d.Matricule == this.Matricule).First();
            return de;
        }
        return null;
    }
}
