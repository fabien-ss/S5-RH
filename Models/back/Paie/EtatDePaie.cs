using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Models.back.Paie;
[Table("EtatDePaie")]
public class EtatDePaie
{

    DateTime Date { get; set; }
    int nombre { get; set; }
    DetailsEmploye Details { get; set; }
    String Categorie { get; set; }
    String Fonction { get; set; }

    public EtatDePaie()
    {
        
    }

    
}