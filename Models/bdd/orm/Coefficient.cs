namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("coefficient")]
public class Coefficient
{
    [Key]
    [Column("id_coefficient")]
    public int IdCoefficient { get; set; }
    [Column("valeur")]
    public int Value { get; set; }
    [Column("text")]
    public string Text { get; set; }
}