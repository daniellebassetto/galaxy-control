using GalaxyControl.Helpers;

namespace GalaxyControl.Models;

public class Usuario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Senha { get; set; }
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
        string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
        Senha = newPassword.GenerateHash();
        return newPassword;
    }
}