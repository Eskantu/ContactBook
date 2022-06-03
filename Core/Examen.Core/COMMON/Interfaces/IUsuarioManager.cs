using ContactBook.Core.Auth.Modelos;
using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBook.Core.COMMON.Interfaces
{
    public interface IUsuarioManager:IGenericManager<Usuario>
    {
        Usuario Login(LoginRequest loginRequest );
    }
}
