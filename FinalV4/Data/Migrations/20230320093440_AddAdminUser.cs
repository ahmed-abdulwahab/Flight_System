using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalV4.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Age], [Fname], [Lname]) VALUES (N'87d28aaa-20e6-46a2-81b5-cc6aff08656f', N'admin', N'ADMIN', N'admin@admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEMM15GAJT/WtL6VhTxezt830Fl7Z+YuGHRCKNy2FoRUyRSKkJtQoj9lpAfs1APPQsg==', N'HHJZK7JXFNK7BMAM64T6NASVPBTTX7VQ', N'9370db0e-2d9e-4e2c-92d4-18b3a2eccf0f', NULL, 0, 0, NULL, 1, 0, 0, N'Shrief', N'Hesham')\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[Users] where Id='87d28aaa-20e6-46a2-81b5-cc6aff08656f'");
        }
    }
}
