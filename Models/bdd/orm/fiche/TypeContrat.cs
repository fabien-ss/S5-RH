using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iTextSharp.text;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("type_contrat")]
public class TypeContrat
{
    [Key]
    [Column("id_type_contrat")]
    public int IdContrat { get; set; }
    [Column("nom")]
    public string Nom { get; set; }

    public static List<TypeContrat> ObtenirTypeContrat()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.TypeContrat.ToList();
        }
    }
}