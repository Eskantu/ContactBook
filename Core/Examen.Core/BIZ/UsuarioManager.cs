using Examen.Core.Auth.Modelos;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen.Core.BIZ
{
  public class UsuarioManager : GenericManager<Usuario>, IUsuarioManager
  {
    public UsuarioManager(IGenericRepository<Usuario> repository) : base(repository)
    {
    }

    public Usuario Login(LoginRequest loginRequest)
    {
        return _repository.Query<Usuario>(new SpParametros(
            "SpUsuario",
            new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion", 5),
                new KeyValuePair<string, object>("@UserName", loginRequest.UserName),
                new KeyValuePair<string, object>("@Email", loginRequest.UserName),
                new KeyValuePair<string, object>("@Contrasenia", loginRequest.Password)
            }
        )).FirstOrDefault();
    }
  }
}
