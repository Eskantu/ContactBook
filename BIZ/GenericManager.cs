using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.BIZ
{
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public GenericManager(IGenericRepository<T> repository) => _repository = repository;

        public string Errror => _repository.Error;

        public bool Actualizar(SpParametros parametros) => _repository.Update(parametros);

        public T Crear(SpParametros parametros) => _repository.Create(parametros);

        public bool Eliminar(SpParametros parametros) => _repository.Delete(parametros);

        public List<T> ObtenerTodos(SpParametros parametros) => _repository.Read(parametros);
    }
}
