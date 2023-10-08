using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm.fiche;

[Keyless]
[Table("v_horraire")]
public class VHorraire
{
    [Column("id_contrat")]
    public int IdContrat { get; set; }
    [Column("entree")]
    public string Entree { get; set; }
    [Column("sortie")]
    public string Sortie { get; set; }
    [Column("jour")]
    public string Jour { get; set; }

    [Column("id_employe")]
    public int IdEmploye { get; set; }
}

