
using System.ComponentModel.DataAnnotations;

namespace Examen.Vue.Modelos
{
 public class LoginRequest
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
  }
  
}


