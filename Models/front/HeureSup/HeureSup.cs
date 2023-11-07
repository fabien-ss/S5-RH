using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.front.HeureSup;

public class HeureSup
{
    [Required]
    public DateTime DateEtat { get; set; }
}