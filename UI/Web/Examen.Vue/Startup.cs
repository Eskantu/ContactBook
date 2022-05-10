using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Core.BIZ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VueCliMiddleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Examen.Core.Auth.Modelos;
using Examen.Core.Auth.Interfaces;
using Microsoft.OpenApi.Models;

namespace Examen.Vue
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
#if DEBUG
      string connectionString = Configuration.GetConnectionString("DevlopConnection");
#else
      string connectionString = Configuration.GetConnectionString("ProductionConnection");
#endif
      services.AddDbContext<DbContextEFCore>(options => options.UseSqlServer(connectionString));

      services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
      var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
      services.AddScoped<IAuthenticateService, Modelos.TokenAuthenticationService>();
      services.AddScoped<IUserService, UserService>();
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "clientapp/dist";
      });
      services.AddManagers(Configuration, connectionString);
      //    var provider = services.BuildServiceProvider();
      //    var myService = provider.GetService<IContactoManager>();
      //    myService.ObtenerTodos(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("@Opcion", 1), })).ForEach(item =>
      //    {
      //        Console.WriteLine($"{item.IdContacto}----->{item.Nombre} {item.ApellidoPaterno} {item.ApellidoMaterno}");
      //    });
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          //ValidateLifetime = true,
          //ClockSkew = TimeSpan.Zero,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(token.Secret)),
          ValidIssuer=token.Issuer,
          ValidAudience=token.Audience,
          ValidateIssuer = true,
          ValidateAudience = true
        };
      });
      services.AddMvc()
     .AddSessionStateTempDataProvider();
      services.AddSession();

      var contact = new OpenApiContact()
      {
        Name = "Mario Escalante",
        Email = "marioescalante3@gmail.com",
        Url = new Uri("mailto:marioescalante3@gmail.com")
      };

      var info = new OpenApiInfo()
      {
        Version = "v1",
        Title = "ContactBook API",
        Description = "API que da acceso a los datos de la agenda y otros servicios",
        Contact = contact,
      };

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", info);
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          In = ParameterLocation.Header,
          Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}",
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
            {
              Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
            }
           },
           new string[] { }
         }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }


      app.UseRouting();
      app.UseSession();
      app.UseSpaStaticFiles();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactBook V1");
      });

      app.UseSpa(spa =>
      {
        if (env.IsDevelopment())
          spa.Options.SourcePath = "clientapp";
        else
          spa.Options.SourcePath = "clientapp/dist";

        if (env.IsDevelopment())
        {
          spa.UseVueCli(npmScript: "serve");
        }

      });
    }
  }
}
