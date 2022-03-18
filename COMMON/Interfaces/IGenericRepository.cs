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
        T Create(SpParametros parametros);
        List<T> Read(SpParametros parametros);
        bool Update(SpParametros parametros);
        bool Delete(SpParametros parametros);
        string Error { get; }
    }
}
