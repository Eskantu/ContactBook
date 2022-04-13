using Examen.Core.COMMON.Models;
using Examen.Vue;
using Examen.Vue.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Examen.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public async Task UsuarioControllerTest()
        {
            // Create a DB context
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            var optionsBuilder = new DbContextOptionsBuilder<DbContextEFCore>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            var context = new DbContextEFCore(optionsBuilder.Options);

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            Assert.Equal(1, 1);
            // Create controller
            // var controller = new UsuarioController();
            // Add user
            // porbar los metodos del controller
            // Check: does get all return added users
        }
    }
}
