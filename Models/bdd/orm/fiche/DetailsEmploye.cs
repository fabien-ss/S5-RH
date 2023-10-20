using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm.fiche;

[Keyless]
[Table("v_details_employe")]
public class DetailsEmploye
{
    [Column("nom")]
    public string? Nom{ get; set;}
    [Column("prenom")]
    public string? Prenom{ get; set;}
    [Column("date_de_naissance")]
    public DateTime? DateDeNaissance{ get; set;}
    [Column("contact")]
    public string? Contact{ get; set;}
    [Column("details")]
    public string? Poste{ get; set;}
    [Column("id_poste")]
    public int IdPoste{ get; set;}
    [Column("date_debut")]
    public DateTime? DateDebut{ get; set;}
    [Column("date_fin")]
    public DateTime? DateFin{ get; set;}
    [Column("matricule")]
    public string? matricule{ get; set;}
    [Column("libelle_contrat")]
    public string? LibelleContrat{ get; set;}
    [Column("id_employe")]
    public int IdEmploye{ get; set;}

    [Column("renumeration")]
    public double? Salaire { get; set; }
    [Column("typesalaire")]
    public string? TypeSalaire { get; set; }
    [Column("service")] 
    public string? Service { get; set; }
    [Column("valide")]
    public int IsValide { get; set; }
    [NotMapped]
    public List<VAvantages> VAvantages{ get; set;}
    [NotMapped]
    public List<Mission> Missions{ get; set;}

    [NotMapped]
    public List<VHorraire> VHorraires{ get; set;}
    
    public void setAvantages()
    {
        this.VAvantages = new VAvantages().ListAvantageByEmp(this.IdEmploye);
    }
    public void setHorraire()
    {
        //this.VHorraires = new VHorraire().ObtenirHorraireParIdEmploye(this.IdEmploye);
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.VHorraires = context.VHorraires.Where(
                h => h.IdEmploye == this.IdEmploye
            ).ToList();
        }
    }
    public void setMission()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.Missions = context.Mission.Where(m => m.IdPoste == this.IdPoste).ToList();
            foreach (var m in this.Missions)
            {
                m.setTaches();
            }
        }

        //this.Missions = new Mission().ObtenirMissionParIdPoste(this.IdPoste);
    }
    public DetailsEmploye ObtenirDetailsEmployeParId()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.DetailsEmploye.Where(d => d.IdEmploye == this.IdEmploye).First();
        }
    }
}
