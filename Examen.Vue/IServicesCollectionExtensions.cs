using Examen.Core.BIZ;
using Examen.Core.COMMON.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Vue
{
    public static class IServicesCollectionExtensions
    {
        public static void AddManagers(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MSSQLServerSomee");
            services.AddSingleton<IContactoManager>(x => Core.BIZ.Factory.FactoryManager.GetContactoManager(connectionString));
            services.AddSingleton<ITipoContactoManager>(x => Core.BIZ.Factory.FactoryManager.GetTipoContactoManager(connectionString));
            services.AddSingleton<IEstadoCivilManager>(x => Core.BIZ.Factory.FactoryManager.GetEstadoCivilManager(connectionString));
        }
    }
}
