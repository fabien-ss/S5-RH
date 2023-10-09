namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("reponse")]
public class Reponse {
    [Column("id_question")] 
    public int IdQuestion { get; set; }
    [Key]
    [Column("id_reponse")]
    public int IdReponse { get; set;}
    [Column("reponse")]
    public int? Valimpanontaniana { get; set;}
    [Column("verite")]
    public int Verite { get; set;}

    public List<Reponse> GetReponseByIdQuestion()
    {
        List<Reponse> reponses = new List<Reponse>();
        using (var context = ApplicationDbContextFactory.Create())
        {
            reponses = context.Reponse
                .Where(r => r.IdQuestion == this.IdQuestion).ToList();
        }
        return reponses;
    }
    public List<Reponse> GetReponseVraiByIdQuestion()
    {
        List<Reponse> reponses = new List<Reponse>();
        using (var context = ApplicationDbContextFactory.Create())
        {
            reponses = context.Reponse
                .Where(r => r.IdQuestion == this.IdQuestion && r.Valimpanontaniana == 1).ToList();
        }
        return reponses;
    }

    public bool CheckResponse( List<Reponse> list){
        bool res = false;
        List<Reponse> lst = this.GetReponseVraiByIdQuestion();
        if( list.Count == lst.Count ){
            res = true;
            for( int i = 0 ; i < lst.Count ; i++ ){  
                if( lst[i].IdReponse != list[i].IdReponse){
                    res = false;
                }
            }
        }
        return res;    
    }

}