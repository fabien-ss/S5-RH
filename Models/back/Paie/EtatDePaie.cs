using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Models.back.Paie;
[Table("EtatDePaie")]
public class EtatDePaie
{

    public DateTime Date { get; set; }
    public int Nombre { get; set; }
    public DetailsEmploye Details { get; set; }
    String Categorie { get; set; }
    // String Fonction { get; set; }

    public EtatDePaie(){}
    public EtatDePaie(DetailsEmploye detail)
    {
        Date = DateTime.Now;
        Nombre = 1;
        Details = detail;
    }

    public double GetHeure()
    {
        double TauxHoraire = Decimal.ToDouble(Math.Round((decimal)(this.Details.Salaire/173.33)));
        float heures = this.Details._heureSupplementaire;
        double retour = (1.3 * TauxHoraire) * heures ;
        return Decimal.ToDouble(Math.Round((decimal)retour));
    }
    public double? getBrutSalary()
    {
        return Decimal.ToDouble(Math.Round((decimal)(this.Details.Salaire + this.GetHeure())));
    }
    public List<EtatDePaie> GetEtatDePaie(){
        var le = new List<EtatDePaie>();
        var details = new DetailsEmploye().ObtenirTousLesEmployes(this.Date);
        foreach( DetailsEmploye detail in details){
          // eto mandeha
            le.Add(new EtatDePaie(detail));
            Console.WriteLine("GetEtatDePaie "+detail._heureSupplementaire);
        }
        Console.WriteLine("salamae "+le.Count);
        return le;
    }

    public double? GetCNaPSOnePercent(){
        double? calc = Decimal.ToDouble(Math.Round((decimal)this.getBrutSalary()/100));
        if(calc>10080){
            calc = 10080;
        }
        return calc;
    }
    public double? GetCNaPSEightPercent(){
        double? calc = Decimal.ToDouble(Math.Round((decimal)this.getBrutSalary()*8/100));
        return calc;
    }
    public double? GetOSTIEOnePercent(){
        return Decimal.ToDouble(Math.Round((decimal)this.getBrutSalary()/100));
    }
    public double? GetOSTIEFivePercent(){
        return Decimal.ToDouble(Math.Round((decimal)this.getBrutSalary()*5/100));
    }

    public double? GetTotalHeureSupplementaire()
    {
        List<EtatDePaie> states = this.GetEtatDePaie();
        double? res = 0;
        foreach(EtatDePaie state in states)
        {
            res += state.GetHeure();
        }
        return res;
    }
    public double? GetTotalBrutSalary(){
        List<EtatDePaie> states = this.GetEtatDePaie();
        double? res = 0;
        foreach(EtatDePaie state in states){
            res += state.getBrutSalary();
        }
        return res;
    }
    public double? GetTotalOnePercentCNaPS(){
        List<EtatDePaie> states = this.GetEtatDePaie();
        double? res = 0;
        foreach(EtatDePaie state in states){
            res += state.GetCNaPSOnePercent();
        }
        return res;
    }
    public double? GetTotalOnePercentOSTIE(){
        List<EtatDePaie> states = this.GetEtatDePaie();
        double? res = 0;
        foreach(EtatDePaie state in states){
            res += state.GetOSTIEOnePercent();
        }
        return res;
    }   
    public double? GetNetAPayer(){
        return this.Details.Salaire - GetCNaPSOnePercent() - GetOSTIEOnePercent();
    }    
    public double? GetTotalNetAPayer(){
        return GetTotalNet() - GetTotalOnePercentCNaPS() - GetTotalOnePercentOSTIE();
    }

    public double? GetTotalNet()
    {
        List<EtatDePaie> states = this.GetEtatDePaie();
        double? res = 0;
        foreach(EtatDePaie state in states)
        {
            res += state.Details.Salaire;
        }
        return res;   
    }
}