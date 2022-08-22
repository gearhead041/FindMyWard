using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindMyWard.DataAccess.Migrations
{
    public partial class modifyLocation_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Locations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Locations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "Zoom",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zoom",
                table: "Locations");

            migrationBuilder.AlterColumn<long>(
                name: "Longitude",
                table: "Locations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<long>(
                name: "Latitude",
                table: "Locations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
