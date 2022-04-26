using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Examen.Core.Auth.Interfaces;
using Examen.Core.Auth.Modelos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Examen.Vue.Modelos
{
  public class TokenAuthenticationService : IAuthenticateService
  {
    private readonly IUserService _userService;
    private readonly TokenManagement _tokenManagement;
    public TokenAuthenticationService(IUserService userService, IOptions<TokenManagement> tokenManagement)
    {
      _userService = userService;
      _tokenManagement = tokenManagement.Value;
    }
    public bool IsAuthenticated(LoginRequest request, out AuthenticationModel authenticationModel)
    {
      authenticationModel=null;
      if (!_userService.IsValid(request))
        return false;
      authenticationModel = new AuthenticationModel
      {
        Apellidos = "Escalante",
        Email="example@example.com",
        Foto="https://randomuser.me/api/portraits/men/81.jpg",
        IdUsuario=1,
        IsAuthenticated=true,
        Message="User authenticated",
        Nombre="Mario",
        UserName="Eskantu",
        Roles=new List<string> { "Admin" },
        Token=GenerateToken(request)
      };
    
      return true;
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
     string  token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
      return token;
    }
  }
}