using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class CommessaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployeesCommissions_AppCommissions_CommessaId",
                table: "AppEmployeesCommissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployeesCommissions_AppDipendenti_DipendenteId",
                table: "AppEmployeesCommissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppEmployeesCommissions",
                table: "AppEmployeesCommissions");

            migrationBuilder.RenameTable(
                name: "AppEmployeesCommissions",
                newName: "AppDipendentiCommesse");

            migrationBuilder.RenameIndex(
                name: "IX_AppEmployeesCommissions_DipendenteId",
                table: "AppDipendentiCommesse",
                newName: "IX_AppDipendentiCommesse_DipendenteId");

            migrationBuilder.RenameIndex(
                name: "IX_AppEmployeesCommissions_CommessaId",
                table: "AppDipendentiCommesse",
                newName: "IX_AppDipendentiCommesse_CommessaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppDipendentiCommesse",
                table: "AppDipendentiCommesse",
                columns: new[] { "DipendenteId", "CommessaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppDipendentiCommesse_AppCommissions_CommessaId",
                table: "AppDipendentiCommesse",
                column: "CommessaId",
                principalTable: "AppCommissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppDipendentiCommesse_AppDipendenti_DipendenteId",
                table: "AppDipendentiCommesse",
                column: "DipendenteId",
                principalTable: "AppDipendenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDipendentiCommesse_AppCommissions_CommessaId",
                table: "AppDipendentiCommesse");

            migrationBuilder.DropForeignKey(
                name: "FK_AppDipendentiCommesse_AppDipendenti_DipendenteId",
                table: "AppDipendentiCommesse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppDipendentiCommesse",
                table: "AppDipendentiCommesse");

            migrationBuilder.RenameTable(
                name: "AppDipendentiCommesse",
                newName: "AppEmployeesCommissions");

            migrationBuilder.RenameIndex(
                name: "IX_AppDipendentiCommesse_DipendenteId",
                table: "AppEmployeesCommissions",
                newName: "IX_AppEmployeesCommissions_DipendenteId");

            migrationBuilder.RenameIndex(
                name: "IX_AppDipendentiCommesse_CommessaId",
                table: "AppEmployeesCommissions",
                newName: "IX_AppEmployeesCommissions_CommessaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppEmployeesCommissions",
                table: "AppEmployeesCommissions",
                columns: new[] { "DipendenteId", "CommessaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployeesCommissions_AppCommissions_CommessaId",
                table: "AppEmployeesCommissions",
                column: "CommessaId",
                principalTable: "AppCommissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployeesCommissions_AppDipendenti_DipendenteId",
                table: "AppEmployeesCommissions",
                column: "DipendenteId",
                principalTable: "AppDipendenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
