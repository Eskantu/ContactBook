using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Core.COMMON.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Vue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager _usuarioManager;
        public UsuarioController(IUsuarioManager usuarioManager) => _usuarioManager = usuarioManager;

        // GET: api/Usuario
        [HttpGet]
        public IActionResult Get() => Ok();

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Usuario/5
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
