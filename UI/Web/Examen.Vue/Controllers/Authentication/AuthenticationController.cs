using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Microsoft.AspNetCore.Authorization;
using Examen.Vue.Modelos;
using Examen.Vue.Interfaces;

namespace Examen.Vue.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
     private readonly IAuthenticateService _authService;
    public AuthenticationController(IAuthenticateService authService)
    {
      this._authService = authService;
    }

    [AllowAnonymous]
    [HttpPost, Route("requestToken")]
    public IActionResult RequestToken([FromBody] LoginRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Invalid Model");
      }
      string token;
      if (_authService.IsAuthenticated(request, out token))
      {
        return Ok(token);
      }
      else
      {
        return BadRequest("Invalid credentials");
      }
    }
  }
}