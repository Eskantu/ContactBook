using ContactBook.Core.COMMON.Models;
using ContactBook.Vue;
using ContactBook.Vue.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactBook.Tests
{
    [TestCaseOrderer("Examen.Tests.PriorityOrder", "Examen.Tests")]
    public class IntegrationControllerTest
    {
        [Fact, TestPriority(-1)]
        public void UsuarioControllerTest()
        {
           //await Utils.GenerateDataBase();
            Assert.Equal(1, 1);

            // Create controller
            // var controller = new UsuarioController();
            // Add user
            // porbar los metodos del controller
            // Check: does get all return added users
        }
    }
}
