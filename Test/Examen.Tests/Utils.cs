﻿using Examen.Vue;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Tests
{
    public static class Utils
    {
         
    public static async Task GenerateDataBase()
        {
            // Create a DB context
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            var optionsBuilder = new DbContextOptionsBuilder<DbContextEFCore>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            var context = new DbContextEFCore(optionsBuilder.Options);

            //Detel a DB
            await context.Database.EnsureDeletedAsync();
            //await context.Database.EnsureCreatedAsync();
            await context.Database.MigrateAsync();
        }
    }
}
