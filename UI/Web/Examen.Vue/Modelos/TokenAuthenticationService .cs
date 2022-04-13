using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Examen.Vue.Interfaces;
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
        Foto="https://www.google.com/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjNy7KHhM_eAhVFJ1AKHUqcD_4QjRx6BAgBEAU&url=https%3A%2F%2Fwww.google.com%2F&psig=AOvVaw2_X_Z_Z_q_Z_z_Zq_Z_z_z&ust=1589788240876623",
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