namespace S5_RH.Models.back.fiche;

public class Employe : bdd.orm.fiche.Employe
{
    private Horaire Horaire { get; set; }
    private FicheDePoste FicheDePoste { get; set; }
}
