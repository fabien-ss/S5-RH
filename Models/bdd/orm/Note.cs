namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("note")]
public class Note {
    [Key]
    [Column("id_candidature")]
    public int IdCandidature { get; set;}
    [Column("note_cv")]
    public double NoteCv { get; set;}
    [Column("note_question")]
    public double NoteQuestion { get; set;}

    public Note(){}

    public void InsererNote()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            context.Note.Add(this);
            context.SaveChanges();
        }
    }

/*
    public double GetNoteCv(){
        double res = 0;

        List<Score> lst = new Qualification().GetScore(this.IdAnnonce);
        
        CandidatCv tmp = new CandidatCv();
        using (var context = ApplicationDbContextFactory.Create()){
            tmp = context.CandidatCv.Where( tmp => tmp.IdCandidature == this.IdCandidature).ToList()[0] ;
        }

        foreach( Score score in lst){
            if( score.Typa == "Diplome" && score.Id == tmp.IdDiplome){
                res += score.Valeur;
            }
            else if( score.Typa == "Experience" && score.Id == tmp.IdExperience){
                res += score.Valeur;
            }
            else if( score.Typa == "Sexe" && score.Id == tmp.IdSexe){
                res += score.Valeur;
            }
            else if( score.Typa == "SituationMatrimoniale" && score.Id == tmp.IdSituationMatrimoniale){
                res += score.Valeur;
            }
        }

        return res;
    }
*//*
    public double GetNoteQuestion( Dictionary<Question , List<Reponse>> dico){
        double res = 0;
        foreach( KeyValuePair<Question , List<Reponse>> elt in dico){
            if(elt.Value[0].CheckResponse( elt.Value ) == true){
                res += elt.Key.Point;
            }            
        }
        return res;
    } */
}