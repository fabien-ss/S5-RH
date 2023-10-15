using Microsoft.AspNetCore.Mvc;
namespace S5_RH.Controllers.Candidature;

public class CongeController : Controller
{
    public IActionResult Error()
    {
        string error = "tsy mety";
        return View("error",error);
    }
    public async Task<IActionResult> InsertionConge()
    {
        
        ;
     //   string response = await CallApi("dqsd");
        return RedirectToAction("Error");
     //return View();
    }

    public IActionResult ListePersonneConge()
    {
        // string response = await CallApi("");
        return View();
    }

    public IActionResult RechercheEmploye()
    {
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