namespace GalaxyControl.ViewModels;

public class UsuarioViewModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Senha { get; set; }
    public string? Email { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAlteracao { get; set; }
}