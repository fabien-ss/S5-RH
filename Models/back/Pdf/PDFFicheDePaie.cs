using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Models.back.Pdf;

public class PDFFicheDePaie : PDF
{
    private Document Document;
    private DetailsEmploye DetailsEmploye;
    private String Path;
    private double? TauxJournalier;
    private double TauxHoraire;
    private Font fontHeader;
    public void Build()
    {
        
        this.Document = new Document();
        PdfWriter.GetInstance(Document, new FileStream(Path, FileMode.Create));
        this.Document.Open();
        this.Header();
        this.Document.CloseDocument();
    }
    public PDFFicheDePaie(String Path, int IdEmploye)
    {
        this.Path = Path;
        bdd.orm.fiche.DetailsEmploye de = new DetailsEmploye { IdEmploye = IdEmploye };
        this.DetailsEmploye = de.ObtenirDetailsEmployeParId();
        this.fontHeader = new Font(Font.FontFamily.HELVETICA, 9);
        //this.Content();
        //this.Footer();
    }
    public void Header()
    {
        Font titleFont = new Font(Font.FontFamily.HELVETICA, 21, Font.BOLD);
        Paragraph title = new Paragraph("Fiche de paie", titleFont);
        title.Alignment = Element.ALIGN_CENTER;
        Ligne(title, 1);
        this.Document.Add(title);
        
        PdfPTable table = new PdfPTable(2);
        
        table.TotalWidth = this.Document.PageSize.Width - this.Document.LeftMargin - this.Document.RightMargin;
       
        table.DefaultCell.Border = PdfPCell.NO_BORDER;
        
        Paragraph Contenu = new Paragraph();
        
        Contenu.SpacingBefore = 20f;
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"Nom : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Nom}", this.fontHeader));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Prénom : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Prenom}", this.fontHeader));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Matricule : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Matricule}", this.fontHeader));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Date d'embauche : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Matricule}", this.fontHeader));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Ancienneté : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.CapaciteExercice}", this.fontHeader));
        
        table.AddCell(Contenu);
        
        
        Paragraph Contenu2 = new Paragraph();
        
        Contenu2.SpacingBefore = 20f;
        Ligne(Contenu2, 1);
        Contenu2.Add(new Chunk($"Classification : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu2.Add(new Chunk($"{this.DetailsEmploye.Service}", this.fontHeader));
        Ligne(Contenu2, 1);
        Contenu2.Add(new Chunk("Salaire de base : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu2.Add(new Chunk($"{this.DetailsEmploye.Salaire}", this.fontHeader));
        Ligne(Contenu2, 1);
        
        table.AddCell(Contenu2);
        this.Document.Add(table);
    }

    public void Content()
    {
        throw new NotImplementedException();
    }

    public void Footer()
    {
        throw new NotImplementedException();
    }
    public void Ligne(Paragraph contenu,int nombre)
    {
        for (int i = 0; i < nombre; i++)
        {
            contenu.Add(Chunk.NEWLINE);
        }
    }
}