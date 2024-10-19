using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class UserUpdateModel
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Informe o nome")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Informe o login")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }
}