using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalV4.Data.Migrations
{
    public partial class AssignRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '2033bb8e-03b7-45e8-bb24-052b7ff1b3db',Id from [security].[Roles] where Name='User'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '343a3749-dab2-4e57-876c-74365898947c',Id from [security].[Roles] where Name='Company'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '38ac6f62-ec1e-4465-8a39-c487a2b14c7c',Id from [security].[Roles] where Name='Company'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '4389621b-f882-4f8c-94b5-a65e57683a51',Id from [security].[Roles] where Name='User'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '7da7b685-5cf3-44b9-b3a0-b3f58fd07e77',Id from [security].[Roles] where Name='User'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '9e62ab43-2612-4f13-a23a-f16e593c63f7',Id from [security].[Roles] where Name='User'");

            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT 'af018efa-5565-4393-becd-862404be7c5b',Id from [security].[Roles] where Name='User'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT 'd12300a8-3d4e-47bf-a97d-7f5bfa82af14',Id from [security].[Roles] where Name='Company'");
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) SELECT '825ba36d-0c82-4e91-999a-e601aa60e068',Id from [security].[Roles] where Name='Company'");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='2033bb8e-03b7-45e8-bb24-052b7ff1b3db'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='343a3749-dab2-4e57-876c-74365898947c'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='38ac6f62-ec1e-4465-8a39-c487a2b14c7c'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='4389621b-f882-4f8c-94b5-a65e57683a51'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='7da7b685-5cf3-44b9-b3a0-b3f58fd07e77'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='9e62ab43-2612-4f13-a23a-f16e593c63f7'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='af018efa-5565-4393-becd-862404be7c5b'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='d12300a8-3d4e-47bf-a97d-7f5bfa82af14'");
            migrationBuilder.Sql("Delete from [security].[UserRoles] where UserId='825ba36d-0c82-4e91-999a-e601aa60e068'");
        
    }
    }
}
