using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Core.BIZ
{
    public class UsuarioManager : GenericManager<Usuario>, IUsuarioManager
    {
        public UsuarioManager(IGenericRepository<Usuario> repository) : base(repository)
        {
        }
    }
}
