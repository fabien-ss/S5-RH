namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("candidat_cv")]
public class CandidatCv {
    [Key]
    [Column("id_candidat_cv")]
    public int IdCandidatCv { get; set; }
    [Column("id_candidature")]
    public int IdCandidature { get; set; }
    [Column("id_diplome")]
    public int IdDiplome { get; set; }    
    [Column("id_experience")]
    public int IdExperience { get; set; }
    [Column("id_sexe")]
    public int IdSexe { get; set; }
    [Column("id_situation_matrimoniale")]
    public int IdSituationMatrimoniale { get; set; }
    [Column("id_poste")]
    public int IdPoste { get; set; }
    

    public void InsererCandidatCv()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            context.CandidatCv.Add(this);
            context.SaveChanges();
        }
    }
}