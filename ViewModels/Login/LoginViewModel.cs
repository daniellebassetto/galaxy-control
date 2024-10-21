using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o login")]
    public string? Login { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string? Senha { get; set; }
}