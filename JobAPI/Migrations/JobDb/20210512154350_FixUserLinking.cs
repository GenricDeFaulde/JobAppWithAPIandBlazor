using Microsoft.EntityFrameworkCore.Migrations;

namespace JobAPI.Migrations.JobDb
{
    public partial class FixUserLinking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthId",
                schema: "dbo",
                table: "User",
                newName: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileId",
                schema: "dbo",
                table: "User",
                newName: "AuthUserId");
        }
    }
}
