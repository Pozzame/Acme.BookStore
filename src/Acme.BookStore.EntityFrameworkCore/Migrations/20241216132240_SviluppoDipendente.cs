using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class SviluppoDipendente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortBio",
                table: "AppDipendenti",
                newName: "Surname");

            migrationBuilder.AddColumn<decimal>(
                name: "HourlyRate",
                table: "AppDipendenti",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "AppDipendenti",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "AppDipendenti");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "AppDipendenti");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AppDipendenti",
                newName: "ShortBio");
        }
    }
}
