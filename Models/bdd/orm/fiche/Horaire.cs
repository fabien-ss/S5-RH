using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace S5_RH.Models.bdd.orm.fiche;
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