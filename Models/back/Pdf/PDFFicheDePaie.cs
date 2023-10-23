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
        this.Footer();
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
        double? TauxJournalier = this.DetailsEmploye.Salaire/30;
        Contenu2.Add(new Chunk("Taux Journaliers : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu2.Add(new Chunk($"{TauxJournalier}", this.fontHeader));
        Ligne(Contenu2, 1);
        double? TauxHoraire = TauxJournalier/173.33;
        Contenu2.Add(new Chunk("Taux horaires : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu2.Add(new Chunk($"{TauxHoraire }", this.fontHeader));
        
        table.AddCell(Contenu2);
        this.Document.Add(table);
    }

    public void Content()
    {
        PdfPTable table = new PdfPTable(4);
        table.TotalWidth = this.Document.PageSize.Width - this.Document.LeftMargin - this.Document.RightMargin;
       
        PdfPTable table2 = new PdfPTable(3);
        table2.TotalWidth = this.Document.PageSize.Width - this.Document.LeftMargin - this.Document.RightMargin;

        Paragraph contenu1 = new Paragraph();
        Paragraph contenu2 = new Paragraph();
        Paragraph contenu3 = new Paragraph();
        Paragraph contenu4 = new Paragraph();
        Paragraph contenu5 = new Paragraph();
        Paragraph contenu6 = new Paragraph();
        Paragraph contenu7 = new Paragraph();
        
        Ligne(contenu1, 1);
        contenu1.Add(new Chunk($"Designation", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        
        Ligne(contenu2, 1);
        contenu2.Add(new Chunk($"Nombre", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        
        Ligne(contenu3, 1);
        contenu3.Add(new Chunk($"Taux", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        
        Ligne(contenu4, 1);
        contenu4.Add(new Chunk($"Montant", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));

        table.AddCell(contenu1);
        table.AddCell(contenu2);
        table.AddCell(contenu3);
        table.AddCell(contenu4);

        table2.AddCell(contenu5);
        table2.AddCell(contenu6);
        table2.AddCell(contenu7);

        this.Document.Add(table);
        this.Document.Add(table2);
        
    }

    public void Footer()
    {
        PdfPTable table = new PdfPTable(2);
        table.TotalWidth = this.Document.PageSize.Width - this.Document.LeftMargin - this.Document.RightMargin;
       
        table.DefaultCell.Border = PdfPCell.NO_BORDER;

        Paragraph contenu = new Paragraph();
        Paragraph contenu2 = new Paragraph();
        Ligne(contenu, 1);
        contenu.Add(new Chunk($"Employeur", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Ligne(contenu2, 1);
        contenu2.Add(new Chunk($"Employe", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        
        table.AddCell(contenu);
        table.AddCell(contenu2);
        
        this.Document.Add(table);
    }
    public void Ligne(Paragraph contenu,int nombre)
    {
        for (int i = 0; i < nombre; i++)
        {
            contenu.Add(Chunk.NEWLINE);
        }
    }
}