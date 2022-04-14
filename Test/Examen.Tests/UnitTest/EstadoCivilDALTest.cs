using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Examen.Tests.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Examen.Tests.UnitTest
{
    [TestCaseOrderer("Examen.Tests.PriorityOrder", "Examen.Tests")]
    public class EstadoCivilDALTest : GenericTest<EstadoCivil>
    {
        public EstadoCivilDALTest() : base(GenerateRepository<EstadoCivil>.GetTRepository())
        {
        }

        [Fact,TestPriority(1)]
        public void CrearEstadoCivilTest()
        {
           Assert.True( base.Create(new SpParametros("SpEstadoCivil", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",1),
                new KeyValuePair<string, object>("@Nombre","Unit Test"),
            })),$"Estado civil no creado Error -> {base._repository.Error}");
        }

        [Fact, TestPriority(2)]
        public void ReadEstadoCivilTest()
        {
            List<EstadoCivil> entidades = ObtenerEstadosCiviles();
            Assert.True(entidades.Count > 0, $"No se encontraron entidades Error -> {base._repository.Error}");
        }

        private List<EstadoCivil> ObtenerEstadosCiviles()
        {
            return base.Read(new SpParametros("SpEstadoCivil", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",4),
            }));
        }

        [Fact, TestPriority(3)]
        public void UpdateEstadoCivilTest()
        {
            var datos = ObtenerEstadosCiviles();
           Assert.True( base.Update(new SpParametros("SpEstadoCivil", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",2),
                new KeyValuePair<string, object>("@Nombre","Unit Test Modificada"),
                new KeyValuePair<string, object>("@IdEstadoCivil",datos.Select(p=>p.IdEstadoCivil).FirstOrDefault(u=>u!=0)),
            })),$"No se modificaron los datos Error -> {base._repository}");
        }

        [Fact, TestPriority(4)]
        public void DeleteEstadoCivilTest()
        {
            var datos = ObtenerEstadosCiviles();
          Assert.True(  base.Delete(new SpParametros("SpEstadoCivil", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",1),
                  new KeyValuePair<string, object>("@IdEstadoCivil",datos.Select(p=>p.IdEstadoCivil).FirstOrDefault(u=>u!=0)),
            })),$"registro no eliminado Error -> {base._repository.Error}");
        }
    }
}
