using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalV4.Data.Migrations
{
    public partial class CompanyRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                           table: "Roles",
                           columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                           values: new object[] { Guid.NewGuid().ToString(), "Company", "Company".ToUpper(), Guid.NewGuid().ToString() },
                           schema: "security"
                       );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Roles]");
        }
    }
}
