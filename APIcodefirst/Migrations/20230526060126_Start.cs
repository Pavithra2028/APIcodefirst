using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIcodefirst.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Hotels_HotelId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Hotels_HotelId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelDescription",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelLocation",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Staffs",
                newName: "HotelsHotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_HotelId",
                table: "Staffs",
                newName: "IX_Staffs_HotelsHotelId");

            migrationBuilder.RenameColumn(
                name: "RoomCount",
                table: "Rooms",
                newName: "HotelsHotelId");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Customers",
                newName: "HotelsHotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_HotelId",
                table: "Customers",
                newName: "IX_Customers_HotelsHotelId");

            migrationBuilder.AddColumn<string>(
                name: "Room_Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomAvailability",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Reservation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "101, 1"),
                    Check_in_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Check_out_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    hotelsHotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Reservation_id);
                    table.ForeignKey(
                        name: "FK_Reservation_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Hotels_hotelsHotelId",
                        column: x => x.hotelsHotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelsHotelId",
                table: "Rooms",
                column: "HotelsHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomersCustomerId",
                table: "Reservation",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_hotelsHotelId",
                table: "Reservation",
                column: "hotelsHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Hotels_HotelsHotelId",
                table: "Customers",
                column: "HotelsHotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelsHotelId",
                table: "Rooms",
                column: "HotelsHotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Hotels_HotelsHotelId",
                table: "Staffs",
                column: "HotelsHotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Hotels_HotelsHotelId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelsHotelId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Hotels_HotelsHotelId",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelsHotelId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Room_Name",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "RoomAvailability",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "HotelsHotelId",
                table: "Staffs",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_HotelsHotelId",
                table: "Staffs",
                newName: "IX_Staffs_HotelId");

            migrationBuilder.RenameColumn(
                name: "HotelsHotelId",
                table: "Rooms",
                newName: "RoomCount");

            migrationBuilder.RenameColumn(
                name: "HotelsHotelId",
                table: "Customers",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_HotelsHotelId",
                table: "Customers",
                newName: "IX_Customers_HotelId");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HotelDescription",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HotelLocation",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Hotels_HotelId",
                table: "Customers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Hotels_HotelId",
                table: "Staffs",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");
        }
    }
}
