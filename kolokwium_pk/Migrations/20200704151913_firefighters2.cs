using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium_pk.Migrations
{
    public partial class firefighters2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "IdAction",
                keyValue: 3,
                column: "StartTime",
                value: new DateTime(2020, 7, 4, 17, 19, 12, 935, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "IdAction",
                keyValue: 4,
                column: "StartTime",
                value: new DateTime(2020, 7, 4, 17, 19, 12, 941, DateTimeKind.Local).AddTicks(6698));

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "IdAction", "EndTime", "NeedSpecialEquipment", "StartTime" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2020, 7, 4, 17, 19, 12, 941, DateTimeKind.Local).AddTicks(6807) });

            migrationBuilder.InsertData(
                table: "FirefighterActions",
                columns: new[] { "IdFirefighter", "IdAction" },
                values: new object[] { 1, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "IdAction",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FirefighterActions",
                keyColumns: new[] { "IdFirefighter", "IdAction" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "IdAction",
                keyValue: 3,
                column: "StartTime",
                value: new DateTime(2020, 7, 4, 17, 10, 41, 38, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "IdAction",
                keyValue: 4,
                column: "StartTime",
                value: new DateTime(2020, 7, 4, 17, 10, 41, 43, DateTimeKind.Local).AddTicks(7719));
        }
    }
}
