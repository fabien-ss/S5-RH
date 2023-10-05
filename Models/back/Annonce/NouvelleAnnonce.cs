using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting.Internal;

namespace S5_RH.Models.back.Annonce;
public class NouvelleAnnonce 
{ 
    
    [Required(ErrorMessage = "Id not set.")]
    public int IdServices { get; set; }
    [Required(ErrorMessage = "Date debut requis.")]
    public DateTime? Debut { get; set; }
    [Required(ErrorMessage = "Date fin requis.")]
    public DateTime? Fin { get; set; }
    [Required(ErrorMessage = "Description requis.")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Charge de travail requis.")]
    public int ChargeDeTravail { get; set; }
    [Required(ErrorMessage = "Jour/Homme requis.")]
    public int JourHomme { get; set; }
    
    //[Required(ErrorM
    //essage = "Document requis.")]
    //public IFormFile Document { get; set; }
     public List<Service> Services { get; set; }
    //public Models.bdd.orm.Qualification Qualification { get; set; }
    public NouvelleAnnonce()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            Services = context.Service.ToList();
        }
    }
    // enregistrement du fichier
 /* c  public void SauvegardeFichier()
    {
        IHostEnvironment _hostingEnvironment = new HostingEnvironment();
        string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");
        if (Document.Length > 0)
        {
            string filePath = Path.Combine(uploads, Document.FileName);
            Stream fileStream = new FileStream(filePath, FileMode.Create);
            Document.CopyToAsync(fileStream);
            fileStream.Close();
        }
    } */
 
    public void Sauvegarde(Models.bdd.orm.Qualification Qualification, List<Question> questions)
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            bdd.orm.Annonce annonce = new bdd.orm.Annonce
            {
                IdService = this.IdServices,
                Debut = this.Debut,
                Fin = this.Fin,
                Details = this.Description
            };
            context.Annonce.Add(annonce);
            context.SaveChanges();
            Qualification.IdAnnonce = annonce.IdAnnoce;
            context.Qualification.Add(Qualification);
            foreach (var question1 in questions)
            {
                question1.IdAnnonce = annonce.IdAnnoce;
                question1.TraitementInsertionQuestion();    
            }
            context.SaveChanges();
        }
    }
}