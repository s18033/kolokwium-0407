using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium_pk.Migrations
{
    public partial class firefighters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    IdAction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    NeedSpecialEquipment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "FirefighterActions",
                columns: table => new
                {
                    IdAction = table.Column<int>(nullable: false),
                    IdFirefighter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirefighterActions", x => new { x.IdFirefighter, x.IdAction });
                });

            migrationBuilder.CreateTable(
                name: "Firefighters",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighters", x => x.IdFirefighter);
                });

            migrationBuilder.CreateTable(
                name: "FiretruckActions",
                columns: table => new
                {
                    IdAction = table.Column<int>(nullable: false),
                    IdFiretruck = table.Column<int>(nullable: false),
                    IdFiretruckAction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiretruckActions", x => new { x.IdFiretruck, x.IdAction });
                });

            migrationBuilder.CreateTable(
                name: "Firetrucks",
                columns: table => new
                {
                    IdFiretruck = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationalNumber = table.Column<string>(maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firetrucks", x => x.IdFiretruck);
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "IdAction", "EndTime", "NeedSpecialEquipment", "StartTime" },
                values: new object[,]
                {
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2020, 7, 4, 17, 10, 41, 38, DateTimeKind.Local).AddTicks(9950) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2020, 7, 4, 17, 10, 41, 43, DateTimeKind.Local).AddTicks(7719) }
                });

            migrationBuilder.InsertData(
                table: "FirefighterActions",
                columns: new[] { "IdFirefighter", "IdAction" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Firefighters",
                columns: new[] { "IdFirefighter", "FirstName", "LastName" },
                values: new object[] { 1, "Piotr", "Kwiatek" });

            migrationBuilder.InsertData(
                table: "Firetrucks",
                columns: new[] { "IdFiretruck", "OperationalNumber", "SpecialEquipment" },
                values: new object[,]
                {
                    { 1, "ABC1111", true },
                    { 2, "XXX1111", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "FirefighterActions");

            migrationBuilder.DropTable(
                name: "Firefighters");

            migrationBuilder.DropTable(
                name: "FiretruckActions");

            migrationBuilder.DropTable(
                name: "Firetrucks");
        }
    }
}
