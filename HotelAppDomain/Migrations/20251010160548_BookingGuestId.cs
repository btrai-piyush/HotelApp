using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAppLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookingGuestId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Guests_GuestId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingsId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingsId",
                table: "Guests",
                column: "BookingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_BookingsId",
                table: "Guests",
                column: "BookingsId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_BookingsId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_BookingsId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "BookingsId",
                table: "Guests");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Guests_GuestId",
                table: "Bookings",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
