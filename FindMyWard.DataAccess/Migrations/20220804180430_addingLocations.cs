using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindMyWard.DataAccess.Migrations
{
    public partial class addingLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<long>(type: "bigint", nullable: false),
                    Longitude = table.Column<long>(type: "bigint", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_LocationId",
                table: "Students",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Locations_LocationId",
                table: "Students",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Locations_LocationId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Students_LocationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
