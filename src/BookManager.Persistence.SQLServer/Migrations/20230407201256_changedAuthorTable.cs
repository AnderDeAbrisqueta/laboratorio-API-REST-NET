using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Persistence.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class changedAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Book_tb_Autor_AuthorId",
                table: "tb_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Autor",
                table: "tb_Autor");

            migrationBuilder.RenameTable(
                name: "tb_Autor",
                newName: "tb_Author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Author",
                table: "tb_Author",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Book_tb_Author_AuthorId",
                table: "tb_Book",
                column: "AuthorId",
                principalTable: "tb_Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Book_tb_Author_AuthorId",
                table: "tb_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Author",
                table: "tb_Author");

            migrationBuilder.RenameTable(
                name: "tb_Author",
                newName: "tb_Autor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Autor",
                table: "tb_Autor",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Book_tb_Autor_AuthorId",
                table: "tb_Book",
                column: "AuthorId",
                principalTable: "tb_Autor",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
