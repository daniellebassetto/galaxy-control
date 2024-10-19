using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Informe o login")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string Password { get; set; }
}