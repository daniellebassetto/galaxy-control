using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class RegistrarUsuarioViewModel
{
    [Required(ErrorMessage = "Informe o nome")]
    [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [MaxLength(256, ErrorMessage = "O e-mail deve ter no máximo 256 caracteres")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string? Senha { get; set; }
    [Required(ErrorMessage = "Informe a confirmação de senha")]
    public string? ConfirmacaoSenha { get; set; }
}