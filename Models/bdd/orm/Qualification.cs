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

    public Dictionary<string, Dictionary<int, int>> GetScore(int identifiant){
        Dictionary<string, Dictionary<int, int>> lst = new Dictionary<string, Dictionary<int, int>>();
        Qualification tmp = new Qualification();
        
        // maka an'ilay coefficient mifandraika am qualification (diplome, experience, ect ...)
        using (var context = ApplicationDbContextFactory.Create()){
            tmp = context.Qualification.Where( tmp => tmp.IdAnnonce == identifiant).ToList()[0] ;
        }
        // ito angamba maka ny coefficient hoan ny diplome
        Dictionary<int, int> DiplomeValue = new Dictionary<int, int>();  
        foreach( var temp in tmp.Split(tmp.Diplome)){
            String[] str = temp.Split("=", StringSplitOptions.RemoveEmptyEntries);
            DiplomeValue.Add(int.Parse(str[0]), int.Parse(str[1]));
        }
        lst.Add("Diplome", DiplomeValue);
        // ito indray maka anle experience
        
        Dictionary<int, int> ExperienceValue = new Dictionary<int, int>();  
        foreach( var temp in tmp.Split(tmp.Experience)){
            String[] str = temp.Split("=", StringSplitOptions.RemoveEmptyEntries);
            ExperienceValue.Add(int.Parse(str[0]), int.Parse(str[1]));
            //lst.Add( new Score( "Experience" , int.Parse(str[0]) , int.Parse(str[1]) ) );
        }
        lst.Add("Experience", ExperienceValue);
        // ito ndray sexe
        Dictionary<int, int> Sexe = new Dictionary<int, int>();  
        foreach( var temp in tmp.Split(tmp.Sexe)){
            String[] str = temp.Split("=", StringSplitOptions.RemoveEmptyEntries);
            Sexe.Add(int.Parse(str[0]), int.Parse(str[1]));
        }
        lst.Add("Sexe", Sexe);
        // ito ndray ila situation matrimoniale
        Dictionary<int, int> SituationMatrimoniale = new Dictionary<int, int>();  
        foreach( var temp in tmp.Split(tmp.SituationMatrimoniale)){
            String[] str = temp.Split("=", StringSplitOptions.RemoveEmptyEntries);
            SituationMatrimoniale.Add(int.Parse(str[0]), int.Parse(str[1]));
        }
        lst.Add("SituationMatrimoniale", SituationMatrimoniale);
        return lst;
    }
}