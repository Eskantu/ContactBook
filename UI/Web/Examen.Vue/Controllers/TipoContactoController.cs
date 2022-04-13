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
    public class TipoContactoController : ControllerBase
    {
        private readonly ITipoContactoManager _tipoContactoManager;
        public TipoContactoController(ITipoContactoManager tipoContactoManager)
        {
            _tipoContactoManager = tipoContactoManager;
        }
        // GET: api/TipoContacto
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoContactoManager.ObtenerTodos(new SpParametros("select * from TipoContacto")));
        }

        // GET: api/TipoContacto/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_tipoContactoManager.ObtenerTodos(new SpParametros($"select * from TipoContacto where IdTipoContacto = {id}")));
        }

        // POST: api/TipoContacto
        [HttpPost]
        public IActionResult Post(TipoContacto value)
        {
            return Ok(_tipoContactoManager.Crear(new SpParametros($"insert into TipoContacto(Nombre) values({value.Nombre})")));
        }

        // PUT: api/TipoContacto/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TipoContacto value)
        {
            return Ok(_tipoContactoManager.Actualizar(new SpParametros($"UPDATE TipoContacto SET Nombre={value.Nombre} WHERE IdTipoContacto={value.IdTipoContacto}")));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_tipoContactoManager.Eliminar(new SpParametros($"DELETE TipoContacto FROM WHERE IdTipoContacto={id}")));
        }
    }
}
