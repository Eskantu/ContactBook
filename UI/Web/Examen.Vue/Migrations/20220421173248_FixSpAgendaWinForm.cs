using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Vue.Migrations
{
    public partial class FixSpAgendaWinForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 string spContacto = @"
IF(OBJECT_ID('SpAgendaWinForm'))>0
    DROP PROCEDURE SpAgendaWinForm
GO

CREATE PROCEDURE SpAgendaWinForm
    @Opcion INT,
    @Id INT=NULL,
    @Nombre VARCHAR(50)=NULL,
    @ApellidoMaterno VARCHAR(50)=NULL,
    @ApellidoPaterno VARCHAR(50)=NULL,
    @Telefono VARCHAR(50)=NULL,
    @EstadoCivil VARCHAR(50)=NULL,
    @TipoContacto VARCHAR(50)=NULL,
    @Genero VARCHAR(50)=NULL, 
    @FechaNacimiento DATETIME=NULL
AS
BEGIN
    IF(@Opcion=1)
    BEGIN
        SELECT C.IdContacto, 
                C.Nombre, 
                C.ApellidoPaterno, 
                C.ApellidoMaterno, 
                C.Telefono, EC.Nombre AS EstadoCivil, 
                TC.Nombre AS TipoContacto, 
                C.Genero AS Genero,
                DATEDIFF(YEAR,C.FechaNacimiento,GETDATE()) AS Edad,
                C.FechaNacimiento
        FROM Contacto C WITH (NOLOCK) 
        INNER JOIN EstadoCivil EC ON EC.IdEstadoCivil=C.IdEstadoCivil
        INNER JOIN TipoContacto TC ON TC.IdTipoContacto=C.IdTipoContacto
    END
    IF(@Opcion=2)
    BEGIN
        UPDATE C SET C.Nombre=@Nombre, C.ApellidoMaterno=@ApellidoMaterno, C.ApellidoPaterno=@ApellidoPaterno, C.Genero=@Genero, 
            C.IdEstadoCivil = EC.IdEstadoCivil, C.IdTipoContacto = TC.IdTipoContacto FROM Contacto C 
        INNER JOIN EstadoCivil EC ON EC.Nombre=@EstadoCivil
        INNER JOIN TipoContacto TC ON TC.Nombre=@TipoContacto
        WHERE C.IdTipoContacto=@Id
    END
    IF(@Opcion=3)
    BEGIN
        DELETE FROM Contacto WHERE IdContacto = @Id
    END
    IF(@Opcion=4)
    BEGIN
        INSERT INTO Contacto(Nombre,ApellidoPaterno,ApellidoMaterno,Telefono,IdEstadoCivil,IdTipoContacto,Genero,FechaNacimiento) 
        SELECT Nombre=@Nombre, ApellidoPaterno=@ApellidoPaterno, ApellidoMaterno=@ApellidoMaterno, Telefono=@Telefono, 
        IdEstadoCivil=(Select top 1 IdEstadoCivil from EstadoCivil WHERE Nombre=@EstadoCivil),
        IdTipoContacto=(select top 1 IdTipoContacto from TipoContacto where Nombre=@TipoContacto),@Genero,@FechaNacimiento

    END

END";
            migrationBuilder.Sql(spContacto);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
