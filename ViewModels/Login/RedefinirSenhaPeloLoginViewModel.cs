using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class RedefinirSenhaPeloLoginViewModel
{
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string? Email { get; set; }
}