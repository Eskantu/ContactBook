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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager _usuarioManager;
        public UsuarioController(IUsuarioManager usuarioManager) => _usuarioManager = usuarioManager;

        // GET: api/Usuario
        [HttpGet]
        public IActionResult Get()
        {
            if (_usuarioManager.ObtenerTodos() is List<Usuario> usuarios)
            {
                return Ok(usuarios);
            }
            else
            {

                return BadRequest(_usuarioManager.Errror);
            }
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_usuarioManager.ObtenerPorId(id) is Usuario usuarioFound)
            {
                return Ok(usuarioFound);
            }
            else
            {

                return BadRequest(_usuarioManager.Errror);
            }
        }

        // POST: api/Usuario
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] Usuario value)
        {
            if (_usuarioManager.Crear(value))
            {
                return Ok();
            }
            else
            {
                return BadRequest(_usuarioManager.Errror);
            }
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public IActionResult Put([FromBody] Usuario value)
        {
            if (_usuarioManager.Actualizar(value))
                return Ok();
            else
                return BadRequest(_usuarioManager.Errror);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_usuarioManager.Eliminar(id))
                return Ok();
            else
               return BadRequest(_usuarioManager.Errror);
        }
    }
}
