using Microsoft.EntityFrameworkCore.Migrations;

namespace eBookStore.API.Book.Migrations
{
    public partial class Initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "To Kill a Mockingbird", 5m },
                    { 2, 1, "The Great Gatsby", 5m },
                    { 3, 1, "One Hundred Years of Solitude", 5m },
                    { 4, 1, "A Passage to India", 5m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
