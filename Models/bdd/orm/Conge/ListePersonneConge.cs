using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace S5_RH.Models.bdd.orm.Conge;
[Keyless]
[Table("v_liste_personne_conge")]
public class ListePersonneConge
{
    [Column("nom")]
    public string Nom{ get; set;}
    [Column("prenom")]
    public string Prenom{ get; set;}
    [Column("matricule")]
    public string Matricule{ get; set;}
    [Column("date_declaration")]
    public DateTime DateDeclaration{ get; set;}
    [Column("date_debut")]
    public DateTime DateDebut{ get; set;}
    [Column("libelle")]
    public string Libelle{ get; set;}
    [Column("id_type_conge")]
    public int IdTypeConge{ get; set;}

    public List<ListePersonneConge> ObtenirPersonneConges()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.ListePersonneConges.ToList();
        }
    }
    public ListePersonneConge ObtenirPersonneCongesByMatricule()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.ListePersonneConges.Where(l => l.Matricule == this.Matricule 
            ).First();
        }
    }
}