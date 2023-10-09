using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.back.Pdf;

namespace S5_RH.Controllers.Pdf;

public class PdfController : Controller
{
 
    // Generer fiche de poste
    public IActionResult GenererFicheDePoste(string IdCandidature)
    {
        // Obtenir l'emp qui a la candiature IDcandidature
        Models.bdd.orm.fiche.Employe employe = new Models.bdd.orm.fiche.Employe { IdCandidature = int.Parse(IdCandidature) };
        employe = employe.ObtenirEmployeParId();
        // Utiliser l'id de cet emp pour generer sa fiche
        PDFFicheDePoste ficheDePoste = new PDFFicheDePoste("./wwwroot/image/FichePoste.pdf", employe.IdEmploye);
        // Build la fonction qui construit le pdf
        ficheDePoste.Build();
        return View();
    }
    // Generer fiche de contrat / Travail
    public IActionResult GenererContrat(string IdCandidature)
    {
        // Obtenir l'emp qui a la candiature IDcandidature
        Models.bdd.orm.fiche.Employe employe = new Models.bdd.orm.fiche.Employe { IdCandidature = int.Parse(IdCandidature) };
        employe = employe.ObtenirEmployeParId();
        // Utiliser l'id de cet emp pour generer son contrat
        PDFContrat contrat = new PDFContrat("./wwwroot/image/New.pdf", employe.IdEmploye);
        contrat.Build();
        return View();
    }
}