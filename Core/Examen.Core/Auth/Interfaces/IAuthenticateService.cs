


using ContactBook.Core.Auth.Modelos;

namespace ContactBook.Core.Auth.Interfaces
{

  public interface IAuthenticateService
  {
    bool IsAuthenticated(LoginRequest request, out AuthenticationModel authenticationModel);
    bool ValidateToken(string token);
  }
}