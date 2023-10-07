using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using iTextSharp.text;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("salaire")]
public class Salaire
{
    [Key]
    [Column("date_salaire")]
    public DateTime DateSalaire { get; set; }
    [Column("salaire")]
    public double Renumeration { get; set; }
    
    [Column("id_contrat")]
    public int IdContrat { get; set; }
    [Column("id_type_salaire")]
    public int IdTypeSalaire { get; set; }
    
}