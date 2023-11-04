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

    public List<EtatDePaie> GetEtatDePaie(){
        List<EtatDePaie> lst = new();
        List<DetailsEmploye> details = new DetailsEmploye().ObtenirTousLesEmployes();
        foreach( DetailsEmploye detail in details){
            lst.Add(new EtatDePaie(detail));
        }
        return lst;
    }

    public double? GetCNaPSOnePercent(){
        double? calc = Decimal.ToDouble(Math.Round((decimal)this.Details.Salaire/100));
        if(calc>10080){
            calc = 10080;
        }
        return calc;
    }
    public double? GetCNaPSEightPercent(){
        double? calc = Decimal.ToDouble(Math.Round((decimal)this.Details.Salaire*8/100));
        return calc;
    }
    public double? GetOSTIEOnePercent(){
        return Decimal.ToDouble(Math.Round((decimal)this.Details.Salaire/100));
    }
    public double? GetOSTIEFivePercent(){
        return Decimal.ToDouble(Math.Round((decimal)this.Details.Salaire*5/100));
    }

    public double? GetTotalBrutSalary(){
        List<EtatDePaie> states = this.GetEtatDePaie();
        double? res = 0;
        foreach(EtatDePaie state in states){
            res += state.Details.Salaire;
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
        return GetTotalBrutSalary() - GetTotalOnePercentCNaPS() - GetTotalOnePercentOSTIE();
    }
}