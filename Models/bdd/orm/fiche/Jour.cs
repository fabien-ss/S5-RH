using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iTextSharp.text;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("jour")]
public class Jour
{
    [Key]
    [Column("id_jour")]
    public int IdJour { get; set; }
    [Column("jour")]
    public string Journee { get; set; }

    public static List<Jour> ObtenirListeJour()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Jour.ToList();
        }
    }
}

