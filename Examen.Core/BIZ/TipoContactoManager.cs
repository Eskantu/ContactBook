using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.BIZ
{
    public class TipoContactoManager : GenericManager<TipoContacto>, ITipoContactoManager
    {
        public TipoContactoManager(IGenericRepository<TipoContacto> repository) : base(repository)
        {
        }
    }
}
