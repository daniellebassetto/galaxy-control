using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.ViewModels;

public class RedefinirSenhaViewModel
{
    [Required(ErrorMessage = "Informe a senha atual")]
    public string? SenhaAtual { get; set; }
    [Required(ErrorMessage = "Informe a nova senha")]
    public string? NovaSenha { get; set; }
    [Required(ErrorMessage = "Confirme a nova senha")]
    [Compare("NovaSenha", ErrorMessage = "Senha incorreta")]
    public string? ConfirmacaoNovaSenha { get; set; }
}