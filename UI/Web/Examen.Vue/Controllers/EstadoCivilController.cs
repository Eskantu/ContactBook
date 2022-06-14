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
    public class EstadoCivilController : ControllerBase
    {
        private readonly IEstadoCivilManager _estadoCivilManager;
        public EstadoCivilController(IEstadoCivilManager estadoCivilManager)
        {
            _estadoCivilManager = estadoCivilManager;
        }
        // GET: api/EstadoCivil
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estadoCivilManager.ObtenerTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/EstadoCivil/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_estadoCivilManager.ObtenerPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/EstadoCivil
        [HttpPost]
        public IActionResult Post(EstadoCivil value)
        {
            try
            {
                return Ok(_estadoCivilManager.Crear(value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/EstadoCivil/5
        [HttpPut]
        public IActionResult Put(EstadoCivil value)
        {
            try
            {
                return Ok(_estadoCivilManager.Actualizar(value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete(List<int> ids)
        {
            try
            {
                string idsToDelete = "";
                ids.ForEach(item => 
                {
                    idsToDelete += $"{item},";
                });
                return Ok(_estadoCivilManager.Eliminar(ids[0]));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
