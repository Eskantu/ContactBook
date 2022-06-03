using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.BIZ.Factory
{
    public  class FactoryManager
    {
        private readonly IConnection connection;
        public FactoryManager(string connectionString)
        {
            connection ??= new ConnectionBuild().GetConnection(connectionString);
        }
      
        public  IContactoManager GetContactoManager() => new ContactoManager(FactoryRepository<Contacto>.GetRepository(connection));
        public  ITipoContactoManager GetTipoContactoManager() => new TipoContactoManager(FactoryRepository<TipoContacto>.GetRepository(connection));
        public  IEstadoCivilManager GetEstadoCivilManager() => new EstadoCivilManager(FactoryRepository<EstadoCivil>.GetRepository(connection));
        public IUsuarioManager GetUsuarioManager() => new UsuarioManager(FactoryRepository<Usuario>.GetRepository(connection));

    }
}
