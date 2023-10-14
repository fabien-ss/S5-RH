using iTextSharp.text;
using iTextSharp.text.pdf;
using S5_RH.Models.bdd.orm;

namespace S5_RH.Models.back.Annonce;

public interface PDF
{
   
    public void Header(); // en tête
    public void Content(); // contenu
    public void Footer(); // footer
}