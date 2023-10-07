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
    public int IdJour { get; set; }
    [Column("entree")]
    public string Entree { get; set; }
    [Column("sortie")]
    public string Sortie { get; set; }
}