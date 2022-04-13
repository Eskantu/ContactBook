using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Core.COMMON.Models
{
   public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Contrasenia { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IsActive { get; set; }
        public int CreadoPor { get; set; }
        public string Modulos { get; set; }

    }
}
