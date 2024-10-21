using GalaxyControl.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Informe o nome")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Informe o login")]
    public string? Login { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string? Senha { get; set; }
    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string? Email { get; set; }       
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAlteracao { get; set; }

    public bool IsValidPassword(string password)
    {
        return Senha == password.GenerateHash(); 
    }

    public void SetHashPassword()
    {
        Senha = Senha?.GenerateHash();
    }

    public void SetNewPassword(string newPassword)
    {
        Senha = newPassword.GenerateHash();
    }

    public string GenerateNewPassword()
    {
        string newPassword = Guid.NewGuid().ToString().Substring(0,8);
        Senha = newPassword.GenerateHash();
        return newPassword;
    }
}