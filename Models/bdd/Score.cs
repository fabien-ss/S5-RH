namespace S5_RH.Models.bdd;

public class Score {

    public string Id { get; set; }

    public string Typa { get; set; }

    public int Valeur { get; set; }

    public Score( string id, string type, int val){
        Id = id;
        Typa = type;
        Valeur = val;
    }
}