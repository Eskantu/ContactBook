
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Core.Auth.Modelos
{
 public class LoginRequest
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
  }
  
}


