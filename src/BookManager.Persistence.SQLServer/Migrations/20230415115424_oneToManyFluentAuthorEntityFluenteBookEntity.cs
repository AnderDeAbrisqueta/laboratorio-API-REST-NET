using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Persistence.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class oneToManyFluentAuthorEntityFluenteBookEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Book_tb_Author_AuthorId",
                table: "tb_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_AuthorId",
                table: "Fluent_Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Authors_AuthorId",
                table: "Fluent_Books",
                column: "AuthorId",
                principalTable: "Fluent_Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Book_tb_Author_AuthorId",
                table: "tb_Book",
                column: "AuthorId",
                principalTable: "tb_Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Authors_AuthorId",
                table: "Fluent_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_Book_tb_Author_AuthorId",
                table: "tb_Book");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_AuthorId",
                table: "Fluent_Books");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Book_tb_Author_AuthorId",
                table: "tb_Book",
                column: "AuthorId",
                principalTable: "tb_Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
