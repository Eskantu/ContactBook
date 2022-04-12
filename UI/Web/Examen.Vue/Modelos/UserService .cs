using Examen.Vue.Interfaces;

namespace Examen.Vue.Modelos
{
  public class UserService : IUserService
  {
    public bool IsValid(LoginRequest req)
    {
      return true;
    }
  }
}
