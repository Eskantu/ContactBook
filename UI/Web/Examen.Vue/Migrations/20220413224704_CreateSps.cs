using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Vue.Migrations
{
    public partial class CreateSps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"
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
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
