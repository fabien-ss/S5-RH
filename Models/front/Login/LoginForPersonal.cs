using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.Login;

public class LoginForPersonal
{
    [Required(ErrorMessage = "Matricule not set")]
    public string matricule { get; set; }
}

