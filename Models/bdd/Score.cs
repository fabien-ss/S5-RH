namespace S5_RH.Models.bdd;

public class Score{
    public string Typa { set; get;}
    public int Id { set; get;}
    public int Valeur { set; get;}    

    public Score( string type, int id, int value){
        Typa = type;
        Id = id;
        Valeur = value;
    }
}