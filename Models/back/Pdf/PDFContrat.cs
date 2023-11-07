using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using S5_RH.Models.bdd.orm;
using S5_RH.Models.bdd.orm.fiche;
using Font = iTextSharp.text.Font;

namespace S5_RH.Models.back.Annonce;
public class PDFContrat : PDF
{
    public DetailsEmploye DetailsEmploye { get; set; }
    public Document Document { get; set; }
    public string Path { get; set; }
    private Entreprise Entreprise { get; set; }

    public PDFContrat(String Path, int IdEmploye)
    {
        this.Entreprise = new Entreprise().ObtenirEntreprise();
        this.Path = Path;
        this.DetailsEmploye = new DetailsEmploye { IdEmploye = IdEmploye };
        this.DetailsEmploye = this.DetailsEmploye.ObtenirDetailsEmployeParId();
        this.DetailsEmploye.AjoutSuperieur();
        this.DetailsEmploye.setAvantages();
        this.DetailsEmploye.setHorraire();
        this.DetailsEmploye.setMission();
    }

    public void Header()
    { 
        Font titleFont = new Font(Font.FontFamily.HELVETICA, 21, Font.BOLD);
        Paragraph title = new Paragraph("Contrat", titleFont);
        title.Alignment = Element.ALIGN_CENTER;
        this.Document.Add(title);
        Paragraph contenuContrat = new Paragraph();
        Ligne(contenuContrat, 3);
        contenuContrat.SpacingBefore = 20f;
        contenuContrat.Add(new Chunk($"La société {this.Entreprise.nom}, dont le siège situé à {this.Entreprise.Siege} représentée par Mr/Mme. <<None>>."));
        contenuContrat.Add(new Chunk($"Responsable de {this.DetailsEmploye.Service}."));
        Ligne(contenuContrat, 3);
        this.Document.Add(contenuContrat);
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
        Contenu.Add(new Chunk($"Affirme que Mr (Mme) {this.DetailsEmploye.Nom} {this.DetailsEmploye.Prenom} est en alternance dans notre société" +
                              $" pour une durée de {this.DetailsEmploye.DateFin - this.DetailsEmploye.DateDebut} Mois commencé depuis le {this.DetailsEmploye.DateDebut}" +
                              $" {this.DetailsEmploye.DateFin}, en tant que {this.DetailsEmploye.Poste} au sein du département de {this.DetailsEmploye.Service}."));
        Ligne(Contenu, 3);
        Font font = new Font(Font.FontFamily.HELVETICA, 13, Font.BOLD);
        //Contenu.SpacingBefore = 20f;
        Contenu.Add(new Chunk("Horaire : ", font));
        Table(Contenu);
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"Type de contrat : ", font));
        Contenu.Add(new Chunk($" {this.DetailsEmploye.LibelleContrat}"));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"Sous l'autorité de : ", font));
        Contenu.Add(new Chunk($" {this.DetailsEmploye.Superieur.Nom} {this.DetailsEmploye.Superieur.Prenom}"));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Rénumération : ", font));
        Contenu.Add(new Chunk(this.DetailsEmploye.Salaire + ", " + this.DetailsEmploye.TypeSalaire));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Avantages : ", font));
        foreach (var VARIABLE in this.DetailsEmploye.VAvantages)
        {
            Contenu.Add(new Chunk($"{VARIABLE.Nom}"));     
            Ligne(Contenu, 1);
        }
        Contenu.Add(new Chunk("Lieu de travail : ", font));
        Contenu.Add(new Chunk($"section {this.DetailsEmploye.Service}"));
        Ligne(Contenu, 3);

        Contenu.Add(new Chunk("Au cours de cette période, le contrat pourra être rompu par l'une des deux parties à condition"));
        Contenu.Add(new Chunk("du respect du délai de prévenance."));
        Ligne(Contenu, 3);
        Contenu.Add(new Chunk("Cette période pourrait faire l'objet d'un renouvellement passant à un nouveau contrat."));
        Ligne(Contenu, 2);
        
        Document.Add(Contenu);
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
    }

    public void Build()
    {
        this.Document = new Document();
        PdfWriter.GetInstance(Document, new FileStream(this.Path, FileMode.Create));
        this.Document.Open();
        MemoryStream memoryStream = new MemoryStream();
        this.Header();
        this.Content();
        this.Footer();
        Document.Dispose();
        Document.Close();
        byte[] bytes = memoryStream.ToArray();
    }

}