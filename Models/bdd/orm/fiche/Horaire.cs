using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("v_horaire")]
public class Horaire
{
    [Key]
    [Column("id_contrat")]
    public int IdContrat { get; set; }
    [Column("jour")]
    public string Jour { get; set; }
    [Column("id_jour")]
    public int jour { get; set; }
    [Column("entree")]
    string entree { get; set; }
    [Column("sortie")]
    string sortie { get; set; }
}