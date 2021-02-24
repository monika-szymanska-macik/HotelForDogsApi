using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelForDogs.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Breed", "Name", "Weight" },
                values: new object[] { 1, "Crossbreed", "Rex", 15 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Breed", "Name", "Weight" },
                values: new object[] { 2, "Basset", "Max", 8 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Breed", "Name", "Weight" },
                values: new object[] { 3, "Colli", "Fred", 36 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "DogId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, 1, "Jan", "Kowalski", "505505505" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "DogId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, 2, "Jan", "Nowak", "606606606" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "DogId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, 3, "John", "Smith", "707707707" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DogId",
                table: "Clients",
                column: "DogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
