using Examen.Core.Auth.Modelos;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Core.COMMON.Interfaces
{
    public interface IUsuarioManager:IGenericManager<Usuario>
    {
        Usuario Login(LoginRequest loginRequest );
    }
}
