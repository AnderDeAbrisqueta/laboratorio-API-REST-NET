using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Persistence.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryCode = table.Column<string>(name: "Country_Code", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "tb_Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedOn = table.Column<DateTime>(name: "Published_On", type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_tb_Book_tb_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "tb_Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Book_AuthorId",
                table: "tb_Book",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Book");

            migrationBuilder.DropTable(
                name: "tb_Author");
        }
    }
}
