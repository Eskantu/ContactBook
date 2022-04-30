


using Examen.Core.Auth.Modelos;

namespace Examen.Core.Auth.Interfaces
{

  public interface IAuthenticateService
  {
    bool IsAuthenticated(LoginRequest request, out AuthenticationModel authenticationModel);
    bool ValidateToken(string token);
  }
}