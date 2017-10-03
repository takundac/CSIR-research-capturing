using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBIB.Migrations
{
    public partial class UI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfResearchOutput",
                table: "Journal",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ProofOfPeereview",
                table: "Journal",
                newName: "PeerReviewed");

            migrationBuilder.RenameColumn(
                name: "PeerReviewUrl",
                table: "Journal",
                newName: "ProofOfpeerReview");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "Journal",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Journal",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Abstract",
                table: "Journal",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "PeerUrl",
                table: "Journal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeerUrl",
                table: "Journal");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Journal",
                newName: "TypeOfResearchOutput");

            migrationBuilder.RenameColumn(
                name: "ProofOfpeerReview",
                table: "Journal",
                newName: "PeerReviewUrl");

            migrationBuilder.RenameColumn(
                name: "PeerReviewed",
                table: "Journal",
                newName: "ProofOfPeereview");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "Journal",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Journal",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abstract",
                table: "Journal",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
