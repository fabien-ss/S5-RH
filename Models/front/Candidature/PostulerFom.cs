using System.ComponentModel.DataAnnotations;
using S5_RH.Models.bdd;
using S5_RH.Models.bdd.orm;

namespace S5_RH.Models.Front.Candidature;

public class PostulerForm
{
    [Required(ErrorMessage = "Nom not set.")]
    public string Nom{ get; set;}
    [Required(ErrorMessage = "Prenom not set.")]
    public string Prenom{ get; set;}
    [Required(ErrorMessage = "Date de naissance.")]
    public DateTime DateDeNaissance{ get; set;}
    [Required(ErrorMessage = "Telephone.")]
    public string Telephone{ get; set;}
    [Required(ErrorMessage = "Motivation.")]
    public string? Motivation{ get; set;}
    [Required]
    public string IdDiplome{ get; set;}
    [Required]
    public string IdExperience{ get; set;}
    [Required]
    public string IdSexe{ get; set;}
    [Required]
    public string IdSituationMatrimoniale{ get; set;}
    public string Hobies{ get; set;}
    public string IdAnnonce { get; set; }
    public string IdPoste { get; set; }
    public void insertionCandidature(double noteQCM)
    {
        bdd.orm.Candidature candidature = new bdd.orm.Candidature
            {
                IdAnnonce = Convert.ToInt32(this.IdAnnonce),
                Nom = this.Nom,
                Prenom = this.Prenom,
                DateDeNaissance = this.DateDeNaissance,
                Contact = this.Telephone,
                Etat = 0
        };
        candidature.InsererCandidature();
        CandidatCv candidatCv = new CandidatCv
        {
            IdCandidature = candidature.IdCandidature,
            IdDiplome = Convert.ToInt32(this.IdDiplome),
            IdSexe = Convert.ToInt32(this.IdSexe),
            IdSituationMatrimoniale = Convert.ToInt32(this.IdSituationMatrimoniale),
            IdExperience = Convert.ToInt32(this.IdExperience),
            IdPoste = Convert.ToInt32(this.IdPoste)
        };
        candidatCv.InsererCandidatCv();
        double noteCv = this.NoteCv();
        Note note = new Note
        {
            IdCandidature = candidature.IdCandidature,
            NoteCv = noteCv,
            NoteQuestion = noteQCM
        };
        note.InsererNote();
    }
    public double NoteCv()
    {
        Dictionary<string, Dictionary<int, int>> scores = new Dictionary<string, Dictionary<int, int>>();
        Qualification q = new Qualification();
        scores = q.GetScore(int.Parse(this.IdAnnonce));
        int DiplomePoint = scores["Diplome"][Convert.ToInt32(this.IdDiplome)];
        int ExperiencePoint = scores["Experience"][Convert.ToInt32(this.IdExperience)];
        int SexePoint = scores["Sexe"][Convert.ToInt32(this.IdSexe)];
        int SituationMatrimonialePoint = scores["SituationMatrimoniale"][Convert.ToInt32(this.IdSituationMatrimoniale)];
        int total = DiplomePoint + ExperiencePoint + SexePoint + SituationMatrimonialePoint;
        return total;
    }
}