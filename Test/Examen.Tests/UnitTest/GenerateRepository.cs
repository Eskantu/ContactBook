using Examen.Core.BIZ.Factory;
using Examen.Core.COMMON.Interfaces;
using Examen.Vue;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Tests.UnitTest
{
    public static class GenerateRepository<T> where T : class
    {
        private static IGenericRepository<T> _repository;
        private static Database database;
        public static IGenericRepository<T> GetTRepository()
        {
            if (database is null)
            {
                database ??= new Database();
               database.CreateDataBase().Wait();
            }
            return _repository ??= FactoryRepository<T>.GetRepository(GetConnection());
        }



        private static IConnection _connection;
        private static IConnection GetConnection()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            return _connection ??= new ConnectionBuild().GetConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }
    }

    public class Database
    {
        public async Task<bool> CreateDataBase() => await Utils.GenerateDataBase();
    }
}
