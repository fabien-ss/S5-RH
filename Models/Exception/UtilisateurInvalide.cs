using Org.BouncyCastle.Security;

namespace S5_RH.Models.Exception;

public class UtilisateurInvalide : InvalidParameterException
{
    public UtilisateurInvalide(string message) : base(message) { }
}