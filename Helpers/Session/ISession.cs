using GalaxyControl.Models;

namespace GalaxyControl.Helpers;

public interface ISession
{
    void CreateUserSession(string userSerialize);
    void RemoveUserSession();
    UserModel? GetUserSession();
}