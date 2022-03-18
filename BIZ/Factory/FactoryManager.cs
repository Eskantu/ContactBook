using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.BIZ.Factory
{
    public static class FactoryManager
    {
        public static IContactoManager GetContactoManager() => new ContactoManager(FactoryRepository<Contacto>.GetRepository());
        public static ITipoContactoManager GetTipoContactoManager() => new TipoContactoManager(FactoryRepository<TipoContacto>.GetRepository());
        public static IEstadoCivilManager GetEstadoCivilManager() => new EstadoCivilManager(FactoryRepository<EstadoCivil>.GetRepository());
    }
}
