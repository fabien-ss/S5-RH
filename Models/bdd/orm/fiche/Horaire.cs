using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("horaire")]

public class Horaire
{
    [Key] [Column("id")] 
    public int Id { get; set; }
    [Column("id_contrat")]
    public int IdContrat { get; set; }
    [Column("id_jour")]
    public int IdJour { get; set; }
    [Column("entree")]
    public string Entree { get; set; }
    [Column("sortie")]
    public string Sortie { get; set; }
}