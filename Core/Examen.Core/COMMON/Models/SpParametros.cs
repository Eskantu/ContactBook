using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.COMMON.Models
{

   public class SpParametros
    {
        public SpParametros(string nombre, List<KeyValuePair<string, object>> parametros=null)
        {
            Nombre = nombre;
            Parametros = parametros is null ? new List<KeyValuePair<string, object>>() : parametros;
        }
        /// <summary>
        /// Nombre del SP o Query a ejecutar
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Parametros que requiere el SP o Query para poder ser ejecutado
        /// </summary>
        public List<KeyValuePair<string, object>> Parametros { get; set; }

    }
}
