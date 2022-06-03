using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ContactBook.Tests.UnitTest
{
    [TestCaseOrderer("Examen.Tests.PriorityOrder", "Examen.Tests")]
    public class UsuarioDALTest : GenericTest<Usuario>
    {
        public UsuarioDALTest() : base(GenerateRepository<Usuario>.GetTRepository())
        {

        }

        [Fact, TestPriority(1)]
        public void CrearUsuarioTest()
        {
            var result = base.Create(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",1),
                new KeyValuePair<string, object>("@Nombre","UnitTestUser"),
                new KeyValuePair<string, object>("@UserName","UTU"),
                new KeyValuePair<string, object>("@ApellidoMaterno","Test"),
                new KeyValuePair<string, object>("@ApellidoPaterno","Unit"),
                new KeyValuePair<string, object>("@Contrasenia","XyZ2@"),
                new KeyValuePair<string, object>("@Email","example@test.com"),
                new KeyValuePair<string, object>("@CreadoPor",0),
                new KeyValuePair<string, object>("@IsActive",0),
                new KeyValuePair<string, object>("@Modulos",""),
            }));

            Assert.True(result, $"Usuario no creado: {base._repository.Error}");
        }

        [Fact, TestPriority(2)]
        public void ReadUsuarioTest()
        {
            List<Usuario> usuarios = ObtenerUsuarios();
            Assert.True(usuarios.Count == 1, "No se obtuvo el usuario creado");
        }

        private List<Usuario> ObtenerUsuarios()
        {
            return base.Read(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",4)
            }));
        }

        [Fact, TestPriority(3)]
        public void UpdateUsuarioTest()
        {
            var usuarios = ObtenerUsuarios();
            var result = base.Update(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",2),
                new KeyValuePair<string, object>("@Nombre","UnitTestUser Modificado"),
                new KeyValuePair<string, object>("@UserName","UTU"),
                new KeyValuePair<string, object>("@ApellidoMaterno","Test"),
                new KeyValuePair<string, object>("@ApellidoPaterno","Unit"),
                new KeyValuePair<string, object>("@Contrasenia","XyZ2@"),
                new KeyValuePair<string, object>("@Email","example@test.com"),
                new KeyValuePair<string, object>("@CreadoPor",0),
                new KeyValuePair<string, object>("@IsActive",0),
                new KeyValuePair<string, object>("@Modulos",""),
                new KeyValuePair<string, object>("@IdUsuario",usuarios.Select(u=>u.IdUsuario).FirstOrDefault(p=>p!=0)),
            }));
            Assert.True(result, $"Usuario no modiicado: {base._repository.Error}");
        }

        [Fact, TestPriority(4)]
        public void DeleteUsuarioTest()
        {
            var usuarios = ObtenerUsuarios();
            var result = base.Delete(new SpParametros("SpUsuario", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion",3),
                new KeyValuePair<string, object>("@IdUsuario",usuarios.Select(u=>u.IdUsuario).FirstOrDefault(p=>p!=0))
            }));
            Assert.True(result, $"Usuario no eliminado: {base._repository.Error}");
        }
    }
}
