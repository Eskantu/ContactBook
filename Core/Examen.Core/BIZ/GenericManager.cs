using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.BIZ
{
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;
        public GenericManager(IGenericRepository<T> repository) => _repository = repository;

        public string Errror => _repository.Error;

        public bool Actualizar(SpParametros parametros) => _repository.Update(parametros);

        public bool Crear(SpParametros parametros) => _repository.Create(parametros);

        public bool Eliminar(SpParametros parametros) => _repository.Delete(parametros);

        public List<T> ObtenerTodos(SpParametros parametros) => _repository.Read(parametros);

        public virtual List<Y> Query<Y>(SpParametros parametros) => _repository.Query<Y>(parametros);
    }
}
