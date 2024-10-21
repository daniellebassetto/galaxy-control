using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class UsuarioUpdateViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Informe o nome")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string? Email { get; set; }
}