using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using S5_RH.Models.bdd.orm.Conge;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Controllers.Candidature;

public class CongeController : Controller
{
    public IActionResult Valider(int IdConge)
    {
        Conge c = new Conge { IdConge = IdConge };
        c.ValiderConge();
        return RedirectToAction("ListeDemandeConge","Employe");
    }
    public IActionResult UpdateConge()
    {
        string Matricule = HttpContext.Request.Form["Matricule"];
        DateTime dateFin = DateTime.Now;
        Conge c = new Conge { Matricule = Matricule, DateFin = dateFin };
        c.update();
        return RedirectToAction("ListePersonneConge");
    }
    public IActionResult Error(string message)
    {
        string error = message;
        return View("error",error);
    }
    public async Task<IActionResult> InsertionConge(Conge conge)
    {
        Console.WriteLine("Conge raison = "+conge.Details);
        if (ModelState.IsValid)
        {
            try
            {
                conge.insertion();
                return RedirectToAction("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : "+e);
                return Error(e.Message);
            }
        }
        return Error("");
    }

    public IActionResult Success()
    {
        ViewData["Message"] = "succes";
        return View();
    }
    public IActionResult ListePersonneConge(string matricule)
    {
        List<ListePersonneConge> listePersonneConges = new List<ListePersonneConge>();
        
        if (matricule != null)
        {
            ListePersonneConge lc = new ListePersonneConge { Matricule = matricule };
            lc = lc.ObtenirPersonneCongesByMatricule();
            listePersonneConges.Add(lc);
            ViewData["personne"] = listePersonneConges;
            return View();
        }

        listePersonneConges = new ListePersonneConge().ObtenirPersonneConges();
        ViewData["personne"] = listePersonneConges;
        return View();
    }
    
    public async Task<IActionResult> RechercheEmploye(string matricule)
    {
        DetailsEmploye detailsEmploye = null;
        ViewData["typeConge"] = new TypeConge().ObtenirTypeConges();
        if (matricule != null)
        {
            matricule = matricule.Trim();
            string url = "http://localhost:8080/employees/"+matricule;
            Console.WriteLine("Url = "+url);
            string jsonResponse = await CallApi(url);
            detailsEmploye = JsonConvert.DeserializeObject<DetailsEmploye>(jsonResponse);
            detailsEmploye.Matricule = matricule;
            ViewData["detailsEmploye"] = detailsEmploye;
            return View();
        }
        ViewData["detailsEmploye"] = detailsEmploye;
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