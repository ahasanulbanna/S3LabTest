using Microsoft.EntityFrameworkCore.Migrations;

namespace Problem2.Database.Migrations
{
    public partial class UpdateReadingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ObjectsId",
                table: "Reading",
                newName: "ObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "Reading",
                newName: "ObjectsId");
        }
    }
}
