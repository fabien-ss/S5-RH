using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S5_RH.Controllers.Candidature;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.bdd.orm.Conge;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Employe;

public class EmployeController : Controller{
    public async Task<RedirectToActionResult> InsertionHeureSup(HeureSupplementaire heureSupplementaire)
    {
        if (ModelState.IsValid)
        {
            heureSupplementaire.insertHeureSup();
        }
        return RedirectToAction("HeureSup");
    }
    public async Task<IActionResult> HeureSup(string matricule)
    {
        DetailsEmploye detailsEmploye = null;
        ViewData["typeConge"] = new TypeConge().ObtenirTypeConges();
        if (matricule != null)
        {
            matricule = matricule.Trim();
            string url = "http://localhost:8080/employees/"+matricule;
            Console.WriteLine("Url = "+url);
            string jsonResponse = "";
            try
            {
                jsonResponse = await CallApi(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Api response = "+jsonResponse);
            detailsEmploye = JsonConvert.DeserializeObject<DetailsEmploye>(jsonResponse);
            detailsEmploye.Matricule = matricule;
            ViewData["detailsEmploye"] = detailsEmploye;
            return View();
        }
        ViewData["detailsEmploye"] = detailsEmploye;
        return View();
    }
    // Obtenir la liste des candidats admis
    public IActionResult ListeDemandeConge()
    {
        string? matricule = (string)TempData["matricule"];
        DetailsEmploye detailsEmploye = new DetailsEmploye { Matricule = matricule };
        Console.WriteLine("Matricule controller employe = "+detailsEmploye.Matricule);
        detailsEmploye = detailsEmploye.GetEmployeByMatricule();
        Models.bdd.orm.fiche.Employe employe = new Models.bdd.orm.fiche.Employe
            { IdEmploye = detailsEmploye.IdEmploye };
        employe = employe.ObtenirEmployeByIdEmploye();
        List<Models.bdd.orm.fiche.Employe> subordonnees = employe.GetEmployeByIdSuperior();
        List<Conge> conges = new Conge().ListeConge(subordonnees);
        ViewData["conges"] = conges;
        return View();
    }
    public IActionResult ListeAdmis()
    {
        List<Models.bdd.orm.Candidature> candidats = new Models.bdd.orm.Candidature().ObtenirListeCandidature();
        ViewData["ListeCandidature"] = candidats;
        return View();
    }
    // Obtenir la liste des candidats
    public IActionResult ListeCandidat()
    {
        List<Models.bdd.orm.Candidature> candidats = new Models.bdd.orm.Candidature().ObtenirListeCandidatureNonValide();
        ViewData["ListeCandidature"] = candidats;
        return View();
    }
    // Obtenir la liste des personnes en aternance
    public IActionResult ListeAlternance()
    {
        List<Models.bdd.orm.Candidature> candidats = new Models.bdd.orm.Candidature().ObtenirListeAlternance();
        ViewData["ListeEmploye"] = candidats;
        return View();
    }
    // Obtenir la liste des employes
    public IActionResult ListeEmploye()
    {
        List<Models.bdd.orm.Candidature> candidats = new Models.bdd.orm.Candidature().ObtenirListeEmploye();
        ViewData["ListeEmploye"] = candidats;
        return View();
    }

    public IActionResult ListeDetailsParEmploye()
    {
        ViewData["employe"] = new DetailsEmploye().ObtenirTousLesEmployes();
        return View();
    }
    static async Task<string> CallApi(string apiUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Non";
        }
    }
}