using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ContactBook.Core.Auth.Modelos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactBook.vue.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FileController : ControllerBase
  {
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileController(IWebHostEnvironment webHostEnvironment)
    {
      _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost]
    public async Task<IActionResult> Post(IFormCollection files)
    {
      if (!files.Files.Any())
      {
        return BadRequest("No files found");
      }
      if (!Directory.Exists(Path.Combine(_webHostEnvironment.ContentRootPath, "uploads")))
      {
        Directory.CreateDirectory(Path.Combine(_webHostEnvironment.ContentRootPath, "uploads"));
      }
      AuthenticationModel user = JsonConvert.DeserializeObject<AuthenticationModel>(HttpContext.Session.GetString("user"));
      foreach (var item in files.Files)
      {

        var filePath = Path.Combine(_webHostEnvironment.
ContentRootPath, "uploads", $"{user.IdUsuario}_{user.Nombre}_{item.FileName}");
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
          await item.CopyToAsync(stream);
        }
      }
      return Ok();
    }
  }
}