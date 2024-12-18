using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class CommessaCliente1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDipendentiCommesse_AppCommissions_CommessaId",
                table: "AppDipendentiCommesse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCommissions",
                table: "AppCommissions");

            migrationBuilder.RenameTable(
                name: "AppCustomers",
                newName: "AppCliente");

            migrationBuilder.RenameTable(
                name: "AppCommissions",
                newName: "AppCommessa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCliente",
                table: "AppCliente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCommessa",
                table: "AppCommessa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDipendentiCommesse_AppCommessa_CommessaId",
                table: "AppDipendentiCommesse",
                column: "CommessaId",
                principalTable: "AppCommessa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDipendentiCommesse_AppCommessa_CommessaId",
                table: "AppDipendentiCommesse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCommessa",
                table: "AppCommessa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCliente",
                table: "AppCliente");

            migrationBuilder.RenameTable(
                name: "AppCommessa",
                newName: "AppCommissions");

            migrationBuilder.RenameTable(
                name: "AppCliente",
                newName: "AppCustomers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCommissions",
                table: "AppCommissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDipendentiCommesse_AppCommissions_CommessaId",
                table: "AppDipendentiCommesse",
                column: "CommessaId",
                principalTable: "AppCommissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
