using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Models.back.fiche;

public class FicheDePoste 
{
    private Employe Superieur { get; set; }
    private Employe[] Subordonnees { get; set; }
    
    //private VMissions[] Missions { get; set; }
    private VAvantages[] Avantages { get; set; }
    
    
    private DetailsContrat DetailsContrat { get; set; }
}

