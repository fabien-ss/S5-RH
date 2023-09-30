namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("reponse")]
public class Reponse {
    [Key]
    [Column("id_reponse")]
    int IdReponse { get; set;}
    [Column("question")]
    string? Valimpanontaniana { get; set;}
    [Column("verite")]
    int Verite { get; set;}
}