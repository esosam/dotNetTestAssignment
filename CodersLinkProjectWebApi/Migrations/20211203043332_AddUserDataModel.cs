using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodersLinkProjectWebApi.Migrations
{
    public partial class AddUserDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsrDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsrLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsrEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsrDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsrDatas");
        }
    }
}
