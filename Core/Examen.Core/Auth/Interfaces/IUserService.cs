
using Examen.Core.Auth.Modelos;

namespace Examen.Core.Auth.Interfaces
{
  public interface IUserService
    {
      bool IsValid(LoginRequest req);
    }
}
