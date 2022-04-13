

using Examen.Core.Auth.Interfaces;

namespace Examen.Core.Auth.Modelos
{
  public class UserService : IUserService
  {
    public bool IsValid(LoginRequest req)
    {
      return true;
    }
  }
}
