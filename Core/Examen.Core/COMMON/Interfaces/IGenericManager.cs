using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.COMMON.Interfaces
{
   public interface IGenericManager<T> where T:class
    {
        bool Crear(T entidad);
        List<T> ObtenerTodos();
        T ObtenerPorId(int id);
        string Errror { get;  }
        bool Actualizar(T entidad);
        bool Eliminar(int id);
        List<Y> Query<Y>(SpParametros parametros);
    }
}
