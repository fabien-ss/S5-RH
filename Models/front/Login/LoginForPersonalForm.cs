using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.Login;

public class LoginForPersonalForm
{
    [Required(ErrorMessage = "Matricule not set")]
    public string matricule { get; set; }
}

