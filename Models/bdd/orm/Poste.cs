namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("poste")]
public class Poste {
    [Key]
    [Column("id_poste")]
    public int IdPoste { get; set;}
    [Column("id_service")]
    public int IdService { get; set;}
    [Column("details")]
    public string? Details { get; set;}
}