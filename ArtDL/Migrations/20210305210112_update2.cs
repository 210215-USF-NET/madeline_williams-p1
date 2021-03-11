using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtDL.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Arts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Fullart",
                table: "Arts",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxSeries",
                table: "Arts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Arts",
                type: "text",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Arts");

            migrationBuilder.DropColumn(
                name: "Fullart",
                table: "Arts");

            migrationBuilder.DropColumn(
                name: "MaxSeries",
                table: "Arts");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Arts");
        }
    }
}
