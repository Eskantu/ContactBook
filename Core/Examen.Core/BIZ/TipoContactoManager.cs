using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.BIZ
{
    public class TipoContactoManager : GenericManager<TipoContacto>, ITipoContactoManager
    {
        public TipoContactoManager(IGenericRepository<TipoContacto> repository) : base(repository)
        {
        }
    }
}
