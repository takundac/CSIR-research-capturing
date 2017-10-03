using Microsoft.EntityFrameworkCore.Migrations;

namespace CBIB.Migrations
{
    public partial class Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "CoAuthor1",
                table: "Journal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoAuthor2",
                table: "Journal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeerReviewUrl",
                table: "Journal",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProofOfPeereview",
                table: "Journal",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfResearchOutput",
                table: "Journal",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoAuthor1",
                table: "Journal");

            migrationBuilder.DropColumn(
                name: "CoAuthor2",
                table: "Journal");

            migrationBuilder.DropColumn(
                name: "PeerReviewUrl",
                table: "Journal");

            migrationBuilder.DropColumn(
                name: "ProofOfPeereview",
                table: "Journal");

            migrationBuilder.DropColumn(
                name: "TypeOfResearchOutput",
                table: "Journal");

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
        }
    }
}
