using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Vue.Migrations
{
    public partial class FixSpTipoContacto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
           UPDATE TipoContacto SET Nombre=@Nombre WHERE IdTipoContacto=@IdTipoContacto
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
