using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("service")]
public class Service {
    [Key]
    [Column("id_service")]
    int IdService { get; set;}
    [Column("nom")]
    string? Nom { get; set;}
}