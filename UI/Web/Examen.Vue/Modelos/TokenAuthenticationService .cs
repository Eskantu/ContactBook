using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Examen.Core.Auth.Interfaces;
using Examen.Core.Auth.Modelos;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Examen.Vue.Modelos
{
  public class TokenAuthenticationService : IAuthenticateService
  {
    private readonly IUserService _userService;
    private readonly TokenManagement _tokenManagement;
    private readonly IUsuarioManager _usuarioManager;
    public TokenAuthenticationService(IUserService userService, IUsuarioManager usuarioManager, IOptions<TokenManagement> tokenManagement)
    {
      _userService = userService;
      _usuarioManager = usuarioManager;
      _tokenManagement = tokenManagement.Value;
    }
    public bool IsAuthenticated(LoginRequest request, out AuthenticationModel authenticationModel)
    {
      authenticationModel = null;
      if (_usuarioManager.Login(request) is Usuario usuario)
      {

        authenticationModel = new AuthenticationModel
        {
          ApellidoMaterno=usuario.ApellidoMaterno,
          ApellidoPaterno=usuario.ApellidoPaterno,
          Email = usuario.Email,
          Foto = "https://randomuser.me/api/portraits/men/81.jpg",
          IdUsuario = usuario.IdUsuario,
          IsAuthenticated = true,
          Message = "User authenticated",
          Nombre = usuario.Nombre,
          UserName = usuario.UserName,
          Roles = new List<string> { "Admin" },
          Token = GenerateToken(request)
        };

        return true;
      }
      return false;
    }

    private string GenerateToken(LoginRequest request)
    {
      var claims = new[]
    {
          new Claim(ClaimTypes.Name, request.UserName)
      };
      var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_tokenManagement.Secret));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var jwtToken = new JwtSecurityToken(
          _tokenManagement.Issuer,
          _tokenManagement.Audience,
          claims,
          expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
          signingCredentials: credentials
      );
      string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
      return token;
    }


    
   public bool ValidateToken(string token)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var validationParameters=GetValidationParameters();
      try
      {
        var user = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        return true;
      }
      catch (System.Exception)
      {
        return false;
      }
    }

    private TokenValidationParameters GetValidationParameters()
    {
      return new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_tokenManagement.Secret)),
        ValidateIssuer = false,
        ValidateAudience = false,

      };
    }
  }
}