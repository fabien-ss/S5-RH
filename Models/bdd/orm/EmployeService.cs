using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm;

[Keyless]
[Table("v_employe_par_service")]
public class EmployeService
{
    [Column("id_service")]
    public int IdService{ get; set;}
    [Column("id_employe")]
    public int IdEmploye{ get; set;}
    [Column("prenom")]
    public string Prenom{ get; set;}
    [Column("nom")]
    public string Nom{ get; set;}

    public List<EmployeService> GetEmployeServiceByIdService()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.EmployeServices.Where(es => es.IdService == this.IdService).ToList();
        }
    }
}