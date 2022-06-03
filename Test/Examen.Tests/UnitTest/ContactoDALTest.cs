using System;
using System.Collections.Generic;
using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using Xunit;

namespace ContactBook.Tests.UnitTest
{
  [TestCaseOrderer("Examen.Tests.PriorityOrder", "Examen.Tests")]
  public class ContactoDALTest : GenericTest<Contacto>
  {
    IGenericRepository<TipoContacto> _tipoContactoRepository;
    IGenericRepository<EstadoCivil> _estadoCivilRepository;
    public ContactoDALTest() : base(GenerateRepository<Contacto>.GetTRepository())
    {
      _tipoContactoRepository = GenerateRepository<TipoContacto>.GetTRepository();
      _estadoCivilRepository = GenerateRepository<EstadoCivil>.GetTRepository();
    }

    [Fact, TestPriority(1)]
    public void CrearContactoTest()
    {
      Assert.True(_tipoContactoRepository.Create(new SpParametros("SpTipoContacto", new List<KeyValuePair<string, object>>
        {
          new KeyValuePair<string, object>("@Opcion", 1),
          new KeyValuePair<string, object>("@Nombre", "TC Unit Test"),
        })), $"Tipo de contacto no creado Error -> {base._repository.Error}");

      Assert.True(_estadoCivilRepository.Create(new SpParametros("SpEstadoCivil", new List<KeyValuePair<string, object>>
        {
          new KeyValuePair<string, object>("@Opcion", 1),
          new KeyValuePair<string, object>("@Nombre", "EC Unit Test"),
        })), $"Estado civil no creado Error -> {base._repository.Error}");

      Assert.True(base.Create(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
      {
        new KeyValuePair<string, object>("@Opcion", 4),
        new KeyValuePair<string, object>("@Nombre", "Unit Test"),
        new KeyValuePair<string, object>("@ApellidoMaterno", "Unit Test"),
        new KeyValuePair<string, object>("@ApellidoPaterno", "Unit Test"),
        new KeyValuePair<string, object>("@Telefono", "123456789"),
        new KeyValuePair<string, object>("@EstadoCivil", "EC Unit Test"),
        new KeyValuePair<string, object>("@TipoContacto", "TC Unit Test"),
        new KeyValuePair<string, object>("@FechaNacimiento", DateTime.Now),
      })));
    }

    [Fact, TestPriority(2)]
    public void ReadContactos()
    {
      List<Contacto> contactos = ObtenerContactos();
      Assert.True(contactos.Count > 0, "No se encontraron contactos");
    }

    [Fact, TestPriority(3)]
    public void UpdateContacto()
    {
      List<Contacto> contactos = ObtenerContactos();
      Contacto contacto = contactos[0];
      contacto.Nombre = "Unit Test Update";
      Assert.True(base.Update(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
      {
        new KeyValuePair<string, object>("@Opcion", 2),
        new KeyValuePair<string, object>("@Id", contacto.IdContacto),
        new KeyValuePair<string, object>("@Nombre", contacto.Nombre),
        new KeyValuePair<string, object>("@ApellidoMaterno", contacto.ApellidoMaterno),
        new KeyValuePair<string, object>("@ApellidoPaterno", contacto.ApellidoPaterno),
        new KeyValuePair<string, object>("@Telefono", contacto.Telefono),
        new KeyValuePair<string, object>("@EstadoCivil", contacto.EstadoCivil),
        new KeyValuePair<string, object>("@TipoContacto", contacto.TipoContacto),
        new KeyValuePair<string, object>("@FechaNacimiento", contacto.FechaNacimiento),
      })));
    }

    [Fact, TestPriority(4)]
    public void DeleteContacto()
    {
      List<Contacto> contactos = ObtenerContactos();
      Contacto contacto = contactos[0];
      Assert.True(base.Delete(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
      {
        new KeyValuePair<string, object>("@Opcion", 3),
        new KeyValuePair<string, object>("@Id", contacto.IdContacto),
      })));
      Assert.True(_tipoContactoRepository.Delete(new SpParametros("SpTipoContacto", new List<KeyValuePair<string, object>>
        {
          new KeyValuePair<string, object>("@Opcion", 3),
          new KeyValuePair<string, object>("@IdTipoContacto", 1),
        })), $"No se eliminaron los datos Error -> {_tipoContactoRepository.Error}");

         Assert.True( base.Update(new SpParametros("SpEstadoCivil", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",2),
                new KeyValuePair<string, object>("@Nombre","Unit Test Modificada"),
                new KeyValuePair<string, object>("@IdEstadoCivil",1),
            })),$"No se modificaron los datos Error -> {_estadoCivilRepository.Error}");
    }
    
    private List<Contacto> ObtenerContactos()
    {
      List<Contacto> contactos = new List<Contacto>();
      contactos = base.Read(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
      {
        new KeyValuePair<string, object>("@Opcion", 1),
      }));
      return contactos;
    }
  }

}