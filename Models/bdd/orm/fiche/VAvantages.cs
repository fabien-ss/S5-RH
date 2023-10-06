namespace S5_RH.Models.bdd.orm.fiche;
using System.ComponentModel.DataAnnotations.Schema;

[Table("v_avantages")]
public class VAvantages
{
    [Column("id_employe")]
    public int IdEmploye;
    [Column("id_avantage")]
    public int IdAvantage;
    [Column("nom")]
    public string Nom;
}