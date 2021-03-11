using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtDL.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Collectors",
                columns: new[] { "Id", "Email", "Location", "Name" },
                values: new object[] { 1, "fleeyourmind@hotmail.com", "US", "BidBot" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collectors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
