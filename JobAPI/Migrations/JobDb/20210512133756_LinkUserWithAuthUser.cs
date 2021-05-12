using Microsoft.EntityFrameworkCore.Migrations;

namespace JobAPI.Migrations.JobDb
{
    public partial class LinkUserWithAuthUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthId",
                schema: "dbo",
                table: "User",
                defaultValue: 01);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthId",
                schema: "dbo",
                table: "User");
        }
    }
}
