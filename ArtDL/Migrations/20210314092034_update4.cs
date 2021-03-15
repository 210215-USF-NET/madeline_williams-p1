using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtDL.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Sellers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sellers",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Artists",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sellers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Sellers",
                newName: "Name");
        }
    }
}
