namespace S5_RH.Models.back.Annonce;

public interface PDF
{
    public void Header();
    public void Content();
    public void Footer();

    public void Build()
    {
        this.Header();
        this.Content();
        this.Footer();
    }
}