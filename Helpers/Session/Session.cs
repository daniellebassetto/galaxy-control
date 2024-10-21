using GalaxyControl.Models;
using Newtonsoft.Json;

namespace GalaxyControl.Helpers;

public class Session(IHttpContextAccessor httpContextAccessor) : ISession
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public void CreateUserSession(string userSerialize)
    {
        _httpContextAccessor.HttpContext!.Session.SetString("loggedUserSession", userSerialize);
    }

    public Usuario? GetUserSession()
    {
        string userSession = _httpContextAccessor.HttpContext!.Session.GetString("loggedUserSession")!;

        if (string.IsNullOrEmpty(userSession))
            return null;

        return JsonConvert.DeserializeObject<Usuario>(userSession);
    }

    public void RemoveUserSession()
    {
        _httpContextAccessor.HttpContext!.Session.Remove("loggedUserSession");
    }
}