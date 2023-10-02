public class CandidatureForm
{
    private string Nom { get; set; }
    private string Prenom { get; set; }
    private DateTime DateDeNaissance { get; set; }
    private string Telephone { get; set; }
    private string Motivation { get; set; }
    public IFormFile Photo { get; set; }
    public string IdDiplome { get; set; }
    private string IdExperience { get; set; }
    private string IdSexe { get; set; }
    private string IdSituationMatrimoniale { get; set; }
    private string Hobies { get; set; }
    private IFormFile[] Documents { get; set; }
    
}