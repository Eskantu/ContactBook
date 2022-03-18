using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.BIZ
{
    public class ContactoManager : GenericManager<Contacto>, IContactoManager
    {
        public ContactoManager(IGenericRepository<Contacto> repository) : base(repository)
        {
        }
    }
}
