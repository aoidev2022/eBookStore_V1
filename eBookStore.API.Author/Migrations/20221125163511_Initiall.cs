using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eBookStore.API.Author.Migrations
{
    public partial class Initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CenterName = table.Column<string>(nullable: true),
                    AchievedOn = table.Column<DateTimeOffset>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicDegrees_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1980, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Lucas Pavack" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(1984, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Angela Nolskyv" });

            migrationBuilder.InsertData(
                table: "AcademicDegrees",
                columns: new[] { "Id", "AchievedOn", "AuthorId", "CenterName", "Name" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1980, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), 1, "Academy Accel", "Associate degrees" });

            migrationBuilder.InsertData(
                table: "AcademicDegrees",
                columns: new[] { "Id", "AchievedOn", "AuthorId", "CenterName", "Name" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(1995, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), 2, "College Discover", "Associate degrees" });

            migrationBuilder.InsertData(
                table: "AcademicDegrees",
                columns: new[] { "Id", "AchievedOn", "AuthorId", "CenterName", "Name" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(1990, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), 2, "Higher Institute", "Associate degrees" });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicDegrees_AuthorId",
                table: "AcademicDegrees",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
