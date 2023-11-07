using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.bdd.orm.fiche;

namespace S5_RH.Models.back.Pdf;

public class PDFFicheDePoste : PDF
{
    public string Path { get; set; }
    public Document Document { get; set; }
    public DetailsEmploye DetailsEmploye { get; set; }

    public PDFFicheDePoste(String Path, int IdEmploye)
    {
        this.Path = Path;
        this.DetailsEmploye = new DetailsEmploye { IdEmploye = IdEmploye };
        this.DetailsEmploye = this.DetailsEmploye.ObtenirDetailsEmployeParId();
        this.DetailsEmploye.AjoutSuperieur();
        Console.WriteLine("Sup = " + this.DetailsEmploye.Superieur.Nom);
        this.DetailsEmploye.setAvantages();
        this.DetailsEmploye.setHorraire();
        this.DetailsEmploye.setMission();
    }

    public void Build()
    {
        this.Document = new Document();
        PdfWriter.GetInstance(Document, new FileStream(Path, FileMode.Create));
        this.Document.Open();
        this.Header();
        this.Content();
        this.Footer();   
        this.Document.CloseDocument();
    }
    public void Header()
    {
        Font titleFont = new Font(Font.FontFamily.HELVETICA, 21, Font.BOLD);
        Paragraph title = new Paragraph("Fiche de poste", titleFont);
        title.Alignment = Element.ALIGN_CENTER;
        this.Document.Add(title);
        Paragraph Contenu = new Paragraph();
        Contenu.SpacingBefore = 20f;
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"Nom : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Nom}"));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Prénom : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Prenom}"));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Matricule : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Matricule}"));
        Ligne(Contenu, 2);
        LineSeparator separator = new LineSeparator();
        Contenu.Add(separator);
        Ligne(Contenu, 2);
        this.Document.Add(Contenu);
        
    }
    public void Ligne(Paragraph contenu,int nombre)
    {
        for (int i = 0; i < nombre; i++)
        {
            contenu.Add(Chunk.NEWLINE);
        }
    }
    public void Content()
    {
        
        Paragraph Contenu = new Paragraph();
        Contenu.SpacingBefore = 20f;
        Contenu.Add(new Chunk($"Mission : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Poste}"));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"Rénumération du poste (mensuelle) : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Salaire} Ar, {this.DetailsEmploye.TypeSalaire}"));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Tâches : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Ligne(Contenu, 1);
        Contenu.Add(Chunk.SPACETABBING);
        foreach (var VARIABLE in this.DetailsEmploye.Missions)
        {
            Contenu.Add(VARIABLE.Libelle);
            Ligne(Contenu, 1);
            Contenu.Add(Chunk.SPACETABBING);
            Contenu.Add(new Chunk("Ex : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
            foreach (var t in VARIABLE.Taches)
            {
                Contenu.Add(new Chunk($"{t.Details}"));
                Ligne(Contenu, 1);
            }
        }
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Superieur : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Superieur.Prenom}"));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Subordonnés : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk(" *"));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Avantages : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Ligne(Contenu, 1);
        foreach (var VARIABLE in this.DetailsEmploye.VAvantages)
        {
            Contenu.Add(new Chunk($"{VARIABLE.Nom}"));     
        }
        Ligne(Contenu, 1); 
        Contenu.Add(new Chunk("Nature du poste : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Ligne(Contenu, 1); 
        Contenu.Add(new Chunk($"{this.DetailsEmploye.LibelleContrat}")); 
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Horaire : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Ligne(Contenu, 1);
        Table(Contenu);
        Ligne(Contenu, 2);
        LineSeparator separator = new LineSeparator();
        Contenu.Add(separator);

        this.Document.Add(Contenu);
        //throw new NotImplementedException("Not supported yet.");
    }

    public void Footer()
    {
        Paragraph Contenu = new Paragraph();
        Contenu.SpacingBefore = 20f;
        Contenu.Add(new Chunk("Employé ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(Chunk.SPACETABBING);
        Contenu.Add(new Chunk($"Employeur  ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
      
        this.Document.Add(Contenu);
        //throw new NotImplementedException("Not supported yet.");
    }
    public void Table(Paragraph ctx)
    {
        Font font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
        PdfPTable table = new PdfPTable(this.DetailsEmploye.VHorraires.Count + 1);
        table.AddCell(new PdfPCell(new Phrase("Horaires", font)));
        foreach (var jour in this.DetailsEmploye.VHorraires)
        {
            table.AddCell(new PdfPCell(new Phrase(jour.Jour, font)));
            
        }

        table.AddCell("Entrée");
        foreach (var horaire in this.DetailsEmploye.VHorraires)
        {
            table.AddCell(horaire.Entree);
        }
        table.AddCell("Sortie");
        foreach (var horaire in this.DetailsEmploye.VHorraires)
        {
            table.AddCell(horaire.Sortie);
        }
        ctx.Add(table);
    }
}