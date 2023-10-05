using System.ComponentModel.DataAnnotations.Schema;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("fiche_de_poste")]
public class FicheDePoste
{
    [Column("fiche_de_poste")]
    private int IdFicheDePoste { get; set; }
    [Column("id_superieur")]
    private int IdSuperieur;
    [Column("id_subordonnee")]
    private string IdSubordonnees;
}