using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Vue.Controllers
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
    public IActionResult Get() => Ok(_usuarioManager.ObtenerTodos(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("@Opcion",4)
        })));

    // GET: api/Usuario/5
    [HttpGet("{id}")]
    public IActionResult Get(int id) => Ok(_usuarioManager.ObtenerTodos(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("@Opcion",4)
        })).Where(usuario => usuario.IdUsuario == id).FirstOrDefault(x => x != null));

    // POST: api/Usuario
    [HttpPost]
    public IActionResult Post([FromBody] Usuario value)
    {
      var r = _usuarioManager.Crear(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
      {
            new KeyValuePair<string, object>("@Opcion",1),
            new KeyValuePair<string, object>("@Nombre",value.Nombre),
            new KeyValuePair<string, object>("@UserName",value.UserName),
            new KeyValuePair<string, object>("@ApellidoMaterno",value.ApellidoMaterno),
            new KeyValuePair<string, object>("@ApellidoPaterno",value.ApellidoPaterno),
            new KeyValuePair<string, object>("@Contrasenia",value.Contrasenia),
            new KeyValuePair<string, object>("@Email",value.Email),
            new KeyValuePair<string, object>("@CreadoPor",value.CreadoPor),
            new KeyValuePair<string, object>("@IsActive",value.IsActive),
            new KeyValuePair<string, object>("@Modulos",string.IsNullOrEmpty( value.Modulos)?"":value.Modulos),
      }));
      if (r) { return Ok(); }
      else{
        return BadRequest(_usuarioManager.Errror);
      }
    }

    // PUT: api/Usuario/5
    [HttpPut]
    public IActionResult Put([FromBody] Usuario value) => Ok(_usuarioManager.Actualizar(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("@Opcion",2),
            new KeyValuePair<string, object>("@Nombre",value.Nombre),
            new KeyValuePair<string, object>("@UserName",value.UserName),
            new KeyValuePair<string, object>("@ApellidoMaterno",value.ApellidoMaterno),
            new KeyValuePair<string, object>("@ApellidoPaterno",value.ApellidoPaterno),
            new KeyValuePair<string, object>("@Contrasenia",value.Contrasenia),
            new KeyValuePair<string, object>("@Email",value.Email),
            new KeyValuePair<string, object>("@CreadoPor",value.CreadoPor),
            new KeyValuePair<string, object>("@IsActive",value.IsActive),
            new KeyValuePair<string, object>("@Modulos",string.IsNullOrEmpty( value.Modulos)?"":value.Modulos),
            new KeyValuePair<string, object>("@IdUsuario",value.IdUsuario),
        })));

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) => Ok(_usuarioManager.Eliminar(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("@Opcion",3),
            new KeyValuePair<string, object>("@IdUsuario",id),
        })));
  }
}
