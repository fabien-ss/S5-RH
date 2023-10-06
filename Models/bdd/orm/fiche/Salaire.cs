using System.ComponentModel.DataAnnotations.Schema;
namespace S5_RH.Models.bdd.orm.fiche;
[Table("salaire")]
public class Salaire
{
    [Column("date_salaire")]
    public DateTime DateSalaire { get; set; }
    [Column("salaire")]
    public double Renumeration { get; set; }
    
    [Column("id_contrat")]
    public int IdContrat { get; set; }
}