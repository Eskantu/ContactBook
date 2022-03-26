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
        public static IContactoManager GetContactoManager() => new ContactoManager(FactoryRepository<Contacto>.GetRepository(connectionString));
        public static ITipoContactoManager GetTipoContactoManager() => new TipoContactoManager(FactoryRepository<TipoContacto>.GetRepository(connectionString));
        public static IEstadoCivilManager GetEstadoCivilManager() => new EstadoCivilManager(FactoryRepository<EstadoCivil>.GetRepository(connectionString));

        private readonly IConnection connection;

        public static void BuildConnection(string connectionSting) =new ConnectionBuild()
    }
}
