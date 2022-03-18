using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.COMMON.Interfaces
{
   public interface IGenericRepository<T> where T:class
    {
        bool Create(SpParametros parametros);
        List<T> Read(SpParametros parametros);
        bool Update(SpParametros parametros);
        bool Delete(SpParametros parametros);
        string Error { get; }
        List<Y> Query<Y>(SpParametros parametros);
    }
}
