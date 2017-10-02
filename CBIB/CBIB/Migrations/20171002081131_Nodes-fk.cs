using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBIB.Migrations
{
    public partial class Nodesfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Node_NodeID",
                table: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Author_NodeID",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "NodeID",
                table: "Author");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NodeID",
                table: "Author",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_NodeID",
                table: "Author",
                column: "NodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Node_NodeID",
                table: "Author",
                column: "NodeID",
                principalTable: "Node",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
