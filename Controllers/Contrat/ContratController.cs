using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Embauche;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Contrat;

public class ContratController : Controller{
    
    public IActionResult ContratTravail(string? IdCandidature)
    {
        ViewData["TypeContrat"] = TypeContrat.ObtenirTypeContrat();
        ViewData["Jours"] = Jour.ObtenirListeJour();
        ViewData["Avantages"] = TypeAvantage.ObtenirTypeAvantage();
        TempData["IdCandidature"] = IdCandidature;
        ViewData["TypeSalaire"] = TypeSalaire.ObtenirSalaire();
        Models.bdd.orm.Candidature candidature = new Models.bdd.orm.Candidature { IdCandidature = Convert.ToInt32(IdCandidature) };
        candidature = candidature.GetCandidatureById();
        Models.bdd.orm.Annonce annonce = new Models.bdd.orm.Annonce { IdAnnoce = candidature.IdAnnonce };
        annonce = annonce.GetAnnonceById();
        EmployeService es = new EmployeService { IdService = annonce.IdService };
        List<EmployeService> Superieur = es.GetEmployeServiceByIdService();
        ViewData["Superieur"] = Superieur;
        // il faut obtenir la liste des personnes dans le même service
        return View();
    }

    public IActionResult TraitementRenouvellement(ContratTravail contratTravail)
    {
        if (ModelState.IsValid)
        {
            int IdCandidature = int.Parse((string)TempData["IdCandidature"]);
            contratTravail.UpdateContrat(IdCandidature);
            Console.WriteLine(contratTravail.DureeContrat);   
        }
        return RedirectToAction("ContratTravail");
    }
    public IActionResult ContratEssai(int id)
    {
        ViewData["TypeSalaire"] = TypeSalaire.ObtenirSalaire();
        ViewData["Jours"] = Jour.ObtenirListeJour();
        ViewData["Avantages"] = TypeAvantage.ObtenirTypeAvantage();
        ViewData["TypeContrat"] = TypeContrat.ObtenirTypeContrat();
        ViewData["Candidat"] = new Models.bdd.orm.Candidature
        {
            IdCandidature = id
        }.ObtenirListeCandidatureById();
        
        Models.bdd.orm.Candidature candidature = new Models.bdd.orm.Candidature { IdCandidature = Convert.ToInt32(id) };
        candidature = candidature.GetCandidatureById();
        Models.bdd.orm.Annonce annonce = new Models.bdd.orm.Annonce { IdAnnoce = candidature.IdAnnonce };
        annonce = annonce.GetAnnonceById();
        EmployeService es = new EmployeService { IdService = annonce.IdService };
        List<EmployeService> Superieur = es.GetEmployeServiceByIdService();
        ViewData["Superieur"] = Superieur;
        TempData["IdCandidat"] = id;
        return View();
    }
    public IActionResult TraitementContratEssai(ContratEssai contratEssai)
    {
        if (ModelState.IsValid)
        {
            object? currentId = TempData["IdCandidat"];
            contratEssai.InsertionEssai((int)currentId, 3, 10, false);
            return RedirectToAction("ListeCandidat", "Employe");
        }
        return RedirectToAction("ContratEssai?id="+TempData["IdCandidat"]);
    }
}