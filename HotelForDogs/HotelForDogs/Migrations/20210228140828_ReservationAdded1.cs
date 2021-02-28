using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelForDogs.Migrations
{
    public partial class ReservationAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stays_Clients_ClientId",
                table: "Stays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stays",
                table: "Stays");

            migrationBuilder.RenameTable(
                name: "Stays",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Stays_ClientId",
                table: "Reservations",
                newName: "IX_Reservations_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Stays");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ClientId",
                table: "Stays",
                newName: "IX_Stays_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stays",
                table: "Stays",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stays_Clients_ClientId",
                table: "Stays",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
