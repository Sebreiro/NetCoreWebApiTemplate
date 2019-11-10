using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.NetCore.Template.DAL.Migrations
{
    public partial class Add_TestModel_Count_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "TestModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "TestModel");
        }
    }
}
