using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIcodefirst.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Hotels_HotelsHotelId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_HotelsHotelId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HotelsHotelId",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelsHotelId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_HotelsHotelId",
                table: "Customers",
                column: "HotelsHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Hotels_HotelsHotelId",
                table: "Customers",
                column: "HotelsHotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");
        }
    }
}
