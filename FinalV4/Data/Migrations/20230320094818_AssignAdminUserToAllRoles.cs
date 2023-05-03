using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalV4.Data.Migrations
{
    public partial class AssignAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '87d28aaa-20e6-46a2-81b5-cc6aff08656f',Id from [security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='87d28aaa-20e6-46a2-81b5-cc6aff08656f'");
        }
    }
}
