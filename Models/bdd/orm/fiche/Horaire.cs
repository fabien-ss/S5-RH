using System.ComponentModel.DataAnnotations.Schema;

[Table("horaire")]
public class Horaire
{
    [Column("id_horaire")]
    private int IdHoraire { get; set; }
    [Column("jour")]
    private string jour { get; set; }
    [Column("entree")]
    string entree { get; set; }
    [Column("sortie")]
    string sortie { get; set; }
}