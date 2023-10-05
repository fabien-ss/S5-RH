using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using Syncfusion.Pdf;

namespace S5_RH.Controllers.Pdf;

public class PdfController : Controller
{
    public IActionResult GeneratePdf()
    {
        PDFContrat pdfContrat = new PDFContrat();
        pdfContrat.Build();
        return View();
    }
}