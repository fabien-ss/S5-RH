namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("annonce")]
public class Annonce {
    [Key]
    [Column("id_annonce")]
    int IdAnnoce { get; set; }
    [Column("id_service")]
    int IdService { get; set; }
    [Column("debut")]
    TimestampAttribute? Debut { get; set; }
    [Column("fin")]
    TimestampAttribute? Fin { get; set;}
    [Column("details")]
    string? Details { get; set; }
}