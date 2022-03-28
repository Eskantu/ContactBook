using Examen.Core.COMMON.Interfaces;
using Examen.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.BIZ.Factory
{
    public static class FactoryRepository<T> where T:class
    {
        private static IGenericRepository<T> _repository;

        public static IGenericRepository<T> GetRepository(IConnection connection) {
            if (_repository is null)
                _repository = new GenericRepository<T>(connection);
            return _repository;
        }

    }

   public class ConnectionBuild
    {

        private IConnection _connection;
        public IConnection GetConnection(string connectionString) => _connection ??= new Connection(connectionString);

    }
}
