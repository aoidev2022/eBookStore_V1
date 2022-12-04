using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eBookStore.API.Basket.Migrations
{
    public partial class Initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    PurchasedPrice = table.Column<int>(nullable: false),
                    BasketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "CreatedOn", "Status", "Username" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 18, DateTimeKind.Unspecified).AddTicks(2386), new TimeSpan(0, 0, 0, 0, 0)), 1, "aoi@182@live.com" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "CreatedOn", "Status", "Username" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 18, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 0, 0, 0, 0)), 1, "aoi@182@live.com" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BasketId", "BookId", "CreatedOn", "PurchasedPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 0, 0, 0, 0)), 5 },
                    { 2, 1, 2, new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(7019), new TimeSpan(0, 0, 0, 0, 0)), 5 },
                    { 3, 1, 3, new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(7055), new TimeSpan(0, 0, 0, 0, 0)), 5 },
                    { 5, 2, 2, new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(7057), new TimeSpan(0, 0, 0, 0, 0)), 5 },
                    { 6, 2, 2, new DateTimeOffset(new DateTime(2022, 11, 25, 16, 56, 14, 19, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 0, 0, 0, 0)), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_BasketId",
                table: "Items",
                column: "BasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Baskets");
        }
    }
}
