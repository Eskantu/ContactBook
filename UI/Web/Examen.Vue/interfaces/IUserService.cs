using Examen.Vue.Modelos;

namespace Examen.Vue.Interfaces
{
  public interface IUserService
    {
      bool IsValid(LoginRequest req);
    }
}
