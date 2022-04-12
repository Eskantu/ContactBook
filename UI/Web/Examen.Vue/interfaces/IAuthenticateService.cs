
using Examen.Vue.Modelos;

namespace Examen.Vue.Interfaces
{

  public interface IAuthenticateService
  {
    bool IsAuthenticated(LoginRequest request, out string token);
  }
}