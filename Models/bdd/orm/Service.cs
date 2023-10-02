using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("service")]
public class Service {
    [Key]
    [Column("id_service")]
    public int IdService { get; set;}
    [Column("nom")]
    public string? Nom { get; set;}
}