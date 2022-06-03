using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.COMMON.Models
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string TipoContacto { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
