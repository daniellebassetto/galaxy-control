using GalaxyControl.Data;
using GalaxyControl.Models;

namespace GalaxyControl.Repositories;

public class UsuarioRepository(GalaxyControlContext dataBaseContext) : IUsuarioRepository
{
    private readonly GalaxyControlContext _dataBaseContext = dataBaseContext;

    public Usuario Create(Usuario User)
    {
        User.DataCadastro = DateTime.Now;
        User.SetHashPassword();
        _dataBaseContext.Usuarios.Add(User);
        _dataBaseContext.SaveChanges();
        return User;
    }

    public bool Delete(long id)
    {
        Usuario deleteUser = Get(id);

        if (deleteUser == null)
            throw new Exception("Usuário inválido ou inexistente");

        _dataBaseContext.Remove(deleteUser);
        _dataBaseContext.SaveChanges();

        return true;
    }

    public Usuario Get(long id)
    {
        return _dataBaseContext.Usuarios.FirstOrDefault(x => x.Id == id);
    }

    public List<Usuario> GetAll()
    {
        return _dataBaseContext.Usuarios.ToList();
    }

    public Usuario GetLogin(string login)
    {
        return _dataBaseContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
    }

    public Usuario GetLoginAndEmail(string login, string email)
    {
        return _dataBaseContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
    }

    public Usuario RedefinePassword(RedefinirSenhaViewModel redefinePasswordModel)
    {
        Usuario userModel = Get(redefinePasswordModel.UserId) ?? throw new Exception("Houve um erro na atualização da senha, usuário não encontrado");

        if (!userModel.IsValidPassword(redefinePasswordModel.CurrentPassword))
            throw new Exception("Senha atual incorreta");

        if (userModel.IsValidPassword(redefinePasswordModel.NewPassword))
            throw new Exception("Nova senha deve ser diferente da senha atual");

        userModel.SetNewPassword(redefinePasswordModel.NewPassword);
        userModel.DataAlteracao = DateTime.Now;

        _dataBaseContext.Usuarios.Update(userModel);
        _dataBaseContext.SaveChanges();

        return userModel;
    }

    public Usuario Update(Usuario User)
    {
        Usuario updateUser = Get(User.Id) ?? throw new Exception("Usuário inválido ou inexistente");

        updateUser.Nome = User.Nome;            
        updateUser.Login = User.Login;
        updateUser.Email = User.Email;
        updateUser.DataAlteracao = DateTime.Now;

        _dataBaseContext.Update(updateUser);
        _dataBaseContext.SaveChanges();
        return updateUser;
    }
}