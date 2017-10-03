using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBIB.Migrations
{
    public partial class Fields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TypeOfResearchOutput",
                table: "Journal",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TypeOfResearchOutput",
                table: "Journal",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
