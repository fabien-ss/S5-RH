using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.back.Pdf;

namespace S5_RH.Controllers.Pdf;

public class PdfController : Controller
{
    public IActionResult GeneratePdf(int IdEmploye)
    {
        PDFContrat pdfContrat = new PDFContrat("New.pdf", IdEmploye);
        pdfContrat.Build();
        return View();
    }

    public IActionResult GenererFicheDePoste(string IdCandidature)
    {
        Models.bdd.orm.fiche.Employe employe = new Models.bdd.orm.fiche.Employe { IdCandidature = int.Parse(IdCandidature) };
        employe = employe.ObtenirEmployeParId();
        PDFFicheDePoste ficheDePoste = new PDFFicheDePoste("./wwwroot/image/FichePoste.pdf", employe.IdEmploye);
        ficheDePoste.Build();
        return View();
    }
    public IActionResult GenererContrat(string IdCandidature)
    {
        Console.WriteLine(IdCandidature);
        Models.bdd.orm.fiche.Employe employe = new Models.bdd.orm.fiche.Employe { IdCandidature = int.Parse(IdCandidature) };
        employe = employe.ObtenirEmployeParId();
        PDFContrat contrat = new PDFContrat("./wwwroot/image/New.pdf", employe.IdEmploye);
        contrat.Build();
        return View();
    }
}