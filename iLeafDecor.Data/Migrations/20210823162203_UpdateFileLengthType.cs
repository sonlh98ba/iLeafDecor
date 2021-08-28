using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iLeafDecor.Data.Migrations
{
    public partial class UpdateFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ac8e37ad-85e8-4577-9cb5-a1ef5ddc1b7e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc3765b0-3790-4006-98a4-1155fb1a7a04", "AQAAAAEAACcQAAAAENm9NFXultBd2W2ppPg7NaBiDOHUJXHID4LSToQxncdsGc0HbQr1Q1+65JIraGQi4Q==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 23, 23, 22, 2, 754, DateTimeKind.Local).AddTicks(8623));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "822224d5-cda9-45c1-b3f4-2adea6919010");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7b12471-86a1-4d0a-a779-db903d0d04d5", "AQAAAAEAACcQAAAAECVFTiMDHh9rP7KzK9xmL6MbdnD/WqDbbw742J1R4dxn+H+RXQxiaWkYX4WC0RLrjw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 23, 21, 36, 10, 454, DateTimeKind.Local).AddTicks(7001));
        }
    }
}
