using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations.Schema;

[Table("details_contrat")]
public class DetailsContrat
{
    [Column("id_details_contrat")]
    private int IdDetailsContrat { get; set; }
    [Column("date_debut")]
    private DateTime DateDebut { get; set; }
    [Column("date_fin")]
    private DateTime DateFin { get; set; }
    [Column("id_contrat")] 
    private int IdContrat { get; set; }
    [Column("salaire")]
    private double Salaire { get; set; }

    public static void Main(string[] args)
    {
    }
}