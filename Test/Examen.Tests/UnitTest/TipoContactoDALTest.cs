using System;
using System.Collections.Generic;
using System.Linq;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using Xunit;

namespace Examen.Tests.UnitTest
{
  [TestCaseOrderer("Examen.Tests.PriorityOrder", "Examen.Tests")]
  public class TipoContactoDALTest : GenericTest<TipoContacto>
  {
    public TipoContactoDALTest() : base(GenerateRepository<TipoContacto>.GetTRepository())
    {
    }

    [Fact, TestPriority(1)]
    public void CrearTipoContactoTest()
    {
      Assert.True(base.Create(new SpParametros("SpTipoContacto", new List<KeyValuePair<string, object>>
        {
          new KeyValuePair<string, object>("@Opcion", 1),
          new KeyValuePair<string, object>("@Nombre", "Unit Test"),
        })), $"Tipo de contacto no creado Error -> {base._repository.Error}");
    }

    [Fact, TestPriority(2)]
    public void ReadTipoContactoTest()
    {
      List<TipoContacto> entidades = ObtenerTiposContacto();
      Assert.True(entidades.Count > 0, $"No se encontraron entidades Error -> {base._repository.Error}");
    }

    private List<TipoContacto> ObtenerTiposContacto()
    {
      return base.Read(new SpParametros("SpTipoContacto", new List<KeyValuePair<string, object>>
        {
          new KeyValuePair<string, object>("@Opcion", 4),
        }));
    }

    [Fact, TestPriority(3)]
    public void UpdateTipoContactoTest()
    {
      var datos = ObtenerTiposContacto();
      Assert.True(base.Update(new SpParametros("SpTipoContacto", new List<KeyValuePair<string, object>>
        {
          new KeyValuePair<string, object>("@Opcion", 2),
          new KeyValuePair<string, object>("@Nombre", "Unit Test Modificada"),
          new KeyValuePair<string, object>("@IdTipoContacto", datos.Select(p => p.IdTipoContacto).FirstOrDefault(u => u != 0)),
        })), $"No se modificaron los datos Error -> {base._repository.Error}");
    }

    [Fact, TestPriority(4)]
    public void DeleteTipoContactoTest()
    {
      var datos = ObtenerTiposContacto();
      Assert.True(base.Delete(new SpParametros("SpTipoContacto", new List<KeyValuePair<string, object>>
        {
          new KeyValuePair<string, object>("@Opcion", 3),
          new KeyValuePair<string, object>("@IdTipoContacto", datos.Select(p => p.IdTipoContacto).FirstOrDefault(u => u != 0)),
        })), $"No se eliminaron los datos Error -> {base._repository.Error}");
    }
  }
}