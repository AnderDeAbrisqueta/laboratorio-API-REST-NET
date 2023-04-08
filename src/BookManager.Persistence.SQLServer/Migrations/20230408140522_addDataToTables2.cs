using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Persistence.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class addDataToTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tb_Author (Name, LastName, Birth, Country_Code) VALUES ('Ander', 'De Abrisqueta', '1978-07-02T19:01:55.788Z', 'VE')");
            migrationBuilder.Sql("INSERT INTO tb_Author (Name, LastName, Birth, Country_Code) VALUES ('Asier', 'De Abrisqueta', '2009-05-19T19:01:55.788Z', 'VE')");
            migrationBuilder.Sql("INSERT INTO tb_Author (Name, LastName, Birth, Country_Code) VALUES ('Arai', 'De Abrisqueta', '2012-11-03T19:01:55.788Z', 'VE')");
            migrationBuilder.Sql("INSERT INTO tb_Author (Name, LastName, Birth, Country_Code) VALUES ('Meyerling', 'Betancourt', '1980-08-08T19:01:55.788Z', 'VE')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
