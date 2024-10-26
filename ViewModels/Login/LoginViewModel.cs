using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [MaxLength(256, ErrorMessage = "O e-mail deve ter no máximo 256 caracteres")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string? Senha { get; set; }
}