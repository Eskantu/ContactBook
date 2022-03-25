using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Vue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoManager _contactoManager;
        public ContactoController(IContactoManager contactoManager)
        {
            _contactoManager = contactoManager;
        }
        // GET: api/Contacto
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_contactoManager.ObtenerTodos(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@Opcion",1)
                })));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Contacto/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_contactoManager.ObtenerTodos(new SpParametros(@$" 
                SELECT C.IdContacto, 
                    C.Nombre, 
                    C.ApellidoPaterno, 
                    C.ApellidoMaterno, 
                    C.Telefono, EC.Nombre AS EstadoCivil, 
                    TC.Nombre AS TipoContacto, 
                    C.Genero AS Genero,
                    DATEDIFF(YEAR,C.FechaNacimiento,GETDATE()) AS Edad,
                    C.FechaNacimiento
                FROM Contacto C WITH (NOLOCK) 
                   INNER JOIN EstadoCivil EC ON EC.IdEstadoCivil=C.IdEstadoCivil
                   INNER JOIN TipoContacto TC ON TC.IdTipoContacto=C.IdTipoContacto WHERE C.IdContacto = {id}")));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Contacto
        [HttpPost]
        public IActionResult Post(Contacto value)
        {
            try
            {
                return Ok(_contactoManager.Crear(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@Opcion",4),
                    new KeyValuePair<string, object>("@Id",0),
                    new KeyValuePair<string, object>("@Nombre",value.Nombre),
                    new KeyValuePair<string, object>("@ApellidoMaterno",value.ApellidoMaterno),
                    new KeyValuePair<string, object>("@ApellidoPaterno",value.ApellidoPaterno),
                    new KeyValuePair<string, object>("@Telefono",value.Telefono),
                    new KeyValuePair<string, object>("@EstadoCivil",value.EstadoCivil),
                    new KeyValuePair<string, object>("@TipoContacto",value.TipoContacto),
                    new KeyValuePair<string, object>("@Genero",value.Genero),
                    new KeyValuePair<string, object>("@FechaNacimiento",value.FechaNacimiento)
                })));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Contacto/5
        [HttpPut("{id}")]
        public IActionResult Put(Contacto value)
        {
            try
            {
                return Ok(_contactoManager.Actualizar(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@Opcion",4),
                    new KeyValuePair<string, object>("@Id",value.IdContacto),
                    new KeyValuePair<string, object>("@Nombre",value.Nombre),
                    new KeyValuePair<string, object>("@ApellidoMaterno",value.ApellidoMaterno),
                    new KeyValuePair<string, object>("@ApellidoPaterno",value.ApellidoPaterno),
                    new KeyValuePair<string, object>("@Telefono",value.Telefono),
                    new KeyValuePair<string, object>("@EstadoCivil",value.EstadoCivil),
                    new KeyValuePair<string, object>("@TipoContacto",value.TipoContacto),
                    new KeyValuePair<string, object>("@Genero",value.Genero),
                    new KeyValuePair<string, object>("@FechaNacimiento",value.FechaNacimiento)
                })));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_contactoManager.Eliminar(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@Opcion",3),
                    new KeyValuePair<string, object>("@Id",id),
                })));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
