using GalaxyControl.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class UserModel
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Informe o nome")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Informe o login")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }       
    public DateTime RegistrationDate { get; set; }
    public DateTime? ChangeDate { get; set; }

    public bool IsValidPassword(string password)
    {
        return Password == password.GenerateHash(); 
    }

    public void SetHashPassword()
    {
        Password = Password.GenerateHash();
    }

    public void SetNewPassword(string newPassword)
    {
        Password = newPassword.GenerateHash();
    }

    public string GenerateNewPassword()
    {
        string newPassword = Guid.NewGuid().ToString().Substring(0,8);
        Password = newPassword.GenerateHash();
        return newPassword;
    }
}