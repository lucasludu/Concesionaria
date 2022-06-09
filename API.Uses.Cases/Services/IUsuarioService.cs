using API.Core.Business.Authentication.Request;
using API.Core.Business.Authentication.Response;

namespace API.Uses.Cases.Services
{
    public interface IUsuarioService
    {
        UserResponse Registrar(UserRequest usuario, string password);
        UserResponse Login(string email, string password);
        string GetToken(UserResponse usuario);
    }
}
