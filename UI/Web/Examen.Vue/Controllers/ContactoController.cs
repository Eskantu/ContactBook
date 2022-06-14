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
                return Ok(_contactoManager.ObtenerTodos());
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
                return Ok(_contactoManager.ObtenerPorId(id));
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
                return Ok(_contactoManager.Crear(value));
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
                return Ok(_contactoManager.Actualizar(value));
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
                return Ok(_contactoManager.Eliminar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
