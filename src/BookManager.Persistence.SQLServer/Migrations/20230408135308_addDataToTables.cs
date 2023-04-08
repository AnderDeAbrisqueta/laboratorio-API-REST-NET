using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Persistence.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class addDataToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tb_Author (Name, LastName, Birth, Country_Code) VALUES ('Ander', 'De Abrisqueta', '1978-07-02T19:01:55.788Z', 'VE')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
