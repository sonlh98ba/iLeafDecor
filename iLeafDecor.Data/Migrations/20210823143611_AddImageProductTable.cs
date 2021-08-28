using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iLeafDecor.Data.Migrations
{
    public partial class AddImageProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "75743daf-6f2f-405d-9b2b-89b8a2e72714");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "543c606d-f9c4-422c-ac10-8a2d60ccdc4b", "AQAAAAEAACcQAAAAEEG7tT28X2ZUUPb5wXhG42VQkcKCJXMQBGZWlaSmos45gXMmsYzGMVBIq35rkoU52g==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 18, 12, 12, 218, DateTimeKind.Local).AddTicks(1069));
        }
    }
}
