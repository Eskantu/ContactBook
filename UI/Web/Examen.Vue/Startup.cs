using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Core.BIZ;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Examen.Vue.Modelos;
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
using Examen.Vue.Interfaces;

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
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token= Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            services.AddScoped<IAuthenticateService, TokenAuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSpaStaticFiles(configuration =>
            {
               configuration.RootPath = "clientapp/dist";
            });
            services.AddManagers(Configuration);
            //    var provider = services.BuildServiceProvider();
            //    var myService = provider.GetService<IContactoManager>();
            //    myService.ObtenerTodos(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("@Opcion", 1), })).ForEach(item =>
            //    {
            //        Console.WriteLine($"{item.IdContacto}----->{item.Nombre} {item.ApellidoPaterno} {item.ApellidoMaterno}");
            //    });
            services.AddAuthentication(x=>{
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=>{
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(token.Secret)),
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
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
            app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
