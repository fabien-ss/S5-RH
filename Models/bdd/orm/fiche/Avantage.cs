using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.bdd.orm.fiche;
using System.ComponentModel.DataAnnotations.Schema;

[Table("avantage_employe")]
public class Avantage
{ 
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("id_employe")]
    public int IdEmploye { get; set; }
    [Column("id_avantage")]
    public int IdAvantage { get; set; }
}

