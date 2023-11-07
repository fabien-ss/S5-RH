using System.ComponentModel.DataAnnotations;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm.fiche;
using System.ComponentModel.DataAnnotations.Schema;

[Keyless]
[Table("v_avantages")]
public class VAvantages
{
    [Column("id_employe")]
    public int IdEmploye;
    [Column("id_avantage")]
    public int IdAvantage;
    [Column("nom")]
    public string Nom;

    public List<VAvantages> ListAvantageByEmp(int IdEmp)
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
           // return context.VAvantages.Where(v => v.IdEmploye == IdEmp).ToList();
        }

        List<VAvantages> avantagesList = new List<VAvantages>();
        avantagesList.Add(new VAvantages { Nom = "Véhiculé" });
        return avantagesList;
    }
    
}