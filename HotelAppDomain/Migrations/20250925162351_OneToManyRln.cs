using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAppLibrary.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRln : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                unique: true);
        }
    }
}
