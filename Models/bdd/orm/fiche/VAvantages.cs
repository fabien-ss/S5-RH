namespace S5_RH.Models.bdd.orm.fiche;
using System.ComponentModel.DataAnnotations.Schema;

[Table("v_avantages")]
public class VAvantages
{
    [Column("id_employe")]
    private int IdEmploye;
    [Column("id_avantage")]
    private int IdAvantage;
    [Column("nom")]
    private string Nom;
}