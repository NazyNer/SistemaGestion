using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestion.Migrations
{
    /// <inheritdoc />
    public partial class Correcionentablausuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Usuarios_UsuarioId_usuario",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_UsuarioId_usuario",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "UsuarioId_usuario",
                table: "Localidades");

            migrationBuilder.RenameColumn(
                name: "ProvinciaNombre",
                table: "Provincias",
                newName: "Provincia_nombre");

            migrationBuilder.RenameColumn(
                name: "LocalidadNo",
                table: "Localidades",
                newName: "Localidad_nombre");

            migrationBuilder.AlterColumn<int>(
                name: "Condicion_iva",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_localidad",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Id_rol",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id_user",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId_localidad",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_usuario",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LocalidadId_localidad",
                table: "Usuarios",
                column: "LocalidadId_localidad");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadId_localidad",
                table: "Usuarios",
                column: "LocalidadId_localidad",
                principalTable: "Localidades",
                principalColumn: "Id_localidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadId_localidad",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_LocalidadId_localidad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_localidad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_user",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LocalidadId_localidad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_usuario",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Provincia_nombre",
                table: "Provincias",
                newName: "ProvinciaNombre");

            migrationBuilder.RenameColumn(
                name: "Localidad_nombre",
                table: "Localidades",
                newName: "LocalidadNo");

            migrationBuilder.AlterColumn<string>(
                name: "Condicion_iva",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Localidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId_usuario",
                table: "Localidades",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_UsuarioId_usuario",
                table: "Localidades",
                column: "UsuarioId_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Usuarios_UsuarioId_usuario",
                table: "Localidades",
                column: "UsuarioId_usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_usuario");
        }
    }
}
