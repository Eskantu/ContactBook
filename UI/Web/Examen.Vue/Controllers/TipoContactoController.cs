using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Vue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            return Ok(_tipoContactoManager.ObtenerTodos());
        }

        // GET: api/TipoContacto/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_tipoContactoManager.ObtenerPorId(id));
        }

        // POST: api/TipoContacto
        [HttpPost]
        public IActionResult Post(TipoContacto value)
        {
            return Ok(_tipoContactoManager.Crear(value));
        }

        // PUT: api/TipoContacto
        [HttpPut]
        public IActionResult Put(TipoContacto value)
        {
            return Ok(_tipoContactoManager.Actualizar(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_tipoContactoManager.Eliminar(id));
        }
    }
}
