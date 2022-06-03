using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.BIZ
{
    public class ContactoManager : GenericManager<Contacto>, IContactoManager
    {
        public ContactoManager(IGenericRepository<Contacto> repository) : base(repository)
        {
        }
    }
}
