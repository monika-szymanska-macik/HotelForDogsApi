using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelForDogs.Migrations
{
    public partial class ClientIdAddedtoDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Dogs_DogId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_DogId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 1,
                column: "ClientId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 2,
                column: "ClientId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 3,
                column: "ClientId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ClientId",
                table: "Dogs",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Clients_ClientId",
                table: "Dogs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Clients_ClientId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_ClientId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Dogs");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "DogId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "DogId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 3,
                column: "DogId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DogId",
                table: "Clients",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Dogs_DogId",
                table: "Clients",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "DogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
