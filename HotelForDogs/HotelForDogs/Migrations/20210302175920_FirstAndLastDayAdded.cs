using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelForDogs.Migrations
{
    public partial class FirstAndLastDayAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysNumberOfStay",
                table: "Reservations");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstDay",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDay",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstDay",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LastDay",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "DaysNumberOfStay",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DaysNumberOfStay",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DaysNumberOfStay",
                value: 2);
        }
    }
}
