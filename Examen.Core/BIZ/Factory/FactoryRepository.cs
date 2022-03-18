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

        public static IGenericRepository<T> GetRepository(string connectionString) {
            if (_repository is null)
                _repository = new GenericRepository<T>(GetConnection(connectionString));
            return _repository;
        }

        private static IConnection GetConnection(string connectionString) => new Connection(connectionString);
    }
}
