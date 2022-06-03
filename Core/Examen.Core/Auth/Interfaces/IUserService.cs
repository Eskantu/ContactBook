
using ContactBook.Core.Auth.Modelos;

namespace ContactBook.Core.Auth.Interfaces
{
  public interface IUserService
    {
      bool IsValid(LoginRequest req);
    }
}
