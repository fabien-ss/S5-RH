namespace S5_RH.Models.Exception;

public class CongeAnneeInvalide : InvalidTimeZoneException
{
    public CongeAnneeInvalide(string message) : base(message) { }
}

