using System.Collections.Generic;

namespace Examen.Core.Auth.Modelos
{
 public class AuthenticationModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
        public string Foto { get; set; }
        public string Token { get; set; }
    }
}