using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using Microsoft.AspNetCore.Authorization;
using ContactBook.Core.Auth.Interfaces;
using ContactBook.Core.Auth.Modelos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ContactBook.Vue.Modelos;

namespace ContactBook.Vue.Controllers
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
      if (_authService.IsAuthenticated(request, out AuthenticationModel user))
      {
        string value = JsonConvert.SerializeObject(user);
        HttpContext.Session.SetString("user", value);
        return Ok(user);
      }
      else
      {
        return BadRequest("Invalid credentials");
      }
    }

    [HttpPost, Route("getSession")]
    public IActionResult GetSession([FromBody] TokenClient token)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Invalid Model");
      }
      if (string.IsNullOrEmpty(token.Token) || token.Token=="undefined")
      {
        return Unauthorized("Session expired");
      }
      if(_authService.ValidateToken(token.Token) && !string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
      {
        return Ok(JsonConvert.DeserializeObject<AuthenticationModel>(HttpContext.Session.GetString("user")));
      }
      else
      {
        return Unauthorized("Session expired");
      }
    }

  }
}