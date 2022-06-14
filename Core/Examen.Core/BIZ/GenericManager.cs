using ContactBook.Core.COMMON.Enumeraciones;
using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.BIZ
{
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;
        public GenericManager(IGenericRepository<T> repository) => _repository = repository;

        public string Errror => _repository.Error;

        public bool Actualizar(T entidad) => _repository.Update(entidad.CrearParametros<T>(Accion.Actualizar));

        public bool Crear(T entidad) => _repository.Create(entidad.CrearParametros<T>(Accion.Crear));

        public bool Eliminar(int id) => _repository.Delete(CrearParametros(Accion.Eliminar));

        public List<T> ObtenerTodos() => _repository.Read(CrearParametros(Accion.Obtener));

        private SpParametros CrearParametros(Accion accion)
        {
            Type type = typeof(T);
            string sp = $"Sp{type.Name}";
            return new SpParametros(sp, new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("@Opcion", accion == Accion.Obtener ? 4 : 3) });
        }

        public virtual List<Y> Query<Y>(SpParametros parametros) => _repository.Query<Y>(parametros);

        public T ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
