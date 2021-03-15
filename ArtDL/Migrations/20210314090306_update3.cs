using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArtDL.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistGallery",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    ArtId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    ArtistStatement = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Signature = table.Column<string>(type: "text", nullable: true),
                    ArtistPhoto = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ArtistCommentary = table.Column<string>(type: "text", nullable: true),
                    Thumbnail = table.Column<string>(type: "text", nullable: true),
                    Fullart = table.Column<byte[]>(type: "bytea", nullable: true),
                    MaxSeries = table.Column<int>(type: "integer", nullable: false),
                    CurrentValue = table.Column<decimal>(type: "numeric", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArtId = table.Column<int>(type: "integer", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: false),
                    Notify = table.Column<int>(type: "integer", nullable: false),
                    MinimumBid = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CollectorId = table.Column<int>(type: "integer", nullable: false),
                    ArtId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    TimeOfBid = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlackList",
                columns: table => new
                {
                    ArtId = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Collectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectorsGallery",
                columns: table => new
                {
                    CollectorId = table.Column<int>(type: "integer", nullable: false),
                    ArtId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SellerInventory",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "integer", nullable: false),
                    ArtId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "ArtistPhoto", "ArtistStatement", "Biography", "CountryCode", "Location", "Name", "Signature" },
                values: new object[,]
                {
                    { 1, "", "Art is but an illusion", "Trans artist located in seattle wa", "", "US", "Madeline Williams", "Madzy" },
                    { 2, "", "I spit on your art", "found as a baby in a junkyard on the outskirts of arkansas, Cranky Pants formed their view of the world by making beauty from ugly surroundings.", "", "US", "cranky pants johonson", "Cranky Pants" },
                    { 3, "", "...", "newborn artist googoo, smears her hand over canvas to produce expressive art peices", "", "NZ", "googoo", "Goo Goo" },
                    { 4, "", "We exist in the intersection between fields of reality and dreams, stare in awe the liminal space", "Blue Heart has arted for 162 years, winner of the blue hearty grand prize 10 years in a row", "", "US", "Blue Heart", "Blue" },
                    { 5, "", "Simplicity is useful, complexity divine", "I'm too modest to talk about my extraordinary life", "", "UK", "ludwig popper", "LP" },
                    { 6, "", "Art is for hanging on your walls and should by pastoral", "Mama Moomin is the proud mother of 13 cats and lives on a farm raising goats, which she uses as inpiration for her art", "", "IT", "Mama Moomin", "MMoo" }
                });

            migrationBuilder.InsertData(
                table: "Arts",
                columns: new[] { "Id", "ArtistCommentary", "ArtistId", "CurrentValue", "Description", "Fullart", "Location", "MaxSeries", "Name", "Thumbnail" },
                values: new object[,]
                {
                    { 1, "", 3, 0.00m, "digital art produced by transforming the waveform of ringing bells into an abstract painting", null, "US", 1, "The Exquisite Loss of Hearing", "" },
                    { 2, "a phsyical representation of my bipolar disorder", 4, 0.0m, "A child menaced by dark figures in the background, screams with laughter, a tear drops from her eye", null, "NZ", 1, "Scream, scream, cry", "" },
                    { 3, "all art is crap", 2, 0.0m, "a peice of poo on a stick", null, "US", 1000, "Dookey", "" },
                    { 4, "shatter your conceptions", 1, 0.0m, "A photo of broken glass", null, "US", 1, "Shatter", "" },
                    { 5, "Bah", 1, 0.0m, "The world swirls with silver tears among a beautiful goat farm", null, "IT", 1, "A field of Broken Skies", "" },
                    { 6, "all the beats are made of stars", 6, 0.0m, "random scribbles on a canvas", null, "UK", 1, "Scratchy Painting", "" },
                    { 7, "Philosophical contemplation of the deep", 4, 0.0m, "The Monster of the deep rises", null, "US", 1, "A large Lost Kraken", null },
                    { 8, "we fall into the process driven by maddness", 1, 0.0m, "Abstracted ant farm", null, "US", 1, "Unfortunate Mayhem", null },
                    { 9, "there are no more tears left to spare", 2, 0.0m, "A scrawl of broken lines fluttering in and out of existence", null, "UK", 1, "Dabble Doodle", null }
                });

            migrationBuilder.InsertData(
                table: "Collectors",
                columns: new[] { "Id", "Email", "Location", "Name" },
                values: new object[] { 1, "fleeyourmind@hotmail.com", "US", "BidBot" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistGallery");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Arts");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "BlackList");

            migrationBuilder.DropTable(
                name: "Collectors");

            migrationBuilder.DropTable(
                name: "CollectorsGallery");

            migrationBuilder.DropTable(
                name: "SellerInventory");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
