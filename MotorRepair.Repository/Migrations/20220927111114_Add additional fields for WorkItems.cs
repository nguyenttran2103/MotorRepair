using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorRepair.Repository.Migrations
{
    public partial class AddadditionalfieldsforWorkItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WorkItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "WorkItems");
        }
    }
}
