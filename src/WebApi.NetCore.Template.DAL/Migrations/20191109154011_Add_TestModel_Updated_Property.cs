using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.NetCore.Template.DAL.Migrations
{
    public partial class Add_TestModel_Updated_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "TestModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated",
                table: "TestModel");
        }
    }
}
