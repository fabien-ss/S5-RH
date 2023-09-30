namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("poste")]
public class Poste {
    [Key]
    [Column("id_poste")]
    int IdPoste { get; set;}
    [Column("id_service")]
    int IdService { get; set;}
    [Column("details")]
    string? Details { get; set;}
}