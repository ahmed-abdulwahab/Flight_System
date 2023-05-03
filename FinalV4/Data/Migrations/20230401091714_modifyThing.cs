using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalV4.Data.Migrations
{
    public partial class modifyThing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='af018efa-5565-4393-becd-862404be7c5b'");
          
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='825ba36d-0c82-4e91-999a-e601aa60e068'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '825ba36d-0c82-4e91-999a-e601aa60e068',Id from [security].[Roles] where Name='User'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT 'af018efa-5565-4393-becd-862404be7c5b',Id from [security].[Roles] where Name='Company'");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='af018efa-5565-4393-becd-862404be7c5b'");

            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='825ba36d-0c82-4e91-999a-e601aa60e068'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT 'af018efa-5565-4393-becd-862404be7c5b',Id from [security].[Roles] where Name='User'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '825ba36d-0c82-4e91-999a-e601aa60e068',Id from [security].[Roles] where Name='Company'");
        }
    }
}
