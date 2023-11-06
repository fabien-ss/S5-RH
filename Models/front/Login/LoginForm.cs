using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.Login;

public class LoginForm
{
    [Required]
    public string Email{ get; set;}
    [Required]
    public string Password { get; set;}
}