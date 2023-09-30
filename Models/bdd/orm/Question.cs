namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 [Table("question")]
public class Question {
    [Key]
    [Column("id_question")]
    int IdQuestion { get; set;}
    [Column("question")]
    string? Fanontaniana { get; set;}
}