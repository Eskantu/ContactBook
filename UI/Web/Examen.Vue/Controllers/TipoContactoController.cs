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
            return Ok(_tipoContactoManager.ObtenerTodos(new Core.COMMON.Models.SpParametros("select * from TipoContacto")));
        }

        // GET: api/TipoContacto/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_tipoContactoManager.ObtenerTodos(new Core.COMMON.Models.SpParametros($"select * from TipoContacto where IdTipoContacto = {id}")));
        }

        // POST: api/TipoContacto
        [HttpPost]
        public void Post(TipoContacto value)
        {
        }

        // PUT: api/TipoContacto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
