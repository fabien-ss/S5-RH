using iTextSharp.text;
using iTextSharp.text.pdf;

namespace S5_RH.Models.back.Annonce;

public interface PDF
{
    public void Header(); // en tête
    public void Content(); // contenu
    public void Footer(); // footer
}