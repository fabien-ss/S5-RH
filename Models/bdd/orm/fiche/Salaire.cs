using System.ComponentModel.DataAnnotations.Schema;

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