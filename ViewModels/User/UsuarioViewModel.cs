using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class UsuarioViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Informe o nome")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string? Senha { get; set; }
    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string? Email { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAlteracao { get; set; }
}