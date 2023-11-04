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
    private double? TauxHoraire;
    private Font fontHeader;
    private double Cnaps = 0;
    private double Sanitaire = 0;
    private double TotalIRSA = 0;
    private double Droits;
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
    public PDFFicheDePaie(String Path, int IdEmploye)
    {
        this.Path = Path;
        bdd.orm.fiche.DetailsEmploye de = new DetailsEmploye { IdEmploye = IdEmploye };
        this.DetailsEmploye = de.ObtenirDetailsEmployeParId();
        de.AjoutSuperieur();
        this.fontHeader = new Font(Font.FontFamily.HELVETICA, 11);
    }
    public void Header()
    {
        Font titleFont = new Font(Font.FontFamily.HELVETICA, 21, Font.BOLD);
        Paragraph title = new Paragraph("Fiche de paie", titleFont);
        title.Alignment = Element.ALIGN_CENTER;
        Ligne(title, 1);
        this.Document.Add(title);
        
        PdfPTable table = new PdfPTable(2);
        
        table.TotalWidth = this.Document.PageSize.Width - this.Document.LeftMargin;
       
        table.DefaultCell.Border = PdfPCell.NO_BORDER;
        
        Paragraph Contenu = new Paragraph();
        
        Contenu.SpacingBefore = 20f;
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk($"Nom : ", new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Nom}", this.fontHeader));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Prénom : ", new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Prenom}", this.fontHeader));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Matricule : ", new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.Matricule}", this.fontHeader));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Date d'embauche : ", new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.DateDebut}", this.fontHeader));
        Ligne(Contenu, 1);
        Contenu.Add(new Chunk("Ancienneté : ", new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
        Contenu.Add(new Chunk($"{this.DetailsEmploye.CalculateAnciennete()} jours", this.fontHeader));
        
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
        this.TauxJournalier = Decimal.ToDouble(Math.Round((decimal)(this.DetailsEmploye.Salaire/30)));
        Contenu2.Add(new Chunk("Taux Journaliers : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu2.Add(new Chunk($"{TauxJournalier}", this.fontHeader));
        Ligne(Contenu2, 1);
        this.TauxHoraire = Decimal.ToDouble(Math.Round((decimal)(this.DetailsEmploye.Salaire/173.33)));
        Contenu2.Add(new Chunk("Taux horaires : ", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Contenu2.Add(new Chunk($"{TauxHoraire }", this.fontHeader));
        
        table.AddCell(Contenu2);
        this.Document.Add(table);
    }

    public void Content()
    {

        PdfPTable table = new PdfPTable(4);
        // table.TotalWidth = this.Document.PageSize.Width - this.Document.LeftMargin - this.Document.RightMargin;

        PdfPCell designation = new PdfPCell(new Phrase("Designation", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        designation.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell nombre = new PdfPCell(new Phrase("Nombre", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        nombre.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell taux = new PdfPCell(new Phrase("Taux", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        taux.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell Montant = new PdfPCell(new Phrase("Montant", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Montant.HorizontalAlignment = Element.ALIGN_CENTER;

        table.AddCell(designation);  
        table.AddCell(nombre);  
        table.AddCell(taux);  
        table.AddCell(Montant);  
        

        table.AddCell("Salaire");  
        table.AddCell("1 mois");  
        table.AddCell("");  
        table.AddCell($"{this.DetailsEmploye.Salaire}");  
        
        table.AddCell("Absence deductible");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell($"{this.TauxJournalier}"); 

        table.AddCell("Prime de rendement");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell(""); 
        
        table.AddCell("Prime d'anciennete");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell(""); 
        
        table.AddCell("Heures supplémentaires majorées de 30%");  
        table.AddCell("");  
        table.AddCell("");
        table.AddCell($"{Decimal.ToDouble(Math.Round((decimal)(TauxHoraire * 1.3)))}");

        table.AddCell("Heures supplémentaires majorées de 40%");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell($"{Decimal.ToDouble(Math.Round((decimal)(TauxHoraire * 1.4)))}"); 
        
        table.AddCell("Heures supplémentaires majorées de 50% ");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell($"{Decimal.ToDouble(Math.Round((decimal)(TauxHoraire * 1.5)))}"); 
        
        table.AddCell("Heures supplémentaires majorées de 100%");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell($"{Decimal.ToDouble(Math.Round((decimal)(TauxHoraire * 2)))}"); 
        
        table.AddCell("Majoration pour heures de nuit");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell($"{Decimal.ToDouble(Math.Round((decimal)(TauxHoraire * 0.3)))}"); 
        
        table.AddCell("Primes diverses");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell(""); 
        
        table.AddCell("Rappels sur période antérieure");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell(""); 
        
        table.AddCell("Droits de congés");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell($"{this.TauxJournalier}"); 
        
        table.AddCell("Droits de préavis");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell("");        
        
        table.AddCell("Indemnités de licenciement");  
        table.AddCell("");  
        table.AddCell(""); 
        table.AddCell($"{this.TauxJournalier}");         

        PdfPCell salaireBrut = new PdfPCell(new Phrase("Salaire Brut", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        salaireBrut.Colspan = 3;
        salaireBrut.HorizontalAlignment = Element.ALIGN_RIGHT;
        salaireBrut.Border = PdfPCell.NO_BORDER;
        
        table.AddCell(salaireBrut); 
        table.AddCell($"{this.DetailsEmploye.Salaire}");         
        
        getCNaPS();

        PdfPCell cnaps = new PdfPCell(new Phrase("Retenue CNaPS"));
        cnaps.Colspan = 2;
        cnaps.HorizontalAlignment = Element.ALIGN_CENTER;

        table.AddCell(cnaps);  
        table.AddCell(""); 
        table.AddCell($"{this.Cnaps}");   

        PdfPCell sanitaire = new PdfPCell(new Phrase("Retenue sanitaire"));
        sanitaire.Colspan = 2;
        sanitaire.HorizontalAlignment = Element.ALIGN_CENTER;
        this.Sanitaire = Decimal.ToDouble(Math.Round((decimal)(this.DetailsEmploye.Salaire * 0.01)));
        table.AddCell(sanitaire);  
        table.AddCell(""); 
        table.AddCell($"{this.Sanitaire}");         
        
        PdfPCell IRSA = new PdfPCell(new Phrase("Tranche IRSA INF 350 0000"));
        IRSA.Colspan = 2;
        IRSA.HorizontalAlignment = Element.ALIGN_CENTER;
        double irsa1 = 0;
        table.AddCell(IRSA);  
        table.AddCell(""); 
        table.AddCell("");         

        if(this.DetailsEmploye.Salaire > 350001 && this.DetailsEmploye.Salaire < 400000){
            PdfPCell IRSA2 = new PdfPCell(new Phrase("Tranche IRSA I DE 350 001 à 400 000"));
            IRSA2.Colspan = 2;
            IRSA2.HorizontalAlignment = Element.ALIGN_CENTER;
            double irsa2 = 50000*0.05;
            table.AddCell(IRSA2);  
            table.AddCell("5%"); 
            table.AddCell($"{irsa2}"); 
            this.TotalIRSA += irsa2;
        }        
    
        if(this.DetailsEmploye.Salaire > 400001 && this.DetailsEmploye.Salaire < 500000){
            PdfPCell IRSA3 = new PdfPCell(new Phrase("Tranche IRSA I DE 400 001 à 500 000"));
            IRSA3.Colspan = 2;
            IRSA3.HorizontalAlignment = Element.ALIGN_CENTER;
            double irsa3 = 100000*0.1;
            table.AddCell(IRSA3);  
            table.AddCell("10%"); 
            table.AddCell($"{irsa3}");   
            this.TotalIRSA += irsa3;      
        }

        if(this.DetailsEmploye.Salaire > 500001 && this.DetailsEmploye.Salaire < 600000){
            PdfPCell IRSA4 = new PdfPCell(new Phrase("Tranche IRSA I DE 500 001 à 600 000"));
            IRSA4.Colspan = 2;
            IRSA4.HorizontalAlignment = Element.ALIGN_CENTER;
            double irsa4 = 100000*0.15;
            table.AddCell(IRSA4);  
            table.AddCell("15%"); 
            table.AddCell($"{irsa4}"); 
            this.TotalIRSA += irsa4;        
        }
        if(this.DetailsEmploye.Salaire > 600000){
            PdfPCell IRSA5 = new PdfPCell(new Phrase("Tranche IRSA SUP 600 0000"));
            IRSA5.Colspan = 2;
            IRSA5.HorizontalAlignment = Element.ALIGN_CENTER;
            double irsa5 = 0;
            table.AddCell(IRSA5);  
            table.AddCell("20%"); 
            table.AddCell($"{irsa5}");      
            this.TotalIRSA += irsa5;     
        }
         
        PdfPCell total = new PdfPCell(new Phrase("Total IRSA",  new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        total.Colspan = 2;
        total.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(total);   
        table.AddCell(""); 
        table.AddCell($"{this.TotalIRSA}");         

        PdfPCell retenues = new PdfPCell(new Phrase("Total des retenues",  new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        retenues.Colspan = 3;
        retenues.HorizontalAlignment = Element.ALIGN_RIGHT;
        retenues.Border = PdfPCell.NO_BORDER;
        table.AddCell(retenues); 
        table.AddCell($"{this.getTotalRetenues()}");         
          
        PdfPCell autres = new PdfPCell(new Phrase("Autre indemnitées",  new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        autres.Colspan = 3;
        autres.HorizontalAlignment = Element.ALIGN_RIGHT;
        autres.Border = PdfPCell.NO_BORDER;
        table.AddCell(autres);  
        table.AddCell("");         
        
        PdfPCell net = new PdfPCell(new Phrase("Net a payer ",  new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        net.Colspan = 3;
        net.HorizontalAlignment = Element.ALIGN_RIGHT;
        net.Border = PdfPCell.NO_BORDER;
        table.AddCell(net); 
        table.AddCell($"{this.getNetAPayer()}");         
          
        PdfPCell montantImposable = new PdfPCell(new Phrase("Montant imposable",  new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        net.HorizontalAlignment = Element.ALIGN_RIGHT;
        table.AddCell("Montant imposable");  
        table.AddCell($"{this.getMontantImposable()}");    
          
        PdfPCell mode = new PdfPCell(new Phrase("Mode de paiment ",  new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        mode.HorizontalAlignment = Element.ALIGN_RIGHT;
        mode.Border = PdfPCell.NO_BORDER;
        PdfPCell mode2 = new PdfPCell(new Phrase("Virement/Chèque",  new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        mode2.HorizontalAlignment = Element.ALIGN_RIGHT;
        mode2.Border = PdfPCell.NO_BORDER;
        table.AddCell(mode);  
        table.AddCell(mode2); 

        this.Document.Add(Chunk.NEWLINE);
        this.Document.Add(table);
        
    }

    public void Footer()
    {
        PdfPTable table = new(2);
        table.TotalWidth = this.Document.PageSize.Width - this.Document.LeftMargin - this.Document.RightMargin;
       
        table.DefaultCell.Border = PdfPCell.NO_BORDER;

        Paragraph contenu = new Paragraph();
        Paragraph contenu2 = new Paragraph();
        Ligne(contenu, 1);
        contenu.Add(new Chunk("L'employeur", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        Ligne(contenu2, 1);
        contenu2.Add(new Chunk("L'employé(e)", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));
        
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

    public double getTotalRetenues(){
        double res = this.TotalIRSA + this.Cnaps + this.Sanitaire;
        return res;
    }

    public void getCNaPS(){
        if((this.DetailsEmploye.Salaire*0.01) < 20000){
            this.Cnaps = (double)(this.DetailsEmploye.Salaire*0.01);
        }else{
            this.Cnaps = 20000;
        }

    }
    public double getMontantImposable(){
        double res = (double)(DetailsEmploye.Salaire - this.Cnaps - this.Sanitaire);
        return  res;
    }
    public double getNetAPayer(){
        double res = (double)(this.DetailsEmploye.Salaire - this.getTotalRetenues());
        return  res;
    }
}