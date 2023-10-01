using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace S5_RH.Models.back.Annonce;
public class NouvelleAnnonce
{
    
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

    public void SauvegardeTemporaire()
    {
    }
}