using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class RedefinirSenhaPeloLoginViewModel
{
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string? Email { get; set; }
}