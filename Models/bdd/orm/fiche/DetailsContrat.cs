using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;
[Table("details_contrat")]
public class DetailsContrat
{
    [Column("id_details_contrat")]
    public int IdDetailsContrat { get; set; }
    [Column("date_debut")]
    public DateTime DateDebut { get; set; }
    [Column("date_fin")]
    public DateTime DateFin { get; set; }
    [Column("id_contrat")] 
    public int IdContrat { get; set; }
    [Column("matricule")]
    public string Matricule { get; set; }
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
            Salaires = context.Salaire.Where(s => IdContrat == this.IdContrat).ToList();
        }
    }
    public void setHoraire()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            Horaires = context.Horaire.
                Where(h => IdContrat == this.IdContrat)
                .ToList();
        }
    }
}