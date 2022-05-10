using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Core.BIZ;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Examen.Vue
{
  public class Program
  {
    [Obsolete]
    public static void Main(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", false, true)
      .Build();
#if DEBUG
      string connectionString = configuration.GetConnectionString("DevlopConnection");
#else
      string connectionString = configuration.GetConnectionString("ProductionConnection");
#endif

      Log.Logger = new LoggerConfiguration()
      .WriteTo.
      MSSqlServer(connectionString, "Logs", autoCreateSqlTable: true, 
      restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
      .CreateLogger();



      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>()
              .UseSerilog();

            });
  }
}
