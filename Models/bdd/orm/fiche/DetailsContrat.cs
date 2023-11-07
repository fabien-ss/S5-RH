using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("details_contrat")]
public class DetailsContrat
{
    [Key]
    [Column("id_details_contrat")]
    public int IdDetailsContrat { get; set; }
    [Column("id_employe")]
    public int IdEmploye { get; set; }
    [Column("date_debut")]
    public DateTime DateDebut { get; set; }
    [Column("date_fin")]
    public DateTime DateFin { get; set; }
    [Column("id_type_contrat")] 
    public int IdTypeContrat { get; set; }
    [Column("matricule")]
    public string Matricule { get; set; }
    [Column("is_valide")]
    public int IdValide { get; set; }
    [NotMapped]
    public List<Salaire> Salaires { get; set; }
    [NotMapped] 
    public List<Horaire> Horaires { get; set; }

    public void Initializer()
    {
        this.setSalaires();
        this.setHoraire();
    }

    public void setSalaires()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            this.Salaires = context.Salaire.Where(s => IdTypeContrat == this.IdTypeContrat).ToList();
        }
    }
    public void setHoraire()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            Horaires = context.Horaire.
                Where(h => IdTypeContrat == this.IdTypeContrat)
                .ToList();
        }
    }
}