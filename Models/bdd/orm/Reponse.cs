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
    public string? Valimpanontaniana { get; set;}
    [Column("verite")]
    public int Verite { get; set;}

    [NotMapped]
    public int UserReponse { get; set; }

    public void setUserReponse(HttpContext context)
    {
        string IdReponseString = this.IdReponse.ToString();
        this.UserReponse = int.Parse(context.Request.Form[IdReponseString]);
    }
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
                .Where(r => r.IdQuestion == this.IdQuestion && r.Verite == 1).ToList();
        }
        return reponses;
    }
    // debut
    public Reponse getReponseById()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            return context.Reponse.Where(r => r.IdReponse == this.IdReponse).First();
        }
    }

    public static List<Reponse> listeDesReponses(string[] idReponses)
    {
        List<Reponse> respReponses = new List<Reponse>();
        foreach (var VARIABLE in idReponses)
        {
            Reponse r = new Reponse { IdReponse = int.Parse(VARIABLE) };
            r = r.getReponseById();
            respReponses.Add(r);
        }
    
        return respReponses;
    }
    // fin
    public bool CheckResponse(List<Reponse> list){
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