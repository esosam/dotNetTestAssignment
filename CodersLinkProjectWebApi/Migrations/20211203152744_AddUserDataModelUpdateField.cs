﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodersLinkProjectWebApi.Migrations
{
    public partial class AddUserDataModelUpdateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "UsrDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "UsrDatas");
        }
    }
}
