using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class RedefinirSenhaPeloLoginViewModel
{
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [MaxLength(256, ErrorMessage = "O e-mail deve ter no máximo 256 caracteres")]
    public string? Email { get; set; }
}