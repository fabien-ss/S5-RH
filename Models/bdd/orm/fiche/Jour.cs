using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("jour")]
public class Jour
{
    [Key]
    [Column("id_jour")]
    private int IdJour { get; set; }
    [Column("jour")]
    private string Journee { get; set; }
}

