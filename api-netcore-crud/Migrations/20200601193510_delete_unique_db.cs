using Microsoft.EntityFrameworkCore.Migrations;

namespace api_netcore_crud.Migrations
{
    public partial class delete_unique_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Paises_PaisId",
                table: "Provincias");

            migrationBuilder.AlterColumn<string>(
                name: "NomProv",
                table: "Provincias",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodProv",
                table: "Provincias",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomPais",
                table: "Paises",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodPais",
                table: "Paises",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "UQ_CodProv",
                table: "Provincias",
                column: "CodProv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_NomProv",
                table: "Provincias",
                column: "NomProv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_CodPais",
                table: "Paises",
                column: "CodPais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_NomPais",
                table: "Paises",
                column: "NomPais",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Paises_PaisId",
                table: "Provincias",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Paises_PaisId",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "UQ_CodProv",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "UQ_NomProv",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "UQ_CodPais",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "UQ_NomPais",
                table: "Paises");

            migrationBuilder.AlterColumn<string>(
                name: "NomProv",
                table: "Provincias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CodProv",
                table: "Provincias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NomPais",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CodPais",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Paises_PaisId",
                table: "Provincias",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
