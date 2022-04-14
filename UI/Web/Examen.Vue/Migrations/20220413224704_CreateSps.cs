using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Vue.Migrations
{
    public partial class CreateSps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string spUsuarios = @"
    IF OBJECT_ID('SpUsuario')>0
        DROP PROCEDURE SpUsuario;
    GO

    create procedure SpUsuario
        @Opcion INT,
        @Nombre VARCHAR(50) ='',
        @UserName VARCHAR(50)='',
        @ApellidoMaterno VARCHAR(50) ='',
        @ApellidoPaterno VARCHAR(50)  ='',
        @Contrasenia VARCHAR(50)  ='',
        @Email VARCHAR(50)  ='',
        @CreadoPor INT  = 0,
        @IsActive BIT  =0,
        @Modulos VARCHAR(100) ='',
        @IdUsuario INT =0
    AS
    BEGIN
        IF(@Opcion=1)
        BEGIN
            INSERT INTO Usuario
                (Nombre,UserName,ApellidoMaterno,ApellidoPaterno,Contrasenia,Email,CreadoPor,Modulos,IsActive)
            VALUES(@Nombre, @UserName, @ApellidoMaterno, @ApellidoPaterno, @Contrasenia, @Email, @CreadoPor, @Modulos, @IsActive)
        END
        IF(@Opcion=2)
        BEGIN
            UPDATE Usuario SET Nombre=@Nombre, ApellidoMaterno=@ApellidoMaterno, ApellidoPaterno=@ApellidoPaterno, 
            Contrasenia=@Contrasenia,Email=@Email, Modulos=@Modulos, IsActive=@IsActive, UserName=@UserName where IdUsuario=@IdUsuario
        END
        IF(@Opcion=3)
        BEGIN
            delete from Usuario WHERE IdUsuario=@IdUsuario
        END
        IF(@Opcion=4)
        BEGIN
            SELECT *
            FROM Usuario
        END
        IF(@Opcion=5)
        BEGIN
            SELECT *
            from Usuario
            where Contrasenia=@Contrasenia AND (@UserName=UserName OR Email=@Email)
        END
    END";
            migrationBuilder.Sql(spUsuarios);
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
        INSERT INTO Contacto(Nombre,ApellidoPaterno,ApellidoMaterno,Telefono,IdEstadoCivil,IdTipoContacto,Genero) 
        SELECT Nombre=@Nombre, ApellidoPaterno=@ApellidoPaterno, ApellidoMaterno=@ApellidoMaterno, Telefono=@Telefono, 
        IdEstadoCivil=(Select top 1 IdEstadoCivil from EstadoCivil WHERE Nombre=@EstadoCivil),
        IdTipoContacto=(select top 1 IdTipoContacto from TipoContacto where Nombre=@TipoContacto),@Genero

    END

END";
            migrationBuilder.Sql(spContacto);

            string spEstadoCivil = @"  IF OBJECT_ID('SpEstadoCivil')>0
        DROP PROCEDURE SpEstadoCivil;
    GO

    create procedure SpEstadoCivil
        @Opcion INT,
        @Nombre VARCHAR(50) ='',
        @IdEstadoCivil INT =0
    AS
    BEGIN
        IF(@Opcion=1)
        BEGIN
            INSERT INTO EstadoCivil (Nombre) VALUES(@Nombre)
        END
        IF(@Opcion=2)
        BEGIN
            UPDATE EstadoCivil SET Nombre=@Nombre WHERE IdEstadoCivil=@IdEstadoCivil
        END
        IF(@Opcion=3)
        BEGIN
            delete from EstadoCivil WHERE IdEstadoCivil=@IdEstadoCivil
        END
        IF(@Opcion=4)
        BEGIN
            SELECT *
            FROM EstadoCivil
        END
    END";
            migrationBuilder.Sql(spEstadoCivil);

            string spTipoContacto = @"  IF OBJECT_ID('SpTipoContacto')>0
        DROP PROCEDURE SpTipoContacto;
    GO

    create procedure SpTipoContacto
        @Opcion INT,
        @Nombre VARCHAR(50) ='',
        @IdTipoContacto INT =0
    AS
    BEGIN
        IF(@Opcion=1)
        BEGIN
            INSERT INTO TipoContacto (Nombre) VALUES(@Nombre)
        END
        IF(@Opcion=2)
        BEGIN
            UPDATE EstadoCivil SET Nombre=@Nombre WHERE IdEstadoCivil=@IdTipoContacto
        END
        IF(@Opcion=3)
        BEGIN
            delete from TipoContacto WHERE IdTipoContacto=@IdTipoContacto
        END
        IF(@Opcion=4)
        BEGIN
            SELECT *
            FROM TipoContacto
        END
    END";
            migrationBuilder.Sql(spTipoContacto);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
