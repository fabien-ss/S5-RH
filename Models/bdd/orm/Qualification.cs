namespace S5_RH.Models.bdd.orm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using S5_RH.Models.bdd;

[Table("qualification")]
public class Qualification {
    [Key]
    [Column("id_qualification")]
    public int IdQualification { get; set; }
    [Column("id_annonce")]
    public int IdAnnonce { get; set; }

    [Column("diplome")]
    public string? Diplome { get; set;}
    [Column("experience")]
    public string? Experience { get; set; }
    [Column("sexe")]
    public string? Sexe { get; set; }
    [Column("situation_matrimoniale")]
    public string? SituationMatrimoniale { get; set; }

    public String[] Split(String value){
        String[] separator = { ";", "," };
        return value.Split( separator, StringSplitOptions.RemoveEmptyEntries );
    }
    
    public List<Qualification> ListAll(){
        List<Qualification> lst = new List<Qualification>();
        using (var context = ApplicationDbContextFactory.Create()){
            lst = context.Qualification.ToList();
        }
        return lst;
    }

    public List<Score> GetScore( int identifiant ){
        List<Score> lst = new List<Score>();
        Qualification tmp = new Qualification();
        using (var context = ApplicationDbContextFactory.Create()){
            tmp = context.Qualification.Where( tmp => tmp.IdAnnonce == identifiant).ToList()[0] ;
        }

        foreach( var temp in tmp.Split(tmp.Diplome)){
            String[] str = temp.Split("=", StringSplitOptions.RemoveEmptyEntries);
            lst.Add( new Score( "Diplome" , int.Parse(str[0]) , int.Parse(str[1]) ) );
        }

        foreach( var temp in tmp.Split(tmp.Experience)){
            String[] str = temp.Split("=", StringSplitOptions.RemoveEmptyEntries);
            lst.Add( new Score( "Experience" , int.Parse(str[0]) , int.Parse(str[1]) ) );
        }

        foreach( var temp in tmp.Split(tmp.Sexe)){
            String[] str = temp.Split("=", StringSplitOptions.RemoveEmptyEntries);
            lst.Add( new Score( "Sexe" , int.Parse(str[0]) , int.Parse(str[1]) ) );
        }

        foreach( var temp in tmp.Split(tmp.SituationMatrimoniale)){
            String[] str = temp.Split("=", StringSplitOptions.RemoveEmptyEntries);
            lst.Add( new Score( "SituationMatrimoniale" , int.Parse(str[0]) , int.Parse(str[1]) ) );
        }
        return lst;
    }

}