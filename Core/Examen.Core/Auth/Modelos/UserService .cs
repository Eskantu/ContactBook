

using ContactBook.Core.Auth.Interfaces;

namespace ContactBook.Core.Auth.Modelos
{
  public class UserService : IUserService
  {
    public bool IsValid(LoginRequest req)
    {
      return true;
    }
  }
}
