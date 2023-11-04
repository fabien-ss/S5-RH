namespace S5_RH.Models.Authentification;

public class Authentification
{
    public static Boolean checkUser(string email, string password)
    {
        if (email.Equals("1@gmail.com") & password.Equals("password")) return true;
        return false;
    }
}

