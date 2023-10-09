using iTextSharp.text;
using iTextSharp.text.pdf;

namespace S5_RH.Models.back.Annonce;

public interface PDF
{
    public void Header(); // en tête
    public void Content(); // contenu
    public void Footer(); // footer

    public void Tabulation(Paragraph ctx, int number)
    {
        for (int i = 0; i < number; i++)
        {
            ctx.Add(Chunk.SPACETABBING);
        }
    }
    public void Build()
    {
        this.Header();
        this.Content();
        this.Footer();
    }
    public void Table(Paragraph ctx, string[] colonne, object[][] data)
    {
        Font font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
        PdfPTable table = new PdfPTable(colonne.Length);
        // ecriture des noms de colonne
        for (int i = 0; i < colonne.Length; i++)
        {
            table.AddCell(colonne[i]);
        } 
        // ecriture des lignes
        for(int i = 0; i< data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                table.AddCell((PdfPCell)data[i][j]);
            }
        }
        ctx.Add(table);
    }
    public void Ligne(Paragraph contenu,int nombre)
    {
        for (int i = 0; i < nombre; i++)
        {
            contenu.Add(Chunk.NEWLINE);
        }
    }
}