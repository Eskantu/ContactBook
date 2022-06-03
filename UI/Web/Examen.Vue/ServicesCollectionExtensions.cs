using ContactBook.Core.BIZ;
using ContactBook.Core.BIZ.Factory;
using ContactBook.Core.COMMON.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Vue
{
  public static class ServicesCollectionExtensions
  {
    public static void AddManagers(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
      FactoryManager factoryManager = new FactoryManager(connectionString);
      services.AddSingleton<IContactoManager>(x => factoryManager.GetContactoManager());
      services.AddSingleton<ITipoContactoManager>(x => factoryManager.GetTipoContactoManager());
      services.AddSingleton<IEstadoCivilManager>(x => factoryManager.GetEstadoCivilManager());
      services.AddSingleton<IUsuarioManager>(x => factoryManager.GetUsuarioManager());
    }
  }
}
