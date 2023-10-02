using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace S5_RH.Models.back.Annonce;
public class NouvelleAnnonce 
{ 
    
    [Required(ErrorMessage = "Id not set.")]
    public int IdServices { get; set; }
    [Required(ErrorMessage = "Date debut requis.")]
    public DateTime? Debut { get; set; }
    [Required(ErrorMessage = "Date fin requis.")]
    public DateTime? Fin { get; set; }
    [Required(ErrorMessage = "Description requis.")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Charge de travail requis.")]
    public int ChargeDeTravail { get; set; }
    [Required(ErrorMessage = "Jour/Homme requis")]
    public int JourHomme { get; set; }
    
    public List<Service> Services { get; set; }
    //public Models.bdd.orm.Qualification Qualification { get; set; }
    public NouvelleAnnonce()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            Services = context.Service.ToList();
        }
    }
    // ici on effectue la sauvegarde de toute les données a propos de l'annonce
    public void Sauvegarde(Models.bdd.orm.Qualification Qualification)
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            bdd.orm.Annonce annonce = new bdd.orm.Annonce
            {
                IdService = this.IdServices,
                Debut = this.Debut,
                Fin = this.Fin,
                Details = this.Description
            };
            context.Annonce.Add(annonce);
            context.SaveChanges();
            Qualification.IdAnnonce = annonce.IdAnnoce;
            context.Qualification.Add(Qualification);
            context.SaveChanges();
        }
    }
}