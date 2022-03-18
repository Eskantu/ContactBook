using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.COMMON.Interfaces
{
   public interface IGenericManager<T> where T:class
    {
        T Crear(SpParametros parametros);
        List<T> ObtenerTodos(SpParametros parametros);
        string Errror { get;  }
        bool Actualizar(SpParametros parametros);
        bool Eliminar(SpParametros parametros);
        List<Y> Query<Y>(SpParametros parametros);
    }
}
