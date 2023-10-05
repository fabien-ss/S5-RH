using iTextSharp.text;
using iTextSharp.text.pdf;
namespace S5_RH.Models.back.Annonce;
public class PDFContrat
{
    private string Titre { get; set; }
    private string Path { get; set; }
    public string Societe { get; set; }
    public string Adresse { get; set; }
    public string Responsable { get; set; }
    public string Employe { get; set; }
    public string Duree { get; set; }
    public string DateDebut { get; set; }
    public string DateFin { get; set; }
    public string Poste { get; set; }
    public string Departement { get; set; }
    public string Horaire { get; set; }
    public string Salaire { get; set; }
    public string avantages { get; set; }
    private Document Document { get; set; }

    public PDFContrat(string titre, string path, string societe, string adresse, string responsable, string employe, string duree, string dateDebut, string dateFin, string poste, string departement, string horaire, string salaire, string avantages)
    {
        Titre = titre;
        Path = path;
        Societe = societe;
        Adresse = adresse;
        Responsable = responsable;
        Employe = employe;
        Duree = duree;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Poste = poste;
        Departement = departement;
        Horaire = horaire;
        Salaire = salaire;
        this.avantages = avantages;
        this.Document = new Document();
        PdfWriter.GetInstance(Document, new FileStream(this.Path, FileMode.Create));
        this.Document.Open();
    }

    public PDFContrat()
    {
        Titre = "Contrat de Travail";
        Path = "Doc.pdf";
        Societe = "Soins";
        Adresse = "Lot K7";
        Responsable = "Jean Pierre";
        Employe = "RAKOTO Jean Marc";
        Duree = "3";
        DateDebut = "12 Septembre 2023";
        DateFin = "12 Novembre 2023";
        Poste = "Developpeur Fullstacl";
        Departement = "Informatique";
        Horaire = "8H à 16 H";
        Salaire = "123123123";
        this.avantages = avantages;
        this.Document = new Document();
        PdfWriter.GetInstance(Document, new FileStream(this.Path, FileMode.Create));
        this.Document.Open();
    }

    public void Header()
    {   
        // Ajoute le titre du contrat
        Font titleFont = new Font(Font.FontFamily.HELVETICA, 21, Font.BOLD);
        Paragraph title = new Paragraph(this.Titre, titleFont);
        title.Alignment = Element.ALIGN_CENTER;
        this.Document.Add(title);
        Paragraph contenuContrat = new Paragraph();
        Ligne(contenuContrat, 3);
        // Ajoute les détails du contrat
        //Font contentFont = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
        Font contentFont = new Font(Font.FontFamily.HELVETICA, 16, Font.NORMAL);
        contenuContrat.SpacingBefore = 20f;
        contenuContrat.Add(new Chunk($"La société {Societe}, dont le siège situé à {Adresse}"));
        Ligne(contenuContrat, 2);
        contenuContrat.Add(new Chunk($"Représentée par Mr/Mme. {Responsable}."));
        Ligne(contenuContrat, 2);
        contenuContrat.Add(new Chunk($"Responsable de {Departement}."));
        Ligne(contenuContrat, 4);
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
        Contenu.Add(new Chunk($"Affirme que Mr (Mme) {Employe} est en alternance dans notre société"));
        Ligne(Contenu, 2);
        Contenu.Add(new Chunk($"pour une durée de {Duree} Mois commencé depuis le {DateDebut}"));
        Ligne(Contenu, 2);
        Contenu.Add(new Chunk($"{DateFin}, en tant que {Poste} au sein du département de {Departement}."));
        Ligne(Contenu, 4);
        
        Contenu.SpacingBefore = 20f;
        Contenu.Add(new Chunk("Horaire : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Contenu.Add(new Chunk(this.Horaire));
        Ligne(Contenu, 2);
        Contenu.Add(new Chunk("Rénumération : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Contenu.Add(new Chunk(this.Salaire));
        Ligne(Contenu, 2);
        Contenu.Add(new Chunk("Avantages : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Contenu.Add(new Chunk(this.avantages));
        Ligne(Contenu, 2);
        Contenu.Add(new Chunk("Lieu de travail : ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        Contenu.Add(new Chunk($"{Societe}, section {Departement}"));
        Ligne(Contenu, 4);

        Contenu.Add(new Chunk("Au cours de cette période, le contrat pourra être rompu par l'une"));
        Ligne(Contenu, 2);
        Contenu.Add(new Chunk("partie, à tout moment, sous réserve du respect du délai de prévenance"));
        Ligne(Contenu, 4);
        Contenu.Add(new Chunk("Cette période pourrait faire l'objet d'un renouvellement passant à un contrat de travail."));
        Ligne(Contenu, 2);
        Document.Add(Contenu);
    }
    
    public void Build()
    {
        this.Header();
        this.Content();
        Document.Dispose();
        Document.Close();
    }

}