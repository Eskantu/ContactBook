using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Vue.Migrations
{
  public partial class AddContactoTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      var table = @"
CREATE TABLE Contacto(
	IdContacto int IDENTITY(1,1) NOT NULL,
	Nombre varchar(50) NULL,
	ApellidoPaterno varchar(50) NULL,
	ApellidoMaterno varchar(50) NULL,
	Telefono varchar(50) NULL,
	IdEstadoCivil int NULL,
	IdTipoContacto int NULL,
	FechaNacimiento datetime NULL,
	Genero varchar(50) NULL,
)

ALTER TABLE Contacto ADD CONSTRAINT Pk_Contacto_IdContacto PRIMARY KEY CLUSTERED(IdContacto)

ALTER TABLE Contacto  WITH CHECK ADD  CONSTRAINT Fk_Contacto_IdEstadoCivil FOREIGN KEY(IdEstadoCivil)
REFERENCES EstadoCivil (IdEstadoCivil)
GO
ALTER TABLE Contacto CHECK CONSTRAINT Fk_Contacto_IdEstadoCivil
GO
ALTER TABLE Contacto  WITH CHECK ADD  CONSTRAINT Fk_Contacto_IdTipoContacto FOREIGN KEY(IdTipoContacto)
REFERENCES TipoContacto (IdTipoContacto)
GO
ALTER TABLE Contacto CHECK CONSTRAINT Fk_Contacto_IdTipoContacto
GO";
      migrationBuilder.Sql(table);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }

}
