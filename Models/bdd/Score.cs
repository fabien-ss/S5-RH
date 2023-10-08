namespace S5_RH.Models.bdd;

public class Score{
    public string Typa { set; get;}
    public string Id { set; get;}
    public int Valeur { set; get;}    

    public Score( string type, string id, int value){
        Typa = type;
        Id = id;
        Valeur = value;
    }
}